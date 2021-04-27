using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class Controller : MonoBehaviour
{
    private static double TOLERANCE = 0.001f;

    private Animator _animator;
    [SerializeField] private GameObject _sprite;
    [SerializeField] private Light _light;
    public Light getLight { get => _light; }
    
    [SerializeField] private float verticalHalfSize = 0.65f;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPos;
    
    private float _horizontalInput;
    private float _horizontalSpeed;
    [Header("Run")]
    [SerializeField] private AnimationCurve runTimeAccel;
    [SerializeField] private AnimationCurve runTimeDecel;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float runGravity = 0.1f;
    [SerializeField] private float deadZone = -20f;
    [SerializeField] private DetectWall detectWall;
    
    [Header("Jump")]
    [SerializeField] private AnimationCurve jumpTimePosition;
    [SerializeField] private DetectGround detectGround;
    [SerializeField] private TextMeshProUGUI verticalSpeedText;
    [SerializeField] private TextMeshPro interactText;
    [SerializeField] private Color black;
    [SerializeField] private Color white;
    private bool _jumping;
    private bool jumping{
        get => _jumping;
        set
        {
            //_rigidbody.isKinematic = value;
            _jumping = value;
        }
    }
    private float _jumpTimer;
    private float _yJumpStart;

    [Header("Dead")] 
    [SerializeField] private Animator respawnUI;
    [SerializeField] private GameObject deadBulb;
    private bool _dead = false;
    public bool IsAlive(){return !_dead;}
    private bool _stop = false;

    private AbstractInteract _interact;

    public bool OnGround() {return detectGround.OnGround() && (!jumping || _jumpTimer > 0.4f);}
    public bool OnWall() {return detectWall.HitWall();}
    public float GetHorizontalSpeed() {return _horizontalSpeed;}
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        if(OnGround() && (_rigidbody.velocity.y < deadZone))
        {
            Respawn();
        }

        if (!_stop) HorizontalMovement();
        else _rigidbody.velocity = new Vector2(0.0f, _rigidbody.velocity.y);

        if (_interact != null && _interact.CouldInteract() && !_dead && !_stop && _light.globe.enabled)
        {
            interactText.text = _interact.info;
            interactText.color = _light.switchLight ? black : white;
        }
        else interactText.text = "";
        _animator.SetFloat("Speed", Math.Abs(_horizontalSpeed));
        _animator.SetBool("Ground", OnGround());
        _animator.SetBool("Jump", jumping);
        _animator.SetBool("Dead", _dead);
    }

    
    void FixedUpdate()
    {

        if(!_stop) VerticalMovement();
        verticalSpeedText.text = ((int)_rigidbody.velocity.y).ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Vector2.Dot(other.contacts[0].normal, Vector2.up) < -0.7f)
        {
            jumping = false;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0.0f);
        }
    }
    
    public void Respawn(bool stop = true)
    {
        if (_dead) return;
        _rigidbody.velocity = new Vector2(0 ,_rigidbody.velocity.y);
        _dead = true;
        if (stop) StopPlayer();
        respawnUI.Play("Respawn", 0, 0.0f);
        StartCoroutine("UpdateRespawn");
    }

    IEnumerator UpdateRespawn() 
    {
        yield return new WaitForSeconds(2.1f);
        StopPlayer();
        
        if (_light.globe.enabled)
        {
            Instantiate(deadBulb, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.value * 360f));
        }

        transform.position = _startPos;
        _light.Plug();
        FindObjectOfType<Cog>().energy -= 1.0f;
        _light.Stop();
        yield return new WaitForSeconds(1f);
        _dead = false;
        yield return new WaitForSeconds(2f);
        foreach (var interact in FindObjectsOfType<AbstractInteract>())
        {
            interact.Reset();
        }
        StartPlayer();
    }
    IEnumerator UnPlugLight() 
    {
        _light.UnPlug();
        yield return new WaitForSeconds(3f);
        Respawn();
    }
    
    public void StopPlayer()
    {
        _stop = true;
        _horizontalSpeed = 0;
        _rigidbody.velocity = Vector2.up * _rigidbody.velocity.y;    
    }

    public void StartPlayer()
    {
        _stop = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AbstractInteract interact;
        if (other.TryGetComponent<AbstractInteract>(out interact))
        {
            if(interact.CouldInteract())
                _interact = interact;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        AbstractInteract interact;
        if (other.TryGetComponent<AbstractInteract>(out interact))
        {
            if(interact == _interact)
                _interact = null;
        }
    }

    
#region Movement
    void HorizontalMovement()
    {
        float horizontalSpeedAbs = Math.Abs(_horizontalSpeed);
        if (OnWall())
            _horizontalSpeed = 0.0f;
        else if (Math.Abs(_horizontalInput) <= Math.Abs(_horizontalSpeed/maxSpeed) || (Math.Abs(Mathf.Sign(_horizontalSpeed) - Mathf.Sign(_horizontalInput)) > TOLERANCE && horizontalSpeedAbs > TOLERANCE) )
        {
            _horizontalSpeed = runTimeDecel.Evaluate(TimeFromValue(runTimeDecel,  horizontalSpeedAbs/maxSpeed) - Time.deltaTime) * Mathf.Sign(_horizontalSpeed) * maxSpeed;
        }
        else if (Math.Abs(_horizontalInput) > Math.Abs(_horizontalSpeed/maxSpeed) && Math.Abs(_horizontalInput) > 0.1f)
        {
            _horizontalSpeed = runTimeAccel.Evaluate(TimeFromValue(runTimeAccel,  horizontalSpeedAbs/maxSpeed) + Time.deltaTime) * Mathf.Sign(_horizontalInput) * maxSpeed;
        }
        if(Math.Abs(_horizontalSpeed) > 0.0f)
            _sprite.transform.localScale = new Vector3(Math.Abs(_sprite.transform.localScale.x) * Math.Sign(_horizontalSpeed) ,_sprite.transform.localScale.y, _sprite.transform.localScale.z);
        else if(Math.Abs(_horizontalInput) > 0.0f)
            _sprite.transform.localScale = new Vector3(Math.Abs(_sprite.transform.localScale.x) * Math.Sign(_horizontalInput) ,_sprite.transform.localScale.y, _sprite.transform.localScale.z);

        if (OnGround())
        {
            RaycastHit2D predictionHit = Physics2D.Raycast(transform.position + Vector3.right * Math.Sign(_sprite.transform.localScale.x) * 0.35f, -Vector2.up, 2.0f, LayerMask.GetMask("Default"));
            Debug.DrawLine(transform.position + Vector3.right * Math.Sign(_sprite.transform.localScale.x) * 0.35f, transform.position + Vector3.right * Math.Sign(_sprite.transform.localScale.x) * 0.35f - Vector3.up, Color.red);
            Vector2 dir = Vector2.right;

            float verticalSpeed = 0;
            if (predictionHit.collider != null)
            {
                dir = -Vector2.Perpendicular(predictionHit.normal);
            }

            RaycastHit2D centerHit = Physics2D.Raycast(transform.position, -Vector2.up, 2.0f, LayerMask.GetMask("Default"));

            if (centerHit.collider != null)
            {
                if (centerHit.distance > verticalHalfSize && Vector2.Dot(centerHit.normal, Vector2.up) > 0.9f)
                {
                    verticalSpeed = -runGravity;
                }

                Debug.DrawLine(transform.position, transform.position + (Vector3) dir, Color.blue);
                if (Vector2.Dot(centerHit.normal, Vector2.up) < Vector2.Dot(predictionHit.normal, Vector2.up))
                {
                    dir = -Vector2.Perpendicular(centerHit.normal);
                }
            }
            _rigidbody.velocity = dir * _horizontalSpeed + verticalSpeed * Vector2.up;
        }
        else
        {
            _rigidbody.velocity = Vector2.right * _horizontalSpeed + _rigidbody.velocity.y * Vector2.up;
        }
    }
    void VerticalMovement()
    {
        float verticalVelocity = _rigidbody.velocity.y;
        if (OnGround())
        {
            jumping = false;
        }
        else if (jumping)
        {
            _jumpTimer += Time.deltaTime;

            if (jumpTimePosition.keys[jumpTimePosition.length - 1].time <= _jumpTimer)
            {
                jumping = false;
            }
            else
            {
                verticalVelocity = (jumpTimePosition.Evaluate(_jumpTimer) + _yJumpStart - transform.position.y) / Time.deltaTime ;
            }
            _rigidbody.velocity = Vector2.right * _rigidbody.velocity.x + verticalVelocity * Vector2.up;
        }
    }
#endregion
#region Input
    public void UpdateHorizontalInput(InputAction.CallbackContext context)
    {
        _horizontalInput = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumping || !OnGround() || !context.performed) 
            return;
        
        _jumpTimer = 0.0f;
        jumping = true;
        _yJumpStart = transform.position.y;
    }
    public void Switch(InputAction.CallbackContext context)
    {
        if (!context.performed) 
            return;
        
        _light.Switch();
    }

    public void TryInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _interact != null && _interact.CouldInteract() && !_dead && !_stop && _light.globe.enabled)
        {
            _interact.Interact();
        }
    }
    public void Pause()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        transform.position = _startPos;
        _rigidbody.velocity = Vector2.zero;
#endif
    }
#endregion

    public static float TimeFromValue(AnimationCurve c, float value, float precision = 1e-6f)
    {
        float minTime = c.keys[0].time;
        float maxTime = c.keys[c.keys.Length-1].time;
        float best = (maxTime + minTime) / 2;
        float bestVal = c.Evaluate(best);
        int it=0;
        const int maxIt = 1000;
        float sign = Mathf.Sign(c.keys[c.keys.Length-1].value -c.keys[0].value);
        while(it < maxIt && Mathf.Abs(minTime - maxTime) > precision) {
            if((bestVal - value) * sign > 0) {
                maxTime = best;
            } else {
                minTime = best;
            }
            best = (maxTime + minTime) / 2;
            bestVal = c.Evaluate(best);
            it++;
        }
        return best;
    }
}

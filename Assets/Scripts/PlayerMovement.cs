using UnityEngine;

public enum DeadState { Alive, Dead }

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _jumpableGround;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private AudioSource _jumpSoundEffect;

    private enum MovementState { Idle, Running, Jumping, Falling }

    public DeadState PlayerState = DeadState.Alive;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private SpriteRenderer _sprite;
    private Animator _animator;

    private void Update() => CheckInput();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    private void CheckInput()
    {
        if (PlayerState == DeadState.Dead) return;
        
        float moveInputX = Input.GetAxisRaw("Horizontal");
        Move(moveInputX);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        
        UpdateAnimationState(moveInputX);
    }

    private void Jump()
    {
        _jumpSoundEffect.Play();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private void Move(float moveInput)
    {
        _rigidbody.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody.velocity.y);
    }
    

    private void UpdateAnimationState(float moveInput)
    {
        MovementState state;

        if (moveInput > 0f)
        {
            state = MovementState.Running;
            _sprite.flipX = false;
        }
        else if (moveInput < 0f)
        {
            state = MovementState.Running;
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (_rigidbody.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (_rigidbody.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        _animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
    }
}

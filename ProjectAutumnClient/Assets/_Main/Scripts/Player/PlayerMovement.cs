using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CerenityStudio
{
    public class PlayerMovement : MonoBehaviour
    {
    #region VARIABLE
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpingPower = 16f;
        private float horizontal;
        private bool isFacingRight = true;

        private bool isWallSliding;
        private float wallSlidingSpeed = 2f;

        private bool isWallJumping;
        private float wallJumpingDirection;
        private float wallJumpingTime = 0.2f;
        private float wallJumpingCounter;
        private float wallJumpingDuration = 0.4f;
        private Vector2 wallJumpingPower = new Vector2(8f, 16f);

        private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private LayerMask wallLayer;
    #endregion

    #region UNITY FUNCTION
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            _rigidbody.velocity = new Vector2(horizontal * speed, _rigidbody.velocity.y);

            if(!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }

            WallSlide();
            WallJump();
        }
    #endregion

    #region PUBLIC FUNCTION
        // input ketika bergerak moving
        public void Move(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;

            // when move value is not 0, play the animation
            if (horizontal != 0)
                _animator.SetBool("isMove", true);
            else
                _animator.SetBool("isMove", false);
        }

        // input ketika lompat
        public void Jump(InputAction.CallbackContext context)
        {
            // ketika tombol lompat ditekan ditanah
            if (context.performed && IsGrounded())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpingPower);
                _animator.SetTrigger("isJump");
            }

            // ketika tombol lompat ditekan di wall
            if (context.performed && wallJumpingCounter > 0f)
            {
                isWallJumping = true;
                _rigidbody.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
                wallJumpingCounter = 0f;

                if(transform.localScale.x != wallJumpingDirection)
                {
                    isFacingRight = !isFacingRight;
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                }

                Invoke(nameof(StopWallJumping), wallJumpingDuration);
            }

            // ketika tombol lompat dilepas
            if (context.canceled && _rigidbody.velocity.y > 0f)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }
        }
    #endregion

    #region PRIVATE FUNCTION
        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private bool IsWalled()
        {
            return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
        }

        private void WallSlide()
        {
            if (IsWalled() && !IsGrounded() && horizontal != 0f)
            {
                isWallSliding = true;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }
            else
            {
                isWallSliding = false;
            }
        }

        private void WallJump()
        {
            if (isWallSliding)
            {
                isWallJumping = false;
                wallJumpingDirection = -transform.localScale.x;
                wallJumpingCounter = wallJumpingTime;

                CancelInvoke(nameof(StopWallJumping));
            }
            else
            {
                wallJumpingCounter -= Time.deltaTime;
            }
        }

        private void StopWallJumping()
        {
            isWallJumping = false;
        }

        IEnumerator LandAnimation()
        {
            _animator.SetBool("isGrounded", true);
            yield return new WaitForSeconds(1f);
            _animator.SetBool("isGrounded", false);
        }
    #endregion
    }
}

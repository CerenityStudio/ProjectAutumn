using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CerenityStudio
{
    public class PlayerMovement : MonoBehaviour
    {
    #region VARIABLE
        public Transform groundCheck;
        public LayerMask groundLayer;
        public Animator anim;

        private Rigidbody2D rb;
        private float horizontal;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpingPower = 16f;
        [SerializeField] private bool isFacingRight = true;
    #endregion

    #region UNITY FUNCTION
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            Debug.Log(horizontal);

            if(!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }
        }
    #endregion

    #region PUBLIC FUNCTION
        // input ketika bergerak moving
        public void Move(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;

            // when move value is not 0, play the animation
            if (horizontal != 0) 
                anim.SetBool("isMove", true);
            else 
                anim.SetBool("isMove", false);
        }

        // input ketika lompat
        public void Jump(InputAction.CallbackContext context)
        {
            // ketika tombol lompat ditekan
            if (context.performed && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                anim.SetTrigger("isJump");
            }

            // ketika tombol lompat dilepas
            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    #endregion

    #region PRIVATE FUNCTION
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    #endregion
    }
}

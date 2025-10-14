using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Vector2 direction;
        private Rigidbody2D rb;


        private Animator animator;

        private Vector3 TPosition;
        private bool IsWalking = false;

       

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);

            if (Input.GetMouseButton(0))
            {
                TriggerPosition();
            }

            if (IsWalking)
            {
                ItsMove();
                animator.SetBool("IsWalking", true);
            }

        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

            if (direction.x == 0 & direction.y == 0)
            {
                animator.SetBool("IsWalking", false);
            }
            else
            {
                animator.SetBool("IsWalking", true);
            }
        }

        void TriggerPosition()
        {
            TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TPosition.z = transform.position.z;

            IsWalking = true;
        }

        void ItsMove()
        {
            transform.position = Vector3.MoveTowards(transform.position, TPosition, speed * Time.deltaTime);

            if (transform.position == TPosition)
            {
                IsWalking = false;
            }
        }
    }

}

using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 70f;

        public Camera Camera;

        private Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();

            if (Camera == null)
            {
                Camera = Camera.main;
            }
        }

        private void FixedUpdate()
        {
            var movement = Input.GetAxis("Vertical") * Camera.transform.forward + Input.GetAxis("Horizontal") * Camera.transform.right;
            movement.y = -1f;

            rigidbody.AddForce(movement * Speed);
            Debug.DrawRay(transform.position, rigidbody.velocity, Color.red);

            Debug.DrawRay(transform.position, (rigidbody.velocity.normalized * -1) * 5, Color.green);
        }
    }
}
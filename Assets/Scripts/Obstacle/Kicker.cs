using UnityEngine;

namespace Assets.Scripts.Obstacle
{
    public class Kicker : MonoBehaviour
    {
        public float Power = 1000.0F;

        private Vector3 direction;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                var playerRigidBody = collision.gameObject.GetComponent<Rigidbody>();

                direction = (collision.contacts[0].point - transform.position).normalized;

                playerRigidBody.AddForce(direction * Power, ForceMode.Impulse);
            }
        }

        private void Update()
        {
            if (direction != null)
            {
                Debug.DrawRay(transform.position, direction, Color.magenta);
            }
        }
    }
}

namespace Assets.Scripts
{
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        public float Speed;

        private Rigidbody rigidBody;

        void Start()
        {
            this.rigidBody = this.GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            this.rigidBody.AddForce(movement * this.Speed);
        }
    }
}

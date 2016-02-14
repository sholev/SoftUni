namespace Assets.Scripts
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform Target;

        private Rigidbody TargetRigidbody;

        [Range(0, 1)]
        public float FollowSpeed;

        private Vector3 offset;

        private void Start()
        {
            this.offset = this.transform.position - this.Target.transform.position;
            this.TargetRigidbody = this.Target.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (this.Target == null)
            {
                return;
            }

            ////Debug.Log("xDistance: " + xDistance);
            ////Debug.Log("zDistance: " + zDistance);
            var direction = this.Target.transform.position + this.offset;
            this.transform.position = Vector3.Lerp(this.transform.position, direction, this.FollowSpeed);
        }
    }
}

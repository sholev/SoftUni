namespace Assets.Scripts
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform Target;

        [Range(0, 1)]
        public float FollowSpeed;

        public float MinDistance;

        private Vector3 offset;

        private void Start()
        {
            this.offset = this.transform.position - this.Target.transform.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (this.Target == null)
            {
                return;
            }
            
            float xDistance = this.transform.position.x - this.Target.position.x;
            float zDistance = this.transform.position.z - this.Target.position.z;

            if (Mathf.Abs(zDistance) > this.MinDistance || Mathf.Abs(xDistance) > this.MinDistance)
            {
                ////Debug.Log("xDistance: " + xDistance);
                ////Debug.Log("zDistance: " + zDistance);
                var direction = this.Target.transform.position + this.offset;
                this.transform.position = Vector3.Lerp(this.transform.position, direction, this.FollowSpeed);
            }
        }
    }
}

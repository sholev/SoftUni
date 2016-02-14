using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;

    public float FollowMultiplier;

    public float SpeedLimit;

    public float MinDistance;

    private Rigidbody rigidBody;
    
    void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (this.Target != null)
        {
            var direction = this.Target.transform.position - this.transform.position;

            if (Vector3.Distance(this.transform.position, this.Target.position) > this.MinDistance)
            {
                ////Debug.Log(this.name + ": " + direction);
                this.rigidBody.drag = 0;

                // Adding fore is more fun than transpose. :D
                this.rigidBody.AddForce(Vector3.ClampMagnitude(direction, this.SpeedLimit) * this.FollowMultiplier);
            }
            if (Vector3.Distance(this.transform.position, this.Target.position) < this.MinDistance)
            {
                this.rigidBody.drag = 5;
            }
        }
    }
}

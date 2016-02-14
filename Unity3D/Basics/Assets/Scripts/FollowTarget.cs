using System.Diagnostics;

using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;

    public float FollowMultiplier;

    public float SpeedLimit;

    public float MinDistance;

    public float StopDrag;

    private Rigidbody rigidBody;

    private Stopwatch cooldownTimer;

    void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.cooldownTimer = new Stopwatch();
        this.cooldownTimer.Start();
    }

    void LateUpdate()
    {
        if (this.Target == null)
        {
            return;
        }

        var direction = this.Target.transform.position - this.transform.position;

        if (Vector3.Distance(this.transform.position, this.Target.position) > this.MinDistance)
        {
            this.rigidBody.drag = 0;

            // Adding force is more fun than transpose. :D
            this.rigidBody.AddForce(Vector3.ClampMagnitude(direction, this.SpeedLimit) * this.FollowMultiplier);
        }

        if (Vector3.Distance(this.transform.position, this.Target.position) < this.MinDistance)
        {
            this.rigidBody.drag = 5;
        }

        // Most likely out of camera view, no need to keep going in the same direction. 
        // Remove the force with drag so the next force will be applied towards the target direction.
        if (Vector3.Distance(this.transform.position, this.Target.position) > 100 && this.cooldownTimer.ElapsedTicks > 500)
        {
            this.cooldownTimer.Reset();
            this.rigidBody.drag = this.StopDrag;
        }
    }

    // Getting out of bounds, adding force tends to do that.
    void OnTriggerExit(Collider other)
    {
        this.rigidBody.drag = this.StopDrag;
        this.transform.position = this.Target.position;
    }
}

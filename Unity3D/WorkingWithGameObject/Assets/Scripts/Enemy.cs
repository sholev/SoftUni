using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float shootDistance;

    public float shootCooldown;

    public GameObject rockedPositionRight;

    public GameObject rockedPositionLeft;

    public GameObject rocket;

    public GameObject target;

    private float shotTime;

    public void Start()
    {
        this.shotTime = this.shootCooldown;
    }
    
    public void Update()
    {
        if (this.target == null)
        {
            return;
        }

        this.transform.LookAt(this.target.transform);
        this.shotTime -= Time.deltaTime;
        if (this.shotTime < 0)
        {
            this.shotTime = this.shootCooldown;
            if (Vector3.Distance(this.transform.position, this.target.transform.position) < this.shootDistance)
            {
                GameObject newRocket = Instantiate(this.rocket);
                newRocket.transform.position = this.rockedPositionLeft.transform.position;
                newRocket.transform.LookAt(this.target.transform);
                newRocket.AddComponent<RocketEngine>();

                newRocket = Instantiate(this.rocket);
                newRocket.transform.position = this.rockedPositionRight.transform.position;
                newRocket.transform.LookAt(this.target.transform);
                newRocket.AddComponent<RocketEngine>();
            }
        }
        
    }
}

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

    private GameObject leftRocket;

    private GameObject rightRocket;

    private float shotTime;

    public void Start()
    {
        this.shotTime = this.shootCooldown;
        this.leftRocket = new GameObject();
        this.rightRocket = new GameObject();
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
                this.leftRocket = Instantiate(this.rocket);
                this.leftRocket.transform.position = this.rockedPositionLeft.transform.position;
                this.leftRocket.transform.LookAt(this.target.transform);
                this.leftRocket.AddComponent<RocketEngine>();

                this.rightRocket = Instantiate(this.rocket);
                this.rightRocket.transform.position = this.rockedPositionRight.transform.position;
                this.rightRocket.transform.LookAt(this.target.transform);
                this.rightRocket.AddComponent<RocketEngine>();
            }
        }
        
    }
}

using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour
{
    private float timeOut = 3;

    private float speed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.position += this.transform.forward * (Time.deltaTime * this.speed);

        this.timeOut -= Time.deltaTime;
        if (this.timeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
    }



}

using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour
{
    public GameObject gun;

    public GameObject Rocket;

    public float moveSpeed;

    public float rotationSpeedf;

    // Update is called once per frame
    public void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotatePlayerX = Input.GetAxis("Mouse X") * Time.deltaTime;
        //float rotateGunX = Input.GetAxis("Mouse Y") * Time.deltaTime;

        moveHorizontal *= this.moveSpeed;
        moveVertical *= this.moveSpeed;
        rotatePlayerX *= this.rotationSpeedf;
        //rotateGunX *= this.rotationSpeedf * -1;

        this.transform.Translate(new Vector3(moveHorizontal, 0f, moveVertical));
        this.transform.Rotate(0f, rotatePlayerX, 0f);
        //this.gun.transform.Rotate(rotateGunX, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newRocket = Instantiate(this.Rocket);
            newRocket.transform.position = this.gun.transform.position + (this.transform.forward * 2);
            newRocket.transform.rotation = this.gun.transform.rotation;
            newRocket.AddComponent<RocketEngine>();
        }
    }
}

using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour
{
    //1. Използвайте аксисите "Horizontal", "Vertical" и "Mouse X" за да напраите контролер за движение. Hint - Transform.Translate, Transform.Rotate
    //2. Добавете код, с който при натикане на левия бутон на мишката се истанцира и изтрелва  куршум, който представлява елементарен куб или сфера.
    //3. Куршумът трябва да се изтрелва от позицията на оръжието, което е дете на този обект и да лети в права посока и да се самоунищожи след 2 секунди съществуване.

    public GameObject gun;
    public float MoveSpeed;
    public float rotationSpeedf;

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotateGunX = Input.GetAxis("Mouse Y") * Time.deltaTime;
        float rotatePlayerX = Input.GetAxis("Mouse X") * Time.deltaTime;

        moveHorizontal *= this.MoveSpeed;
        moveVertical *= this.MoveSpeed;
        rotateGunX *= this.rotationSpeedf * -1;
        rotatePlayerX *= this.rotationSpeedf;

        this.gun.transform.Rotate(rotateGunX, 0f, 0f);
        this.transform.Translate(new Vector3(moveHorizontal, 0f, moveVertical));
        this.transform.Rotate(0f, rotatePlayerX, 0f);
    }
}

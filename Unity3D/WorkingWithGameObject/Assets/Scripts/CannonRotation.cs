using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour
{

    Vector3 posToFace = new Vector3(0.28f, 1.89f, 10.72f);
    Camera mainCamera;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30f));

        transform.position = new Vector3(transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime), transform.position.y, transform.position.z);

#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 30f));
        }
#endif

        transform.LookAt(posToFace);

        transform.eulerAngles = new Vector3(0f, transform.localRotation.eulerAngles.y - 180f, 0f);
    }
}

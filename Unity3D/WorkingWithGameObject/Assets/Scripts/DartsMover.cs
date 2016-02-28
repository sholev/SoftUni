using UnityEngine;
using System.Collections;

public class DartsMover : MonoBehaviour
{


    int score = 0;

    Vector3 newPos;
    Vector3 startPos;
    float progress = 0f;

    // Use this for initialization
    void Start()
    {
        NewCoords();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startPos, newPos, progress);

        progress += Time.deltaTime * (0.5f + (score / 10));

        if (progress >= 1f)
        {
            NewCoords();
        }
    }


    void NewCoords()
    {
        startPos = transform.position;
        newPos = new Vector3(Random.Range(-6.5f, 6f), Random.Range(4f, 16f), 11f);
        progress = 0f;
    }


    void OnTriggerEnter(Collider other)
    {
        NewCoords();
        score++;
        Debug.Log("Score: " + score.ToString());
    }


}

using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void OnGUI()
    {
        Debug.Log("OnGUI");

        Event e = Event.current;
        if (e.isMouse)
        {

            switch (e.button)
            {
                case 0:
                    Debug.Log("Left Click");
                    break;
                case 1:
                    Debug.Log("Right Click");
                    break;
                case 2:
                    Debug.Log("Middle Click");
                    break;
                default:
                    Debug.Log("Another button in the mouse clicked");
                    break;
            }
        }


        if (e.isKey)
        {

            string keys = "";
            if (e.shift)
            {
                keys += "Shift + ";
            }

            keys += e.keyCode;

            Debug.Log(keys);
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}
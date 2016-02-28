using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputTouch : MonoBehaviour
{
    
    public Text txt;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.touchCount > 0)
        {
            txt.text = Input.touches[0].phase.ToString();
        }
	}
}

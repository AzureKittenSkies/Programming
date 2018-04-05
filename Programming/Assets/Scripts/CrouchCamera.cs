using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCamera : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        
        // Placeholder code to mimic playermodel animating to a crouch
		if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            this.transform.Translate(0, -0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            this.transform.Translate(0, 0.5f, 0);
        }

	}
}

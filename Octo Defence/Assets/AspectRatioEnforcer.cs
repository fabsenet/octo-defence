using UnityEngine;
using System.Collections;

public class AspectRatioEnforcer : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//this game requires at least 16:10 widescreen. 16:9 and 3:2 will just see more left to right.
		var cam = Camera.main;
		var aspectRatio = Screen.width/(float)Screen.height;

		if (aspectRatio < 16f / 10f)
		{
			//this screen is not wide enough to show 16:10 minimum
			//we need to apply letterboxing
			Debug.Log("Aspect ratio " + aspectRatio + " is NOT good enough");

			var desiredScreenHeight = Screen.width/16f*10f;

			var verticalQuotient = desiredScreenHeight/Screen.height;
			var relativeBarHeight = 1f - verticalQuotient;
			cam.rect = new Rect(0, relativeBarHeight/2, 1, verticalQuotient);
		}
		else
		{
			Debug.Log("Aspect ratio "+ aspectRatio+" is good enough");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

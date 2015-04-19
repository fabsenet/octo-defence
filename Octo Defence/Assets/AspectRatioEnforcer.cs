using UnityEngine;
using System.Collections;

public class AspectRatioEnforcer : MonoBehaviour {
	private static Camera _cam;


	// Use this for initialization
	void Awake ()
	{
		ChangeAspectRatio();
	}
	void Start()
	{
		ChangeAspectRatio();
	}

	void Update()
	{
		ChangeAspectRatio();
	}

	private static void ChangeAspectRatio()
	{
		if(_cam==null) { _cam = Camera.main;}
		
		//this game requires at least 16:10 widescreen. 16:9 and 3:2 will just see more left to right.
		var aspectRatio = Screen.width/(float) Screen.height;

		if (aspectRatio >= 16f/10f - 0.001f)
		{
			if (_cam.rect.height < 1f || _cam.rect.width < 1f)
			{
				_cam.rect = new Rect(0f,0f, 1f, 1f);
			}
			return;
		}

		//this screen is not wide enough to show 16:10 minimum
		//we need to apply letterboxing
		Debug.Log("Aspect ratio " + aspectRatio + " is NOT good enough");

		var desiredScreenHeight = Screen.width/16f*10f;

		var verticalQuotient = desiredScreenHeight/Screen.height;
		var relativeBarHeight = 1f - verticalQuotient;
		_cam.rect = new Rect(0, relativeBarHeight/2, 1, verticalQuotient);
	}
}

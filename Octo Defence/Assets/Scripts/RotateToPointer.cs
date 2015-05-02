using UnityEngine;
using System.Collections;

public class RotateToPointer : MonoBehaviour
{
	private Camera _cam;

    public GameTimer GameTimer;

	// Use this for initialization
	void Start ()
	{
		_cam = Camera.main;
	}
	
	// Update is called once per frame
	internal void Update ()
	{
	    if (GameTimer != null && GameTimer.IsPaused) return;

		var origin = transform.position;
		var target = _cam.ScreenToWorldPoint(Input.mousePosition);
		target = new Vector3(target.x,target.y, origin.z);

		//Debug.DrawLine(origin,target);

		var newRotation = Quaternion.LookRotation(_cam.transform.forward, target-origin);

		var eulerAngle = newRotation.eulerAngles;
		var z = eulerAngle.z;
		var isIn0To90 = z >= 0 && z <= 90;
		var isIn270To360 = z >= 270 && z <= 360;
		if (!isIn0To90 && !isIn270To360)
		{
			//the gun is pointing downwards
			var distanceTo90 = z - 90;
			var distanceTo270 = 270 - z;
			if (distanceTo90 < distanceTo270)
			{
				newRotation = Quaternion.Euler(0,0,90);
			}
			else
			{
				newRotation = Quaternion.Euler(0,0,270);
			}
		}
		transform.rotation = newRotation;
	}
}

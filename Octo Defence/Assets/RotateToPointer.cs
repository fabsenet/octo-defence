using UnityEngine;
using System.Collections;
using UnityEditor;

public class RotateToPointer : MonoBehaviour {
	private Camera _cam;

	// Use this for initialization
	void Start ()
	{
		_cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var origin = transform.position;
		var target = _cam.ScreenToWorldPoint(Input.mousePosition);
		target = new Vector3(target.x,target.y, origin.z);

		Debug.DrawLine(origin,target);

		var newRotation = Quaternion.LookRotation(_cam.transform.forward, target-origin);
		transform.rotation = newRotation;
	}
}

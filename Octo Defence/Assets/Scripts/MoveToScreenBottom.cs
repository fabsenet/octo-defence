using UnityEngine;
using System.Collections;

public class MoveToScreenBottom : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var cam = Camera.main;
		var worldPos = cam.ScreenToWorldPoint(new Vector3(Screen.width/2f, 0, 0));
		var position = new Vector3(transform.position.x,worldPos.y, transform.position.z);
		transform.position =position;
		Debug.Log("moving " + name + " to " + position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

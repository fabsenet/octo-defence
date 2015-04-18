using UnityEngine;
using System.Collections;

public class MoveToScreenBottom : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var cam = Camera.main;
		var worldPos = cam.ScreenToWorldPoint(new Vector3(Screen.width/2f, 0, 0));
		transform.position =new Vector3(transform.position.x,worldPos.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

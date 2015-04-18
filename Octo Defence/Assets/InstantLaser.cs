using UnityEngine;
using System.Collections;

public class InstantLaser : MonoBehaviour
{

	public Color LaserColor = Color.green;

	public float Thickness=1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1"))
		{
			Debug.Log("fire!!");
		}
	}
}

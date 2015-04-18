using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ResizeParticleSystemToFullscreen : MonoBehaviour
{

	public Transform LowerBoundIndicator;
	// Use this for initialization
	void Start ()
	{
		var cam = Camera.main;
		var worldSizeUL = cam.ScreenToWorldPoint(new Vector3(0, Screen.height));
		var worldSizeLR = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0));
		var worldSize = worldSizeUL - worldSizeLR;

		var lowerBound = LowerBoundIndicator.position;

		var yScale = Mathf.Abs(lowerBound.y - worldSizeUL.y);

		transform.position = new Vector3(transform.position.x, lowerBound.y + (worldSizeUL.y - lowerBound.y) / 2f, transform.position.y);
		transform.localScale = new Vector3(worldSize.x, yScale, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

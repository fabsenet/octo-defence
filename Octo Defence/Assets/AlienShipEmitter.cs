using UnityEngine;
using System.Collections;

public class AlienShipEmitter : MonoBehaviour
{

	public Transform AlienShipPrefab;
	public float EmittingRate = 0.8f;
	public float Width = 1f;
	public float Height = 1f;

	private float _nextEmittingTime;

	// Use this for initialization
	void Start ()
	{
		_nextEmittingTime = Time.time + 1/EmittingRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _nextEmittingTime)
		{
			
		}
	}
}

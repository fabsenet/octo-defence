using UnityEngine;
using System.Collections;

public class AlienShipEmitter : MonoBehaviour
{

	public Transform AlienShipPrefab;
	public float EmittingRate = 0.8f;
	public float Width = 1f;
	public float Height = 1f;

	private float _nextEmittingTime;

	private float _top, _left, _right, _bottom;
	// Use this for initialization
	void Start ()
	{
		_nextEmittingTime = Time.time + 1/EmittingRate;

		var center = transform.position;

		_top = center.y + Height/2;
		_bottom = center.y - Height/2;
		_left = center.x - Width/2;
		_right= center.x + Width/2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _nextEmittingTime)
		{
			_nextEmittingTime = Time.time + 1/EmittingRate;
			Instantiate(AlienShipPrefab, new Vector3(Random.Range(_left, _right), Random.Range(_bottom, _top)), Quaternion.identity);
		}
	}
}

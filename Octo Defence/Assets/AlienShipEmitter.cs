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

			var position = new Vector3(Random.Range(_left, _right), Random.Range(_bottom, _top));
			var clone = (Transform)Instantiate(AlienShipPrefab, position, Quaternion.identity);
			clone.parent = transform.parent;
			
			var leftRightMover = clone.GetComponent<LeftRightMover>();

			var isLeftDirection = Random.Range(0f, 1f) >= 0.5f;
			leftRightMover.StartDirection = isLeftDirection ? LeftRightMover.MovingDirection.Left : LeftRightMover.MovingDirection.Right;

			var maxDistanceToBoundary = isLeftDirection ? position.x - _left : _right - position.x;

			leftRightMover.HorizontalDistance = Random.Range(0f, maxDistanceToBoundary);

			if (leftRightMover.HorizontalDistance <= 1f)
			{
				leftRightMover.HorizontalSpeed = 0f;
				leftRightMover.HorizontalDistance = 0f;
			}
			else if (leftRightMover.HorizontalDistance < 4f)
            {
				leftRightMover.HorizontalSpeed = Random.Range(1f, 6f);
			}
			else //4+
			{
				leftRightMover.HorizontalSpeed = Random.Range(3f, 5.5f);
			}

		}
	}
}

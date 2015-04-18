using UnityEngine;
using System.Collections;
using UnityEditor;

public class LeftRightMover : MonoBehaviour
{
	public enum MovingDirection
	{
		Right=1,
		Left=-1
	}

	public MovingDirection StartDirection = MovingDirection.Right;
	public float HorizontalDistance = 5;
	public float HorizontalSpeed = 5;

	internal float _movedDistance = 0f;
	private MovingDirection _movingDirection = MovingDirection.Right;
	// Use this for initialization
	void Start () {
		if (StartDirection == MovingDirection.Left)
		{
			_movedDistance = HorizontalDistance;
			_movingDirection = MovingDirection.Left;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		var deltaDistance = Time.deltaTime*HorizontalSpeed*(int) _movingDirection;

		_movedDistance += deltaDistance;

		if (_movingDirection == MovingDirection.Right && _movedDistance >= HorizontalDistance)
		{
			//zu weit, umdrehen!
			_movingDirection = MovingDirection.Left;
		}
		if (_movingDirection == MovingDirection.Left && _movedDistance <= 0)
		{
			//zu weit, umdrehen!
			_movingDirection = MovingDirection.Right;
		}

		transform.Translate(deltaDistance, 0 ,0);
	}
}

public class LeftRightMoverGizmoDrawer
{
	[DrawGizmo(GizmoType.Active|GizmoType.Selected|GizmoType.NotSelected)]
	public static void DrawGizmoForLeftRightMover(LeftRightMover src, GizmoType gizmoType)
	{
		if (src.StartDirection == LeftRightMover.MovingDirection.Left && !Application.isPlaying)
		{
			var movedDistance = src.HorizontalDistance;
            Debug.DrawLine(new Vector3(src.transform.position.x - movedDistance, src.transform.position.y)
				, new Vector3(src.transform.position.x - movedDistance + src.HorizontalDistance, src.transform.position.y), Color.yellow);
		}
		else
		{
			Debug.DrawLine(new Vector3(src.transform.position.x - src._movedDistance, src.transform.position.y)
				, new Vector3(src.transform.position.x - src._movedDistance + src.HorizontalDistance, src.transform.position.y), Color.yellow);
		}
	}
}

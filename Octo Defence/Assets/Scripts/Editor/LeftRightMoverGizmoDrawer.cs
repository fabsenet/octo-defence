using UnityEngine;
using System.Collections;
using UnityEditor;

public class LeftRightMoverGizmoDrawer
{
	[DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NotSelected)]
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

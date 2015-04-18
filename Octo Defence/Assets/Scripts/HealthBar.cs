using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class HealthBar : MonoBehaviour
{
	public bool ShouldDisplayBarsFor100Percent = false;

	private HealthStats _healthStats;

	private LineRenderer _greenBar;
	private LineRenderer _redGround;


	// Use this for initialization
	void Start ()
	{
		_healthStats = GetComponentInParent<HealthStats>();
		if (_healthStats == null)
		{
			Debug.LogError("Could not find health stats");
		}

		var childLineRenderers = GetComponentsInChildren<LineRenderer>();
		if (childLineRenderers.Count() != 2)
		{
			throw new Exception("There should be exactly 2 LineRenderes in Children. Found "+childLineRenderers.Count());
		}
		_greenBar = childLineRenderers[0];
		_redGround = childLineRenderers[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (_healthStats.MaxHealthPoints <= _healthStats.CurrentHealthPoints)
		{
			//the object has full health, display bars only if configured
			_greenBar.enabled = ShouldDisplayBarsFor100Percent;
			_redGround.enabled = ShouldDisplayBarsFor100Percent;
		}
		else
		{
			//the object is damaged, always dispay bars
			_greenBar.enabled = true;
			_redGround.enabled = true;

			var cutOverPoint = new Vector3(_healthStats.CurrentHealthPoints / _healthStats.MaxHealthPoints, 0, 0);
			_greenBar.SetPosition(1, cutOverPoint);
			_redGround.SetPosition(0, cutOverPoint);
		}
	}
}

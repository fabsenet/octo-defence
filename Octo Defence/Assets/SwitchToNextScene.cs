using UnityEngine;
using System.Collections;

public class SwitchToNextScene : MonoBehaviour
{

	public float TimeToWait = 3f;

	public float _startTime;
	// Use this for initialization
	void Start ()
	{
		_startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - _startTime > TimeToWait)
		{
			Application.LoadLevel("Level1");
		}
	}
}

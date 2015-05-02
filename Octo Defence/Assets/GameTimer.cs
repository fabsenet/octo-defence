using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameTimer : MonoBehaviour
{
    public float StartTimeLeft = 30;

    public Button[] ButtonsToDisableOnPause;
    private Text _text;
	// Use this for initialization
	void Start ()
	{
	        AudioListener.pause = false;
        _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var remainingSeconds = StartTimeLeft - Time.time;
	    _text.text = String.Format("Time Left: {0:0}", Mathf.Max(0, remainingSeconds));

	    if (remainingSeconds < 0)
	    {
	        //game over!
	        Time.timeScale = 0;

            //inform all components
	        IsPaused = true;
	        AudioListener.pause = true;
	        if (ButtonsToDisableOnPause != null)
	        {
	            foreach (var button in ButtonsToDisableOnPause)
	            {
	                button.interactable = false;
	            }
	        }
	    }
	    else
	    {
	    }
    }

    public bool IsPaused = false;
}

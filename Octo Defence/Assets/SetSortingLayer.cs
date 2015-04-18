using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SetSortingLayer : MonoBehaviour {

	
	// Use this for initialization
	void Start ()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();

		var ps = GetComponent<ParticleSystem>();
		if (ps != null)
		{
		}

		var lr = GetComponent<LineRenderer>();
		if (lr != null)
		{
			lr.sortingLayerName = spriteRenderer.sortingLayerName;
			lr.sortingOrder = spriteRenderer.sortingOrder;
			lr.sortingLayerID = spriteRenderer.sortingLayerID;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

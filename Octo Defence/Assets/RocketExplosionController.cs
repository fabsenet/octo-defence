using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class RocketExplosionController : MonoBehaviour
{

	private int framesAlive = 0;
	private Collider2D _explosionRadius;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 3f);
		_explosionRadius = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		framesAlive++;
		if (framesAlive == 3)
		{
			_explosionRadius.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var health = other.GetComponent<HealthStats>();
		if (health != null)
		{
			health.ApplyDamage(110f);
		}
	}
}

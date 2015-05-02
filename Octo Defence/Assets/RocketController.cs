using UnityEngine;
using System.Collections;

[RequireComponent(typeof (RotateToPointer))]
[RequireComponent(typeof (ConstantForce2D))]
[RequireComponent(typeof (Rigidbody2D))]
public class RocketController : MonoBehaviour
{
    public GameTimer GameTimer;
	public Transform HittableLowerBound;
	public Transform Exhaust;
	public Transform RocketExplosionPrefab;

	private Camera _cam;
	private bool isFlying = false;
	private RotateToPointer _rotateToPointer;

	private Vector3 _target;
	private ConstantForce2D _constantForce;
	private Rigidbody2D _rigidbody;
	private AudioSource _audioSource;
	// Use this for initialization
	private void Start()
	{
		_cam = Camera.main;
		_rotateToPointer = GetComponent<RotateToPointer>();
		_constantForce = GetComponent<ConstantForce2D>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();

	}
	
	private float _lastDistance = 9999f;

	private Vector3 _startPosition;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			var health = other.GetComponent<HealthStats>();
			if (health != null)
			{
				health.ApplyDamage(110f);
			}

			ExplodeAndReset();
		}
	}

	void ExplodeAndReset()
	{
		Instantiate(RocketExplosionPrefab, transform.position, Quaternion.identity);
		ResetRocket();
	}
	// Update is called once per frame
	private void Update()
	{
		if (isFlying)
		{
			//check for collision
			var distanceToTarget = (transform.position - _target).magnitude;

			if (_lastDistance < distanceToTarget)
			{
				Debug.Log("boom!");
				ExplodeAndReset();
			}
			else
			{
				_lastDistance = distanceToTarget;
			}
		}
		else
		{
			//point marks the target
			var isShooting = Input.GetButton("Fire1") && (GameTimer==null || !GameTimer.IsPaused);
			var target = _cam.ScreenToWorldPoint(Input.mousePosition);
			isShooting = isShooting && target.y > HittableLowerBound.position.y;

			if (isShooting)
			{
				_startPosition = transform.position;
                _rotateToPointer.enabled = false;
				isFlying = true;
				_target = new Vector3(target.x, target.y, transform.position.z);
				_constantForce.enabled = true;
				Exhaust.gameObject.SetActive(true);
				_audioSource.Play();
			}
		}
	}

	private void ResetRocket()
	{
		isFlying = false;
		_lastDistance = 9999f;
		transform.position = _startPosition;
		_rotateToPointer.enabled = true;
		_rotateToPointer.Update();

		_constantForce.enabled = false;
		_rigidbody.velocity = Vector2.zero;
		_rigidbody.angularVelocity = 0;
		Exhaust.gameObject.SetActive(false);
		_audioSource.Stop();
    }
}

using UnityEngine;
using System.Collections;

public class InstantLaser : MonoBehaviour
{
    public GameTimer GameTimer;
    public Color LaserColor = Color.green;

    public LayerMask HittableLayers;

    public Transform MuzzlePoint;
    public Transform LaserRay;
    public Transform HittableLowerBound;

    public float DamagePerSecond = 30f;

    private Camera _cam;
    private Vector3 _maxLaserLength;
    private LineRenderer _laserRayLineRenderer;
    private AudioSource _laserSoundSource;

    private void Start()
    {
        _cam = Camera.main;
        _maxLaserLength = new Vector3(0, 50, 0);

        _laserRayLineRenderer = LaserRay.GetComponent<LineRenderer>();
        _laserSoundSource = GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        if (GameTimer != null && GameTimer.IsPaused) return;

        var isShooting = Input.GetButton("Fire1");


        var origin = transform.position;
        var target = _cam.ScreenToWorldPoint(Input.mousePosition);

        //disallow shooting downwards
        isShooting = isShooting && target.y > HittableLowerBound.position.y;

        _laserRayLineRenderer.enabled = isShooting;
        _laserSoundSource.enabled = isShooting;

        if (isShooting)
        {
            target = new Vector3(target.x, target.y, origin.z);
            var rotation = Quaternion.LookRotation(_cam.transform.forward, target - origin);
            var farTarget = origin + (rotation*_maxLaserLength);
            Debug.DrawLine(origin, farTarget, Color.grey);

            var hit = Physics2D.Raycast(origin, target - origin, _maxLaserLength.magnitude, HittableLayers);

            Vector3 rayTarget;
            if (hit.collider != null)
            {
                //Debug.Log("hitting " + hit.collider);
                //Debug.DrawLine(origin, hit.point, LaserColor);

                rayTarget = hit.point;

                var targetHealthStats = hit.collider.GetComponent<HealthStats>();
                if (targetHealthStats != null)
                {
                    //the target has health so we will damage it!
                    targetHealthStats.ApplyDamage(Time.deltaTime*DamagePerSecond);
                }
            }
            else
            {
                rayTarget = farTarget;
            }

            _laserRayLineRenderer.SetPosition(0, MuzzlePoint.position);
            _laserRayLineRenderer.SetPosition(1, rayTarget);
        }

    }
}


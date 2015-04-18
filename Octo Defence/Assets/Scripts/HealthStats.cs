using UnityEngine;
using System.Collections;

public class HealthStats : MonoBehaviour
{

	public float MaxHealthPoints = 100;
	public float CurrentHealthPoints = 100;

	public Transform DeathAnimationPrefab;

	public void ApplyDamage(float damageInPonts)
	{
		CurrentHealthPoints = Mathf.Max(CurrentHealthPoints - damageInPonts, 0);

		Debug.Log(name + " took "+ damageInPonts + " damage and has now "+CurrentHealthPoints+" health points left");
		if (CurrentHealthPoints <= 0.00001f)
		{
			//dead!
			var deathAnimation = (Transform)Instantiate(DeathAnimationPrefab, gameObject.transform.position, Quaternion.identity);
			deathAnimation.parent = gameObject.transform.parent;
			Destroy(gameObject);
			Destroy(deathAnimation.gameObject, 3);
		}
	}
}

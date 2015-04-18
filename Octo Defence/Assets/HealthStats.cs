using UnityEngine;
using System.Collections;

public class HealthStats : MonoBehaviour
{

	public float MaxHealthPoints = 100;
	public float CurrentHealthPoints = 100;

	public void ApplyDamage(float damageInPonts)
	{
		CurrentHealthPoints = Mathf.Max(CurrentHealthPoints - damageInPonts, 0);

		Debug.Log("Took "+ damageInPonts + " damage and have now "+CurrentHealthPoints+" health points left");
		if (CurrentHealthPoints <= 0.00001f)
		{
			//dead!
			Destroy(gameObject);
		}
	}
}

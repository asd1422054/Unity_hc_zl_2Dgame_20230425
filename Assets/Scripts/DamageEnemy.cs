using UnityEngine;

public class DamageEnemy : DamageBasic
{
	[Header("傷害值預置物")]
	public GameObject prefabDamage;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("武器"))
		{
			Damage(50);
			Instantiate(prefabDamage, transform.position, transform.rotation);
		}
	}
}

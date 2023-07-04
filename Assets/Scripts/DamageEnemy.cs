using UnityEngine;

public class DamageEnemy : DamageBasic
{
	private DataEnemy dataEnemy;
	private void Start()
	{
		dataEnemy = (DataEnemy)data;
		print(dataEnemy.expProbability);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("武器"))
		{
			Damage(50);
		}
	}

	protected override void Dead()
	{
		base.Dead();
		Destroy(gameObject);

		//print("隨機值:" + Random.value);

		if (Random.value < dataEnemy.expProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}

}

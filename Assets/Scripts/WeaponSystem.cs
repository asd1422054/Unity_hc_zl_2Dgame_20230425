using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
	[Header("生成間隔"), Range(0, 10)]
	public float interval = 3.5f;

	[Header("武器攻擊"), Range(0, 1000)]
	public float attack = 50;

	[Header("武器生成預置物")]
	public GameObject prefabWeapon;

	[Header("武器推力")]
	public Vector2 power;

	private void SpawnWeapon()
	{
		GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, transform.rotation);

		Rigidbody2D rigWeapon  = tempWeapon.GetComponent<Rigidbody2D>();

		rigWeapon.AddForce(power);

		tempWeapon.GetComponent<Weapon>().attack = this.attack;
	}

	private void Awake()
	{
		InvokeRepeating("SpawnWeapon", 0, interval);
	}

	public void Restart()
	{
		CancelInvoke("SpawnWeapon");
		InvokeRepeating("SpawnWeapon", 0, interval);
	}

	public void Stop()
	{
		CancelInvoke("SpawnWeapon");
	}
}

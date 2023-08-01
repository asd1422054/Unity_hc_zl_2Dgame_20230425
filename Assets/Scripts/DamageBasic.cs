using TMPro;
using UnityEngine;

public class DamageBasic : MonoBehaviour
{
	[Header("資料")]
	public DataBasic data;
	[Header("傷害值預置物")]
	public GameObject prefabDamage;

	protected float hp;
	protected float hpMax;

	private void Awake()
	{
		hp = data.hp;
	}

	public virtual void Damage(float damage)
	{
		hp -= damage;
		GameObject tempDamage = Instantiate(prefabDamage, transform.position, transform.rotation);
		tempDamage.transform.Find("傷害值文字").GetComponent<TextMeshProUGUI>().text = damage.ToString();

		Destroy(tempDamage, 1.5f);

		print($"<color=#ffee66>{gameObject.name} 血量剩下:{hp}</color>");

		if (hp <= 0) Dead();
	}

	protected virtual void Dead()
	{
		print($"<color=#ff9966>{gameObject.name} 死亡</color>");
	}
}

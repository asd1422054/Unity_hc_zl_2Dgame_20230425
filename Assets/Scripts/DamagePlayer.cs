using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    [Header("血條")]
    public Image imgHp;
	[Header("控制系統")]
	public ControlSystem controlSystem;
	[Header("武器生成點")]
	public WeaponSystem weaponSystem;
	[Header("結束畫面")]
	public GameObject goFinal;
	[Header("結束標題")]
	public TextMeshProUGUI textFinal;
	
	//private void Start()
	//{

	//}

	public override void Damage(float damage)
	{
		base.Damage(damage);
		imgHp.fillAmount = hp / hpMax;
	}

	protected override void Dead()
	{
		base.Dead();
		controlSystem.enabled = false;
		textFinal.text = "你已經死了.........";
		goFinal.SetActive(true);
	}

	public void Win()
	{
		controlSystem.enabled = false;
		textFinal.text = "恭喜過關";
		goFinal.SetActive(true);
	}
}

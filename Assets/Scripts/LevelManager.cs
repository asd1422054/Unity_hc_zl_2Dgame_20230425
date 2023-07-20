﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
	[Header("經驗值")]
	public Image imgExp;
	[Header("文字等級")]
	public TextMeshProUGUI textLv;
	[Header("文字經驗值")]
	public TextMeshProUGUI textExp;
	[Header("升級面板")]
	public GameObject goLvUp;
	[Header("技能1~3")]
	public GameObject[] goSkillUI;
	
	/// <summary>
	/// 0 武器生成間隔減少
	/// 1 生命值增加
	/// 2 移動速度提升
	/// 3 經驗吸取範圍提升
	/// 4 攻擊力增加
	/// </summary>
	[Header("技能資料陣列")]
	public DataSkill[] dataSkills;

	public List<DataSkill> randomSkill = new List<DataSkill>();

	private int lv = 1;
	private float exp = 0;

	public float[] expNeeds = { 100, 200, 300 };

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//print($"<color=#6699ff>{collision.name}</color>");

		if (collision.name.Contains("經驗值"))
		{
			collision.GetComponent<Expsystem>().enabled = true;
		}
	}

	//private void Start()
	//{
		//for (int i =0; i < 10; i++)
		//{
	
			//print($"<color=#6699>i 的值 : {i}</color>");

		//}	
	//}

	public void AddExp(float exp)
	{
		this.exp += exp;

		if (this.exp > expNeeds[lv - 1])
		{
			this.exp -= expNeeds[lv - 1];
			lv++;
			textLv.text = lv.ToString();
			LevelUp();
		}

		textExp.text = this.exp + "/ " + expNeeds[lv - 1];
		imgExp.fillAmount = this.exp / expNeeds[lv - 1];
	}

	private void LevelUp()
	{
		goLvUp.SetActive(true);
		Time.timeScale = 0;

		randomSkill = dataSkills.Where(x => x.skillLv < 5).ToList();
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillName;
			goSkillUI[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
			goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv" + randomSkill[i].skillLv;
			goSkillUI[i].transform.Find("技能圖示").GetComponent<Image>().sprite = randomSkill[i].skillPicture;

		}
	}

	[ContextMenu("產生經驗值需求資料")]
	private void ExpNeeds()
	{
		expNeeds = new float[100];

		for (int i = 0; i < 100; i++)
		{
			expNeeds[i] = (i + 1) * 100;
		}
	}

	public void ClickSkillButton(int indexSkill)
	{
		//print($"<color=#6699ff>點擊技能編號:{indexSkill}</color>");
		randomSkill[indexSkill].skillLv++;
		goLvUp.SetActive(false);
		Time.timeScale = 1;
		if (randomSkill[indexSkill].skillName == "增加經驗吸取的範圍") UpdateExpRange();
		if (randomSkill[indexSkill].skillName == "增加攻擊力") UpdateSwordAttack();
		if (randomSkill[indexSkill].skillName == "減少武器生成間隔") UpdateInterval();
		if (randomSkill[indexSkill].skillName == "生命增加") UpdatePlayerHp();
		if (randomSkill[indexSkill].skillName == "提升移動速度") UpdateMoveSpeed();
	}

	[Header("獸耳娘 : 圓形碰撞")]
	public CircleCollider2D playerExpRange;

	private void UpdateExpRange()
	{
		int lv = dataSkills[3].skillLv - 1;
		playerExpRange.radius = dataSkills[3].skillValues[lv];
	}

	[Header("武器劍生成點")]
	public WeaponSystem weaponSystemSword;

	private void UpdateSwordAttack()
	{
		int lv = dataSkills[4].skillLv - 1;
		weaponSystemSword.attack = dataSkills[4].skillValues[lv];
	}

	private void UpdateInterval()
	{
		int lv = dataSkills[0].skillLv - 1;
		weaponSystemSword.interval = dataSkills[0].skillValues[lv];
	}

	[Header("玩家資料")]
	public DataBasic dataBasic;

	private void UpdatePlayerHp()
	{
		int lv = dataSkills[1].skillLv - 1;
		dataBasic.hp = dataSkills[1].skillValues[lv];
	}

	[Header("獸耳娘 : 控制系統")]
	public ControlSystem controlSystem;

	private void UpdateMoveSpeed()
	{
		int lv = dataSkills[2].skillLv - 1;
		controlSystem.moveSpeed = dataSkills[2].skillValues[lv];
	}
}
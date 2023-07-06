using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	[Header("經驗值")]
	public Image imgExp;
	[Header("文字等級")]
	public TextMeshProUGUI textLv;
	[Header("文字經驗值")]
	public TextMeshProUGUI textExp;

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
		
	//}

	public void AddExp(float exp)
	{
		this.exp += exp;

		textExp.text = this.exp + "/100";
		imgExp.fillAmount = this.exp / 100;
	}
}

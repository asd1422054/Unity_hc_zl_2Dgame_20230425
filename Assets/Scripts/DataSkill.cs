using UnityEngine;

[CreateAssetMenu(menuName ="abyss/Data Skill")]
public class DataSkill : ScriptableObject
{
	[Header("技能名稱")]
	public string skillMame;
	[Header("技能圖片")]
	public Sprite skillPicture;
	[Header("技能描述"), TextArea(2, 5)]
	public string skillDescription;
	[Header("技能等級")]
	public int skillLv;
	[Header("技能數值")]
	public float[] skillValues;
}

using UnityEngine;

[CreateAssetMenu(menuName ="abyss/Data Enemy")]
public class DataEnemy : DataBasic
{
	[Header("掉落經驗值機率"), Range(0, 1)]
	public float expProbability;

	[Header("掉落經驗值預置物")]
	public GameObject prefabExp;
}

using UnityEngine;

[CreateAssetMenu(menuName = "abyss/Data Basic")]
public class DataBasic : ScriptableObject
{
	[Header("血量"), Range(0, 5000)]
	public float hp;

	[Header("攻擊力"), Range(0, 9999)]
	public float attack;

	[Header("移動速度"), Range(0, 200)]
	public float moveSpeed;

}

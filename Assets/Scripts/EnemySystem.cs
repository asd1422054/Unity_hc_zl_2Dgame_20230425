using UnityEngine;

public class EnemySystem : MonoBehaviour
{
	[Header("敵人資料")]
	public DataEnemy data;

	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("獸耳娘").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
	}

}

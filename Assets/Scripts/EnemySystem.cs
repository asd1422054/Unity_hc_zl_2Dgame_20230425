using UnityEngine;

public class EnemySystem : MonoBehaviour
{
	[Header("敵人資料")]
	public DataEnemy data;

	private Transform player;

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
		Gizmos.DrawSphere(transform.position, data.attackRamge);
	}

	private void Awake()
	{
		player = GameObject.Find("獸耳娘").transform;
	}

	private void Update()
	{
		float distance = Vector3.Distance(transform.position, player.position);
		print(distance);

		if(distance > data.attackRamge)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
		}
	}

}

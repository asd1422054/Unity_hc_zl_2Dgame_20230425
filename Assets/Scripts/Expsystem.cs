using System.Runtime.CompilerServices;
using UnityEngine;

public class Expsystem : MonoBehaviour
{
	[Header("移動速度"), Range(0, 10)]
	public float speed = 3.5f;
	[Header("吃掉的距離"), Range(0, 3)]
	public float distanceEat = 1;
	[Header("經驗值"), Range(0, 500)]
	public float exp = 30;

	private Transform player;
	private LevelManager levelManager;

	private void Awake()
	{
		player = GameObject.Find("獸耳娘").transform;
		levelManager = player.GetComponent<LevelManager>();
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, player.position) < distanceEat)
		{
			levelManager.AddExp(exp);
			Destroy(gameObject);
		}
	}

}

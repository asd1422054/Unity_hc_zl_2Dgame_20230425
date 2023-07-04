using UnityEngine;

public class Expsystem : MonoBehaviour
{
	[Header("移動速度"), Range(0, 10)]
	public float speed = 3.5f;

	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("獸耳娘").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime) ;		
	}
}

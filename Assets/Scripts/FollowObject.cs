using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("要跟隨的物件")]
    public Transform target;
    [Header("位移")]
    public float y = -3;

	private void Update()
	{
		Vector3 targetPos = target.position;
		targetPos.y += y;
		transform.position = targetPos;
	}
}

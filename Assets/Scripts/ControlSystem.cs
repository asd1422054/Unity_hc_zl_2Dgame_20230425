using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("移動速度")]
    [Range(0,20)]
    public float moveSpeed = 3.5f;
    [Header("鋼體")]
    public Rigidbody2D rig;
    private void Awake()
    {
        
    }

    private void Start()
    {
       
    }

    private void Update()
    {
      //呼叫移動方法
        Move();
    }

    private void Move()
	{
        float h = Input.GetAxis("Horizontal");
        print("水平值:" + h);
        float v = Input.GetAxis("Vertical");
        print("垂直值:" + v);

        rig.velocity = new Vector2(h, v) * moveSpeed;
	}

}
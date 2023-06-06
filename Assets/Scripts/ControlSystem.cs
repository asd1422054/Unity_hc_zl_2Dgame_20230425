using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("移動速度")]
    [Range(0,20)]
    public float moveSpeed = 3.5f;

    [Header("鋼體")]
    public Rigidbody2D rig;

    [Header("動畫控制器")]
    public Animator ani;

    [Header("跑步參數")]
    public string parRun = "開關走路";

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
        //print("水平值:" + h);

        float v = Input.GetAxis("Vertical");
        //print("垂直值:" + v);

        rig.velocity = new Vector2(h, v) * moveSpeed;

        //h 不等於 0 或者 v 不等於 0 要走路
        ani.SetBool(parRun, h != 0 || v!=0 );

        //print(Input.GetKeyDown(KeyCode.A));

        if (Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.LeftArrow))
		{
            //print("玩家按下A");
            transform.eulerAngles = new Vector3(0, 180, 0);
		}

		if (Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow))
		{
            //print("玩家按下D");
            transform.eulerAngles = new Vector3(0, 0, 0);
		}

	}

}
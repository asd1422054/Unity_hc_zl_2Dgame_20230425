using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    private void Awake()
    {
        print("測試一");
        print(1 + 2);
        print($"錢{1 + 2}");
        print("1+2");
    }

    private void Start()
    {
        print("<color=red>開始事件</color>");
    }
    private void Update()
    {
        print("<color=blue>更新事件</color>");
    }
}
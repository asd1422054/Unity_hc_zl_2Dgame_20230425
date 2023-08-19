using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool canDestory = true;
    public float attack;

    private void Awake()
    {
        if(canDestory)
            {
                Destroy(gameObject, 3);
                
            }
       
    }
}
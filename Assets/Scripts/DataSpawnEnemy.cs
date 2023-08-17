using UnityEngine;

[CreateAssetMenu(menuName = "abyss/Data Spawn Enemy")]
public class DataSpawnEnemy : ScriptableObject
{
    [Header("這波怪物的生成時間點")]
    public float timeToSpawn;
    [Header("要生成的怪物")]
    public GameObject prefabEnemy;
    [Header("生成怪物的間隔"), Range(0, 5)]
    public float intervalSpawn;
}
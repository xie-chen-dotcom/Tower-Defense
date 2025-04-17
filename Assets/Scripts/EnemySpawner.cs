using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    public Transform startPoint;
    public List<Wave> waveList;
    private int enemyCount = 0;
    public Coroutine spawnCoroutine;

    private void Awake()
    {
        // 防止单例被多个实例覆盖，确保只存在一个 EnemySpawner 对象
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       // DontDestroyOnLoad(gameObject); // 确保在场景切换时，EnemySpawner 不被销毁，保持持续生成敌人
    }

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy()); // 保存协程的引用，方便随时停止它
    }

     public IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waveList)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, startPoint.position, Quaternion.identity);
                enemyCount++;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate); // 控制每个敌人之间的生成时间
                }
            }

            // 等待当前波次所有敌人被消灭后再生成下一波
            while (enemyCount > 0)
            {
                yield return null; // 使用 yield return null 而不是 yield return 0，更符合 Unity 的协程惯例
            }
        }

        // 确保所有敌人被消灭后，触发游戏胜利逻辑
        while (enemyCount > 0)
        {
            yield return null; // 确保最后的敌人也被处理完成
        }
        GameManager.Instance.Win(); // 通知游戏管理器，玩家赢得了游戏
    }

    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine); // 停止敌人生成的协程，确保不会再生成新的敌人
        // 可以在这里添加清除当前场景中剩余敌人的逻辑，以确保游戏状态的一致性
    }

    public void DecreateEnemyCount()
    {
        if (enemyCount > 0)
        {
            enemyCount--; // 减少当前敌人数量
        }
        else
        {
            Debug.LogWarning("Attempted to decrease enemyCount below zero!"); // 防止敌人数量变成负数，帮助调试潜在的问题
        }
    }
}
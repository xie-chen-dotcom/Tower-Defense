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
        // ��ֹ���������ʵ�����ǣ�ȷ��ֻ����һ�� EnemySpawner ����
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       // DontDestroyOnLoad(gameObject); // ȷ���ڳ����л�ʱ��EnemySpawner �������٣����ֳ������ɵ���
    }

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy()); // ����Э�̵����ã�������ʱֹͣ��
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
                    yield return new WaitForSeconds(wave.rate); // ����ÿ������֮�������ʱ��
                }
            }

            // �ȴ���ǰ�������е��˱��������������һ��
            while (enemyCount > 0)
            {
                yield return null; // ʹ�� yield return null ������ yield return 0�������� Unity ��Э�̹���
            }
        }

        // ȷ�����е��˱�����󣬴�����Ϸʤ���߼�
        while (enemyCount > 0)
        {
            yield return null; // ȷ�����ĵ���Ҳ���������
        }
        GameManager.Instance.Win(); // ֪ͨ��Ϸ�����������Ӯ������Ϸ
    }

    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine); // ֹͣ�������ɵ�Э�̣�ȷ�������������µĵ���
        // ������������������ǰ������ʣ����˵��߼�����ȷ����Ϸ״̬��һ����
    }

    public void DecreateEnemyCount()
    {
        if (enemyCount > 0)
        {
            enemyCount--; // ���ٵ�ǰ��������
        }
        else
        {
            Debug.LogWarning("Attempted to decrease enemyCount below zero!"); // ��ֹ����������ɸ�������������Ǳ�ڵ�����
        }
    }
}
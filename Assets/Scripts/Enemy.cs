using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition=Vector3.zero;
    public float speed = 4;
    public float hp = 100;
    public GameObject explosionPrefab;
    private Slider hpSlider;
    public float maxHp = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition=Waypoints.Instance.GetWaypoint(pointIndex);
        //hpSlider= GetComponent<Slider>();
        hpSlider=transform.Find("Canvas/HpSlider").GetComponent<Slider>();
        hpSlider.value = 1;
        maxHp = hp;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            MoveNextPoint();
        }

    }
    private void MoveNextPoint()
    {
        pointIndex++;
        if (pointIndex > (Waypoints.Instance.GetLength() - 1))
        {
            GameManager.Instance.Fail();
           
            Die();
            return;
        }
        targetPosition = Waypoints.Instance.GetWaypoint(pointIndex);
    }
    void Die()
    {
        Destroy(this.gameObject);
        EnemySpawner.Instance.DecreateEnemyCount();
        GameObject go= GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.identity);
        Destroy(go,1);
    }
    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / maxHp;
        if (hp <= 0) 
        {
            Die();
        }
    }
}

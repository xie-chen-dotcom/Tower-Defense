using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletExplosionPrefab;
    public int damage=50;
    public float speed = 30;

    private Transform target;
    private void Update()
    {
        if (target == null) {
            Dead();
            return; }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
        if(Vector3.Distance(transform.position, target.position) < 0.2)
        {
            Dead();
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    // Start is called before the first frame update
    public void SetTarget(Transform _transform)
    {
        this.target = _transform;
    }
    private void Dead()
    {
        Destroy(this.gameObject);
        GameObject go= GameObject.Instantiate(bulletExplosionPrefab,this.transform.position,Quaternion.identity);
        Destroy(go, 1);
        /**if (target != null) 
        {
            go.transform.parent = target.transform;
        }**/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    public LineRenderer lineRender;
    public float damagePerSecond = 60;
    public Transform laserStartPosition;
    // Start is called before the first frame update
    protected override void Attack()
    {
        Transform target=GetTarget();
        if (target == null) 
        {
            lineRender.enabled = false;
            return; 
        }
        target.GetComponent<Enemy>().TakeDamage(damagePerSecond*Time.deltaTime);
        lineRender.enabled = true;
        lineRender.SetPosition(0, laserStartPosition.position);
        lineRender.SetPosition(1,target.position);
    }
}

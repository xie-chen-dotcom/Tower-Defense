using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class TurretData 
{
    // Start is called before the first frame update
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradePrefab;
    public int costUpgrade;
    public TurretType type;
}
public enum TurretType
{
    StandardTurret,
    MissileTurret,
    LaserTurret
} 

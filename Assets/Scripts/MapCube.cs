using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject turretGo;
    private TurretData turretData;
    private bool isUpgraded = false;
    // Start is called before the first frame update
   
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return;
        if (turretGo != null)
        {
            BuildManager.Instance.ShowUpgradeUI(this, transform.position, isUpgraded);
        }
        else
        {
            BuildTurret();
        }



    }
    private void BuildTurret()
    {
        TurretData selectedTD = BuildManager.Instance.selectedTurretData;
        if (selectedTD == null || selectedTD.turretPrefab == null) return;

        // 检查玩家是否有足够的金钱
        if (!BuildManager.Instance.IsEnough(selectedTD.cost))
        {
            return;
        }

        // 扣除金钱
        BuildManager.Instance.ChangeMoney(-selectedTD.cost);

        // 建造炮塔
        turretGo = GameObject.Instantiate(selectedTD.turretPrefab, transform.position, Quaternion.identity);

        // 赋值 turretData，保存当前建造的炮塔的数据
        turretData = selectedTD;
    }

    public void OnTurretUpgrade()
    {
        if (turretData == null)
        {
            Debug.LogWarning("Cannot upgrade turret, turretData is null.");
            return;
        }

        // 检查玩家是否有足够的金钱来升级
        if (BuildManager.Instance.IsEnough(turretData.costUpgrade))
        {
            // 扣除升级的金钱
            BuildManager.Instance.ChangeMoney(-turretData.costUpgrade);

            // 升级炮塔
            if (turretGo != null)
            {
                Destroy(turretGo);
            }
            turretGo = GameObject.Instantiate(turretData.turretUpgradePrefab, transform.position, Quaternion.identity);
            isUpgraded = true;
        }
    }

    public void OnTurretDestroy()
    {
        Destroy(turretGo);
        turretData = null;
        turretGo = null;
    }
}
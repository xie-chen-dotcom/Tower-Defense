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

        // �������Ƿ����㹻�Ľ�Ǯ
        if (!BuildManager.Instance.IsEnough(selectedTD.cost))
        {
            return;
        }

        // �۳���Ǯ
        BuildManager.Instance.ChangeMoney(-selectedTD.cost);

        // ��������
        turretGo = GameObject.Instantiate(selectedTD.turretPrefab, transform.position, Quaternion.identity);

        // ��ֵ turretData�����浱ǰ���������������
        turretData = selectedTD;
    }

    public void OnTurretUpgrade()
    {
        if (turretData == null)
        {
            Debug.LogWarning("Cannot upgrade turret, turretData is null.");
            return;
        }

        // �������Ƿ����㹻�Ľ�Ǯ������
        if (BuildManager.Instance.IsEnough(turretData.costUpgrade))
        {
            // �۳������Ľ�Ǯ
            BuildManager.Instance.ChangeMoney(-turretData.costUpgrade);

            // ��������
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
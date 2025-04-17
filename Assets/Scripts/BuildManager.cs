using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;

    public TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    private int money = 1000;
    public UpgradeUI upgradeUI;
    private MapCube upgradeCube;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }

    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn) { }
        selectedTurretData = missileTurretData;
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn) { }
        selectedTurretData = laserTurretData;
    }
    public bool IsEnough(int need)
    {
        return need <= money;
    }
    public void ChangeMoney(int value)
    {
        this.money += value;
        moneyText.text = "￥" + money.ToString();
    }
    public void ShowUpgradeUI(MapCube cube, Vector3 position, bool isDisableUpgrade)
    {
        upgradeCube = cube;
        upgradeUI.Show(position, isDisableUpgrade);
    }
    public void HideUpgradeUI()
    {
        upgradeUI.Hide();
    }
    public void OnTurretUpgrade()
    {
        upgradeCube?.OnTurretUpgrade();
        HideUpgradeUI();
    }
    public void OnTurretDestroy()
    {
        upgradeCube?.OnTurretDestroy();//?判断是否为空 不为空时调用
        HideUpgradeUI();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public NewBehaviourScript standartTurret;
    public NewBehaviourScript misslelauncher;
    public NewBehaviourScript laserBeamer;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.selectTurretToBuild(standartTurret);
    }
    public void SelectMissleLauncher ()
    {
        Debug.Log("MissleLauncherSelected  ");
        buildManager.selectTurretToBuild(misslelauncher);
    }

    public void SelectLeaserBeamer()
    {
        Debug.Log("Laser Beamerr Selected  ");
        buildManager.selectTurretToBuild(laserBeamer);
    }




}

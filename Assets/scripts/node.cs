using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;


public class node : MonoBehaviour {
    public Color hoverColor;
    public Color notEnoughtMoney;
    public Vector3 positionOffset;
    public GameObject turret;
    [HideInInspector]
    BuildManager buildManager;
    [HideInInspector]
    public NewBehaviourScript turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;
     void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
  public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
       
        

        if (turret !=null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.canBuild)
            return;
        //build a turret
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (NewBehaviourScript blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("No Money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        Debug.Log("Turret build! Money left:  " + PlayerStats.Money);
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;


        //Get rid of the old turret
        Destroy(turret);


        //building a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
    


        Debug.Log("Turret build! Money left:  " + PlayerStats.Money);
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded = true;


    }

    public void SellTurret()
    {

        PlayerStats.Money += turretBlueprint.GetSellAmount()  ;
        //Spawn a cool effect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;

    }


    void OnMouseEnter ()

    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
       
        if (buildManager.canBuild)
            return;
       /* if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }*/ else
        {
            rend.material.color = notEnoughtMoney;
        }

        rend.material.color = hoverColor;
    }
    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}

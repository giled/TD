
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    void Awake()
    {
        

        if (instance != null)
        {
            Debug.LogError("More than one Build");
            return;
                
        }
      
      
        instance = this;
        
    }
   
    public GameObject buildEffect;
        
  
    private NewBehaviourScript turretToBuild;
    public bool canBuild { get { return turretToBuild != null; } }
    //public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    public void buildTurretOn(node node)
    {
           if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No Money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
       
       GameObject turret=(GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret build! Money left:  " + PlayerStats.Money);
        GameObject effect=(GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
	public void selectTurretToBuild(NewBehaviourScript turret)
    {
        turretToBuild = turret;
    }
}

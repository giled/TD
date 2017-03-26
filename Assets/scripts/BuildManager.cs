
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
    public GameObject sellEffect;
  
    private NewBehaviourScript turretToBuild;
    private node selectedNode;
    public NodeUI nodeUI;
    public bool canBuild { get { return turretToBuild != null; } }
    //public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
   

    public void SelectNode(node node)
    {
        if (selectedNode==node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
	public void selectTurretToBuild(NewBehaviourScript turret)
    {

        turretToBuild = turret;
        DeselectNode();
    }
    public  NewBehaviourScript GetTurretToBuild()
    {
        return turretToBuild;
    }
}

using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;


public class node : MonoBehaviour {
    public Color hoverColor;
    public Color notEnoughtMoney;
    public Vector3 positionOffset;
    public GameObject turret;
    [Header("Optinional")]
    BuildManager buildManager;

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
        if (!buildManager.canBuild)
            return;
        

        if (turret !=null)
        {
            Debug.Log("Cant build there!");
            return;
        }
        //build a turret
        buildManager.buildTurretOn(this);
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

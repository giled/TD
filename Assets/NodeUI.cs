
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButon;

    public Text sellAmount;


    private node target;
    public void SetTarget(node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "€" + target.turretBlueprint.upgradeCost;
            upgradeButon.interactable = true;
        }else
        {
            upgradeCost.text = "DONE";
             upgradeButon.interactable = false;
        }


        sellAmount.text = "€" + target.turretBlueprint.GetSellAmount();




        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

	}


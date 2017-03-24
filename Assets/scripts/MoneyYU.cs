using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MoneyYU : MonoBehaviour {
    public Text moneytext;

	
	// Update is called once per frame
	void Update () {
        moneytext.text = PlayerStats.Money.ToString();
	}
}

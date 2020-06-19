using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] // unity will save and load values inside of this class and they're visible for us in the inspector
public class TurretBlueprint
{
     
    // Start is called before the first frame update
    
    public GameObject prefab;
    public int cost; 

    public GameObject upgradedPrefab; 
    public int upgradeCost;

    public int GetSellAmount() {
        return cost/2;
    }

}

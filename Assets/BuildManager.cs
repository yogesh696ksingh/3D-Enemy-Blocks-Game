
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //MakeItAvailableWithout reference. That is using singleton pattern

    public static BuildManager instance;
    
    void Awake() {
        instance = this;
    }

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild; 
    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } } //property: only allowed to get something
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } 

    public NodeUI nodeUI;  

    public void SelectNode (Node node) {
        if(selectedNode == node) {
            DeselectNode();
            return;
        }
        selectedNode = node; 
        turretToBuild = null;
        nodeUI.SetTarget (node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret) {
        turretToBuild = turret;
        DeselectNode(); 
    }

    public TurretBlueprint GetTurretToBuild () {
        return turretToBuild; 
    }
}

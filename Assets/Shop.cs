
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher; 
    public TurretBlueprint laserBeamer;

    BuildManager buildManager; 

    void Start () {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret () {
        Debug.Log("Standard Turret Selected"); 
        buildManager.SelectTurretToBuild(standartTurret); 
    }
    
     public void SelectMissileLauncher () {
        Debug.Log("Missile Launcher Selected"); 
        buildManager.SelectTurretToBuild(missileLauncher); 
    }

    public void SelectLaserBeamer () {
        Debug.Log("Laser Beamer Selected"); 
        buildManager.SelectTurretToBuild(laserBeamer); 
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level01"; 
   public void Play () {
        SceneManager.LoadScene(levelToLoad);     
   }
   public void Quit () {
       Debug.Log("Exiting... "); 
       Application.Quit(); 
   }
}

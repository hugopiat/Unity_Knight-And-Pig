using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceLevel : MonoBehaviour
{


    public string Level2Load;
    public string LevelToLoad1;
    public string LevelToLoad2;
    public string LevelToLoad3;

     public static ChoiceLevel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }

    public void Level1()
    {
        Level2Load = LevelToLoad1;
        SceneManager.LoadScene("ChoiceDifficulty");
     

    }
    public void BOSS()
    {
        Level2Load = LevelToLoad3;
        SceneManager.LoadScene("ChoiceDifficulty");
        

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


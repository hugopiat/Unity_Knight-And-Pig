using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceDifficulty : MonoBehaviour
{
    public int degatschoix;

    public static ChoiceDifficulty instance;
    public void Back()
    {
        SceneManager.LoadScene("ChoiceLevel");
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }
    public void Easy()
    {
        SceneManager.LoadScene(ChoiceLevel.instance.Level2Load);
        degatschoix = 1;
    }
    public void Normale()
    {
        SceneManager.LoadScene(ChoiceLevel.instance.Level2Load);
        degatschoix = 2;
    }

    public void Hard()
    {
        SceneManager.LoadScene(ChoiceLevel.instance.Level2Load);
        degatschoix = 3;
    }


}


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewSceneEnd : MonoBehaviour
{
    public bool isInRange;

    public Text intercatUI;

    private void Awake()
    {
        intercatUI = GameObject.FindGameObjectWithTag("InteractUIEnd").GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("ChoiceLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intercatUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intercatUI.enabled = false;
            isInRange = false;
        }
    }

}

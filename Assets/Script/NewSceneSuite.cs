using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewSceneSuite : MonoBehaviour
{
    public bool isInRange;

    public Text intercatUISuite;

    private void Awake()
    {
        intercatUISuite = GameObject.FindGameObjectWithTag("InteractUISuite").GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("BOSS");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intercatUISuite.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intercatUISuite.enabled = false;
            isInRange = false;
        }
    }

}

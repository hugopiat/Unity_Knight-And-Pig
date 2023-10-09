using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{ 

    PlayerHealth PlayerHealth;

    public static CountDownScript instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }



    float time = 120f;


    void Start()
    {
        StartCoroutine(timer());
        time += 1;
    }


    void Update()
    {

    }

    IEnumerator timer()
    {
        while(time>0)
        {
            time--;
            yield return new WaitForSeconds (1f);
            GetComponent<Text> ().text= "" +time;
        }

           if (time==0)
        {
        yield return new WaitForSeconds (1f);
        PlayerHealth.instance.isdie = true;
        PlayerHealth.instance.Die();
        }
    }
    

}

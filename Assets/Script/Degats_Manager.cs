using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degats_Manager : MonoBehaviour
{
    public static Degats_Manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention, instance > 1 !");
            return;
        }
        instance = this;
    }

    void Update()
    {
        Ennemy_Patrol.instance.damage = ChoiceDifficulty.instance.degatschoix;
        trap.instance.damage = ChoiceDifficulty.instance.degatschoix;
    }
}

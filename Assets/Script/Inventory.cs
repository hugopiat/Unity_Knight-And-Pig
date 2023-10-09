using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int CoinCount;
    public Text CoinCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scene");
            return;
        }

        instance = this;
    }

    public void AddCoins(int Count)
    {
        CoinCount += Count;
        CoinCountText.text = CoinCount.ToString();
    }
}

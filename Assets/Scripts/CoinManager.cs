using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TMP_Text coinText;
    public int currentCouins = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinText.text = currentCouins.ToString();
    }

   public void IncreaseCoins(int v)
    {
        currentCouins += v;
        coinText.text = currentCouins.ToString();
    }
   
}

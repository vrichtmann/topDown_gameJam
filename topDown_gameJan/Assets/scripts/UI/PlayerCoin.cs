using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoin : MonoBehaviour
{
    public GameObject PlayerCoinTXT;
    public float coin = 300;

   void Start()
   {
        PlayerCoinTXT.GetComponent<Text>().text = coin.ToString();
    }

    public void setCoinValue(float _value){
        coin = _value;
        PlayerCoinTXT.GetComponent<Text>().text = coin.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalBuy : MonoBehaviour
{
    public GameObject TotalTXT;
    public float total = 0;

    public void setTotalValue(float _value, float _playerCoin)
    {
        total = _value;
        TotalTXT.GetComponent<Text>().text = total.ToString();
        if (_value > _playerCoin){//not enough
            TotalTXT.GetComponent<Text>().color = new Color(255f, 0f, 0f, 1);
        }
        else{
            TotalTXT.GetComponent<Text>().color = new Color(255f, 255f, 255f, 1);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject BG;
    public GameObject BGIMG;
    [SerializeField] private PlayerMoviment PlayerMV;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            PlayerMV.inShop = false;
        }
    }
}

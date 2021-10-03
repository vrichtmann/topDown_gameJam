using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopPlayerCustomization : MonoBehaviour
{
    public GameObject armor;
    public GameObject Hat;
    public GameObject Glasses;

    [HideInInspector] public Sprite initArmorIMG;
    [HideInInspector] public Sprite initHatIMG;
    [HideInInspector] public Sprite initGlassesIMG;
    void Start()
    {
        initArmorIMG = armor.GetComponent<Image>().sprite;
        initHatIMG = Hat.GetComponent<Image>().sprite;
        initGlassesIMG = Glasses.GetComponent<Image>().sprite;
    }

}

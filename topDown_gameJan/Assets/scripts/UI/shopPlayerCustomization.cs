using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopPlayerCustomization : MonoBehaviour
{
    public GameObject armor;
    public GameObject Hat;
    public GameObject Glass;

    [HideInInspector] public Sprite initArmorIMG;
    [HideInInspector] public Sprite initHatIMG;
    [HideInInspector] public Sprite initGlassesIMG;
    void Start()
    {
        setInitSprites();
    }

    public void setInitSprites()
    {
        initArmorIMG = armor.GetComponent<Image>().sprite;
        initHatIMG = Hat.GetComponent<Image>().sprite;
        initGlassesIMG = Glass.GetComponent<Image>().sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour
{
    public GameObject placeHolder;
    public GameObject nameItem;
    public GameObject priceItem;
    public GameObject ItemImg;

    public void setNameItem(string _name)
    {
        nameItem.GetComponent<Text>().text = _name;
    }

    public void setPriceItem(float _price)
    {
        priceItem.GetComponent<Text>().text = _price.ToString();
    }

    public void setItemImg(Sprite _image)
    {
        ItemImg.GetComponent<Image>().sprite = _image;
        placeHolder.gameObject.SetActive(false);
    }

    public void setPlaceHolder() {
        nameItem.gameObject.transform.parent.gameObject.SetActive(false);
        priceItem.gameObject.transform.parent.gameObject.SetActive(false);
        ItemImg.gameObject.SetActive(false);

    }
}

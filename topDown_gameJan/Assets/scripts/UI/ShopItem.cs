using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour
{
    public GameObject placeHolder;
    public GameObject nameItem;
    public GameObject textBox;
    public GameObject priceItem;
    public GameObject ItemImg;
    public GameObject cursorIcon;
    public GameObject selected;
    public GameObject soldOut;

    public bool isSouldOut = false;

    private void Start()
    {
        //cursorIcon.gameObject.active = false;
        // textBox.gameObject.active = false;
        cursorIcon.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        nameItem.gameObject.GetComponent<Text>().color = new Color(255f, 255f, 255f, 0);
        textBox.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        selected.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        soldOut.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
    }
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

    public void activeSoldOut()
    {
        soldOut.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1);
    }

    public void selectItem()
    {
        selected.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1);
    }

    public void unselectItem()
    {
        selected.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
    }

    public void onCursor()
    {
        cursorIcon.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1);
        textBox.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1);
        nameItem.gameObject.GetComponent<Text>().color = new Color(255f, 255f, 255f, 1);
    }

    public void outCursor()
    {
        cursorIcon.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        textBox.gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0);
        nameItem.gameObject.GetComponent<Text>().color = new Color(255f, 255f, 255f, 0);
    }

    public void setPlaceHolder() {
        nameItem.gameObject.transform.parent.gameObject.SetActive(false);
        priceItem.gameObject.transform.parent.gameObject.SetActive(false);
        ItemImg.gameObject.SetActive(false);

    }
}

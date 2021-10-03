using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionControl : MonoBehaviour
{
    public GameObject optionName;
    public GameObject optionIcon;
    public GameObject textBox;

    public void setOptionName(string _name)
    {
        optionName.GetComponent<UnityEngine.UI.Text>().text = _name;
    }

    public void setOptionImage(Sprite _optionIcon)
    {
        optionIcon.GetComponent<Image>().sprite = _optionIcon;
    }

    public void setSelectOption(bool _isSelected)
    {
        if (_isSelected)
        {
            optionIcon.GetComponent<Image>().color = new Color32(6, 217, 44, 225);
            optionIcon.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
        }
        else
        {
            optionIcon.GetComponent<Image>().color = new Color32(255, 255, 225, 225);
            optionIcon.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
    }
}

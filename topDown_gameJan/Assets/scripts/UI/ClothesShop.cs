using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClothesShop : MonoBehaviour
{
    [SerializeField] GameObject leftLockerRoom;
    [SerializeField] GameObject rightLockerRoom;

    [SerializeField] GameObject rowShopping;
    [SerializeField] GameObject shopItem;

    [SerializeField] itemList[] forsale;

    // Start is called before the first frame update
    void Start()
    {
        createClothesMenu();
    }

    private void createClothesMenu(){
        //GameObject currentLeftRow = Instantiate(rowShopping, new Vector3(30, 0, 0), Quaternion.identity);
        //currentLeftRow.transform.parent = leftLockerRoom.transform.GetChild(0).GetChild(0);//this.transform;
         GameObject currentLeftRow = new GameObject();
        GameObject currentRigthRow = new GameObject();
         //GameObject currentRigthRow = Instantiate(rowShopping, new Vector3(30, 0, 0), Quaternion.identity);
         //currentRigthRow.transform.parent = rightLockerRoom.transform.GetChild(0).GetChild(0);//this.transform;


         float numberOfRow = Mathf.Floor((forsale.Length / 6)) + 1 ;

        if (forsale.Length % 6 == 0) numberOfRow -= 1;

        int contItens = 0;

        Debug.Log("numberOfRow : " + (forsale.Length % 5));
        Debug.Log("numberOfRow : " + numberOfRow);
        if(forsale.Length > 0)
        {
            for (int i = 0; i < (numberOfRow * 6); i++)
            {

                if(contItens == 0)
                {
                    currentLeftRow = Instantiate(rowShopping, new Vector3(30, 0, 0), Quaternion.identity);
                    currentLeftRow.transform.parent = leftLockerRoom.transform.GetChild(0).GetChild(0);//this.transform;

                    currentRigthRow = Instantiate(rowShopping, new Vector3(30, 0, 0), Quaternion.identity);
                    currentRigthRow.transform.parent = rightLockerRoom.transform.GetChild(0).GetChild(0);//this.transform;
                }

                GameObject currentItemShop;
                bool isPlaceHolder = (i > (forsale.Length - 1)) ? true : false;  //(contItens < forsale.Length);
                itemList currentItemList = new itemList();

                if (contItens < 3)
                {
                    currentItemShop = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
                    currentItemShop.transform.parent = currentLeftRow.transform;//this.transform;
                }
                else
                {
                    currentItemShop = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
                    currentItemShop.transform.parent = currentRigthRow.transform;//this.transform;
                }
               
                //Debug.Log("Item Name : " + forsale[0].itemName);
                if (!isPlaceHolder) currentItemList = forsale[i];

                setClothes(currentItemShop, isPlaceHolder, currentItemList);

                contItens++;
                if (contItens >= 6) contItens = 0;
            }
        }
        
    }

    private void setClothes(GameObject _currentItemShop, bool isPlaceHolder, itemList _currentItemList)
    {
        ShopItem currentItem = _currentItemShop.GetComponent<ShopItem>();
        if (!isPlaceHolder)
        {
            currentItem.setNameItem(_currentItemList.itemName);
            currentItem.setPriceItem(_currentItemList.price);
            currentItem.setItemImg(_currentItemList.figure);
        }
        else
        {
            currentItem.setPlaceHolder();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClothesShop : MonoBehaviour
{
    [SerializeField] GameObject leftLockerRoom;
    [SerializeField] GameObject rightLockerRoom;

    [SerializeField] ArrayList itensShop;
    [SerializeField] GameObject rowShopping;
    [SerializeField] GameObject shopItem;
    [SerializeField] GameObject cursor;
    

    [SerializeField] itemList[] forsale;
    private int cursorX = 0;
    private int cursorY = 0;
    private float numberOfRow;
    // Start is called before the first frame update
    void Start()
    {
        itensShop = new ArrayList();
        createClothesMenu();
        alignCursor(2, cursorY);
    }

    void Update(){
        cursorListener();
    }

    private void createClothesMenu(){
        GameObject currentLeftRow = new GameObject();
        GameObject currentRigthRow = new GameObject();

        numberOfRow = Mathf.Floor((forsale.Length / 6)) + 1 ;

        if (forsale.Length % 6 == 0) numberOfRow -= 1;

        int contItens = 0;

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
               
                if (!isPlaceHolder) currentItemList = forsale[i];

                setClothes(currentItemShop, isPlaceHolder, currentItemList);

                itensShop.Add(currentItemShop);
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

    private void alignCursor(int _row, int _colunm)
    {
        Debug.Log("MUDOU ROW : " + _row);
        Debug.Log("MUDOU Column : " + _colunm);
        GameObject targetCursorItem = itensShop[0] as GameObject;
        Vector3 targetPos = targetCursorItem.GetComponent<RectTransform>().localPosition;
        float rigthValue = _row > 2 ? 150 : 0;
        cursor.GetComponent<RectTransform>().localPosition = new Vector3(targetPos.x - 110 + (_row * 32) + rigthValue, targetPos.y + 17 - (_colunm * 50), targetPos.z);
    }

    void cursorListener(){
        if (Input.GetKeyDown(KeyCode.U))
        {
            cursorY -= 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            cursorY += 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            cursorX -= 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            cursorX += 1;
            updateCursor();
        }
    }

    private void updateCursor()
    {
        if (cursorX > 5) cursorX = 0;
        if (cursorX < 0) cursorX = 5;
        if (cursorY > numberOfRow) cursorY = 0;
        if (cursorY < 0) cursorY = (int)numberOfRow;
        Debug.Log("cursorX : " + cursorX);
        Debug.Log("cursorY : " + cursorY);
        alignCursor(cursorX, cursorY);
    }
}

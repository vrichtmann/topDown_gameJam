using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClothesShop : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject leftLockerRoom;
    [SerializeField] GameObject rightLockerRoom;

    [SerializeField] ArrayList itensShop;
    [SerializeField] GameObject rowShopping;
    [SerializeField] GameObject shopItem;
    [SerializeField] GameObject Char;
    [SerializeField] GameObject playerCoin;
    [SerializeField] GameObject total;
    
    [SerializeField] itemList[] forsale;

    ArrayList seletedItensArray;
    ArrayList seletedIDSArray;
    ArrayList boughtItemsArray;

    private int cursorX = 0;
    private int cursorY = 0;
    private float numberOfRow;
    private int lastCursorIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        itensShop = new ArrayList();
        seletedItensArray = new ArrayList();
        seletedIDSArray = new ArrayList();
        boughtItemsArray = new ArrayList();
        createClothesMenu();
    }

    void Update(){
        cursorListener();
        selectItemListener();
        Buy();
        alignCursor(cursorX, cursorY);
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
            if (checkIsBought(_currentItemList)){
                currentItem.activeSoldOut();
            }
        }
        else
        {
            currentItem.setPlaceHolder();
        }
    }

    private bool checkIsBought(itemList _shopItem){
        for(int i = 0; i < boughtItemsArray.Count; i++)
        {
            itemList bouthItemList = boughtItemsArray[i] as itemList;
            if (bouthItemList.id == _shopItem.id)
            {
                return true;
            }
        }
        return false;
    }

    private void alignCursor(int _row, int _colunm)
    {
        int indexCursor = _row + (_colunm * 6);
        
        GameObject oldCursorItem = itensShop[lastCursorIndex] as GameObject;
        ShopItem oldItem = oldCursorItem.GetComponent<ShopItem>();
        oldItem.outCursor();

        GameObject targetCursorItem = itensShop[indexCursor] as GameObject;
        ShopItem item = targetCursorItem.GetComponent<ShopItem>();
        item.onCursor();
        lastCursorIndex = indexCursor;
    }

    void cursorListener(){
        if (Input.GetKeyDown(KeyCode.W))
        {
            cursorY -= 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            cursorY += 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cursorX -= 1;
            updateCursor();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            cursorX += 1;
            updateCursor();
        }
    }

    private void selectItemListener() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject currentPart;
            int currrentID = cursorX + (cursorY * 6);
            GameObject targetSkin =  Resources.Load<GameObject>("UI/Shop/" + forsale[currrentID].itemtype + "/" + forsale[currrentID].id) ;

            if(forsale[currrentID].itemtype.ToString() == "hat")
            {
                currentPart = Char.GetComponent<shopPlayerCustomization>().Hat;
                currentPart.GetComponent<Image>().sprite = targetSkin.GetComponent<Image>().sprite;
            }
            else if (forsale[currrentID].itemtype.ToString() == "glass")
            {
                currentPart = Char.GetComponent<shopPlayerCustomization>().Glass;
                currentPart.GetComponent<Image>().sprite = targetSkin.GetComponent<Image>().sprite;
            }
            else if (forsale[currrentID].itemtype.ToString() == "armor")
            {
                currentPart = Char.GetComponent<shopPlayerCustomization>().armor;
                currentPart.GetComponent<Image>().sprite = targetSkin.GetComponent<Image>().sprite;
            }

            GameObject currentShopItemGB = itensShop[currrentID] as GameObject;
            ShopItem currenShopItem = currentShopItemGB.GetComponent<ShopItem>();
            CheckSelectItem(forsale[currrentID],  currenShopItem, currrentID);
            calculateTotal();
        }
    }

    private void updateCursor()
    {
        if (cursorX > 5) cursorX = 0;
        if (cursorX < 0) cursorX = 5;
        if (cursorY > (numberOfRow - 1)) cursorY = 0;
        if (cursorY < 0) cursorY = (int)(numberOfRow - 1);
        alignCursor(cursorX, cursorY);
    }

    private bool CheckSelectItem(itemList _selectedItem, ShopItem _currentShopItem, int _ID)
    {

        int isExistNB = checkExistType(_selectedItem, _currentShopItem);

        for (int i = 0; i < seletedItensArray.Count; i++)
        {
            var currentSelected = seletedItensArray[i] as itemList;
            if (_selectedItem.id == currentSelected.id)
            {
                seletedItensArray.RemoveAt(i);
                seletedIDSArray.RemoveAt(i);

                setInitClotheByType(_selectedItem.itemtype.ToString());
                
                _currentShopItem.unselectItem();
                return false;
            }
        }

        if(isExistNB != -1)
        {
            GameObject oldItem = itensShop[(int)seletedIDSArray[isExistNB]] as GameObject;
            ShopItem oldShopItem = oldItem.GetComponent<ShopItem>();

            oldShopItem.unselectItem();

            seletedItensArray.RemoveAt(isExistNB);
            seletedIDSArray.RemoveAt(isExistNB);
        }

        seletedItensArray.Add(_selectedItem);
        seletedIDSArray.Add(_ID);
        _currentShopItem.selectItem();
        return true;
    }

    private int checkExistType(itemList _selectedItem, ShopItem _currentShopItem)
    {
        for (int i = 0; i < seletedItensArray.Count; i++)
        {
            itemList currentSelected = seletedItensArray[i] as itemList;
            if (_selectedItem.itemtype == currentSelected.itemtype && _selectedItem.id != currentSelected.id)
            {
                return i;
            }
        }
        return -1;
    }

    private void setInitClotheByType(string itemType)
    {
        shopPlayerCustomization shopPlayer = Char.GetComponent<shopPlayerCustomization>();

        if (itemType == "hat")
        {
            GameObject currentPart = Char.GetComponent<shopPlayerCustomization>().Hat;
            currentPart.GetComponent<Image>().sprite =  shopPlayer.initHatIMG;
        }
        else if (itemType == "glass")
        {
            GameObject currentPart = Char.GetComponent<shopPlayerCustomization>().Glass;
            currentPart.GetComponent<Image>().sprite = shopPlayer.initGlassesIMG;
        }
        else if (itemType == "armor")
        {
            GameObject currentPart = Char.GetComponent<shopPlayerCustomization>().armor;
            currentPart.GetComponent<Image>().sprite = shopPlayer.initArmorIMG;
        }
    }

    public void calculateTotal()
    {
        float totalCount = 0f;
        for (int i = 0; i < seletedItensArray.Count; i++)
        {
            var currentSelected = seletedItensArray[i] as itemList;
            totalCount += currentSelected.price;
        }

        float playerMoney = playerCoin.GetComponent<PlayerCoin>().coin;

        total.GetComponent<TotalBuy>().setTotalValue(totalCount, playerMoney);
    }

    private void Buy()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Buy
            PlayerCoin playerCoinComponent = playerCoin.GetComponent<PlayerCoin>();
            TotalBuy totalComponent = total.GetComponent<TotalBuy>();

            float playerMoney = playerCoinComponent.coin;
            float totalMoney = totalComponent.total;
            if (totalMoney <= playerMoney && totalMoney != 0)
            {
                 //Debug.Log("CONSEGUE COMPRAR");
                total.GetComponent<TotalBuy>().setTotalValue((playerMoney - totalMoney), playerMoney);
                playerCoin.GetComponent<PlayerCoin>().setCoinValue((playerMoney - totalMoney));
                setPlayerSkin();

                seletedItensArray = new ArrayList();
                seletedIDSArray = new ArrayList();

                Shop.gameObject.active = false;
            }
        }
    }

    private void setPlayerSkin()
    {
        PlayerMoviment playerMV = Player.GetComponent<PlayerMoviment>();

        for (int i = 0; i < seletedItensArray.Count; i++)
        {
            var currentSelected = seletedItensArray[i] as itemList;

            boughtItemsArray.Add(currentSelected);
            playerMV.changeSkin(currentSelected.id.ToString(), currentSelected.itemtype.ToString());

            GameObject currentSelectedItem = itensShop[(int)seletedIDSArray[i]] as GameObject;
            ShopItem targetShopItem = currentSelectedItem.GetComponent<ShopItem>();
            targetShopItem.unselectItem();
        }
    }

}

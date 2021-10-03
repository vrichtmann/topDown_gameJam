using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clotheTypeController : MonoBehaviour
{
    public OptionType.playerParts[] playerParts;
    [SerializeField] private GameObject firstOption;
    [SerializeField] private GameObject middleOption;
    [SerializeField] private GameObject lastOption;
       
    public int currentOptionCount = 0;
    public int oldOptionCount = 0;
    public ArrayList optionsArray;

    void Start(){
        optionsArray = new ArrayList();
        createHeaderMenu();
    }

    void Update(){
        addListerners();
    }


    void createHeaderMenu(){
        for (int i = 0; i < playerParts.Length + 1; i++)
        {
            GameObject option;
            if (i == 0){
                //Create icon "All Parts"
                option = Instantiate(firstOption);
            }else if (i < (playerParts.Length)){
                //Middle Content
                option =  Instantiate(middleOption);
            }else{
                //Last Content
                option = Instantiate(lastOption);
            }
            option.transform.parent = this.transform;

            //Set Info
            OptionControl optionControl = option.GetComponent<OptionControl>();
            Sprite levelIconBG;
            string nameOption;

            if (i == 0){
                nameOption = "Everything";
                levelIconBG = Resources.Load<Sprite>("UI/header/All");
            } else{
                nameOption = playerParts[i - 1].ToString();
                levelIconBG = Resources.Load<Sprite>("UI/header/" + playerParts[i - 1].ToString());
            }

            if (i == 0) optionControl.setSelectOption(true);

            optionControl.setOptionName(nameOption);
            optionControl.setOptionImage(levelIconBG);
            optionControl.textBox.active = false;
            optionsArray.Add(option);
        }

        activateOption(0);
    }

 
    void addListerners()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            currentOptionCount++;
            if (currentOptionCount > playerParts.Length) currentOptionCount = 0;
            activateOption(currentOptionCount);
            Debug.Log("Next Option : " + currentOptionCount);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentOptionCount--;
            if (currentOptionCount < 0) currentOptionCount = playerParts.Length;
            activateOption(currentOptionCount);
            Debug.Log("Previous Option");
        }
    }

    void activateOption(int _option){
        GameObject currentOption = optionsArray[_option] as GameObject;
        OptionControl optionControl = currentOption.GetComponent<OptionControl>();
        GameObject oldOptionGO = optionsArray[oldOptionCount] as GameObject;
        OptionControl oldOptionControl = oldOptionGO.GetComponent<OptionControl>();

        if(currentOptionCount != oldOptionCount)
        {
            oldOptionControl.textBox.active = false;
            oldOptionControl.setSelectOption(false);
            
        }
        
        optionControl.textBox.active = true;
        optionControl.setSelectOption(true);
        oldOptionCount = _option;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonCreator : MonoBehaviour
{
    //SearchSceen related variables
    public TextAsset textJSON;
    public InputData searchData;

    //DataBase related variables
    [SerializeField] public GameObject listItems;
    [SerializeField] public GameObject listcontent;
    public ScrollRect scrollRect;
    public GameObject items;
    public GameObject Requireditems;
    public GameObject notFoundNamePanel;
    public float scrollValue;
    public int rank = 1;
    public int scrollpos = 1;


    [System.Serializable]
    public class Data
    {
       public string name;
       public int code;
    }

    [System.Serializable]
    public class DataList
    {
        public List<Data> data;
    }
    public DataList mydata = new DataList();

    public void Awake()
    {
        ExtractingAndArranginJsonData();
        scrollRect.verticalScrollbar.value = 1f   + AutoScrollLogic();

        
    }

    public float AutoScrollLogic()
    {
        float decreasinValue = 1f / (rank - 14);
        Debug.Log(rank);
        Debug.Log(1f/25f);
        Debug.Log(decreasinValue);
        for(int i = 1;i<=(scrollpos - 7);i++)
        {
            scrollValue = scrollValue - decreasinValue;
        }
        Debug.Log(scrollValue);
        return scrollValue;

    }

    public void ExtractingAndArranginJsonData()
    {
        bool hasName = false;
        searchData = GetComponent<InputData>();
        scrollRect = listcontent.GetComponent<ScrollRect>();


        mydata = JsonUtility.FromJson<DataList>(textJSON.text);

        foreach (Data dat in mydata.data)
        {

            items = Instantiate(listItems);

            if (strComparisonLoop(searchData.ChangeData(),dat.name))
            {
                items.GetComponent<Image>().color = new Color(1f, 0.5f, 0.32f);
                hasName = true;
                scrollpos = rank;

            }
            items.transform.SetParent(this.gameObject.transform, false);
            items.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = rank.ToString();
            rank++;
            items.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dat.name;
            items.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dat.code.ToString();

        }

        if (!hasName)
        {
            notFoundNamePanel.SetActive(true);
        }

    }

    private bool strComparisonLoop(string v, string name)
    {
   
        int nameLenght = name.Length;
        bool isEqual = false;
        for(int i = 0;i<name.Length;i++)
        {
           if(v[i]==name[i])
           {
                isEqual = true;
           }
           else
           {
                isEqual = false;
                break;
           }
        }
        
        return isEqual;
    }
}

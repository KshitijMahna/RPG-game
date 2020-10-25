using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;
    public List<Items> items = new List<Items>();
    public List<int> itemNumbers = new List<int>();

    //public Items item_03;//TEST VARIABLE
    public GameObject[] slots;

    private void Awake() //Singleton Pattern
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
                    }
        DontDestroyOnLoad(gameObject);
    }

    //void Update()//TEST METHOD 
    //{
    //    if (Input.GetKeyDown(KeyCode.M))
    //    {
    //        AddItems(item_03);
    //    }
    //}
        
    private void Start()
    {
        DisplayItems();
    }

    void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].item_sprite;

            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(0, 0, 0, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
        }
    }

    public void AddItems(Items _item)
    {
        //If this item is new to our inventory
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        //If the item is there from beginning
        else
        {
            Debug.Log("Item is already there m8 ;o");
            for (int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItems();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject itemButton;
    private inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    //We can place item here
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

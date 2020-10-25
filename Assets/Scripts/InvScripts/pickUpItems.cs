using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour
{
    public Items item_data;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GameManager.instance.AddItems(item_data);
    }
}

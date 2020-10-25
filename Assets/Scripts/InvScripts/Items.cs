using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Item", fileName= "New Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public string itemDescp;
    public Sprite item_sprite;
    public int itemPrice;
    
}

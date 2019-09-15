using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    
    public int itemId;
    public ItemType type;
    public string itemName;
    public Sprite image = null;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public int inventoryNo;
    private Item item;
    private bool isLock;
    public Image equipImage;


    public void AddItem(Item item)
    {
        this.item = item;
        SetItem();
    }

    private void SetItem()
    {
        Image image = this.gameObject.GetComponent<Image>();
        image.sprite = this.item.image;
        image.enabled = true;
        //equipImage.enabled = item.isEquipable;
    }

    public Item GetItem()
    {
        return this.item;
    }


    public void OnClickItem()
    {
        equipImage.enabled = !equipImage.enabled;

        if (isLock)
        {
            Debug.Log("Locking!!");
        }
        else
        {
            Debug.Log("Unlocking!!");
        }
    }


}

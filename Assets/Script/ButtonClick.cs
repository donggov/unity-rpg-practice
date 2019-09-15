using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Image filterImage;
    public float coolTime = 5.0f;
    private float coolTimeCheckSpeed = 0.1f;
    private float increaseFillAmount;
    private bool isClickable = true;
    public GameObject inventoryPanel;
    public Item newItem;

    void Start()
    {   
        increaseFillAmount = coolTimeCheckSpeed / coolTime;
    }

    public void OnClick()
    {
        Debug.Log("OnClick");
        if (isClickable)
        {
            isClickable = false;
            filterImage.fillAmount = 0.0f;
            StartCoroutine("ResetCoolTime");
        }

    }

    public void OnClickInventory()
    {
        Debug.Log("OnClickInventory");
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void OnClickAddItem()
    {
        InventoryManager.instance.AddItem(newItem);
    }

    IEnumerator ResetCoolTime()
    {
        while (filterImage.fillAmount < 1.0f)
        {
            yield return new WaitForSeconds(coolTimeCheckSpeed);
            filterImage.fillAmount += increaseFillAmount;
        }
        isClickable = true;
        yield break;
    }


}

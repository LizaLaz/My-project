using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;
    public Transform itemsParent;
    InventorySlot[] slots;
   
    void Start()
    {
        inventory = Inventory.inctance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentInChildren<InventorySlot>();

    }
    
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(inventoryUI.activeSelf);
        }
    }
    void UpdateUI()
    {
       for (int i = 0; i<slots.Length; i++)
       {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
       }
    }
}

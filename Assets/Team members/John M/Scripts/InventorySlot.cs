﻿using UnityEngine;
using UnityEngine.UI;

namespace JonathonMiles
{
    public class InventorySlot : MonoBehaviour 
    {

        public Image icon;			// Reference to the Icon image
        public Button removeButton;	// Reference to the remove button

        ItemBase item;  // Current item in the slot

        // Add item to the slot
        public void AddItem (ItemBase newItem)
        {
            item = newItem;

            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
        }

        // Clear the slot
        public void ClearSlot ()
        {
            item = null;

            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
        }

        public void OnRemoveButton ()
        {
            Inventory.instance.Remove(item);
        }

        public void UseItem ()
        {
            if (item != null)
            {
                item.Use();
            }
        }

    }
}
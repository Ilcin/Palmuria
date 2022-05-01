using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
	public Transform slotParent;
	public ItemSlot itemSlotPrefab;
	public List<ItemSlot> itemSlots = new List<ItemSlot>(8);
	public ItemSlot selectedItem;
	public AudioSource voSource;
	public TextManager textManager;
	public CharacterProps characterProps;

    // This function is called by the PickedUpItemReaction in order to add an item to the inventory.
    public void AddItem(Item itemToAdd)
	{
		if (!itemToAdd) {
			throw new ArgumentNullException ();
		}
		ItemSlot itemSlot = Instantiate<ItemSlot> (itemSlotPrefab, slotParent);
		itemSlot.item = itemToAdd;
		itemSlots.Add(itemSlot);

		var itemCombinations = ItemCombination.AllInstances ();
		foreach (var combination in itemCombinations) {
			if (combination.TryCombining(this)) {
				
				voSource.clip = combination.audioClip;
				voSource.PlayDelayed (2.5f);
				textManager.DisplayMessage (combination.message, characterProps, 2.5f);
			}
		}
    }


    // This function is called by the LostItemReaction in order to remove an item from the inventory.
    public void RemoveItem (Item itemToRemove)
    {
		if (selectedItem && selectedItem.item == itemToRemove) {
			SelectItemSlot (null);
		}
		foreach (var slot in itemSlots.FindAll(slot => slot.item == itemToRemove)) {
			itemSlots.Remove (slot);
			DestroyObject (slot.gameObject);
		}
    }

	public void SelectItemSlot (ItemSlot itemSlot) {
		if (selectedItem) {
			selectedItem.image.rectTransform.anchoredPosition = Vector2.zero;
		}
		if (itemSlot != null) {
			selectedItem = itemSlot;
		} else {
			selectedItem = null;
		}
	}

	public void Update() {
		if (!selectedItem) {
			return;
		}

		Vector3 mousePos = Input.mousePosition;
		Vector3 pos = new Vector3 (
			              mousePos.x + selectedItem.image.rectTransform.rect.width * (2 / 3f),
			              mousePos.y - selectedItem.image.rectTransform.rect.height * (2 / 3f),
			              selectedItem.image.rectTransform.position.z
		              );

		selectedItem.image.rectTransform.position = pos;
	}	
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {
	public Image image;
	public Image placeholderMask;
	public Item item {
		get {
			return itemField;
		}
		set {
			if (!value) {
				throw new ArgumentNullException ();
			}
			if (itemField) {
				throw new InvalidOperationException();
			}
			itemField = value;
			image.sprite = item.sprite;
			placeholderMask.sprite = item.sprite;
		}
	}

	private Item itemField = null;
	private Inventory inventory;

	public void Start() {
		inventory = FindObjectOfType<Inventory> ();
	}
		
	public void OnPointerClick(PointerEventData evt) {
		if (inventory.selectedItem) {
			inventory.SelectItemSlot (null);
		} else {
			inventory.SelectItemSlot (this);
		}
	}
}

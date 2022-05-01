using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemCombination : ScriptableObject {

	private static ItemCombination[] instances = null;
	public static ItemCombination[] AllInstances() {
		if (instances != null) {
			return instances;
		}
		instances = Resources.LoadAll<ItemCombination> ("");
		return instances;
	}

	public List<Item> items = new List<Item> ();
	public Item resultItem;
	public AudioClip audioClip;
	public string message;

	public bool TryCombining(Inventory inventory) {
		if (!items.TrueForAll (item => inventory.itemSlots.Exists (slot => slot.item == item))) {
			return false;
		}
		// all needed items in inventory, remove them and add the result item
		foreach (var item in items) {
			inventory.RemoveItem (item);
		}
		inventory.AddItem (resultItem);
		return true;
	}
}

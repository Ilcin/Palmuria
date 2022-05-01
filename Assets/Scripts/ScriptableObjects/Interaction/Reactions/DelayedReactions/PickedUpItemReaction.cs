using System;
using UnityEngine;
using System.Collections;

public class PickedUpItemReaction : DelayedReaction
{
    public Item item;               // The item asset to be added to the Inventory.


    private Inventory inventory;    // Reference to the Inventory component.


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory>();
    }


    protected override void ImmediateReaction()
    {
        inventory.AddItem(item);
		var itemCombinations = ItemCombination.AllInstances ();
		for (int i = 0; i < itemCombinations.Length; i++) {
			itemCombinations[i].TryCombining (inventory);
		}
    }
}

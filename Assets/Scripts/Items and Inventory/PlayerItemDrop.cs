using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Items
{
    public class PlayerItemDrop : ItemDrop
    {
        [Header("Player's drop")]
        [SerializeField] private float chanceToLooseItems;
        [SerializeField] private float chanceToLooseMaterials;

        public override void GenerateDrop()
        {
            Inventory inventory = Inventory.instance;

            List<InventoryItem> itemsToUnequip = new List<InventoryItem>();
            List<InventoryItem> materialsToLoose = new List<InventoryItem>();

            foreach (InventoryItem item in inventory.GetEquipmentList())
            {
                if (Random.Range(0, 100) <= chanceToLooseItems)
                {
                    DropItem(item.data);
                    itemsToUnequip.Add(item);
                }
            }

            for (int i = 0; i < itemsToUnequip.Count; i++)
            {
                inventory.UnequipItem(itemsToUnequip[i].data as ItemDataEquipment);
            }



            foreach (InventoryItem item in inventory.GetStashList())
            {
                if (Random.Range(0, 100) <= chanceToLooseMaterials)
                {
                    DropItem(item.data);
                    materialsToLoose.Add(item);
                }
            }

            for (int i = 0; i < materialsToLoose.Count; i++)
            {
                inventory.RemoveItem(materialsToLoose[i].data);
            }
        }
    }
}
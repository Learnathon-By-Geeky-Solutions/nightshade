using MyGameNamespace.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
namespace MyGameNamespace.Utils
{
    public class UICraftSlot : UIItemSlot
    {
        private void OnEnable()
        {
            UpdateSlot(item);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            ItemDataEquipment craftData = item.data as ItemDataEquipment;

            Inventory.instance.CanCraft(craftData, craftData.craftingMaterials);
        }
    }
}
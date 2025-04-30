using MyGameNamespace.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
namespace MyGameNamespace.Utils
{
    public class UIEquipmentSlot : UIItemSlot
    {
        public EquipmentType slotType;

        private void OnValidate()
        {
            gameObject.name = "Equipment slot - " + slotType.ToString();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            Inventory.instance.UnequipItem(item.data as ItemDataEquipment);
            Inventory.instance.AddItem(item.data as ItemDataEquipment);


            CleanUpSlot();
        }
    }
}
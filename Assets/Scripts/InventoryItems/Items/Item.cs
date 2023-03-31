using UnityEngine;

namespace InventoryItems.Items
{
    public abstract class Item : ScriptableObject
    {
        [field: SerializeField] public string Name { get; set; } = "Item Name";
        [field: SerializeField] public Sprite UiIcon { get; set; }
        [field: SerializeField] public GameObject PickupPrefab { get; set; }
        
        public abstract void Use(ItemAttachment attachment);
    }
}
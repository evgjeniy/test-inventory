using UnityEngine;

namespace InventoryItems.Items
{
    public abstract class Weapon : Item
    {
        [SerializeField] protected float damage;
        [SerializeField] protected LayerMask attackMask;
    }
}
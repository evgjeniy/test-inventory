using UnityEngine;

namespace InventoryItems
{
    public class HandItem : MonoBehaviour
    {
        [SerializeField] private ItemPickup itemPickupPrefab;

        public void ThrowItem()
        {
            var parentPosition = transform.parent;
            Instantiate(itemPickupPrefab, parentPosition.transform.position + parentPosition.forward * 3.0f,
                Quaternion.identity);
        }
    }
}
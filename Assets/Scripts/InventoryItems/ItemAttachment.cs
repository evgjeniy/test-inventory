using InventoryItems.Items;
using UnityEngine;

namespace InventoryItems
{
    public class ItemAttachment : MonoBehaviour
    {
        private GameObject _gameObject;
        
        private void OnEnable() => Inventory.OnItemSelected += Attach;

        private void OnDisable() => Inventory.OnItemSelected -= Attach;

        private void Attach(Item item)
        {
            if (_gameObject != null) Destroy(_gameObject);
            if (item != null) _gameObject = Instantiate(item.PickupPrefab, transform);
        }
    }
}

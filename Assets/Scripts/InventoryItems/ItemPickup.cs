using InventoryItems.Items;
using UnityEngine;

namespace InventoryItems
{
    [RequireComponent(typeof(Collider))]
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private Item item;
        [SerializeField] private float rotationSpeed = 30.0f;
        
        private void Update() => transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Inventory>(out var inventory)) return;
            
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
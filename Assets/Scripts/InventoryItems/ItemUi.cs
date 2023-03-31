using InventoryItems.Items;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryItems
{
    public class ItemUi : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Text itemName;
        
        [SerializeField, Space(10)] private Sprite defaultIcon;
        
        private void OnEnable() => Inventory.OnItemSelected += UpdateView;
        
        private void OnDisable() => Inventory.OnItemSelected -= UpdateView;
        
        private void UpdateView(Item item)
        {
            if (item == null)
            {
                icon.sprite = defaultIcon;
                itemName.text = "Empty";
            }
            else
            {
                icon.sprite = item.UiIcon;
                itemName.text = item.Name;
            }
        }
    }
}
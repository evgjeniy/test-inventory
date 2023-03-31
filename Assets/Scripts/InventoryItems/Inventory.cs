using System;
using System.Collections.Generic;
using InventoryItems.Items;
using UnityEngine;

namespace InventoryItems
{
    public class Inventory : MonoBehaviour
    {
        private readonly List<Item> _items = new();
        private int _currentIndex;

        public static event Action<Item> OnItemSelected;

        public void AddItem(Item item)
        {
            _items.Add(item);
            SelectNext();
        }

        public void RemoveItem()
        {
            _items.Remove(GetCurrentItem());
            SelectPrev();
        }
        
        public void SelectNext()
        {
            if (++_currentIndex >= _items.Count) _currentIndex = 0;
            
            OnItemSelected?.Invoke(GetCurrentItem());
        }
        
        public void SelectPrev()
        {
            if (--_currentIndex < 0)
            {
                if (_items.Count == 0) _currentIndex = 0;
                else _currentIndex = _items.Count - 1;
            }
            
            OnItemSelected?.Invoke(GetCurrentItem());
        }

        public Item GetCurrentItem()
        {
            if (_currentIndex < 0 || _currentIndex >= _items.Count) return null;
            return _items[_currentIndex];
        }
    }
}
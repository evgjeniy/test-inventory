using InputHandlers;
using InventoryItems;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(IInputHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField, Min(0.0f)] private float speed = 5.0f;
        [SerializeField, Min(0.0f)] private float smoothSpeed = 20.0f;

        private IInputHandler _inputHandler;
        private Inventory _inventory;
        private ItemAttachment _attachment;

        private void Start()
        {
            _inputHandler = GetComponent<IInputHandler>();
            _inventory = GetComponent<Inventory>();
            _attachment = GetComponentInChildren<ItemAttachment>();
        }

        private void Update()
        {
            var direction = _inputHandler.GetMoveDirection();
            if (direction != Vector3.zero) Move(direction);
            
            if (_inventory == null) return;
            
            if (_inputHandler.IsSelectNextInventoryItem) _inventory.SelectNext();
            if (_inputHandler.IsSelectPrevInventoryItem) _inventory.SelectPrev();
            if (_inputHandler.IsUseInventoryItem) _inventory.GetCurrentItem()?.Use(_attachment);

            if (_inputHandler.IsRemoveInventoryItem)
            {
                _attachment.GetComponentInChildren<HandItem>()?.ThrowItem();
                _inventory.RemoveItem();
            }
        }

        private void Move(Vector3 direction)
        {
            transform.position += direction * (speed * Time.deltaTime);
            
            var targetRotation = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        }
    }
}
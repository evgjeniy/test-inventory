using UnityEngine;

namespace InputHandlers
{
    public class KeyboardInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] private KeyCode selectNextInventoryItem;
        [SerializeField] private KeyCode selectPrevInventoryItem;
        [SerializeField] private KeyCode useInventoryItem;
        [SerializeField] private KeyCode removeInventoryItem;

        private const string HorizontalAxisKey = "Horizontal";
        private const string VerticalAxisKey = "Vertical";
        
        public bool IsSelectNextInventoryItem => Input.GetKeyDown(selectNextInventoryItem);
        public bool IsSelectPrevInventoryItem => Input.GetKeyDown(selectPrevInventoryItem);
        public bool IsUseInventoryItem => Input.GetKeyDown(useInventoryItem);
        public bool IsRemoveInventoryItem => Input.GetKeyDown(removeInventoryItem);

        public Vector3 GetMoveDirection()
        {
            var horizontal = Input.GetAxis(HorizontalAxisKey);
            var vertical = Input.GetAxis(VerticalAxisKey);

            return new Vector3(horizontal, 0.0f, vertical).normalized;
        }
    }
}
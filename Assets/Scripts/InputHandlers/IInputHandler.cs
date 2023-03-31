using UnityEngine;

namespace InputHandlers
{
    public interface IInputHandler
    {
        bool IsSelectNextInventoryItem { get; }
        bool IsSelectPrevInventoryItem { get; }
        bool IsUseInventoryItem { get; }
        bool IsRemoveInventoryItem { get; }
        Vector3 GetMoveDirection();
    }
}
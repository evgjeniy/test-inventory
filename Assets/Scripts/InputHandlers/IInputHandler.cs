using UnityEngine;

namespace InputHandlers
{
    public interface IInputHandler
    {
        bool IsSelectNextInventoryItem { get; }
        bool IsSelectPrevInventoryItem { get; }
        bool IsUseInventoryItem { get; }
        Vector3 GetMoveDirection();
    }
}
using DG.Tweening;
using UnityEngine;

namespace InventoryItems.Items
{
    [CreateAssetMenu(menuName = "Items/Weapons/Bow", fileName = "Bow")]
    public class Bow : Weapon
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private float flyingDistance = 30.0f;
        [SerializeField] private float flyingTime = 0.5f;

        public override void Use(ItemAttachment attachment)
        {
            var attachmentTransform = attachment.transform;
            var arrow = Instantiate(arrowPrefab, attachmentTransform.position, 
                Quaternion.LookRotation(attachmentTransform.forward));

            arrow.transform.DOLocalMove(arrow.transform.forward * flyingDistance, flyingTime).OnUpdate(() =>
            {
                var center = arrow.transform.position;
                var forward = arrow.transform.forward;
                var colliders = Physics.OverlapCapsule(
                    center - forward * 0.7f, center + forward * 0.7f, 0.03f, attackMask);

                foreach (var collider in colliders)
                    collider.GetComponent<IDamageable>()?.TakeDamage(damage);
                
            }).SetEase(Ease.Linear).OnComplete(() => Destroy(arrow));
        }
    }
}
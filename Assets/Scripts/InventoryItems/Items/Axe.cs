using DG.Tweening;
using UnityEngine;

namespace InventoryItems.Items
{
    [CreateAssetMenu(menuName = "Items/Weapons/Axe", fileName = "Axe")]
    public class Axe : Weapon
    {
        private bool _canPlaySequence = true;

        public override void Use(ItemAttachment attachment)
        {
            if (_canPlaySequence) CreateSequence(attachment.transform).Play();
        }

        private Sequence CreateSequence(Transform parent)
        {
            var sequence = DOTween.Sequence();
            var startRotation = parent.localEulerAngles;

            sequence.Append(parent.DOLocalRotate(new Vector3(-30, 0, 0), 0.3f).SetEase(Ease.OutQuad))
                .Append(parent.DOLocalRotate(new Vector3(60, 0, 0), 0.1f).SetEase(Ease.InOutQuad))
                .Append(parent.DOLocalRotate(startRotation, 0.2f).SetEase(Ease.InOutQuad))
                .Insert(0, parent.DOLocalMove(new Vector3(0.5f, 1.0f, 1.0f),
                    sequence.Duration()).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutExpo));
            
            sequence.OnPlay(() => _canPlaySequence = false);
            sequence.OnComplete(() => _canPlaySequence = true);
            sequence.OnUpdate(() =>
            {
                var colliders = Physics.OverlapSphere(parent.position + parent.up * 1.5f, 0.25f, attackMask);

                foreach (var collider in colliders)
                    collider.GetComponent<IDamageable>()?.TakeDamage(damage);
            });

            return sequence;
        }
    }
}
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Moonkey.UI.Behaviour
{
    public class Move : UIBehaviour
    {
        [MinValue(-1), MaxValue(1), SerializeField] private Vector2 direction;
        [SerializeField] private float distance;

        [TabGroup("Show"), SerializeField] private Ease showEase = Ease.OutCubic;
        [TabGroup("Show"), SerializeField] private float showDuration = .5f;
        [TabGroup("Hide"), SerializeField] private Ease hideEase = Ease.OutCubic;
        [TabGroup("Hide"), SerializeField] private float hideDuration = .5f;

        public override void OnShow(UIView _view)
        {
            Vector2 finalPos = _view.OriginalPos + direction * distance;
            _view.Rt.DOAnchorPos(finalPos, showDuration).SetEase(showEase);
        }

        public override void OnHide(UIView _view)
        {
            Vector2 finalPos = _view.OriginalPos;
            _view.Rt.DOAnchorPos(finalPos, hideDuration).SetEase(hideEase);
        }

        public override void OnShowInstant(UIView _view)
        {
            Vector2 finalPos = _view.OriginalPos + direction * distance;
            _view.Rt.anchoredPosition = finalPos;
        }

        public override void OnHideInstant(UIView _view)
        {
            Vector2 finalPos = _view.OriginalPos;
            _view.Rt.anchoredPosition = finalPos;
        }
    }
}


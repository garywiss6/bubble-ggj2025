using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Moonkey.UI.Behaviour
{
    public class Scale : UIBehaviour
    {
        [SerializeField] private float scale;

        [TabGroup("Show"), SerializeField] private Ease showEase = Ease.OutCubic;
        [TabGroup("Show"), SerializeField] private float showDuration = .5f;
        [TabGroup("Hide"), SerializeField] private Ease hideEase = Ease.OutCubic;
        [TabGroup("Hide"), SerializeField] private float hideDuration = .5f;

        public override void OnShow(UIView _view)
        {
            _view.Rt.DOScale(scale, showDuration).SetEase(showEase);
        }

        public override void OnHide(UIView _view)
        {
            _view.Rt.DOScale(1, hideDuration).SetEase(hideEase);
        }

        public override void OnShowInstant(UIView _view)
        {
            _view.Rt.localScale = Vector3.one * scale;
        }

        public override void OnHideInstant(UIView _view)
        {
            _view.Rt.localScale = Vector3.one;
        }
    }
}

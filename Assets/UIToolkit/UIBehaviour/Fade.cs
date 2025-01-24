using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Moonkey.UI.Behaviour
{
    public class Fade : UIBehaviour
    {
        [SerializeField] private Vector2 alpha;
        [SerializeField] private bool blockRaycast;
        [SerializeField] private bool interactable;

        [TabGroup("Show"), SerializeField] private Ease showEase = Ease.OutCubic;
        [TabGroup("Show"), SerializeField] private float showDuration = .5f;
        [TabGroup("Hide"), SerializeField] private Ease hideEase = Ease.OutCubic;
        [TabGroup("Hide"), SerializeField] private float hideDuration = .5f;

        public override void OnShow(UIView _view)
        {
            DOTween.To(() => _view.Cg.alpha = 0, x => _view.Cg.alpha = x, alpha.y, showDuration).SetEase(showEase);
            _view.Cg.blocksRaycasts = blockRaycast;
            _view.Cg.interactable = interactable;
        }

        public override void OnHide(UIView _view)
        {
            DOTween.To(() => _view.Cg.alpha = _view.Cg.alpha, x => _view.Cg.alpha = x, alpha.x, hideDuration).SetEase(hideEase);
            _view.Cg.blocksRaycasts = false;
            _view.Cg.interactable = false;
        }

        public override void OnShowInstant(UIView _view)
        {
            _view.Cg.alpha = alpha.y;
            _view.Cg.blocksRaycasts = blockRaycast;
            _view.Cg.interactable = interactable;
        }

        public override void OnHideInstant(UIView _view)
        {
            _view.Cg.alpha = alpha.x;
            _view.Cg.blocksRaycasts = false;
            _view.Cg.interactable = false;
        }
    }
}

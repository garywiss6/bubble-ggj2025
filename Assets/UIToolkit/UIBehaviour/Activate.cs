namespace Moonkey.UI.Behaviour
{
    public class Activate : UIBehaviour
    {
        public override void OnShow(UIView _view)
        {
            _view.gameObject.SetActive(true);
        }

        public override void OnHide(UIView _view)
        {
            _view.gameObject.SetActive(false);
        }

        public override void OnShowInstant(UIView _view)
        {
            _view.gameObject.SetActive(true);
        }

        public override void OnHideInstant(UIView _view)
        {
            _view.gameObject.SetActive(false);
        }
    }
}

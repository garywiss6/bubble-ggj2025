using UnityEngine;

namespace Moonkey.UI
{
	public class UIViewManager : MonoBehaviour
	{
		[SerializeField] private UIView view;

		public virtual void Show()
		{
			view.Show();
		}

		public virtual void Hide()
		{
			view.Hide();
		}
		public virtual void ShowInstant()
		{
			view.ShowInstant();
		}

		public virtual void HideInstant()
		{
			view.HideInstant();
		}
	}
}
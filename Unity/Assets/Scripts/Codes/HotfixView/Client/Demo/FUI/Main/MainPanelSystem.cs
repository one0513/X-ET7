using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof(MainPanel))]
	public static class MainPanelSystem
	{
		public static void Awake(this MainPanel self)
		{
		}

		public static void RegisterUIEvent(this MainPanel self)
		{
			self.FUIMainPanel.btnTest.AddListner(() =>
			{
				LineHelp.ShowLine(self.FUIMainPanel.btnTest.xy,Vector2.zero);
			});
		}

		public static void OnShow(this MainPanel self, Entity contextData = null)
		{
		}

		public static void OnHide(this MainPanel self)
		{
		}

		public static void BeforeUnload(this MainPanel self)
		{
		}
	}
}
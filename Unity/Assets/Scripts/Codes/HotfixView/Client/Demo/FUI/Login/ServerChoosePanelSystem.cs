using ET.Client.Login;
using UnityEditor;

namespace ET.Client
{
	[FriendOf(typeof(ServerChoosePanel))]
	public static class ServerChoosePanelSystem
	{
		public static void Awake(this ServerChoosePanel self)
		{
			for (int i = 0; i < 10; i++)
			{
				var com = self.FUIServerChoosePanel.listLeft.AddItemFromPool();
				ServerLeftItem item = self.AddChild<ServerLeftItem, FUI_ServerLeftItem>(com as FUI_ServerLeftItem, true);
				ServerLeftItem_ContextData data = item.AddChild<ServerLeftItem_ContextData>();
				data.Data = i.ToString();
				item.InitInfo(data);
			}
		}

		public static void RegisterUIEvent(this ServerChoosePanel self)
		{
		}

		public static void OnShow(this ServerChoosePanel self, Entity contextData = null)
		{
			
			
		}

		public static void OnHide(this ServerChoosePanel self)
		{
		}

		public static void BeforeUnload(this ServerChoosePanel self)
		{
		}
	}
}
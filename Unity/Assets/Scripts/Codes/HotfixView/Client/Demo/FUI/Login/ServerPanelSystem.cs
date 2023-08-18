namespace ET.Client
{
	[FriendOf(typeof(ServerPanel))]
	public static class ServerPanelSystem
	{
		public static void Awake(this ServerPanel self)
		{
		}

		public static void RegisterUIEvent(this ServerPanel self)
		{
			self.FUIServerPanel.btnChange.AddListner(self.OnclickBtnChange);
			self.FUIServerPanel.btnBegin.AddListner(() =>
			{
				self.DomainScene().GetComponent<FUIComponent>().HideAndShowPanelStackAsync(PanelId.ServerPanel,PanelId.MainPanel).Coroutine();
			});
		}

		private static void OnclickBtnChange(this ServerPanel self)
		{
			self.DomainScene().GetComponent<FUIComponent>().ShowPanelAsync(PanelId.ServerChoosePanel,UIPanelType.PopUp).Coroutine();
		}
		public static void OnShow(this ServerPanel self, Entity contextData = null)
		{
		}

		public static void OnHide(this ServerPanel self)
		{
		}

		public static void BeforeUnload(this ServerPanel self)
		{
		}
	}
}
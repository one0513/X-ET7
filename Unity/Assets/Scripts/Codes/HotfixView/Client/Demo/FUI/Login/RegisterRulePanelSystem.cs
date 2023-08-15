namespace ET.Client
{
	[FriendOf(typeof(RegisterRulePanel))]
	public static class RegisterRulePanelSystem
	{
		public static void Awake(this RegisterRulePanel self)
		{
		}

		public static void RegisterUIEvent(this RegisterRulePanel self)
		{
			self.FUIRegisterRulePanel.CloseBtn.onClick.Add(() =>
			{
				self.DomainScene().GetComponent<FUIComponent>().HideSecondPanel(PanelId.RegisterRulePanel);
			});
		}

		public static void OnShow(this RegisterRulePanel self, Entity contextData = null)
		{
		}

		public static void OnHide(this RegisterRulePanel self)
		{
		}

		public static void BeforeUnload(this RegisterRulePanel self)
		{
		}
	}
}
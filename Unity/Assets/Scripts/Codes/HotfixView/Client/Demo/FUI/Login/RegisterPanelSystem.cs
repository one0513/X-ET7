namespace ET.Client
{
	[FriendOf(typeof(RegisterPanel))]
	public static class RegisterPanelSystem
	{
		public static void Awake(this RegisterPanel self)
		{
		}

		public static void RegisterUIEvent(this RegisterPanel self)
		{
			self.FUIRegisterPanel.CloseBtn.onClick.Add(() =>
			{
				self.DomainScene().GetComponent<FUIComponent>().HidePanel(PanelId.RegisterPanel);
			});
			
			self.FUIRegisterPanel.RuleBtn.onClick.Add(() =>
			{
				self.DomainScene().GetComponent<FUIComponent>().ShowSecondPanelAsync(PanelId.RegisterRulePanel).Coroutine();
			});
			
			self.FUIRegisterPanel.LoginBtn.onClick.Add(self.CheckPassWord);
		}

		public static void OnShow(this RegisterPanel self, Entity contextData = null)
		{
			self.ResetPassWord();
		}

		public static void OnHide(this RegisterPanel self)
		{
		}

		public static void BeforeUnload(this RegisterPanel self)
		{
		}

		private static void ResetPassWord(this RegisterPanel self)
		{
			self.FUIRegisterPanel.PasswordInput.Input.text = "";
			self.FUIRegisterPanel.ConfirmPasswordInput.Input.text = "";

		}
		
		private static void CheckPassWord(this RegisterPanel self)
		{
			if (self.FUIRegisterPanel.PasswordInput.Input.text != self.FUIRegisterPanel.ConfirmPasswordInput.Input.text)
			{
				self.ResetPassWord();
				TipsHelp.ShowTips("请输入相同的密码！");
			}
		}
	}
}
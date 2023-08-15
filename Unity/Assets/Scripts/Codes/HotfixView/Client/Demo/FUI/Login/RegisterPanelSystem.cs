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
			
			self.FUIRegisterPanel.LoginBtn.onClick.Add(() =>
			{
				self.CheckPassWord().Coroutine();
			});
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
		
		private static async ETTask CheckPassWord(this RegisterPanel self)
		{
			if (self.FUIRegisterPanel.PasswordInput.Input.text != self.FUIRegisterPanel.ConfirmPasswordInput.Input.text)
			{
				self.ResetPassWord();
				TipsHelp.ShowTips("请输入相同的密码！");
				return;
			}

			int erro = await LoginHelper.Login(self.DomainScene(), self.FUIRegisterPanel.AccountInput.Input.text, self.FUIRegisterPanel.PasswordInput.Input.text,true);
			switch (erro)
			{
				case ErrorCode.ERR_Success:
					TipsHelp.ShowTips("登入成功");
					self.DomainScene().GetComponent<FUIComponent>().HidePanel(PanelId.RegisterPanel);
					break;
				case ErrorCode.ERR_LoginInfoError:
					TipsHelp.ShowTips("账号或密码错误");
					break;
				case ErrorCode.ERR_AccountMessaFormatError:
					TipsHelp.ShowTips("请输入5-15位的账号密码");
					break;
				default:
					TipsHelp.ShowTips("网络错误"); break;
			}
		}
	}
}
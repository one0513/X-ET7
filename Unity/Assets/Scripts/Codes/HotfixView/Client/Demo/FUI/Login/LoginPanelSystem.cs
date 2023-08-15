using System;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
	public static class LoginPanelSystem
	{
		public static void Awake(this LoginPanel self)
		{

		}

		public static void RegisterUIEvent(this LoginPanel self)
		{
			self.FUILoginPanel.LoginBtn.AddListnerAsync(self.Login);
			
			self.FUILoginPanel.register.onClick.Add(self.OnClickRegister);
		}

		public static void OnShow(this LoginPanel self, Entity contextData = null)
		{
			var context = (LoginPanel_ContextData)contextData;
			Log.Info(context.Data);


		}

		public static void OnHide(this LoginPanel self)
		{

		}

		public static void BeforeUnload(this LoginPanel self)
		{

		}

		private static void OnClickRegister(this LoginPanel self)
		{
			self.DomainScene().GetComponent<FUIComponent>().ShowPanelAsync(PanelId.RegisterPanel,UIPanelType.PopUp).Coroutine();
		}
		private static async ETTask Login(this LoginPanel self)
		{
			int erro = await LoginHelper.Login(self.DomainScene(), self.FUILoginPanel.AccountInput.Input.text, self.FUILoginPanel.PasswordInput.Input.text);
			switch (erro)
			{
				case ErrorCode.ERR_Success:
					TipsHelp.ShowTips("登入成功");
					break;
				case ErrorCode.ERR_LoginInfoError:
					TipsHelp.ShowTips("账号或密码错误");
					break;
				case ErrorCode.ERR_AccountNotExist:
					TipsHelp.ShowTips("账号不存在");
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
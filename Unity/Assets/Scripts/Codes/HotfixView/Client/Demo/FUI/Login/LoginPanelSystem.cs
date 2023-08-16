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
			self.FUILoginPanel.btnSure.AddListnerAsync(self.Login);
			
			self.FUILoginPanel.btnRe.AddListner(self.OnClickRegister);
			
			self.FUILoginPanel.cbPW.onChanged.Add(()=> {
				//记住密码取消勾选时 强行取消勾选自动登录
				if (!self.FUILoginPanel.cbPW.selected)
				{
					self.FUILoginPanel.cbAuto.selected = false;
					PlayerPrefs.SetInt("IsSavePW",0);
				}
				else
				{
					PlayerPrefs.SetInt("IsSavePW",1);
				}
					
				
				
			});
		}

		public static void OnShow(this LoginPanel self, Entity contextData = null)
		{
			self.FUILoginPanel.inputAN.text = PlayerPrefs.GetString("Account", "");
			var context = (LoginPanel_ContextData)contextData;
			if (PlayerPrefs.GetInt("IsSavePW",0) != 0)
			{
				self.FUILoginPanel.cbPW.selected = true;
				self.FUILoginPanel.inputPW.text = PlayerPrefs.GetString("PassWord","");
			}
			
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
			PlayerPrefs.SetString("Account", self.FUILoginPanel.inputAN.text);
			int erro = await LoginHelper.Login(self.DomainScene(), self.FUILoginPanel.inputAN.text, self.FUILoginPanel.inputPW.text);
			switch (erro)
			{
				case ErrorCode.ERR_Success:
					TipsHelp.ShowTips("登入成功");
					if (PlayerPrefs.GetInt("IsSavePW",0) != 0)
					{
						PlayerPrefs.SetString("PassWord",self.FUILoginPanel.inputPW.text);
					}
					
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

namespace ET.Client
{
	public static class TestBPanelSystem
	{
		public static void Awake(this TestBPanel self)
		{
			self.Com1 = self.AddChild<OneComponent, ET.Client.TestB.FUI_OneComponent>(self.FUITestBPanel.Com1, true);
			self.Com2 = self.AddChild<TwoComponent, ET.Client.Common.FUI_TwoComponent>(self.FUITestBPanel.Com2, true);
		}

		public static void RegisterUIEvent(this TestBPanel self)
		{
			self.FUITestBPanel.OpenTestCBtn.AddListner(() =>
			{
				TipsHelp.ShowTips(RandomGenerator.RandInt64().ToString());
				
				// var fuiCom = self.ClientScene().GetComponent<FUIComponent>();
				//
				// TestCPanel_ContextData testCPanelContextData = fuiCom.AddChild<TestCPanel_ContextData>();
				// TestBPanel_ContextData testBPanelContextData = (TestBPanel_ContextData)self.GetParent<FUIEntity>().ContextData;
				// testCPanelContextData.Data = testBPanelContextData.Data;
				//
				// fuiCom.HideAndShowPanelStackAsync(PanelId.TestBPanel, PanelId.TestCPanel, testCPanelContextData).Coroutine();
			});
			
			self.FUITestBPanel.CloseBtn.AddListner(() =>
			{
				self.ClientScene().GetComponent<FUIComponent>().HidePanel(PanelId.TestBPanel);
			});
			
			self.Com1.RegisterUIEvent();
			self.Com2.RegisterUIEvent();
		}

		public static void OnShow(this TestBPanel self, Entity contextData = null)
		{
			if (contextData != null)
			{
				TestBPanel_ContextData data = contextData as TestBPanel_ContextData;
				Log.Info(data.Data);
			}
			else
			{
				Log.Info("contextData is null");
			}
			
			self.Com1.OnShow();
			self.Com2.OnShow();
		}

		public static void OnHide(this TestBPanel self)
		{
			self.Com1.OnHide();
			self.Com2.OnHide();
		}

		public static void BeforeUnload(this TestBPanel self)
		{
			self.Com1.BeforeUnload();
			self.Com2.BeforeUnload();
		}
	}
}
using FairyGUI;
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
			self.FUIMainPanel.btnTest.onTouchBegin.Add((eventData) =>
			{
				eventData.CaptureTouch();
				Vector2 nowPos = GRoot.inst.GlobalToLocal(new Vector2(eventData.inputEvent.x, eventData.inputEvent.y));
				LineHelp.ShowLine(nowPos,Vector2.zero);
			});
			
			self.FUIMainPanel.btnTest.onTouchMove.Add((eventData) =>
			{
				Vector2 nowPos = GRoot.inst.GlobalToLocal(new Vector2(eventData.inputEvent.x, eventData.inputEvent.y));
				LineHelp.ShowLine(Vector2.zero,nowPos);
			});
			
			self.FUIMainPanel.btnTest.onRollOver.Add(() =>
			{
				self.FUIMainPanel.btnTest.scale = new Vector2(2, 2);
			});
			
			self.FUIMainPanel.btnTest.onRollOut.Add(() =>
			{
				self.FUIMainPanel.btnTest.scale = new Vector2(1, 1);
			});
			
			self.FUIMainPanel.btnTest.onTouchEnd.Add(LineHelp.HideLine);
			
			self.FUIMainPanel.btnTest.AddListner(() =>
			{
				//LineHelp.HideLine();
				//LineHelp.ShowLine(self.FUIMainPanel.btnTest.xy,Vector2.zero);
			});
		}

		public static void OnShow(this MainPanel self, Entity contextData = null)
		{
			self.FUIMainPanel.btnTest.title = "测试";
		}

		public static void OnHide(this MainPanel self)
		{
		}

		public static void BeforeUnload(this MainPanel self)
		{
		}
	}
}
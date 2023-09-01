using ET.Client.Main;
using FairyGUI;
using Spine.Unity;
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

				if (Stage.isTouchOnUI && GRoot.inst.touchTarget.name == "Player")
				{
				}
			});
			
			
			self.FUIMainPanel.btnTest.onTouchEnd.Add(LineHelp.HideLine);
			
			self.FUIMainPanel.btnTest.AddListner(() =>
			{
				//LineHelp.HideLine();
				//LineHelp.ShowLine(self.FUIMainPanel.btnTest.xy,Vector2.zero);
			});
			
			self.FUIMainPanel.MoveBg.onTouchMove.Add(() =>
			{
				self.FUIMainPanel.Player.player.displayObject.gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "run";
			});
			self.FUIMainPanel.MoveBg.onTouchEnd.Add(() =>
			{
				self.FUIMainPanel.Player.player.displayObject.gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "idle_1";
			});
			self.FUIMainPanel.Player.onRollOver.Add(() =>
			{
				self.FUIMainPanel.Player.player.displayObject.gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "sword_attack";
				self.FUIMainPanel.Player.onSelect.selectedIndex = (int)FUI_Player.onSelectPage.on;
				
			} );
			self.FUIMainPanel.Player.onRollOut.Add(() =>
			{
				self.FUIMainPanel.Player.player.displayObject.gameObject.GetComponentInChildren<SkeletonAnimation>().AnimationName = "idle_1";
				self.FUIMainPanel.Player.onSelect.selectedPage = "off";
			} );
		}

		public static void OnShow(this MainPanel self, Entity contextData = null)
		{
			self.FUIMainPanel.btnTest.title = "测试";
			GameObject prefab = ResComponent.Instance.LoadAsset<GameObject>("Knight");
			GameObject go = UnityEngine.Object.Instantiate(prefab);

			go.transform.position = Vector3.zero;
			self.FUIMainPanel.Player.player.SetNativeObject(new GoWrapper(go));
			var _catBoatSpine = self.FUIMainPanel.Player.displayObject.gameObject.GetComponentInChildren<SkeletonAnimation>();
			_catBoatSpine.loop = true;
			_catBoatSpine.AnimationName = "idle_1";
			self.FUIMainPanel.Player.onSelect.selectedPage = "off";
		}

		public static void OnHide(this MainPanel self)
		{
		}

		public static void BeforeUnload(this MainPanel self)
		{
		}
	}
}
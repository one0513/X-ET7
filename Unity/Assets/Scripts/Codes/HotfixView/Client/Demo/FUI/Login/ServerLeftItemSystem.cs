using ET.Client.Login;

namespace ET.Client
{
	public class ServerLeftItemAwakeSystem : AwakeSystem<ServerLeftItem, FUI_ServerLeftItem>
	{
		protected override void Awake(ServerLeftItem self, FUI_ServerLeftItem fuiServerLeftItem)
		{
			self.Awake(fuiServerLeftItem);
		}
	}

	[FriendOf(typeof(ServerLeftItem))]
	public static class ServerLeftItemSystem
	{
		public static void Awake(this ServerLeftItem self, FUI_ServerLeftItem fuiServerLeftItem)
		{
			self.FUIServerLeftItem = fuiServerLeftItem;
		}

		public static void RegisterUIEvent(this ServerLeftItem self)
		{

		}

		public static void OnShow(this ServerLeftItem self, Entity contextData = null)
		{
		}

		public static void OnHide(this ServerLeftItem self)
		{
		}

		public static void BeforeUnload(this ServerLeftItem self)
		{
		}
		
		
		public static void InitInfo(this ServerLeftItem self,ServerLeftItem_ContextData data)
		{
			self.FUIServerLeftItem.title = data.Data;
		}
	}
}
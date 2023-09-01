using ET.Client.Login;

namespace ET.Client
{
	[ChildOf]
	public class ServerLeftItem: Entity, IAwake<FUI_ServerLeftItem>
	{
		public FUI_ServerLeftItem FUIServerLeftItem { get; set; }
		

	}
	
	[ChildOf]
	public class ServerLeftItem_ContextData: Entity, IAwake
	{
		/// <summary>
		/// 测试数据
		/// </summary>
		public string Data { get; set; }
	}
}

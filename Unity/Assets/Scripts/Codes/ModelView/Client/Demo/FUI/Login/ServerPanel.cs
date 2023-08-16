using ET.Client.Login;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class ServerPanel: Entity, IAwake
	{
		private FUI_ServerPanel _fuiServerPanel;

		public FUI_ServerPanel FUIServerPanel
		{
			get => _fuiServerPanel ??= (FUI_ServerPanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}

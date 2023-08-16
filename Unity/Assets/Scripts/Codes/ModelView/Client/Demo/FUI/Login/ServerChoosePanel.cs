using ET.Client.Login;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class ServerChoosePanel: Entity, IAwake
	{
		private FUI_ServerChoosePanel _fuiServerChoosePanel;

		public FUI_ServerChoosePanel FUIServerChoosePanel
		{
			get => _fuiServerChoosePanel ??= (FUI_ServerChoosePanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}

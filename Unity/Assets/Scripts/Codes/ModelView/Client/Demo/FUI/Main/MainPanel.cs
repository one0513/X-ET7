using ET.Client.Main;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class MainPanel: Entity, IAwake
	{
		private FUI_MainPanel _fuiMainPanel;

		public FUI_MainPanel FUIMainPanel
		{
			get => _fuiMainPanel ??= (FUI_MainPanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}

using ET.Client.Login;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class RegisterPanel: Entity, IAwake
	{
		private FUI_RegisterPanel _fuiRegisterPanel;

		public FUI_RegisterPanel FUIRegisterPanel
		{
			get => _fuiRegisterPanel ??= (FUI_RegisterPanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}

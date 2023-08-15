using ET.Client.Login;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class RegisterRulePanel: Entity, IAwake
	{
		private FUI_RegisterRulePanel _fuiRegisterRulePanel;

		public FUI_RegisterRulePanel FUIRegisterRulePanel
		{
			get => _fuiRegisterRulePanel ??= (FUI_RegisterRulePanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}

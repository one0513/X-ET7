/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_RegisterRulePanel: GComponent
	{
		public ET.Client.Common.FUI_CloseBtn CloseBtn;
		public const string URL = "ui://rgfb0w49fyg94";

		public static FUI_RegisterRulePanel CreateInstance()
		{
			return (FUI_RegisterRulePanel)UIPackage.CreateObject("Login", "RegisterRulePanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			CloseBtn = (ET.Client.Common.FUI_CloseBtn)GetChildAt(1);
		}
	}
}

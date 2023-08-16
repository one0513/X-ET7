/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_RegisterPanel: GComponent
	{
		public Transition show;
		public Transition hide;
		public GTextInput inputAN;
		public GTextInput inputPW;
		public GTextInput inputAgainPW;
		public ET.Client.Common.FUI_NormalBtn btnClose;
		public ET.Client.Common.FUI_NormalBtn btnSure;
		public const string URL = "ui://rgfb0w49p7d2d";

		public static FUI_RegisterPanel CreateInstance()
		{
			return (FUI_RegisterPanel)UIPackage.CreateObject("Login", "RegisterPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			show = GetTransitionAt(0);
			hide = GetTransitionAt(1);
			inputAN = (GTextInput)GetChildAt(8);
			inputPW = (GTextInput)GetChildAt(9);
			inputAgainPW = (GTextInput)GetChildAt(10);
			btnClose = (ET.Client.Common.FUI_NormalBtn)GetChildAt(12);
			btnSure = (ET.Client.Common.FUI_NormalBtn)GetChildAt(13);
		}
	}
}

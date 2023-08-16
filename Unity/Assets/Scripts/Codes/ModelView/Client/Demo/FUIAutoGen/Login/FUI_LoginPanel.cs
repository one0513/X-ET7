/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_LoginPanel: GComponent
	{
		public Transition show;
		public Transition hide;
		public Transition t2;
		public GButton cbPW;
		public GButton cbAuto;
		public ET.Client.Common.FUI_NormalBtn btnRe;
		public ET.Client.Common.FUI_NormalBtn btnSure;
		public GTextInput inputAN;
		public GTextInput inputPW;
		public const string URL = "ui://rgfb0w49p7d24";

		public static FUI_LoginPanel CreateInstance()
		{
			return (FUI_LoginPanel)UIPackage.CreateObject("Login", "LoginPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			show = GetTransitionAt(0);
			hide = GetTransitionAt(1);
			t2 = GetTransitionAt(2);
			cbPW = (GButton)GetChildAt(3);
			cbAuto = (GButton)GetChildAt(4);
			btnRe = (ET.Client.Common.FUI_NormalBtn)GetChildAt(5);
			btnSure = (ET.Client.Common.FUI_NormalBtn)GetChildAt(6);
			inputAN = (GTextInput)GetChildAt(9);
			inputPW = (GTextInput)GetChildAt(10);
		}
	}
}

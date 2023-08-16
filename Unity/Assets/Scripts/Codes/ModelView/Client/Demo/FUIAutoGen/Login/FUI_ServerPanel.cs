/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_ServerPanel: GComponent
	{
		public Transition show;
		public Transition hide;
		public ET.Client.Common.FUI_NormalBtn2 btnBegin;
		public ET.Client.Common.FUI_NormalBtn2 btnChange;
		public GTextField txtName;
		public const string URL = "ui://rgfb0w49p7d2u";

		public static FUI_ServerPanel CreateInstance()
		{
			return (FUI_ServerPanel)UIPackage.CreateObject("Login", "ServerPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			show = GetTransitionAt(0);
			hide = GetTransitionAt(1);
			btnBegin = (ET.Client.Common.FUI_NormalBtn2)GetChildAt(2);
			btnChange = (ET.Client.Common.FUI_NormalBtn2)GetChildAt(3);
			txtName = (GTextField)GetChildAt(4);
		}
	}
}

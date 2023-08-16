/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_ServerChoosePanel: GComponent
	{
		public Transition show;
		public Transition hide;
		public GList listLeft;
		public GTextField txtName;
		public GLoader imgState;
		public GTextField txtRange;
		public GList listRight;
		public const string URL = "ui://rgfb0w49p7d2g";

		public static FUI_ServerChoosePanel CreateInstance()
		{
			return (FUI_ServerChoosePanel)UIPackage.CreateObject("Login", "ServerChoosePanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			show = GetTransitionAt(0);
			hide = GetTransitionAt(1);
			listLeft = (GList)GetChildAt(0);
			txtName = (GTextField)GetChildAt(7);
			imgState = (GLoader)GetChildAt(8);
			txtRange = (GTextField)GetChildAt(9);
			listRight = (GList)GetChildAt(11);
		}
	}
}

/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_ServerLeftItem: GButton
	{
		public GImage imgBK;
		public const string URL = "ui://rgfb0w49p7d2o";

		public static FUI_ServerLeftItem CreateInstance()
		{
			return (FUI_ServerLeftItem)UIPackage.CreateObject("Login", "ServerLeftItem");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			imgBK = (GImage)GetChildAt(0);
		}
	}
}

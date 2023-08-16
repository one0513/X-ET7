/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_MainPanel: GComponent
	{
		public ET.Client.Main.FUI_MainMoveBg MoveBg;
		public const string URL = "ui://9dh52fkao4sh5";

		public static FUI_MainPanel CreateInstance()
		{
			return (FUI_MainPanel)UIPackage.CreateObject("Main", "MainPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			MoveBg = (ET.Client.Main.FUI_MainMoveBg)GetChildAt(0);
		}
	}
}

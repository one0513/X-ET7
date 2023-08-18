/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_MainPanel: GComponent
	{
		public ET.Client.Main.FUI_MainMoveBg MoveBg;
		public ET.Client.Common.FUI_NormalBtn btnTest;
		public GGraph Player;
		public const string URL = "ui://9dh52fkao4sh5";

		public static FUI_MainPanel CreateInstance()
		{
			return (FUI_MainPanel)UIPackage.CreateObject("Main", "MainPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			MoveBg = (ET.Client.Main.FUI_MainMoveBg)GetChildAt(0);
			btnTest = (ET.Client.Common.FUI_NormalBtn)GetChildAt(2);
			Player = (GGraph)GetChildAt(3);
		}
	}
}

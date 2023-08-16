/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_MainMoveBg: GComponent
	{
		public GImage Bg;
		public const string URL = "ui://9dh52fkao4sh7";

		public static FUI_MainMoveBg CreateInstance()
		{
			return (FUI_MainMoveBg)UIPackage.CreateObject("Main", "MainMoveBg");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Bg = (GImage)GetChildAt(0);
		}
	}
}

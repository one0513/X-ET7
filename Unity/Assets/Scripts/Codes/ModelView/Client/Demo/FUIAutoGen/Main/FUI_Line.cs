/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_Line: GComponent
	{
		public GImage start;
		public GImage p1;
		public GImage p2;
		public GImage p3;
		public GImage p4;
		public GImage p5;
		public GImage end;
		public const string URL = "ui://9dh52fkap7d28";

		public static FUI_Line CreateInstance()
		{
			return (FUI_Line)UIPackage.CreateObject("Main", "Line");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			start = (GImage)GetChildAt(0);
			p1 = (GImage)GetChildAt(1);
			p2 = (GImage)GetChildAt(2);
			p3 = (GImage)GetChildAt(3);
			p4 = (GImage)GetChildAt(4);
			p5 = (GImage)GetChildAt(5);
			end = (GImage)GetChildAt(6);
		}
	}
}

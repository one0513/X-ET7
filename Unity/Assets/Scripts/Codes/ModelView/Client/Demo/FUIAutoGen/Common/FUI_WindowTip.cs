/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Common
{
	public partial class FUI_WindowTip: GComponent
	{
		public GRichTextField txtInfo;
		public ET.Client.Common.FUI_NormalBtn closeButton;
		public GGraph dragArea;
		public GGraph contentArea;
		public const string URL = "ui://f2boiu4ip7d2z";

		public static FUI_WindowTip CreateInstance()
		{
			return (FUI_WindowTip)UIPackage.CreateObject("Common", "WindowTip");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txtInfo = (GRichTextField)GetChildAt(3);
			closeButton = (ET.Client.Common.FUI_NormalBtn)GetChildAt(4);
			dragArea = (GGraph)GetChildAt(5);
			contentArea = (GGraph)GetChildAt(6);
		}
	}
}

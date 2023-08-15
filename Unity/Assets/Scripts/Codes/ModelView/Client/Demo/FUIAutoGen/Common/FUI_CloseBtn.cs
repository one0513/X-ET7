/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Common
{
	public partial class FUI_CloseBtn: GButton
	{
		public GLoader image;
		public const string URL = "ui://f2boiu4iue3912";

		public static FUI_CloseBtn CreateInstance()
		{
			return (FUI_CloseBtn)UIPackage.CreateObject("Common", "CloseBtn");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			image = (GLoader)GetChildAt(0);
		}
	}
}

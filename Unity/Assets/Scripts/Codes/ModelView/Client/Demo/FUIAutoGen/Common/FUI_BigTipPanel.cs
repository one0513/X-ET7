/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Common
{
	public partial class FUI_BigTipPanel: GComponent
	{
		public GTextField msg;
		public const string URL = "ui://f2boiu4igu5kw";

		public static FUI_BigTipPanel CreateInstance()
		{
			return (FUI_BigTipPanel)UIPackage.CreateObject("Common", "BigTipPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			msg = (GTextField)GetChildAt(1);
		}
	}
}

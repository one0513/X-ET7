/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.TestB
{
	public partial class FUI_TestDPanel: GComponent
	{
		public GLoader Loader1;
		public const string URL = "ui://296l7tjhucoh4";

		public static FUI_TestDPanel CreateInstance()
		{
			return (FUI_TestDPanel)UIPackage.CreateObject("TestB", "TestDPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Loader1 = (GLoader)GetChildAt(3);
		}
	}
}

/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Common
{
	public partial class FUI_InputField3: GComponent
	{
		public GTextInput Input;
		public const string URL = "ui://f2boiu4iue3911";

		public static FUI_InputField3 CreateInstance()
		{
			return (FUI_InputField3)UIPackage.CreateObject("Common", "InputField3");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Input = (GTextInput)GetChildAt(1);
		}
	}
}

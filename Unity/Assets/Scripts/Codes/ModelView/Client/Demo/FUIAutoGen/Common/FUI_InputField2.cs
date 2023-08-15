/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Common
{
	public partial class FUI_InputField2: GComponent
	{
		public GTextInput Input;
		public const string URL = "ui://f2boiu4iue3910";

		public static FUI_InputField2 CreateInstance()
		{
			return (FUI_InputField2)UIPackage.CreateObject("Common", "InputField2");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Input = (GTextInput)GetChildAt(1);
		}
	}
}

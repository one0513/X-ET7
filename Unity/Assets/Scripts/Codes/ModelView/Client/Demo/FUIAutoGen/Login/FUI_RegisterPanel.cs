/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_RegisterPanel: GComponent
	{
		public ET.Client.Common.FUI_InputField1 AccountInput;
		public ET.Client.Common.FUI_InputField2 PasswordInput;
		public ET.Client.Common.FUI_InputField3 ConfirmPasswordInput;
		public ET.Client.Common.FUI_CommonBtn LoginBtn;
		public ET.Client.Common.FUI_CloseBtn CloseBtn;
		public ET.Client.Common.FUI_CommonBtn RuleBtn;
		public const string URL = "ui://rgfb0w49ue393";

		public static FUI_RegisterPanel CreateInstance()
		{
			return (FUI_RegisterPanel)UIPackage.CreateObject("Login", "RegisterPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			AccountInput = (ET.Client.Common.FUI_InputField1)GetChildAt(1);
			PasswordInput = (ET.Client.Common.FUI_InputField2)GetChildAt(2);
			ConfirmPasswordInput = (ET.Client.Common.FUI_InputField3)GetChildAt(3);
			LoginBtn = (ET.Client.Common.FUI_CommonBtn)GetChildAt(4);
			CloseBtn = (ET.Client.Common.FUI_CloseBtn)GetChildAt(5);
			RuleBtn = (ET.Client.Common.FUI_CommonBtn)GetChildAt(6);
		}
	}
}

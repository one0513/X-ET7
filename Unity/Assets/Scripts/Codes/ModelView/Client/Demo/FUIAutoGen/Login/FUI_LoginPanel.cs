/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
	public partial class FUI_LoginPanel: GComponent
	{
		public ET.Client.Common.FUI_InputField1 AccountInput;
		public ET.Client.Common.FUI_InputField2 PasswordInput;
		public ET.Client.Common.FUI_CommonBtn LoginBtn;
		public ET.Client.Common.FUI_CommonBtn register ;
		public const string URL = "ui://rgfb0w498omm0";

		public static FUI_LoginPanel CreateInstance()
		{
			return (FUI_LoginPanel)UIPackage.CreateObject("Login", "LoginPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			AccountInput = (ET.Client.Common.FUI_InputField1)GetChildAt(1);
			PasswordInput = (ET.Client.Common.FUI_InputField2)GetChildAt(2);
			LoginBtn = (ET.Client.Common.FUI_CommonBtn)GetChildAt(3);
			register  = (ET.Client.Common.FUI_CommonBtn)GetChildAt(4);
		}
	}
}

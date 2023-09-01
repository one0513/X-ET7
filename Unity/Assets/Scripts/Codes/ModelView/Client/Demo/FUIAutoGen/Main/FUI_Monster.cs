/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_Monster: GComponent
	{
		public enum onSelectPage
		{
			on,
			off,
		}

		public Controller onSelect;
		public GGraph monster;
		public const string URL = "ui://9dh52fkap7d2i";

		public static FUI_Monster CreateInstance()
		{
			return (FUI_Monster)UIPackage.CreateObject("Main", "Monster");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			onSelect = GetControllerAt(0);
			monster = (GGraph)GetChildAt(0);
		}
	}
}

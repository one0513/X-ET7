/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
	public partial class FUI_Player: GComponent
	{
		public enum onSelectPage
		{
			on,
			off,
		}

		public Controller onSelect;
		public GGraph player;
		public const string URL = "ui://9dh52fkap7d2b";

		public static FUI_Player CreateInstance()
		{
			return (FUI_Player)UIPackage.CreateObject("Main", "Player");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			onSelect = GetControllerAt(0);
			player = (GGraph)GetChildAt(0);
		}
	}
}

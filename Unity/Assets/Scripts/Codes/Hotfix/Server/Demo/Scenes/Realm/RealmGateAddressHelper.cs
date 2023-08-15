using System.Collections.Generic;


namespace ET.Server
{
	public static class RealmGateAddressHelper
	{
		public static StartSceneConfig GetGate(int zone,string account)
		{
			List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];

			int n = account.GetHashCode() % zoneGates.Count;

			return zoneGates[n];
		}

		public static StartSceneConfig GetRealm(int zone)
		{
			StartSceneConfig zoneRealm = StartSceneConfigCategory.Instance.Realms[zone];
			return zoneRealm;
		}
	}
}

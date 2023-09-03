
using System.Collections.Generic;
using ET.Client;
using ET.EventType;
using UnityEngine;

namespace ET
{
    [Event(SceneType.Current)]
    [FriendOf(typeof(CombatUnitComponent))]
    public class AfterCombatUnitComponentCreate_Init:AEvent<Scene,EventType.AfterCombatUnitComponentCreate>
    {

        protected override async ETTask Run(Scene scene, AfterCombatUnitComponentCreate args)
        {
            var self = args.CombatUnitComponent;

        }
    }
}
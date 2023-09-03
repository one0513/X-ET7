using ET.EventType;
using UnityEngine;

namespace ET
{
    [Event(SceneType.Current)]
    public class ChangePosition_MoveAOIUnit: AEvent<Scene,EventType.ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition a)
        {
            EventType.ChangePosition args = a;
            AOIUnitComponent aoiUnitComponent = args.Unit.GetComponent<AOIUnitComponent>();
            if (aoiUnitComponent == null || aoiUnitComponent.IsDisposed) return;
            aoiUnitComponent.Move(args.Unit.Position).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
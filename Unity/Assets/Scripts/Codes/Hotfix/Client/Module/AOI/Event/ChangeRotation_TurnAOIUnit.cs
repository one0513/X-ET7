using ET.EventType;
using UnityEngine;

namespace ET
{
    [Event(SceneType.Current)]
    public class ChangeRotation_TurnAOIUnit: AEvent<Scene,EventType.ChangeRotation>
    {
        protected override async ETTask Run(Scene scene, ChangeRotation a)
        {
            EventType.ChangePosition args; 
            args.Unit = a.Unit;
            
            AOIUnitComponent aoiUnitComponent = args.Unit?.GetComponent<AOIUnitComponent>();
            if (aoiUnitComponent == null || aoiUnitComponent.IsDisposed) return;
            aoiUnitComponent.Turn(args.Unit.Rotation);
            await ETTask.CompletedTask;
        }
    }
}
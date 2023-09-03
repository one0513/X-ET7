using ET.EventType;

namespace ET
{
    [Event(SceneType.Current)]
    public class ChangePosition_NotifyMoveBuffWatcher: AEvent<Scene,EventType.ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition a)
        {
            EventType.ChangePosition args = a;//as EventType.ChangePosition;
            BuffComponent bc = args.Unit.GetComponent<CombatUnitComponent>()?.GetComponent<BuffComponent>();
            if (bc != null)
            {
                bc.AfterMove(args.Unit,args.OldPos);
            }

            await ETTask.CompletedTask;
        }
    }
}
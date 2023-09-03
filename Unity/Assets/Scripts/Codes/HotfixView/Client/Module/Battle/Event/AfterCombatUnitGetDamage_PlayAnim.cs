using ET.Client;
using ET.EventType;

namespace ET
{
    [Event(SceneType.Current)]
    [FriendOf(typeof(CombatUnitComponent))]
    public class AfterCombatUnitGetDamage_PlayAnim:AEvent<Scene,EventType.AfterCombatUnitGetDamage>
    {
        protected override async ETTask Run(Scene scene, AfterCombatUnitGetDamage args)
        {
            var anim = args.Unit.unit.GetComponent<AnimatorComponent>();
            if (anim != null)
            {
                if(args.Unit.unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp)<=0)
                {
                    anim.Play(MotionType.Died);
                }
                else
                    anim.Play(MotionType.Damage);
            }
            else if(args.Unit.unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp)<=0)//直接死了
            {
                args.Unit.unit.Dispose();
            }

            await ETTask.CompletedTask;
        }
    }
}
﻿#if !NOT_UNITY
namespace ET
{
    /// <summary>
    /// 添加特效(aoi创建Unit之前放的技能没添加的就算了，临时特效走这里，常驻还是走buff)
    /// </summary>
    [SkillWatcher(SkillStepType.AddEffect)]
    [FriendOf(typeof(SkillAbility))]
    public class SkillWatcher_AddEffect : ISkillWatcher
    {
        public void Run(SkillPara para)
        {
            if (para.GetCurSkillStepPara().Paras.Length != 1)
            {
                Log.Error(para.SkillConfigId+"添加特效参数数量不对"+para.GetCurSkillStepPara().Paras.Length);
                return;
            }
            var unit = para.From.unit;
            var stepPara = para.GetCurSkillStepPara();
            Log.Info("SkillWatcher_AddEffect");
            if (StepParaHelper.TryParseInt(ref stepPara.Paras[0], out var effectId))
            {
                EventSystem.Instance.Publish(para.DomainScene(),new EventType.AddEffect { EffectId = effectId, Parent = unit, Unit = unit });
            }
        }
        
    }
}
#endif
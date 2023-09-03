namespace ET
{
    [UniqueId(100, 10000)]
    public static class TimerInvokeType
    {
        // 框架层100-200，逻辑层的timer type从200起
        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int ActorLocationSenderChecker = 102;
        public const int ActorMessageSenderChecker = 103;
        
        // 框架层100-200，逻辑层的timer type 200-300
        public const int MoveTimer = 201;
        public const int AITimer = 202;
        public const int SessionAcceptTimeout = 203;
        public const int SkillColliderRemove = 204;//销毁技能判定体
        public const int PlayNextSkillStep = 205;//技能步骤
        public const int RemoveBuff = 206;//移除Buff
        public const int MoveAndSpellSkill = 207;//从施法范围外移动到最远施法位置施法
        public const int GenerateSkillCollider = 208;//延时生成触发器
        public const int DestroyGameObject = 209;//移除GameObject
    }
}
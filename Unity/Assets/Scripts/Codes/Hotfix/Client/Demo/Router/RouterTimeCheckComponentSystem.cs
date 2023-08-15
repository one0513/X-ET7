namespace ET.Client
{
    [ObjectSystem]
    public class RouterTimeCheckComponentSystem: AwakeSystem< RouterTimeCheckComponent>
    {
        protected override void Awake(RouterTimeCheckComponent self)
        {
            CheckAsync(self).Coroutine();
        }
    
        private static async ETTask CheckAsync(RouterTimeCheckComponent self)
        {
            Session session = self.GetParent<Session>();
            await TimerComponent.Instance.WaitAsync(30000);
            session?.Dispose();
            Log.Debug("Reaml session 超时断开 ！！");
        }
     
    }    
}


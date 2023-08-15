namespace ET.Client
{
	[ComponentOf(typeof(Scene))]
	public class SessionComponent: Entity, IAwake, IDestroy
	{
		private EntityRef<Session> session;

		public Session Session
		{
			get
			{
				return session;
			}
			set
			{
				this.session = value;
			}
		}
		
		private EntityRef<Session> realmSession;
		//暂存和Realm的Session 避免在创建账号时候 频繁的发起新的链接 账号验证完成后记得释放
		public Session RealmSession
		{
			get
			{
				return realmSession;
			}
			set
			{
				this.realmSession = value;
			}
		}
	}
}

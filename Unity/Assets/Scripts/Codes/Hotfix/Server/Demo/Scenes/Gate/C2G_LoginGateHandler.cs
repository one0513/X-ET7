using System;


namespace ET.Server
{
	[MessageHandler(SceneType.Gate)]
	public class C2G_LoginGateHandler : AMRpcHandler<C2G_LoginGate, G2C_LoginGate>
	{
		protected override async ETTask Run(Session session, C2G_LoginGate request, G2C_LoginGate response)
		{
			Scene scene = session.DomainScene();
			string account = scene.GetComponent<GateSessionKeyComponent>().Get(request.Key);
			if (account == null)
			{
				response.Error = ErrorCore.ERR_ConnectGateKeyError;
				response.Message = "Gate key验证失败!";
				return;
			}
			
			session.RemoveComponent<SessionAcceptTimeoutComponent>();
			
			long instanceId = session.InstanceId;
			using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, account.GetHashCode()))
			{
				if (instanceId != session.InstanceId)
				{
					return;
				}
				
				//通知登录中心服 记录本次登录的服务器Zone
				StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;
				L2G_AddLoginRecord l2ARoleLogin    = (L2G_AddLoginRecord) await ActorMessageSenderComponent.Instance.Call(loginCenterConfig.InstanceId, 
					new G2L_AddLoginRecord() { AccountId = account.GetHashCode(), ServerId = scene.Zone});
				
				if (l2ARoleLogin.Error != ErrorCode.ERR_Success)
				{
					response.Error = l2ARoleLogin.Error;
					return;
				}
				
				Player player =  scene.GetComponent<PlayerComponent>().Get(account.GetHashCode());

				if (player == null)
				{
					// 添加一个新的GateUnit
					player = scene.GetComponent<PlayerComponent>().AddComponent<Player,string>(account);
					player.AddComponent<PlayerSessionComponent>().Session = session;
					player.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
					await player.AddLocation(LocationType.Player);
			
					session.AddComponent<SessionPlayerComponent>().Player = player;
					scene.GetComponent<PlayerComponent>().Add(player);
				}
				response.PlayerId = player.Id;
			}

		}
	}
}
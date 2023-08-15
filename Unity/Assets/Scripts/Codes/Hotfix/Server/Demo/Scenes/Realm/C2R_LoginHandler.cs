using System;
using System.Net;
using System.Text.RegularExpressions;

namespace ET.Server
{
	[MessageHandler(SceneType.Realm)]
	public class C2R_LoginHandler : AMRpcHandler<C2R_Login, R2C_Login>
	{
		protected override async ETTask Run(Session session, C2R_Login request, R2C_Login response)
		{

			StartSceneConfig accountSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Account");
			long accountInstanceId = accountSceneConfig.InstanceId;

			//通知Account服务器处理账号相关请求
			A2R_LoginAccountResponse loginAccountResponse = (A2R_LoginAccountResponse) await ActorMessageSenderComponent.Instance.Call(
				accountInstanceId, new R2A_LoginAccountRequest() {Account = request.Account, Password = request.Password,IsRegister = request.IsRegister});
			if (loginAccountResponse.Error != ErrorCode.ERR_Success)
			{
				response.Error = loginAccountResponse.Error;
				return;
			}
			
			// 随机分配一个Gate
			StartSceneConfig config = RealmGateAddressHelper.GetGate(session.DomainZone(),request.Account);
			Log.Debug($"gate address: {MongoHelper.ToJson(config)}");
			
			// 向gate请求一个key,客户端可以拿着这个key连接gate
			G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey) await ActorMessageSenderComponent.Instance.Call(
				config.InstanceId, new R2G_GetLoginKey() {Account = request.Account});

			response.Address = config.InnerIPOutPort.ToString();
			response.Key = g2RGetLoginKey.Key;
			response.GateId = g2RGetLoginKey.GateId;
			
		}
	}
}

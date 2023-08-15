using System.Text.RegularExpressions;

namespace ET.Server
{
	[ActorMessageHandler(SceneType.Account)]
	public class R2A_LoginAccountRequestHandler: AMActorRpcHandler<Scene, R2A_LoginAccountRequest, A2R_LoginAccountResponse>
	{
		protected override async ETTask Run(Scene unit, R2A_LoginAccountRequest request, A2R_LoginAccountResponse response)
		{

			if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
			{
				response.Error = ErrorCode.ERR_LoginInfoError;
				return;
			}

			if (!Regex.IsMatch(request.Account.Trim(), @"[a-zA-Z0-9_]{5,15}"))
			{
				response.Error = ErrorCode.ERR_AccountMessaFormatError;
				return;
			}

			if (!Regex.IsMatch(request.Password.Trim(), @"[a-zA-Z0-9_]{5,15}"))
			{
				response.Error = ErrorCode.ERR_AccountMessaFormatError;
				return;
			}

			using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.Account.Trim().GetHashCode()))
			{
				var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(unit.DomainZone())
						.Query<Account>(d => d.accountName.Equals(request.Account.Trim()));
				Account account = null;

				if (accountInfoList != null && accountInfoList.Count > 0)
				{
					account = accountInfoList[0];
					unit.AddChild(account);
					if (account.accountType == (int)AccountType.BlackList)
					{
						response.Error = ErrorCode.ERR_AccountInBlackListError;
						account?.Dispose();
						return;
					}

					if (!account.password.Equals(request.Password))
					{
						response.Error = ErrorCode.ERR_LoginInfoError;
						account?.Dispose();
						return;
					}
				}
				else
				{
					//偷懒 可以补充独立账号注册逻辑
					if (request.IsRegister == 0)//0为账号登入
					{
						response.Error = ErrorCode.ERR_AccountNotExist;
						return;
					}
					
					//数据库没有账号则自动创建账号
					
					account = unit.AddChild<Account>();
					account.accountName = request.Account;
					account.password = request.Password;
					account.createTime = TimeHelper.ServerNow();
					account.accountType = (int)AccountType.Genral;
					await DBManagerComponent.Instance.GetZoneDB(unit.DomainZone()).Save<Account>(account);
				}

				//登入中心服 查找是否有其他玩家在线
				StartSceneConfig sceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "LoginCenter");
				long loginCenterInstanceId = sceneConfig.InstanceId;

				L2A_LoginAccountResponse loginAccountResponse =
						(L2A_LoginAccountResponse)await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId,
							new A2L_LoginAccountRequest() { AccountId = account.accountName });
				if (loginAccountResponse.Error != ErrorCode.ERR_Success)
				{
					response.Error = loginAccountResponse.Error;
					account?.Dispose();
					return;
				}

				account?.Dispose();


			}
		}
	}
}


using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.LoginCenter)]
    public class A2L_LoginAccountRequestHandler : AMActorRpcHandler<Scene,A2L_LoginAccountRequest,L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene unit, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response)
        {
            string account = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock,account.GetHashCode()))
            {
                if (!unit.GetComponent<LoginInfoRecordComponent>().IsExits(account.GetHashCode()))
                {
                    return;
                }

                int zone = unit.GetComponent<LoginInfoRecordComponent>().Get(account.GetHashCode());
                StartSceneConfig sceneConfig = RealmGateAddressHelper.GetGate(zone,account);

                G2L_DisconnectGateUnit g2LDisconnectGateUnit = (G2L_DisconnectGateUnit)await ActorMessageSenderComponent.Instance.Call(sceneConfig.InstanceId, new L2G_DisconnectGateUnit() { AccountId = account });

                response.Error = g2LDisconnectGateUnit.Error;
                
            }
        }
    }
}
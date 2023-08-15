using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Gate)]
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene,L2G_DisconnectGateUnit,G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response)
        {
            long accountId = request.AccountId.GetHashCode();

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate,accountId.GetHashCode()))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                Player player = playerComponent.Get(accountId);

                if (player == null)
                {
                    return;
                }

                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session gateSession = player.GetComponent<PlayerSessionComponent>().Session; 
                if ( gateSession!= null && !gateSession.IsDisposed)
                {
                    gateSession.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin});
                    gateSession?.Disconnect().Coroutine();
                }
            }
        }
    }
}
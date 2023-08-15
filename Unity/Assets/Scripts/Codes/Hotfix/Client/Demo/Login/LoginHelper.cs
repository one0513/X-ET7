using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    
    
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene clientScene, string account, string password, Action onError = null)
        {
            //登入流程
            //1.初始化软路由，通过http获取远端的json文件，json文件内容为：软路由的公网IP和端口号  网关均衡服务器（Realm）的内网IP和端口号
            //网关均衡服务器的端口不需要对外开发,主要是为了创建一个关联网关服务器的主要是为了创建一个关联网关服务器的session，从而获取网关服务器的IP和端口号,和网关连接成功后，所有消息通过网关转发
            //2.通过网关均衡服务器的session 进行登入请求，如果账号验证成功，则下发网关的内网IP和端口号
            //3.获取网关的地址后，建立网关session，后续客户端通过这个session与服务器通讯
            try
            {
                
                Session realmSession = await GetRealmSession(clientScene,account);
                
                R2C_Login r2CLogin;
                //密码使用md5加密 数据库不存真实密码
                r2CLogin = (R2C_Login) await realmSession.Call(new C2R_Login() { Account = account, Password = MD5Helper.StringMD5(password)});

                //账号验证失败
                if (r2CLogin.Error != ErrorCode.ERR_Success)
                {
                    onError?.Invoke();
                    return r2CLogin.Error;
                }
                
                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = await RouterHelper.CreateRouterSession(clientScene, NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                clientScene.GetComponent<SessionComponent>().Session = gateSession;
				
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

                //链接网关失败
                if (g2CLoginGate.Error != ErrorCode.ERR_Success)
                {
                    onError?.Invoke();
                    return ErrorCode.ERR_NetWorkError;
                }
                
                realmSession?.Dispose();
                Log.Debug("登陆gate成功!");
                
                await EventSystem.Instance.PublishAsync(clientScene, new EventType.LoginFinish());
                
            }
            catch (Exception e)
            {
                Log.Error(e);
                onError?.Invoke();
                return ErrorCode.ERR_NetWorkError;
            }
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<Session> GetRealmSession(Scene clientScene, string account)
        {
            RouterAddressComponent routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
            if (clientScene.GetComponent<SessionComponent>() == null)
            {
                clientScene.AddComponent<SessionComponent>();
            }
            Session realmSession = clientScene.GetComponent<SessionComponent>().RealmSession;
            if (routerAddressComponent == null && realmSession ==null)
            {
                // 获取路由跟realmDispatcher地址
                routerAddressComponent = clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                await routerAddressComponent.Init();
                    
                clientScene.RemoveComponent<NetClientComponent>();
                clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
            }
            //账号切换了也无所谓 使用之前的Reaml地址进行通讯
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
            
            if (realmSession == null)
            {
                realmSession = await RouterHelper.CreateRouterSession(clientScene, realmAddress);
                //超时判断
                realmSession.AddComponent<RouterTimeCheckComponent>();
            }
            clientScene.GetComponent<SessionComponent>().RealmSession = realmSession;

            return realmSession;
        }
    }
}
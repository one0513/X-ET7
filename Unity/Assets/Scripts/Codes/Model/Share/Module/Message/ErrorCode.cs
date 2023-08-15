namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        
        public const int ERR_NetWorkError = 200002; //网络错误
        public const int ERR_LoginInfoError = 200003; //账号或密码错误
        public const int ERR_AccountMessaFormatError = 200004; //账号或密码格式错误
        public const int ERR_AccountInBlackListError = 200005; //账号在黑名单
        public const int ERR_RequestRepeatedly = 200006; //频繁请求
        public const int ERR_OtherAccountLogin = 200007;//顶号登入
        public const int ERR_AccountNotExist = 200008;//账号不存在
        
        // 300000 - 310000 客户端框架异常
        public const int ERR_ResourceInitError = 300000;            // 资源初始化失败
        public const int ERR_ResourceUpdateVersionError = 300001;   // 资源更新版本号失败
        public const int ERR_ResourceUpdateManifestError = 300002;  // 资源更新清单失败
        public const int ERR_ResourceUpdateDownloadError = 300003;  // 资源更新下载失败
    }
}
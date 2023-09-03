using System;
namespace ET
{
    public class DamageInfo :IDisposable
    {
        public float Value;
        
        
        public static DamageInfo Create()
        {
            return ObjectPool.Instance.Fetch(TypeInfo<DamageInfo>.Type) as DamageInfo;
        }

        public void Dispose()
        {
            Value = 0;
            ObjectPool.Instance.Recycle(this);
        }
    }
}
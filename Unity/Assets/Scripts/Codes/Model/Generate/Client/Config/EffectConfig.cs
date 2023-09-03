//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace ET
{

public sealed partial class EffectConfig: Bright.Config.BeanBase
{
    public EffectConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Description = _buf.ReadInt();
        Icon = _buf.ReadString();
        StatusSlot = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);EffectId = new System.Collections.Generic.List<float>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { float _e0;  _e0 = _buf.ReadFloat(); EffectId.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Type = new System.Collections.Generic.List<float>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { float _e0;  _e0 = _buf.ReadFloat(); Type.Add(_e0);}}
        PostInit();
    }

    public static EffectConfig DeserializeEffectConfig(ByteBuf _buf)
    {
        return new EffectConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 路径
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 播放时间（-1表示无限，由其他逻辑控制）
    /// </summary>
    public int Description { get; private set; }
    /// <summary>
    /// 特效挂点的索引
    /// </summary>
    public string Icon { get; private set; }
    /// <summary>
    /// 是否挂载，为0的话在被挂载者挂载当时所在位置播放
    /// </summary>
    public int StatusSlot { get; private set; }
    /// <summary>
    /// 相对位置
    /// </summary>
    public System.Collections.Generic.List<float> EffectId { get; private set; }
    /// <summary>
    /// 偏转角度
    /// </summary>
    public System.Collections.Generic.List<float> Type { get; private set; }

    public const int __ID__ = -682668973;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "Description:" + Description + ","
        + "Icon:" + Icon + ","
        + "StatusSlot:" + StatusSlot + ","
        + "EffectId:" + Bright.Common.StringUtil.CollectionToString(EffectId) + ","
        + "Type:" + Bright.Common.StringUtil.CollectionToString(Type) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
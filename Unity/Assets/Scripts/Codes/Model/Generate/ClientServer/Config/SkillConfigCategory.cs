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
   
[Config]
public partial class SkillConfigCategory: ConfigSingleton<SkillConfigCategory>
{
    private readonly Dictionary<int, SkillConfig> _dataMap;
    private readonly List<SkillConfig> _dataList;
    
    public SkillConfigCategory(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, SkillConfig>();
        _dataList = new List<SkillConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            SkillConfig _v;
            _v = SkillConfig.DeserializeSkillConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, SkillConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<SkillConfig> DataList => _dataList;

    public SkillConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public SkillConfig Get(int key) => _dataMap[key];
    public SkillConfig this[int key] => _dataMap[key];

    public override void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    public override void TrimExcess()
    {
        _dataMap.TrimExcess();
        _dataList.TrimExcess();
    }
    
    
    public override string ConfigName()
    {
        return typeof(SkillConfig).Name;
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
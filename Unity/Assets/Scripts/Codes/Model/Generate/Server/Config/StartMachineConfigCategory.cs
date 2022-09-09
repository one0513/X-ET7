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
public partial class StartMachineConfigCategory: ConfigSingleton<StartMachineConfigCategory>
{
    private readonly Dictionary<int, StartMachineConfig> _dataMap;
    private readonly List<StartMachineConfig> _dataList;
    
    public StartMachineConfigCategory(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, StartMachineConfig>();
        _dataList = new List<StartMachineConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            StartMachineConfig _v;
            _v = StartMachineConfig.DeserializeStartMachineConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public StartMachineConfigCategory()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, StartMachineConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<StartMachineConfig> DataList => _dataList;

    public StartMachineConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public StartMachineConfig Get(int key) => _dataMap[key];
    public StartMachineConfig this[int key] => _dataMap[key];

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
    
    partial void PostInit();
    partial void PostResolve();
}
}
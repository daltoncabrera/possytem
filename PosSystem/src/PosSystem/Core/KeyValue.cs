using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Core
{
  public class KeyValue
  {
    public KeyValue()
    {
      
    }

     public KeyValue(string key, string val)
     {
       Key = key;
       Value = val;
     }

    public string Key { get; set; }
    public string Value { get; set; }
  }
}

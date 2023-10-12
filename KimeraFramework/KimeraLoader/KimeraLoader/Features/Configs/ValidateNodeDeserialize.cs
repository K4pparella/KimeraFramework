using System;
using System.ComponentModel.DataAnnotations;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace HyvoxFramework.KimeraLoader.Features.Configs
{
    internal class ValidateNodeDeserialize : INodeDeserializer
    {
        private readonly INodeDeserializer _nodeDeserializer;
        public ValidateNodeDeserialize(INodeDeserializer nodeDeserializer) 
        {
            _nodeDeserializer = nodeDeserializer;
        }

        public bool Deserialize(IParser reader, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
        {
            try
            {
                if(_nodeDeserializer.Deserialize(reader, expectedType,nestedObjectDeserializer, out value))
                {
                    if(value is null)
                        ServerConsole.AddLog("value is null");
                    Validator.ValidateObject(value, new ValidationContext(value), true);
                    return true;
                }
                return false;
            }
            catch (Exception ex) 
            {
                ServerConsole.AddLog(ex.ToString());
                value = null;
                return false;
            }
        }
    }
}

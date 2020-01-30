﻿using Newtonsoft.Json;

namespace Autofac.Extension
{
    public class JsonSerialization : ISerialization
    {
        private readonly JsonSerializerSettings _setting;

        public JsonSerialization()
        {
            _setting = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                TypeNameHandling = TypeNameHandling.Auto,
            };
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, typeof(T), _setting);
        }

        public T Deserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str, _setting);
        }
    }
}

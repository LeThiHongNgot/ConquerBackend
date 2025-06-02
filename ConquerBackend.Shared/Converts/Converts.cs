using Newtonsoft.Json;

namespace ConquerBackend.Shared.Converts
{
    public static  class Converts
    {
        public static string ToJsonString(this object obj, bool indented = false)
        {
            if (obj is null) return string.Empty;

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = indented ? Formatting.Indented : Formatting.None,
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}

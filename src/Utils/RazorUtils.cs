using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Caching.Memory;

namespace AustinSite.Utils
{
    public static class RazorUtils
    {   
        public static string RenderViewToString(IMemoryCache memoryCache,
            string viewName, 
            Dictionary<string, string> binds,
            string failBackTemplate)
        {
            if (memoryCache == null)
                throw new ArgumentNullException(nameof(memoryCache));
                
            string template;
            
            if (!memoryCache.TryGetValue(viewName, out template))
            {
                var path = Directory.GetCurrentDirectory() + 
                    Path.DirectorySeparatorChar.ToString() + 
                    "Views" + 
                    Path.DirectorySeparatorChar.ToString() + 
                    "Template" +
                    Path.DirectorySeparatorChar.ToString() + 
                    $"{viewName}.html";
                
                if (File.Exists(path))
                    template = File.ReadAllText(path);
                
                memoryCache.Set(viewName, template,
                    new MemoryCacheEntryOptions()
                        .SetPriority(CacheItemPriority.NeverRemove));
            }
            
            if (string.IsNullOrEmpty(template))
                return failBackTemplate;
            
            foreach (var bind in binds)
            {
                template = template.Replace($"{{{bind.Key}}}", bind.Value);
            }
            
            return template;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YoutubeApi.Client.Builders
{
    public class FluentEndpointBuilder(string baseUrl)
    {
        private readonly string baseUrl=baseUrl.TrimEnd('/');  
        private readonly List<KeyValuePair<string, string>> queryParams = [];
        private readonly  StringBuilder sbRoute = new();

        public FluentEndpointBuilder AddParam(string key,string value)
        {
            queryParams.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public FluentEndpointBuilder AddRoute(string segment)
        {
            if (!string.IsNullOrEmpty(segment))
            {
                if(!segment.StartsWith('/'))
                    sbRoute.Append('/');    
                if (segment.EndsWith('/'))
                    sbRoute.Append(segment[..^1]);
                else
                    sbRoute.Append(segment);
            }
            return this;
        }
        public string Build()
        {
            var sbUrl=new StringBuilder(baseUrl);   
            if (sbRoute.Length > 0)
            {
                sbUrl.Append(sbRoute);
            }
            if (queryParams.Count > 0)
            {
             var querystring=string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
                sbUrl.Append(querystring);
            }
            return sbUrl.ToString();
        }   
    }
}

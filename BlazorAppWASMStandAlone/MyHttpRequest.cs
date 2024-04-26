using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net;

namespace BlazorAppWASMStandAlone
{
    public class MyHttpRequest
    {
        public async  Task Test()
        {
            //https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
            //https://github.com/cornflourblue/blazor-webassembly-http-post-request-examples/blob/master/Components/PostRequestSetHeaders.razor
            String l_strURI = "https://devapi.diresoft.net/web/backoffice/api/login";
            var parameters = new Dictionary<string, string> { { "platform", "nexus" }, { "site", "" }, { "account", "client1" }, { "password", "ap1234" }, { "brand_code", "All" } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            using (var httpClient = new HttpClient())
            {
                var response2 = await httpClient.PostAsync(l_strURI, encodedContent).ConfigureAwait(false);
                System.Net.HttpStatusCode l_Code = response2.StatusCode;
                var content = await response2.Content.ReadAsStringAsync();
                if (response2.StatusCode == HttpStatusCode.OK)
                {
                    // Do something with response. Example get content:
                    // var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                }
                else
                {

                }
            }
        }
    }
}

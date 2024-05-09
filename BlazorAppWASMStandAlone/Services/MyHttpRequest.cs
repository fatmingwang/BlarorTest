using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace BlazorAppWASMStandAlone.Services
{
    public class MyHttpRequest
    {
		static string m_strURI = "https://devapi.diresoft.net/web/backoffice/";
        static string m_strToken = "eyJhY2NvdW50IjoiY2xpZW50MSIsImN1cnJlbmN5IjoiIiwicm9sZV9jb2RlIjoiYWRtaW4wMSIsInBjb2RlIjoibmV4dXMiLCJiY29kZSI6IkFsbCIsInNjb2RlIjoibmV4dXMiLCJqcHBjb2RlIjoiZ2dib29rIiwiaXAiOiIxMjcuMC4wLjEiLCJ0c21wIjoiMjAyNC8wNC8zMCAxNTozNDo1MSJ9";
		public static async Task Login()
        {
            //https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
            //https://github.com/cornflourblue/blazor-webassembly-http-post-request-examples/blob/master/Components/PostRequestSetHeaders.razor
            string l_strURI = m_strURI+"api/login";
            var parameters = new Dictionary<string, string> { { "platform", "nexus" }, { "site", "" }, { "account", "client1" }, { "password", "ap1234" }, { "brand_code", "All" } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            using (var httpClient = new HttpClient())
            {
                var response2 = await httpClient.PostAsync(l_strURI, encodedContent).ConfigureAwait(false);
                HttpStatusCode l_Code = response2.StatusCode;
                if (response2.StatusCode == HttpStatusCode.OK)
                {
					//https://stackoverflow.com/questions/50884968/how-to-access-children-values-of-a-jobject
					var content = await response2.Content.ReadAsStringAsync();
					JObject jsonObject = JObject.Parse(content);
					JObject l_Data = jsonObject.GetValue("data") as JObject;
                    if(l_Data != null )
                    {
						String l_strToken = l_Data.GetValue("token").ToString();
						m_strToken = l_strToken;
					}
				}
                else
                {

                }
            }
        }

		public static async Task InitDataAsyncTesting()
		{
			//https://stackoverflow.com/questions/27376133/c-httpclient-with-post-parameters
			//https://github.com/cornflourblue/blazor-webassembly-http-post-request-examples/blob/master/Components/PostRequestSetHeaders.razor
			string l_strURI = m_strURI + "api/init";
			var parameters = new Dictionary<string, string> 
			{
				{ "BeginTime", "" },
				{ "EndTime", "" },
				{ "BeginRange", "" },
				{ "EndRange", "" },
				{ "TimeZone", "+8(CT/CST)" },
				{ "CurrencyCode", "USD" },
				{ "Name", "" },
				{ "AllDay", "-1" },
				{ "ReminderHour", "8" },
				{ "PrizeDaily", "1" },
				{ "Symbol", "coin_ap" },
				{ "token", m_strToken },
			};
			var encodedContent = new FormUrlEncodedContent(parameters);
			using (var httpClient = new HttpClient())
			{
				var response2 = await httpClient.PostAsync(l_strURI, encodedContent).ConfigureAwait(false);
				HttpStatusCode l_Code = response2.StatusCode;
				if (response2.StatusCode == HttpStatusCode.OK)
				{
					//https://stackoverflow.com/questions/50884968/how-to-access-children-values-of-a-jobject
					var content = await response2.Content.ReadAsStringAsync();
					JObject jsonObject = JObject.Parse(content);
				}
				else
				//if (response2.StatusCode == HttpStatusCode.BadRequest)
				{
					Console.WriteLine("token problem?");
				}
			}
		}

        public static async Task BOHistory()
        {
            string l_strURI = "https://devapi.diresoft.net/web/history/ticket?platform=nexus&ticketNo=a5RXdJD9MjCT8l&encoderequired=1";
            //var encodedContent = new StringContent("platform=nexus&ticketNo=a5RXdJD9MjCT8l&encoderequired=1", Encoding.UTF8, "text/plain");
            using (var httpClient = new HttpClient())
            {
				try
				{
					var response2 = await httpClient.GetAsync(l_strURI).ConfigureAwait(false);
					HttpStatusCode l_Code = response2.StatusCode;
					if (response2.StatusCode == HttpStatusCode.OK)
					{
						//https://stackoverflow.com/questions/50884968/how-to-access-children-values-of-a-jobject
						var content = await response2.Content.ReadAsStringAsync();
						JObject jsonObject = JObject.Parse(content);
						JObject l_Data = jsonObject.GetValue("data") as JObject;
						if (l_Data != null)
						{
							String l_strToken = l_Data.GetValue("token").ToString();
							m_strToken = l_strToken;
						}
					}
					else
					{

					}
				}
				catch(Exception ex) 
				{
					Console.WriteLine("CROS?? "+ ex.ToString());
				}
            }
        }
    }
}

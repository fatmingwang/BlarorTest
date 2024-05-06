using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
namespace BlazorAppWASMStandAlone.Pages.Statement
{
    public partial class cFilterSelect : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        //@inject NavigationManager Navigator
        //<p> @Navigator.BaseUri</p>
        public List<string> m_SelectArrayName = new List<string> { "qoo", "ooq", "pp" };
        public Dictionary<string, List<string>> m_SelectNameAndSelectOptionTextMap = new Dictionary<string, List<string>>()
        {
            {"qoo",new List<string>{"123","456"} },
            {"666",new List<string>{"999","888"} }
        };
        protected override async Task OnInitializedAsync()
        {
            using (var httpClient = new HttpClient())
            {
                    //{
                    //  "SelectArray": {
                    //    "Platform": [ "nexus,dafa" ],
                    //    "Brand": [ "nexus,dafa" ],
                    //    "Site": [ "nexus,dafa" ],
                    //    "DisplayCurrency": [ "nexus,dafa" ],
                    //    "StartDate": [ "nexus,dafa" ],
                    //    "EndDate": [ "nexus,dafa" ],
                    //    "TimeZone": [ "nexus,dafa" ],
                    //    "WalletType": [ "nexus,dafa" ],
                    //    "AcountType": [ "nexus,dafa" ]
                    //  }
                    //}

                string l_strURI = NavigationManager.BaseUri+ "Data/StatementSelectArray.json";
                string l_StatementSelectArrayData = await httpClient.GetStringAsync(l_strURI);
                //string l_StatementSelectArrayData = await httpClient.GetStringAsync("sample-data/weather.json");
                JObject jsonObject = JObject.Parse(l_StatementSelectArrayData);
                JObject l_Data = jsonObject.GetValue("SelectArray") as JObject;
                foreach(var l_Object in l_Data)
                {
                    string l_strAll = l_Object.ToString();
                    string l_strKey = l_Object.ToString();

                    List<string> l_Array = l_Object.Value.ToObject<List<string>>();
                    //l_Array.Count();


                }
                Console.WriteLine(l_Data);
                //var forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            }
        }

        private void SelectedCarsChanged(ChangeEventArgs e)
        {
            if (e.Value is not null)
            {
                //SelectedCars = (string[])e.Value;
            }
        }
    }
}
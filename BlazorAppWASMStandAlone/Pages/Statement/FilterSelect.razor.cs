using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using BlazorAppWASMStandAlone.CommonFunction;
using System;
namespace BlazorAppWASMStandAlone.Pages.Statement
{
    public partial class cFilterSelect : ComponentBase
    {
        public DateOnly date1 = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        public DateTime date2 = DateTime.Now;
        [Inject]
        CommonFunction.MyCommonFunction g_MyCommonFunction { get; set; } = default!;
        //<p> @Navigator.BaseUri</p>
        public List<string> m_SelectArrayName = new List<string> { "qoo", "ooq", "pp" };
        public Dictionary<string, List<string>> m_SelectNameAndSelectOptionTextMap = new Dictionary<string, List<string>>()
        {
            {"qoo",new List<string>{"123","456"} },
            {"666",new List<string>{"999","888"} }
        };
        protected override async Task OnInitializedAsync()
        {
            string l_str = await g_MyCommonFunction.GetFileStringAsync("Data/StatementSelectArray.json");
            if(l_str != null)
            {
                JObject jsonObject = JObject.Parse(l_str);
                JObject l_Data = jsonObject.GetValue("SelectArray") as JObject;
                m_SelectNameAndSelectOptionTextMap.Clear();
                foreach (var l_Object in l_Data)
                {
                    string l_strAll = l_Object.ToString();
                    string l_strKey = l_Object.Key.ToString();
                    List<string> l_Array = l_Object.Value.ToObject<List<string>>();
                    m_SelectNameAndSelectOptionTextMap[l_strKey] = l_Array;
                }
                Console.WriteLine(l_Data);
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
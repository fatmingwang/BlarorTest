using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace BlazorAppWASMStandAlone.CommonFunction
{
    //please add below code at program.cs
    //builder.Services.AddScoped<MyCommonFunction>();
    //and 
    //[Inject]
    //public NavigationManager m_NavigationManager { get; set; } = default!;
    //protected override void OnInitialized()
    //{
    //    g_MyCommonFunction.m_NavigationManager = m_NavigationManager;
    //}
    public class MyCommonFunction
    {
        [Inject]
        public NavigationManager m_NavigationManager { get; set; } = default!;
        public string BindRelatedAddress(string e_strURI)
        {
            if(m_NavigationManager == null)
            {
                Console.WriteLine("please assign m_NavigationManager first ");
                return null;
            }
            return m_NavigationManager.BaseUri + e_strURI;
    }
        public async Task<string> GetFileStringAsync(string e_strURI,bool e_bDoBindRelatedAddress = true)
        {
            using (var httpClient = new HttpClient())
            {
                string l_strURI = e_strURI;
                if(e_bDoBindRelatedAddress)
                {
                    l_strURI = BindRelatedAddress(e_strURI);
                }
                //string l_strURI = m_NavigationManager.BaseUri + "Data/StatementSelectArray.json";
                try
                {
                    Task<string> l_StatementSelectArrayData = httpClient.GetStringAsync(l_strURI);
                    return await l_StatementSelectArrayData;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }
    }
}

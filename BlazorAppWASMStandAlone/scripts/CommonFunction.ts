//https://www.c-sharpcorner.com/blogs/type-script-with-blazor

//https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/javascript-interoperability/index.md

//namespace Common
//{
    class cCommonFunction
    {
        ////https://stackoverflow.com/questions/75072133/blazor-wasm-create-and-download-a-file
        async DownloadFile(e_strURI)
        {
            console.log("79979");
            //return new Promise((resolve) =>
            {
                const response = await fetch(e_strURI);
                const json = await response.json();
                console.log(JSON.stringify(json));
                return json;
                //resolve(json);
            }
        }

        //static async function getCurrentPosition(options) {
        //    return await new Promise((resolve, reject) => {
        //        navigator.geolocation.getCurrentPosition(resolve, reject, options);
        //    });
        //}
    }

//}

function getCommonInstance(): cCommonFunction 
{
    return new cCommonFunction();
}
//cCommonFunction.
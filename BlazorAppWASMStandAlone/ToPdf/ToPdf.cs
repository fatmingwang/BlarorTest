//https://www.c-sharpcorner.com/article/how-to-create-pdf-using-itextsharp-in-blazor/


//https://stackoverflow.com/questions/69132556/how-to-download-edited-pdf-using-itextsharp-and-c-sharp-blazor

//https://stackoverflow.com/questions/73345726/blazor-wasm-pdf-generation-with-itextsharp

//https://taithienbo.medium.com/displaying-pdfs-in-blazor-ca6b5de2930c

//https://ithelp.ithome.com.tw/articles/10312009?sc=rss.qu

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BlazorAppWASMStandAlone.ToPdf
{
    public class cToPdf
    {

    }

    public class PdfGenerator
    {
        public static void GeneratePdf(string fileName, string title, string body)
        {
            //Create a new document
            Document document = new Document();

            FileStream l_FileStream = new FileStream(fileName, FileMode.Create);

            //Create a PDF writer
            PdfWriter.GetInstance(document, l_FileStream);

            //Open the document
            document.Open();

            //Add a title
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph titleParagraph = new Paragraph(title, titleFont);
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            bool l_bAdded = document.Add(titleParagraph);

            //Add some text
            Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph bodyParagraph = new Paragraph(body, bodyFont);
            bodyParagraph.Alignment = Element.ALIGN_JUSTIFIED;
            bool l_bResult = document.Add(bodyParagraph);
            Console.WriteLine("gen "+ fileName+ " result:" + l_bResult);

            //Close the document
            document.Close();


            //https://stackoverflow.com/questions/76666812/download-a-memorystream-txt-file-from-a-blazor-page
            //// Create the streams.
            //MemoryStream destination = new MemoryStream();
            //{

            //    Console.WriteLine("Source length: {0}", l_FileStream.Length.ToString());

            //    // Copy source to destination.
            //    l_FileStream.CopyTo(destination);
            //}

            Console.WriteLine("Destination length: {0}", destination.Length.ToString());

        }
    }
}

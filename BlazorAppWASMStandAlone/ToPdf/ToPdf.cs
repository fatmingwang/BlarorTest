//https://www.c-sharpcorner.com/article/how-to-create-pdf-using-itextsharp-in-blazor/

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

            //Create a PDF writer
            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

            //Open the document
            document.Open();

            //Add a title
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph titleParagraph = new Paragraph(title, titleFont);
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(titleParagraph);

            //Add some text
            Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph bodyParagraph = new Paragraph(body, bodyFont);
            bodyParagraph.Alignment = Element.ALIGN_JUSTIFIED;
            bool l_bResult = document.Add(bodyParagraph);

            //Close the document
            document.Close();
        }
    }
}

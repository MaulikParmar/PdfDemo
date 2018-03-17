using MpPdfDemoApp.Droid.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(PdfMaker))]
namespace MpPdfDemoApp.Droid.Helpers
{
    public class PdfMaker : MpPdfDemoApp.Helper.IPdfMaker
    {
        public void DrawPdf(string Text)
        {
            MpPdfFile pdf = new MpPdfFile();
            pdf.GeneratePdfFile(Text);
        }
    }
}
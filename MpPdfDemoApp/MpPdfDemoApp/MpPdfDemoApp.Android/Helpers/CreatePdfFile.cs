using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Pdf;
using Android.OS;
using Android.Print;
using Android.Print.Pdf;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using static Android.Graphics.Pdf.PdfDocument;

namespace MpPdfDemoApp.Droid.Helpers
{
    public class MpPdfFile
    {
        public void GeneratePdfFile(string text)
        {
            PrintAttributes printAttrs = new PrintAttributes.Builder()
                .SetColorMode(PrintColorMode.Color)
                .SetMediaSize(PrintAttributes.MediaSize.IsoA4)
                .SetResolution(new PrintAttributes.Resolution("guardianHealthId", "TestReport", 592, 842))
                .SetMinMargins(PrintAttributes.Margins.NoMargins)
                .Build();

            // Create a document
            PdfDocument document = new PrintedPdfDocument(Android.App.Application.Context, printAttrs);

            // Create a page description
            // A4 : Page size
            // pageWidth The page width in PostScript (1/72th of an inch)
            // pageHeight The page height in PostScript(1 / 72th of an inch).
            PageInfo pageInfo = new PageInfo.Builder(592, 842, 1).Create();
            PdfDocument.Page page = document.StartPage(pageInfo);

            Xamarin.Forms.Button btn = new Xamarin.Forms.Button();
            

            // File to create page
            File path = GetDirectoryPath();
            System.IO.FileStream fileStream = new System.IO.FileStream(path.ToString(), System.IO.FileMode.Create);

            Canvas canvas = page.Canvas;
            Paint paint = new Paint();

            canvas.DrawText("This is a demo pdf file.\n" + text, 10, 10, paint);

            document.FinishPage(page);
            document.WriteTo(fileStream);
            document.Close();
            fileStream.Close();
        }

        public File GetDirectoryPath()
        {
            File path = Android.OS.Environment.GetExternalStoragePublicDirectory(
            Android.OS.Environment.DirectoryDownloads);

            string FileName = "GuardionHealthTestRepotrt_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
            File file = new File(path, FileName);

            // Check document directory is exist
            if (path.Exists())
                path.Mkdir();

            return file;
        }
    }
}
using System;
using DevExpress.Pdf;
using System.Drawing;
using System.Diagnostics;

namespace AddLinkToUri {
    class Program {
        static void Main(string[] args) {

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Load a document
                processor.LoadDocument("..\\..\\..\\Document.pdf");

                // Access the first page properties
                PdfPageFacade page = processor.DocumentFacade.Pages[0];

                // Find the target phrase in the document
                string linkText = "PDF Viewer";
                PdfTextSearchResults linkSearchResults = processor.FindText(linkText);

                if (linkSearchResults.Status == PdfTextSearchStatus.Found)
                {
                    PdfRectangle linkRectangle = linkSearchResults.Rectangles[0].BoundingRectangle;
                    string linkUri = "https://community.devexpress.com/blogs/";

                    // Add a link annotation to the found text
                    PdfLinkAnnotationFacade uriAnnotation = page.AddLinkAnnotation(linkRectangle, linkUri);
                    uriAnnotation.Name = "link1";
                    uriAnnotation.HighlightMode = PdfAnnotationHighlightingMode.Push;
                }
                processor.SaveDocument("..\\..\\..\\Result.pdf");
            }
            Process.Start(new ProcessStartInfo("..\\..\\..\\Result.pdf") { UseShellExecute = true });
        }

    }
}

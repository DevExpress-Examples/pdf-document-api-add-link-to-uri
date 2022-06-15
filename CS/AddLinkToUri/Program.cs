using System;
using DevExpress.Pdf;
using System.Drawing;

namespace AddLinkToUri {
    class Program {
        static void Main(string[] args) {

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document.
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create and draw graphics.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawGraphics(graphics);

                    // Create a link to URI specifying link area and URI.
                    graphics.AddLinkToUri(new RectangleF(310, 150, 180, 15), new Uri("https://www.devexpress.com"));

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawGraphics(PdfGraphics graphics) {

            // Draw a text line on the page. 
            using (Font font = new Font("Arial", 10)) {
                SolidBrush blue = (SolidBrush)Brushes.Blue;
                graphics.DrawString("https://www.devexpress.com", font, blue, 310, 150);
            }
        }
    }
}

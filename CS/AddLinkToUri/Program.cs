using DevExpress.Pdf;
using System;
using System.Drawing;

namespace AddLinkToUri
{
    class Program
    {
        static void Main(string[] args)
        {

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                // Create an empty document.
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create and draw graphics.
                using (PdfGraphics graphics = processor.CreateGraphics())
                {
                    using (Font font = new Font("Arial", 34))
                    {
                        SolidBrush blue = (SolidBrush)Brushes.Blue;

                        // Calculate the link size
                        SizeF stringSize = graphics.MeasureString("https://www.devexpress.com", font);
                        RectangleF stringRect = new RectangleF(100, 150, stringSize.Width, stringSize.Height);

                        // Draw a link text. 
                        graphics.DrawString("https://www.devexpress.com", font, blue, stringRect);

                        // Create a link to a URI at the specified page area.
                        graphics.AddLinkToUri(stringRect, new Uri("https://www.devexpress.com"));
                    }

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }

        }
    }
}

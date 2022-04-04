Imports DevExpress.Pdf
Imports System
Imports System.Drawing

Namespace AddLinkToUri

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document.
                processor.CreateEmptyDocument("..\..\Result.pdf")
                ' Create and draw graphics.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    Using font As Font = New Font("Arial", 34)
                        Dim blue As SolidBrush = CType(Brushes.Blue, SolidBrush)
                        ' Calculate the link size
                        Dim stringSize As SizeF = graphics.MeasureString("https://www.devexpress.com", font)
                        Dim stringRect As RectangleF = New RectangleF(100, 150, stringSize.Width, stringSize.Height)
                        ' Draw a link text. 
                        graphics.DrawString("https://www.devexpress.com", font, blue, stringRect)
                        ' Create a link to a URI at the specified page area.
                        graphics.AddLinkToUri(stringRect, New Uri("https://www.devexpress.com"))
                    End Using

                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub
    End Class
End Namespace

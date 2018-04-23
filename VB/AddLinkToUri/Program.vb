Imports System
Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddLinkToUri
    Friend Class Program
        Shared Sub Main(ByVal args() As String)

            Using processor As New PdfDocumentProcessor()

                ' Create an empty document.
                processor.CreateEmptyDocument("..\..\Result.pdf")

                ' Create and draw graphics.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawGraphics(graphics)

                    ' Create a link to URI specifying link area and URI.
                    graphics.AddLinkToUri(New RectangleF(310, 150, 180, 15), New Uri("https://www.devexpress.com"))

                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawGraphics(ByVal graphics As PdfGraphics)

            ' Draw a text line on the page. 
            Using font As New Font("Arial", 10)
                Dim blue As SolidBrush = CType(Brushes.Blue, SolidBrush)
                graphics.DrawString("https://www.devexpress.com", font, blue, 310, 150)
            End Using
        End Sub
    End Class
End Namespace

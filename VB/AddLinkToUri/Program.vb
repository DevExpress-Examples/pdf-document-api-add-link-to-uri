Imports System
Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddLinkToUri

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Load a document
                processor.LoadDocument("..\..\..\Document.pdf")

                ' Access the first page properties
                Dim page As PdfPageFacade = processor.DocumentFacade.Pages(0)

                ' Find the target phrase in the document
                Dim linkText As String = "PDF Viewer"
                Dim linkSearchResults As PdfTextSearchResults = processor.FindText(linkText)

                If linkSearchResults.Status = PdfTextSearchStatus.Found Then
                    Dim linkRectangle As PdfRectangle = linkSearchResults.Rectangles(0).BoundingRectangle
                    Dim linkUri As String = "https://community.devexpress.com/blogs/"

                    ' Add a link annotation to the found text
                    Dim uriAnnotation As PdfLinkAnnotationFacade = page.AddLinkAnnotation(linkRectangle, linkUri)
                    uriAnnotation.Name = "link1"
                    uriAnnotation.HighlightMode = PdfAnnotationHighlightingMode.Push
                End If
                processor.SaveDocument("..\..\..\Result.pdf")
            End Using
            Process.Start(New ProcessStartInfo("..\..\..\Result.pdf") With {.UseShellExecute = True})
        End Sub

    End Class
End Namespace

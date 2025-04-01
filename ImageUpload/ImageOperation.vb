Public Class ImageOperation

    ' Constructor de la clase
    Public Sub New()
        ' Inicializar cualquier configuración necesaria aquí
    End Sub
    Public Sub ImageSave(selectedImage As Image, fileName As String)
        ' Guardar la imagen en un directorio específico
        Dim saveDirectory As String = "C:\YourDirectoryPath\" ' Cambia esta ruta al directorio deseado
        Dim savePath As String = System.IO.Path.Combine(saveDirectory, fileName)
        ' Guardar la imagen usando la clase ImageOperation
        selectedImage.Save(savePath)
    End Sub
    Public Function ReadImage(fileName As String) As Image
        Dim path As String = "C:\YourDirectoryPath\" ' Cambia esta ruta a la ubicación de tu imagen

        Dim imagePath As String = System.IO.Path.Combine(path, fileName)
        Try
            ' Verificar si el archivo existe
            If System.IO.File.Exists(imagePath) Then
                ' Cargar la imagen desde el archivo
                Dim loadedImage As Image = Image.FromFile(imagePath)
                ' agregar una funcion para guardar el nombre de la imagen en la base de datos
                Return loadedImage
            Else
                MessageBox.Show("La imagen no se encontró en la ruta especificada.")
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la imagen: " & ex.Message)
            Return Nothing
        End Try
    End Function
End Class

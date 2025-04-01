Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileName As String = "yourImage.png" 'nombre de la imagen, esta se puede obtener de un registro de la base de datos
        Dim imageOperation As ImageOperation = New ImageOperation
        Dim loadedImage As Image = imageOperation.ReadImage(fileName)
        If loadedImage IsNot
                Nothing Then
            ' Asignar la imagen al PictureBox
            PictureBox1.Image = loadedImage
        Else
            Dim defaultPath As String = AppDomain.CurrentDomain.BaseDirectory ' Usar el directorio actual de la aplicación
            Dim position As Integer = defaultPath.LastIndexOf("ImageUpload")
            If position <> -1 Then
                ' Obtener la subcadena hasta el índice encontrado
                defaultPath = defaultPath.Substring(0, position + "ImageUpload".Length)
            End If
            Dim imagePath As String = System.IO.Path.Combine(defaultPath, "resources\default.jpg")
            PictureBox1.Image = Image.FromFile(imagePath)
        End If

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        ' Crear una instancia del OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Configurar propiedades del OpenFileDialog
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        openFileDialog.Title = "Select an Image File"

        ' Mostrar el OpenFileDialog y verificar si el usuario seleccionó un archivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Cargar la imagen seleccionada en el PictureBox
            Dim selectedImage As Image = Image.FromFile(openFileDialog.FileName)
            PictureBox1.Image = selectedImage
            Dim fileName As String = System.IO.Path.GetFileName(openFileDialog.FileName)
            Dim ImageOperation As ImageOperation = New ImageOperation
            ImageOperation.ImageSave(selectedImage, fileName)

        End If
    End Sub

End Class

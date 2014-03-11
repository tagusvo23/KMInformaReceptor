Module Module1
    
    Public VGstrConfiguracion As String
    Public VGstrUsuario As String
    Sub Main(ByVal args() As String)
        Try
            VGstrConfiguracion = args(0)
            VGstrUsuario = args(1)
            Principal.ShowDialog()

            'frmConfiguracion.txtRuta.Text = VGstrConfiguracion
            'frmConfiguracion.txtConfiguracion.Text = VGstrUsuario
            'frmConfiguracion.ShowDialog()

        Catch ex As Exception
            MsgBox("La aplicación no pudo ser iniciada :" & vbNewLine & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "KM Receptor")
        End Try
    End Sub
End Module

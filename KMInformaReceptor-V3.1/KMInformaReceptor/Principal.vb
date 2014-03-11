Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Data.OracleClient

Public Class Principal
    Dim VMstrwhereFiltros As String ' variable complemento de con la condición de filtrado 
    Dim VMintTotStatA As Integer
    Dim VMblnCancelar As Boolean 'para poder cancelar la actualizacion de información
    Dim VMstrFileName As String
    Dim VMintSw1 As String 'Para control de campo referencia con o sin informacion

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' presenta la ventana de las alertas   
        Me.Refresh()

        CargaParametros()
        LeeAplicacion()
        LeeLayout()
        LeeFormato()
        LlenaCombos()

        VGstrwhere = ""
        VGstrwhere = "where id_usuario = '" & VGstrUsuario & "' and id_lay = " & VGintLayout & " and id_formato = " & _
                      VGintFormato & " and id_aplicacion = " & VGintAplcacion & " and id_TipoReg = " & VGintTiporeg

        lbltitulos.Text = VGstrNombreLayout & "                                           " & _
                         VGstrNombreFormato & "                                           " & _
                      VGstrNombreAplicacion & "                                           " & _
                               VGstrUsuario

        Me.Text = ("Informa  (" & VGstrNombreAplicacion & ")")

    End Sub
    Private Function ArmaCondicion() As Boolean
        Dim VLstrFechaIni As String
        Dim VLstrFechaFin As String

        VMstrwhereFiltros = ""
        TxtObservaciones.Text = ""
        CmbEstado.Text = ""
        VMblnCancelar = False
        PgrBarra.Value = 0
        VSGAlertas.Rows.Count = 1
        VSGAlertas.Refresh()
        TxtTotalAlertas.Text = ""

        Try

        Catch ex As Exception

        End Try

        If ChkFechas.Checked = True Then
            VLstrFechaIni = Format(DtpFechaIni.Value, "yyyy-MM-dd")
            VLstrFechaFin = Format(DtpFechaFin.Value, "yyyy-MM-dd")

            If VLstrFechaIni > VLstrFechaFin Then
                MsgBox("La fecha incial no puede ser mayor que la final", vbOKOnly + MsgBoxStyle.Information)
                DtpFechaIni.Focus()
                ArmaCondicion = False
                Exit Function
            End If
            If Trim(VLstrFechaIni) = "" Or Trim(VLstrFechaFin) = "" Then
                MsgBox("Debe seleccionar la fecha de inicio y la fecha de fin", vbOKOnly + MsgBoxStyle.Information)
                DtpFechaIni.Focus()
                ArmaCondicion = False
                Exit Function
            End If
            FormaFechas()
        End If

        If ChkMensaje.Checked = True Then
            If Trim(TxtMensaje.Text) > " " Then
                FormaMensaje()
            Else
                MsgBox("No Capturo un Mensaje")
                TxtMensaje.Focus()
                ArmaCondicion = False
                Exit Function
            End If
        End If

        If ChkEstado.Checked = True Then
            If Not CmbestadoF.Text = "" Then
                FormaEstado()
            Else
                MsgBox("No selecciono un estado")
                CmbestadoF.Focus()
                ArmaCondicion = False
                Exit Function
            End If
        End If

        If ChkReferencia.Checked = True Then
            If Trim(TxtReferencia.Text) > " " Then
                FormaReferencia()
            Else
                MsgBox("No Capturo una referencia")
                TxtReferencia.Focus()
                ArmaCondicion = False
                Exit Function
            End If
        End If
        ArmaCondicion = True

    End Function
    Private Sub FormaFechas()
        Dim VLstrfecha As String
        Dim VLstrpaso As String

        VMstrwhereFiltros = " and "

        Select Case VGstrOpcDBN_Bitacora
            Case 2      'Oracle
                VLstrfecha = "yyyy-MM-dd HH24:MI:SS:SSSSS"

                VLstrpaso = Format(DtpFechaIni.Value, "yyyy-MM-dd") & " 00:00:00"
                VMstrwhereFiltros = VMstrwhereFiltros & " Fecha_hora >= to_date('" & VLstrpaso & "','" & VLstrfecha & "')"

                VMstrwhereFiltros = VMstrwhereFiltros & " and "

                VLstrpaso = Format(DtpFechaFin.Value, "yyyy-MM-dd") & " 23:59:59"
                VMstrwhereFiltros = VMstrwhereFiltros & " Fecha_hora <= to_date('" & VLstrpaso & "','" & VLstrfecha & "')"

            Case 3      'SQL Server
                VMstrwhereFiltros = VMstrwhereFiltros & " Fecha_Hora between " & "Convert(DateTime, '" & DtpFechaIni.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") & "', 121)"
                VMstrwhereFiltros = VMstrwhereFiltros & " and "
                VMstrwhereFiltros = VMstrwhereFiltros & " Convert(DateTime, '" & DtpFechaFin.Value.ToString("yyyy-MM-dd") & " 23:59:59:999', 121)"

            Case 5      'MySql
                VLstrfecha = "yyyy-MM-dd"

                VMstrwhereFiltros = VMstrwhereFiltros & "Fecha_Hora >= " & "'" & Format(CDate(DtpFechaIni.Value), VGstrFor_Fecha) & "'"
                VMstrwhereFiltros = VMstrwhereFiltros & " and "
                VMstrwhereFiltros = VMstrwhereFiltros & " Fecha_Hora <= " & "'" & Format(CDate(DtpFechaFin.Value), VLstrfecha) & " 23:59:59.9999" & "'"

        End Select

    End Sub
    Private Sub FormaMensaje()
        '    Función para agregar la Condición de mensaje al Query
        VMstrwhereFiltros = VMstrwhereFiltros & " and "

        Select Case VGstrOpcDBN_Bitacora
            Case 2     'Oracle
                VMstrwhereFiltros = VMstrwhereFiltros & "Mensaje like '%" & Trim(TxtMensaje.Text) & "%'"
            Case 3     'SQL Server
                VMstrwhereFiltros = VMstrwhereFiltros & "Mensaje like '%" & Trim(TxtMensaje.Text) & "%'"
            Case 5     'MySQL
                VMstrwhereFiltros = VMstrwhereFiltros & "Mensaje like '%" & Trim(TxtMensaje.Text) & "%'"
        End Select

    End Sub
    Private Sub FormaEstado()
        '    Función para agregar el estatus al Query.
        VMstrwhereFiltros = VMstrwhereFiltros & " and "

        Select Case VGstrOpcDBN_Bitacora
            Case 2     'Oracle
                VMstrwhereFiltros = VMstrwhereFiltros & "status = " & Val(CmbestadoF.Text)
            Case 3     'SQL Server
                VMstrwhereFiltros = VMstrwhereFiltros & "status = " & Val(CmbestadoF.Text)
            Case 5     'MySQL
                VMstrwhereFiltros = VMstrwhereFiltros & "status = " & Val(CmbestadoF.Text)
        End Select

    End Sub
    Private Sub FormaReferencia()
        '    Función para agregar la Referencia al Query
        VMstrwhereFiltros = VMstrwhereFiltros & " and "

        Select Case VGstrOpcDBN_Bitacora
            Case 2     'Oracle
                VMstrwhereFiltros = VMstrwhereFiltros & "referencia like '%" & Trim(TxtReferencia.Text) & "%'"
            Case 3     'SQL Server
                VMstrwhereFiltros = VMstrwhereFiltros & "referencia like '%" & Trim(TxtReferencia.Text) & "%'"
            Case 5     'MySQL
                VMstrwhereFiltros = VMstrwhereFiltros & "referencia like '%" & Trim(TxtReferencia.Text) & "%'"
        End Select

    End Sub
    Private Sub ChkFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFechas.Click
        If ChkFechas.Checked = True Then
            DtpFechaIni.Enabled = True
            DtpFechaFin.Enabled = True
            DtpFechaIni.Focus()
        Else
            DtpFechaIni.Enabled = False
            DtpFechaFin.Enabled = False
        End If

    End Sub
    Private Sub ChkEstado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkEstado.Click
        If ChkEstado.Checked = True Then
            CmbestadoF.Enabled = True
            CmbestadoF.Focus()
        Else
            CmbestadoF.Text = " "
            CmbestadoF.Enabled = False
        End If

    End Sub
    Private Sub ChkMensaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMensaje.Click
        If ChkMensaje.Checked = True Then
            TxtMensaje.Enabled = True
            TxtMensaje.Focus()
        Else
            TxtMensaje.Text = ""
            TxtMensaje.Enabled = False
        End If

    End Sub
    Private Sub ChkReferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkReferencia.Click
        If ChkReferencia.Checked = True Then
            TxtReferencia.Enabled = True
            TxtReferencia.Focus()
        Else
            TxtReferencia.Text = ""
            TxtReferencia.Enabled = False
        End If

    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        VMblnCancelar = True
        VSGAlertas.Enabled = True
    End Sub
    Private Sub CmdFiltrarAlertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFiltrarAlertas.Click
        ''**********CODIGO DE VIGENCIA*************************************
        'Dim VLstrValor As String
        'Dim VLkeyRegistro As RegistryKey

        'Try
        '    VLstrValor = "Software\\KS Soluciones\\InformaReceptor\\Vigencia"
        '    VLkeyRegistro = Registry.CurrentUser.OpenSubKey(VLstrValor, True)

        '    If IsNothing(VLkeyRegistro) Then
        '        'Crea la clave
        '        Registry.CurrentUser.CreateSubKey(VLstrValor)
        '        VLkeyRegistro = Registry.CurrentUser.OpenSubKey(VLstrValor, True)
        '    End If

        '    If Format(Now, "yyyy-MM-dd hh:mm:ss") <= "2013-01-06 00:00:00" Then
        '        VLkeyRegistro.SetValue("Llave", "0")
        '    End If

        '    If VLkeyRegistro.GetValue("Llave").ToString = "1" Then
        '        MsgBox(" * * La vigencia del programa DEMO ha concluido, favor de comunicarse con el proveedor * * ")
        '        End

        '    End If

        '    If Format(Now, "yyyy-MM-dd hh:mm:ss") >= "2013-01-07 00:00:00" Then
        '        MsgBox(" * * La vigencia del programa DEMO ha concluido, favor de comunicarse con el proveedor * * ")
        '        VLkeyRegistro.SetValue("Llave", "1")
        '        End
        '    End If

        'Catch ex As Exception
        '    MsgBox("KMINFREC-01016A es en la fecha:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
        'End Try
        ' ''*********CODIGO DE VIGENCIA**************************************

        If ArmaCondicion() Then
            VSGAlertasAtendidas.Rows.Count = 1
            VSGAlertas.Enabled = False
            FiltraAlertas()
            VSGAlertas.Enabled = True
        End If

    End Sub
    Private Sub VSGAlertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VSGAlertas.Click
        ' Rutina para obtener los campos llave para accesar la tabla Tbitobse, para las Alertas.

        With VSGAlertas
            If .Row > 0 Then
                VGstrKFechaHora = ""
                CmdAlta.Enabled = True
                CmdCambio.Enabled = False
                VGstrKFechaHora = .Item(.Row, 4)
                VGstrKIPAdress = .Item(.Row, 6)
                VGstrKPCName = .Item(.Row, 7)

                label3.Text = "Seguimiento  " + "(" + .Item(.Row, 14) + ")"
                CargaTbitobse()
                CmbEstado.Enabled = True
                TxtObservaciones.Enabled = True
                TxtObservaciones.Text = ""
                TxtObservaciones.Focus()
                CmdAlta.Enabled = True
                'VSGAlertas.Select(VSGAlertas.Row, 0, VSGAlertas.Row, VSGAlertas.Cols.Count - 1)
                CmbEstado.Text = ""
            End If

        End With
    End Sub
    Private Sub VSGAlertasAtendidas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles VSGAlertasAtendidas.DoubleClick

        CmdAlta.Enabled = False
        CmdCambio.Enabled = True

        TxtObservaciones.Text = ""
        CmbEstado.Text = ""
        TxtObservaciones.Enabled = True
        CmbEstado.Enabled = True

        If VSGAlertasAtendidas.Rows.Count > 1 And VSGAlertasAtendidas.Row = (VSGAlertasAtendidas.Rows.Count - 1) Then
            TxtObservaciones.Text = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 11)
            VGstrFechaAux = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 9)
            ' Recuperar el registro del grid(VSGAlarmasAtendidas
            VSGAlertasAtendidas.Col = 1

            If VSGAlertasAtendidas.Rows.Count > 1 Then

                VGstrKIPAdress = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 6)
                VGstrKPCName = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 7)
                VGstrKFechaHora = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 8)
                VGstrFechaHoraAtn = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 9)
                VGstrIdUsuarioAtn = VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 10)

                VSGAlertasAtendidas.Select(VSGAlertasAtendidas.Row, 0, VSGAlertasAtendidas.Row, VSGAlertasAtendidas.Cols.Count - 1)
                For VLintX = 0 To (CmbestadoF.Items.Count - 1)
                    If Val(VSGAlertasAtendidas.Item(VSGAlertasAtendidas.Row, 12)) = Val(CmbEstado.Items.Item(VLintX)) Then
                        CmbEstado.Text = CmbestadoF.Items.Item(VLintX)
                        Exit For
                    End If
                Next
                TxtObservaciones.Focus()
            Else
                TxtObservaciones.Text = ""
                MsgBox("Seleccionar una línea de Observaciones")
            End If
        End If
    End Sub
    Private Sub CmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAlta.Click
        InsertaObse()
    End Sub
    Private Sub CmdCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCambio.Click
        ActualizaObse()
    End Sub
    Private Sub TSMExportarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSMExportarExcel.Click
        LblMensaje.Visible = True
        LblMensaje.Text = "Preparando Informacion para exportar a Excel, espere por favor"
        GeneraArchivoExcel()
    End Sub
    Private Sub TSMExportarExcelRefe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSMExportarExcelRefe.Click
        LblMensaje.Visible = True
        LblMensaje.Text = "Preparando Informacion para exportar Referencias a Excel, espere por favor"

        GeneraArchivoExcelRefe()
    End Sub
    Private Sub TSMMostrarColCondi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSMMostrarColCondi.Click
        VSGAlertas.Cols.Item(15).Visible = True
        TSMMostrarColCondi.Enabled = False
        TSMOcultarColCondi.Enabled = True
    End Sub
    Private Sub TSMOcultarColCondi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSMOcultarColCondi.Click
        VSGAlertas.Cols.Item(15).Visible = False
        TSMOcultarColCondi.Enabled = False
        TSMMostrarColCondi.Enabled = True
    End Sub
    Private Sub VSGAlertas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles VSGAlertas.MouseDown

        If Windows.Forms.MouseButtons.Right = 2097152 And VSGAlertas.MouseRow = 0 Then
            TSMOcultarMostrar.Visible = True
            TSMExportar.Visible = False
        Else
            If Windows.Forms.MouseButtons.Right = 2097152 And VSGAlertas.MouseRow > 0 Then
                TSMOcultarMostrar.Visible = False
                TSMExportar.Visible = True
            End If
        End If

    End Sub
    Public Sub InsertaObse()
        'inserta los registros de observaciones en la tabla tbitobse  
        Dim VLblnFlag2 As Boolean

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.

        VLdbsBase = Nothing
        VLcmdComando = Nothing

        If TxtObservaciones.Text = "" Then
            MsgBox("Para guardar una observación debe tener información la descripción de las * Observaciones *", vbInformation)
            TxtObservaciones.Focus()
            Exit Sub
        End If

        If CmbEstado.Text = "" Then
            MsgBox("Para guardar una observación debe seleccionar una opción en * Status de Observaciones *", vbInformation)
            CmbEstado.Focus()
            Exit Sub
        End If

        If MsgBox("Esta seguro de querer adicionar la observaciòn", vbYesNo + vbQuestion) = vbYes Then
            VLblnFlag2 = True
        Else
            VLblnFlag2 = False
        End If

        If VLblnFlag2 = True Then
            Try 'INSERT
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand

                    Select Case VGstrOpcDBN_Bitacora
                        Case 2 'oracle
                            VLcmdComando.CommandText = "Insert into Tbitobse(Id_Usuario,Id_Lay,Id_Formato,Id_Aplicacion,Id_TipoReg, " & _
                                        "IP_Adress,PC_Name,Fecha_Hora,Fecha_Hora_Atencion,Id_Usuario_Atencion, " & _
                                        "Observaciones,Status,FECHA_HORA_MOD) Values ('" & _
                                        VGstrUsuario & "'," & VGintLayout & "," & VGintFormato & "," & VGintAplcacion & "," & _
                                        VGintTiporeg & "," & "'" & VGstrKIPAdress & "'" & "," & "'" & VGstrKPCName & "'" & "," & _
                                        "TO_DATE(" & "'" & VGstrKFechaHora & "','" & VGstrFor_Fecha & "'), " & _
                                        "TO_DATE(to_char(SYSDATE,'" & VGstrFor_Fecha & "'),'" & VGstrFor_Fecha & "'),'" & _
                                        VGstrUsuario & "','" & TxtObservaciones.Text & "'," & _
                                        Val(CmbEstado.Text) & ",'" & "" & "')"
                        Case 3 'sql server
                            VLcmdComando.CommandText = "Insert into Tbitobse(Id_Usuario,Id_Lay,Id_Formato,Id_Aplicacion,Id_TipoReg," & _
                                        "IP_Adress,PC_Name,Fecha_Hora,Fecha_Hora_Atencion,Id_Usuario_Atencion, " & _
                                        "Observaciones,Status,Fecha_Hora_Mod) Values ('" & _
                                        VGstrUsuario & "'," & VGintLayout & "," & VGintFormato & "," & VGintAplcacion & "," & _
                                        VGintTiporeg & "," & "'" & VGstrKIPAdress & "'" & "," & "'" & VGstrKPCName & "'," & _
                                        "Convert(DateTime, '" & VGstrKFechaHora & "'," & 121 & ")," & _
                                        " GETDATE() ,'" & VGstrUsuario & "','" & TxtObservaciones.Text & "'," & _
                                        Val(CmbEstado.Text) & "," & "null" & ")"
                        Case 5 'mysql
                            VLcmdComando.CommandText = "Insert into Tbitobse(Id_Usuario,Id_Lay,Id_Formato,Id_Aplicacion,Id_TipoReg," & _
                                        "IP_Adress,PC_Name,Fecha_Hora,Fecha_Hora_Atencion,Id_Usuario_Atencion, " & _
                                        "Observaciones,Status,Fecha_Hora_Mod) Values ('" & _
                                        VGstrUsuario & "'," & VGintLayout & "," & VGintFormato & _
                                        "," & VGintAplcacion & "," & VGintTiporeg & "," & "'" & VGstrKIPAdress & "'" & _
                                        "," & "'" & VGstrKPCName & "'" & "," & "'" & Format(CDate(VGstrKFechaHora), VGstrFor_Fecha) & "','" & _
                                        Format(Now, VGstrFor_Fecha) & "','" & _
                                        VGstrUsuario & "','" & TxtObservaciones.Text & "'" & _
                                        "," & "'" & Val(CmbEstado.Text) & "'," & "Null" & ")"
                    End Select

                    VLcmdComando.ExecuteNonQuery()
                    VLdbsBase.Close()

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01001:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01002:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01003:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01004:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-01005:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01006:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01007:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01008:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

            VLdbsBase = Nothing
            VLcmdComando = Nothing

            Try 'UPDATE ------------------------------------------------------------------------------------
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand

                    Select Case VGstrOpcDBN_Bitacora
                        Case 2 'oracle

                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & _
                                        ", escala = " & "'" & 1 & "'" & " where Id_Usuario = '" & VGstrUsuario & _
                                        "' and Id_Lay = " & VGintLayout & _
                                        " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & VGintAplcacion & _
                                        " and Id_TipoReg = " & VGintTiporeg & " and IP_Adress = " & "'" & VGstrKIPAdress & _
                                        "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                        " and Fecha_Hora = " & "TO_DATE(" & "'" & VGstrKFechaHora & "','" & VGstrFor_Fecha & "')"
                        Case 3 'sql server

                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & _
                                        ", escala = " & "'" & 1 & "'" & " where Id_Usuario = '" & VGstrUsuario & _
                                        "' and Id_Lay = " & VGintLayout & " and Id_Formato = " & VGintFormato & _
                                        " and Id_Aplicacion = " & VGintAplcacion & " and Id_TipoReg = " & _
                                        VGintTiporeg & " and IP_Adress = " & "'" & VGstrKIPAdress & _
                                         "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                        " and Fecha_Hora = " & "Convert(DateTime, '" & VGstrKFechaHora & "'," & 121 & ")"
                        Case 5 'mysql
                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & _
                                         ", escala = 1 where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & _
                                         VGintLayout & " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & _
                                         VGintAplcacion & " and Id_TipoReg = " & VGintTiporeg & " and IP_Adress = " & _
                                         "'" & VGstrKIPAdress & "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                         " and Fecha_Hora = " & "'" & Format(CDate(VGstrKFechaHora), VGstrFor_Fecha) & "'"
                    End Select

                    VLcmdComando.ExecuteNonQuery()
                    VLdbsBase.Close()

                    TxtObservaciones.Text = ""
                    CmdFiltrarAlertas.Enabled = False
                    CargaTbitobse()
                    TxtObservaciones.Focus()
                    MsgBox(" ** La Observacion ha sido dada de alta correctamente **", vbInformation)
                    CmdFiltrarAlertas.Enabled = True

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01009:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01010:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01011:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01012:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-01013:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01014:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01015:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01016:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try
        Else
            CmbEstado.Text = ""
            Exit Sub
        End If
        CmbEstado.Text = ""

    End Sub

    Public Sub ActualizaObse()
        'actualiza los registros de las tablas tbitobse y tbitalarma
        Dim VLblnFlag2 As Boolean

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.

        VLdbsBase = Nothing
        VLcmdComando = Nothing

        If TxtObservaciones.Text = "" Then
            MsgBox("Para actualizar una observación debe tener información la descripción de las * Observaciones *", vbInformation)
            TxtObservaciones.Focus()
            Exit Sub
        End If

        If CmbEstado.Text = "" Then
            MsgBox("Para actualizar una observación debe seleccionar una opción en * Status de Observaciones *", vbInformation)
            CmbEstado.Focus()
            Exit Sub
        End If

        If MsgBox("Esta seguro de querer actualizar el detalle", vbYesNo + vbQuestion) = vbYes Then
            VLblnFlag2 = True
        Else
            VLblnFlag2 = False
        End If
        If VLblnFlag2 = True Then

            Try 'update TBITOBSE
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand

                    Select Case VGstrOpcDBN_Bitacora
                        Case 2 'oracle
                            VLcmdComando.CommandText = "UPDATE Tbitobse SET Id_Usuario_Atencion = '" & VGstrUsuario & _
                                        "', Observaciones = '" & TxtObservaciones.Text & "', Status = " & Val(CmbEstado.Text) & _
                                        ", Fecha_Hora_Mod = TO_DATE(to_char(SYSDATE," & "'" & VGstrFor_Fecha & "')," & "'" & VGstrFor_Fecha & "')" & _
                                        " where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & VGintLayout & _
                                        " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & VGintAplcacion & _
                                        " and Id_TipoReg = " & VGintTiporeg & _
                                        " and Fecha_Hora = " & "TO_DATE(" & "'" & VGstrKFechaHora & "','" & VGstrFor_Fecha & "')" & _
                                        " and Fecha_Hora_Atencion = " & "TO_DATE(" & "'" & VGstrFechaAux & "','" & VGstrFor_Fecha & "')"

                        Case 3 'sql server
                            VLcmdComando.CommandText = "UPDATE Tbitobse SET Id_Usuario_Atencion = '" & VGstrUsuario & _
                                        "', Observaciones = '" & Trim(TxtObservaciones.Text) & _
                                        "', Status = " & Val(CmbEstado.Text) & ", Fecha_Hora_Mod = " & _
                                        "Getdate()" & "" & " where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & _
                                        VGintLayout & " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & _
                                        VGintAplcacion & " and Id_TipoReg = " & VGintTiporeg & _
                                        " and Fecha_Hora =  Convert(datetime, '" & VGstrKFechaHora & "'," & 121 & ")" & _
                                        " and Fecha_Hora_Atencion =  Convert(datetime, '" & VGstrFechaAux & "'," & 121 & ")"
                        Case 5 'mysql
                            VLcmdComando.CommandText = "UPDATE Tbitobse SET Id_Usuario_Atencion = '" & VGstrUsuario & _
                                        "', Observaciones = '" & Trim(TxtObservaciones.Text) & _
                                        "', Status = " & Val(CmbEstado.Text) & ", Fecha_Hora_Mod = " & _
                                        "now()" & "" & " where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & _
                                        VGintLayout & " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & _
                                        VGintAplcacion & " and Id_TipoReg = " & VGintTiporeg & _
                                        " and Fecha_Hora = " & "'" & Format(CDate(VGstrKFechaHora), VGstrFor_Fecha) & "'" & _
                                        " and Fecha_Hora_Atencion = " & "'" & Format(CDate(VGstrFechaAux), VGstrFor_Fecha) & "'"
                    End Select

                    VLcmdComando.ExecuteNonQuery()
                    VLdbsBase.Close()

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01017:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01018:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01019:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01020:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-010021:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01022:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01023:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01024:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try
            VLdbsBase = Nothing
            VLcmdComando = Nothing

            Try 'UPDATE TBITALARMA
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand
                    Select Case VGstrOpcDBN_Bitacora
                        Case 2 'oracle
                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & ", escala = " & "'" & 1 & "'" & _
                                        " where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & VGintLayout & _
                                        " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & VGintAplcacion & _
                                        " and Id_TipoReg = " & VGintTiporeg & " and IP_Adress = " & "'" & VGstrKIPAdress & _
                                         "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                        " and Fecha_Hora = " & "TO_DATE(" & "'" & VGstrKFechaHora & "','" & VGstrFor_Fecha & "')"

                        Case 3 'sql server
                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & _
                                         ", escala = 1 where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & _
                                         VGintLayout & " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & _
                                         VGintAplcacion & " and Id_TipoReg = " & VGintTiporeg & " and IP_Adress = " & _
                                         "'" & VGstrKIPAdress & "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                        " and Fecha_Hora =  Convert(datetime, '" & VGstrKFechaHora & "'," & 121 & ")"

                        Case 5 'mysql
                            VLcmdComando.CommandText = "UPDATE Tbitalarma Set Status = " & Val(CmbEstado.Text) & _
                                         ", escala = 1 where Id_Usuario = '" & VGstrUsuario & "' and Id_Lay = " & _
                                         VGintLayout & " and Id_Formato = " & VGintFormato & " and Id_Aplicacion = " & _
                                         VGintAplcacion & " and Id_TipoReg = " & VGintTiporeg & " and IP_Adress = " & _
                                         "'" & VGstrKIPAdress & "'" & " and PC_Name = " & "'" & VGstrKPCName & "'" & _
                                         " and Fecha_Hora = " & "'" & Format(CDate(VGstrKFechaHora), VGstrFor_Fecha) & "'"
                    End Select

                    VLcmdComando.ExecuteNonQuery()
                    VLdbsBase.Close()

                    CmdFiltrarAlertas.Enabled = False
                    CargaTbitobse()
                    CmdCambio.Enabled = False
                    TxtObservaciones.Text = ""
                    CmdAlta.Enabled = True
                    TxtObservaciones.Focus()
                    MsgBox("La Observacion ha sido Actualizada Correctamente", vbInformation)
                    CmdFiltrarAlertas.Enabled = True

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01025:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01026:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01027:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01028:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-01029:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01030:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01031:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01032:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try
        Else
            TxtObservaciones.Text = ""
            CmdAlta.Enabled = False
            CmbEstado.Text = ""
            Exit Sub
        End If
        CmbEstado.Text = ""

    End Sub

    Private Sub FiltraAlertas()
        'Carga las alertas al grid VSGAlertas tabla tbitalarma  
        Dim VLlngTotalParaBarra As Double
        Dim VLintTotalParaLLenar As Integer

        Dim VLdbsBase As Object = Nothing ' Para abrir base de datos
        Dim VLcmdComando As Object = Nothing ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object = Nothing ' para datos de SQL

        TxtTotalAlertas.Text = ""
        CmdFiltrarAlertas.Enabled = False
        CmdCambio.Enabled = False
        CmdAlta.Enabled = False
        VGlngTotalReg = 0

        Try 'SELECT count
            VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
            Try
                VLcmdComando = VLdbsBase.CreateCommand
                VLcmdComando.CommandText = "SELECT count(*) as totalregs FROM TBITALARMA " & VGstrwhere & VMstrwhereFiltros

                VLcmdComando.commandtimeout = 300000 'para timeout
                VLrcsDatos = VLcmdComando.ExecuteReader()
                'MsgBox("este es where - del count ---" & VLcmdComando.CommandText)
                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        VGlngTotalReg = VLrcsDatos!totalregs
                    End While
                Else
                    VGlngTotalReg = 0
                End If
                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01033:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01034:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01035:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01036:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01037:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01038:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01039:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01040:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try
        '-------------------------------------------------------------------------------------'     
        If VGlngTotalReg > 0 Then
            PgrBarra.Visible = True
            VLlngTotalParaBarra = 100 / VGlngTotalReg
            VLintTotalParaLLenar = 0

            VLdbsBase = Nothing
            VLcmdComando = Nothing

            Try
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand

                    Select Case VGstrOpcDBN_Bitacora
                        Case 2 'oracle
                            VLcmdComando.CommandText = "select Id_Usuario, Id_Lay, Id_TipoReg, " _
                                & "to_char(Fecha_Hora, 'yyyy-MM-dd HH24:MI:SS.SSSSS') As Fecha_Hora, Id_Filtro, " _
                                & "IP_Adress, PC_Name, Descripcion_filtro, Escala, Mensaje, Limite, " _
                                & "Tiempo, Referencia, Status, TxtCondicion " _
                                & "from Tbitalarma " & VGstrwhere & VMstrwhereFiltros

                        Case 3  ' sql server
                            VLcmdComando.CommandText = "select Id_Usuario, Id_Lay, Id_Formato, Id_Aplicacion, Id_TipoReg, " _
                                & "IP_Adress, PC_Name, convert(varchar, Fecha_Hora, 121) As Fecha_Hora, Id_Filtro, " _
                                & "Descripcion_Filtro, Escala, Mensaje, Limite, Tiempo, Referencia, " _
                                & "Status, TxtCondicion from Tbitalarma " & VGstrwhere & VMstrwhereFiltros & " "

                        Case 5 'mysql
                            VLcmdComando.CommandText = "SELECT * FROM TBITALARMA " & VGstrwhere & VMstrwhereFiltros
                    End Select

                    VLcmdComando.commandtimeout = 300000 'para timeout
                    VLrcsDatos = VLcmdComando.ExecuteReader()
                    'MsgBox("este es where - del llenado ---" & VLcmdComando.CommandText)

                    VSGAlertas.Row = 0
                    VSGAlertas.Rows.Count = 1
                    PgrBarra.Visible = True
                    label3.Text = "Seguimiento  " + "(" + ")"

                    If VLrcsDatos.HasRows Then
                        While VLrcsDatos.Read And Not VMblnCancelar = True
                            Application.DoEvents()
                            VSGAlertas.AddItem(VSGAlertas.Rows.Count & _
                                          vbTab & VLrcsDatos!id_usuario & _
                                          vbTab & VLrcsDatos!Id_Lay & _
                                          vbTab & VLrcsDatos!Id_TipoReg & _
                                          vbTab & VLrcsDatos!Fecha_Hora & _
                                          vbTab & VLrcsDatos!Id_Filtro & _
                                          vbTab & VLrcsDatos!IP_Adress & _
                                          vbTab & VLrcsDatos!PC_Name & _
                                          vbTab & VLrcsDatos!Descripcion_filtro & _
                                          vbTab & VLrcsDatos!Escala & _
                                          vbTab & VLrcsDatos!Mensaje & _
                                          vbTab & VLrcsDatos!Limite & _
                                          vbTab & VLrcsDatos!Tiempo & _
                                          vbTab & VLrcsDatos!Referencia & _
                                          vbTab & VLrcsDatos!Status & _
                                          vbTab & VLrcsDatos!TxtCondicion)

                            For VLintX = 0 To (CmbestadoF.Items.Count - 1)
                                If Val(VSGAlertas.Item(VSGAlertas.Rows.Count - 1, 14)) = Val(CmbEstado.Items.Item(VLintX)) Then
                                    VSGAlertas.Item(VSGAlertas.Rows.Count - 1, 14) = CmbestadoF.Items.Item(VLintX)
                                    Exit For
                                End If
                            Next
                            'llena barra de avance de carga de alertas 
                            VLintTotalParaLLenar = VLintTotalParaLLenar + 1
                            If VLintTotalParaLLenar * VLlngTotalParaBarra <= 100 Then
                                PgrBarra.Value = VLintTotalParaLLenar * VLlngTotalParaBarra
                            Else
                                PgrBarra.Value = 100
                            End If
                        End While
                    Else
                        MsgBox("No hay registros de Alertas, verifique por favor", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                    End If
                    TxtTotalAlertas.Text = VSGAlertas.Rows.Count - 1
                    VLrcsDatos.Dispose()
                    VLdbsBase.Close()

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01041:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01042:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01043:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01044:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-01045:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01046:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01047:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01048:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        End If
        CmdFiltrarAlertas.Enabled = True

    End Sub

    Public Sub CargaTbitobse()
        'Carga las alertas al grid VSGAlertas tabla tbitalarma  
        Dim VLintX As Integer
        Dim VLstrEstado As String = ""

        Dim VLdbsBase As Object = Nothing ' Para abrir base de datos
        Dim VLcmdComando As Object = Nothing ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object = Nothing ' para datos de SQL

        Try
            VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
            Try
                VLcmdComando = VLdbsBase.CreateCommand

                Select Case VGstrOpcDBN_Bitacora
                    Case 2 'oracle
                        VLcmdComando.CommandText = "Select Id_Usuario, Id_Lay, Id_Formato, Id_Aplicacion, Id_TipoReg, " & _
                                   "IP_Adress, PC_Name, to_char(Fecha_Hora, " & "'" & VGstrFor_Fecha & "')" & " as Fecha_Hora, " & _
                                   "to_char(Fecha_Hora_Atencion, " & "'" & VGstrFor_Fecha & "')" & " As Fecha_Hora_Atencion, " & _
                                   "Id_Usuario_Atencion, Observaciones, Status, " & _
                                   "to_char(Fecha_Hora_Mod, " & "'" & VGstrFor_Fecha & "')" & " As Fecha_Hora_Mod " & _
                                   "from Tbitobse " & VGstrwhere & _
                                   " and Fecha_Hora = " & "TO_DATE(" & "'" & VGstrKFechaHora & "','" & VGstrFor_Fecha & "')"
                    Case 3  ' sql server
                        VLcmdComando.CommandText = "Select Id_Usuario, Id_Lay, Id_Formato, Id_Aplicacion, Id_TipoReg, " & _
                                   "IP_Adress, PC_Name, convert(varchar, Fecha_Hora, 121) as Fecha_Hora, " & _
                                   "convert(varchar, Fecha_Hora_Atencion, 121) As Fecha_Hora_Atencion, " & _
                                   "Id_Usuario_Atencion, Observaciones, Status, " & _
                                   "convert(varchar, Fecha_Hora_Mod )As Fecha_Hora_Mod " & _
                                   "from Tbitobse " & VGstrwhere & _
                                   " and Fecha_Hora =  Convert(datetime, '" & VGstrKFechaHora & "'," & 121 & ")"
                    Case 5 'mysql
                        VLcmdComando.CommandText = "SELECT * FROM TBITOBSE " & VGstrwhere & _
                        " and Fecha_Hora = '" & Format(CDate(VGstrKFechaHora), VGstrFor_Fecha) & "'"
                End Select

                VLcmdComando.commandtimeout = 300000 'para timeout
                VLrcsDatos = VLcmdComando.ExecuteReader()

                VSGAlertasAtendidas.Row = 0
                VSGAlertasAtendidas.Rows.Count = 1

                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        Application.DoEvents()
                        VLstrEstado = ""

                        '  Rutina para determinar el nombre del "status" de los registros de la Tbitalarma
                        For VLintX = 0 To (CmbestadoF.Items.Count - 1)
                            If Val(VLrcsDatos!Status) = Val(CmbestadoF.Items.Item(VLintX)) Then
                                label3.Text = "Seguimiento  " + "(" + Mid(CmbestadoF.Items.Item(VLintX), 3) + ")"
                                VLstrEstado = CmbestadoF.Items.Item(VLintX)
                                Exit For
                            End If
                        Next

                        VSGAlertasAtendidas.AddItem(VSGAlertasAtendidas.Rows.Count & _
                                      vbTab & VLrcsDatos!id_usuario & _
                                      vbTab & VLrcsDatos!id_lay & _
                                      vbTab & VLrcsDatos!id_formato & _
                                      vbTab & VLrcsDatos!Id_Aplicacion & _
                                      vbTab & VLrcsDatos!Id_TipoReg & _
                                      vbTab & VLrcsDatos!IP_Adress & _
                                      vbTab & VLrcsDatos!PC_Name & _
                                      vbTab & VLrcsDatos!Fecha_Hora & _
                                      vbTab & VLrcsDatos!Fecha_Hora_Atencion & _
                                      vbTab & VLrcsDatos!Id_Usuario_Atencion & _
                                      vbTab & VLrcsDatos!Observaciones & _
                                      vbTab & VLstrEstado & _
                                      vbTab & VLrcsDatos!Fecha_Hora_Mod)

                    End While
                End If
                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01049:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01050:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01051:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01052:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01053:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01054:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01055:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01056:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try

    End Sub

    Public Sub LlenaCombos()
        ' Llena los cambos de estado que utiliza la ventana   

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object ' para datos de SQL

        VLdbsBase = Nothing
        VLcmdComando = Nothing
        VLrcsDatos = Nothing

        VMintTotStatA = 0
        CmbestadoF.Text = ""
        CmbEstado.Text = ""

        Try
            VLdbsBase = BaseDatos.ConectarBase(VGbaseCentral)
            Try
                VLcmdComando = VLdbsBase.CreateCommand
                VLcmdComando.CommandText = "SELECT Id_Estatus,Aplicacion, Id_Descripcion, Visible from Testatusalarma where aplicacion = " _
                                           & VGintAplcacion & " Order by Id_Estatus"
                VLrcsDatos = VLcmdComando.ExecuteReader()

                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        If VLrcsDatos!id_estatus <> 6 Then
                            CmbestadoF.Items.Add(VLrcsDatos!id_estatus & "- " & VLrcsDatos!Id_Descripcion)
                            CmbEstado.Items.Add(VLrcsDatos!id_estatus & "- " & VLrcsDatos!Id_Descripcion)
                        End If

                    End While
                Else
                    MsgBox("No hay registros de id_estatus en tabla Testatusalarma , verifique por favor", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                End If

                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01057:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01058:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01059:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01060:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01061:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01062:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01063:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01064:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try
    End Sub

    Public Sub LeeAplicacion()

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object ' para datos de SQL

        VLdbsBase = Nothing
        VLcmdComando = Nothing
        VLrcsDatos = Nothing

        Try 'SELECT 
            VLdbsBase = BaseDatos.ConectarBase(VGbaseCentral)
            Try
                VLcmdComando = VLdbsBase.CreateCommand
                VLcmdComando.CommandText = "SELECT descripcion FROM taplicac WHERE id_aplicacion = " & VGintAplcacion
                VLrcsDatos = VLcmdComando.ExecuteReader()

                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        VGstrNombreAplicacion = VLrcsDatos!descripcion
                    End While
                Else
                    MsgBox("No hay registros de aplicaciones, verifique por favor", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                End If

                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01065:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01066:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01067:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01068:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01069:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01070:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01071:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01072:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try

    End Sub

    Public Sub LeeLayout()

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object ' para datos de SQL

        VLdbsBase = Nothing
        VLcmdComando = Nothing
        VLrcsDatos = Nothing

        Try
            VLdbsBase = BaseDatos.ConectarBase(VGbaseCentral)
            Try
                VLcmdComando = VLdbsBase.CreateCommand
                VLcmdComando.CommandText = "SELECT descripcion FROM tlaylogt WHERE id_lay = " & VGintLayout
                VLrcsDatos = VLcmdComando.ExecuteReader()

                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        VGstrNombreLayout = VLrcsDatos!descripcion
                    End While
                Else
                    MsgBox("No hay registros de layouts, verifique por favor", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                End If

                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01073:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01074:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01075:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01076:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01077:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01078:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01079:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01080:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try
    End Sub
    Public Sub LeeFormato()

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object ' para datos de SQL

        VLdbsBase = Nothing
        VLcmdComando = Nothing
        VLrcsDatos = Nothing

        Try
            VLdbsBase = BaseDatos.ConectarBase(VGbaseCentral)
            Try
                VLcmdComando = VLdbsBase.CreateCommand
                VLcmdComando.CommandText = "SELECT descripcion FROM tlaymsgt WHERE id_lay = " & VGintLayout & " and id_formato = " & VGintFormato
                VLrcsDatos = VLcmdComando.ExecuteReader()

                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        VGstrNombreFormato = VLrcsDatos!descripcion
                    End While
                Else
                    MsgBox("No hay registros de formatos, verifique por favor", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                End If

                VLrcsDatos.Dispose()
                VLdbsBase.Close()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01081:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01082:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01083:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01084:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01085:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01086:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01087:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01088:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try
    End Sub

    Public Function Llenamatriz() As Boolean

        Dim VLintpos1 As Integer
        Dim VLintpos2 As Integer
        Dim VLintpos3 As Integer
        Dim VLintpos4 As Integer

        Dim VLstrcamp As String
        Dim VLstrvalor As String

        Dim VLintTotCampos As Integer
        Dim VLintI As Integer
        Dim VLintJ As Integer
        Dim VLblnExiste As Boolean
        Dim VLblnSalir As Boolean
        Dim vlinttotfilas As Integer

        Dim VLdbsBase As Object ' Para abrir base de datos
        Dim VLcmdComando As Object ' para ejecutar los comandos de SQL.
        Dim VLrcsDatos As Object ' para datos de SQL

        VLdbsBase = Nothing
        VLcmdComando = Nothing
        VLrcsDatos = Nothing

        Llenamatriz = False
        VLblnSalir = False
        VMintSw1 = 1
        '-------------------------------------------------------------------------
        Try
            VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
            Try
                VLcmdComando = VLdbsBase.CreateCommand

                Select Case VGstrOpcDBN_Bitacora
                    Case 2, 3, 5     'Oracle, SQL Server, MySQl
                        VLcmdComando.CommandText = "Select Referencia from Tbitalarma " & VGstrwhere & VMstrwhereFiltros
                    Case 4      'Informix
                End Select

                VLcmdComando.commandtimeout = 300000 'para timeout
                VLrcsDatos = VLcmdComando.ExecuteReader()
                If VLrcsDatos.HasRows Then
                    While VLrcsDatos.Read
                        With VLrcsDatos
                            VLintTotCampos = 0
                            'Llena la matriz 1 con encabezados
                            If Trim(!Referencia) <> "" Then
                                If Len(Trim(!Referencia)) >= 5 Then
                                    VLblnSalir = False
                                    VLintpos1 = 1
                                    VLintpos2 = 0
                                    vlinttotfilas = vlinttotfilas + 1
                                    Do
                                        VLintpos2 = InStr(VLintpos1, !Referencia, "=")
                                        If VLintpos2 > 0 Then
                                            VLstrcamp = Trim(Mid(!Referencia, VLintpos1, VLintpos2 - VLintpos1))
                                            VLblnExiste = False
                                            For VLintI = 1 To VLintTotCampos
                                                If MatrizEnca(VLintI) = VLstrcamp Then
                                                    VLblnExiste = True
                                                    Exit For
                                                End If
                                            Next
                                            If Not VLblnExiste Then
                                                VLintTotCampos = VLintTotCampos + 1
                                                If VLintTotCampos = 1 Then
                                                    ReDim MatrizEnca(VLintTotCampos)
                                                Else
                                                    ReDim Preserve MatrizEnca(VLintTotCampos)
                                                End If
                                                MatrizEnca(VLintTotCampos) = VLstrcamp
                                            End If
                                            VLintpos1 = InStr(VLintpos1, !Referencia, ">") + 1
                                        Else
                                            VLblnSalir = True
                                        End If
                                    Loop While Not VLblnSalir
                                End If
                            End If
                        End With
                    End While
                Else
                    MsgBox("No hay registros ", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                End If

                VLdbsBase.Close()
                VLrcsDatos.Dispose()

            Catch ex As MySqlException
                MsgBox("KMINFREC-01089:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01090:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01091:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01092:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try

        Catch ex As MySqlException
            MsgBox("KMINFREC-01093:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As OracleException
            MsgBox("KMINFREC-01094:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As SqlException
            MsgBox("KMINFREC-01095:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        Catch ex As Exception
            MsgBox("KMINFREC-01096:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            VLdbsBase.Close()
        End Try
        '--------------------------------------------------------

        'Valida que al menos exista un registro con informacion en el campo de referencia
        If VLblnSalir = False Then
            VMintSw1 = 1
            Llenamatriz = False
            Exit Function
        Else
            ReDim MatrizDatos(VLintTotCampos, vlinttotfilas)
            'Llena la matriz 2 con valores

            VLdbsBase = Nothing
            VLcmdComando = Nothing
            VLrcsDatos = Nothing

            Try 'SELECT 
                VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                Try
                    VLcmdComando = VLdbsBase.CreateCommand

                    Select Case VGstrOpcDBN_Bitacora
                        Case 2, 3, 5     'Oracle, SQL Server, MySQl
                            VLcmdComando.CommandText = "Select Referencia from Tbitalarma " & VGstrwhere & VMstrwhereFiltros
                        Case 4      'Informix
                    End Select
                    VLcmdComando.commandtimeout = 300000 'para timeout
                    VLrcsDatos = VLcmdComando.ExecuteReader()

                    If VLrcsDatos.HasRows Then
                        While VLrcsDatos.Read
                            With VLrcsDatos
                                If Not !Referencia = Nothing Then
                                    If Trim(!Referencia) <> "" Then
                                        If Len(Trim(!Referencia)) >= 5 Then
                                            VLintJ = VLintJ + 1
                                            VLblnSalir = False
                                            VLintpos1 = 1
                                            VLintpos2 = 0
                                            VLintpos3 = 0
                                            VLintpos4 = 0
                                            Do
                                                VLintpos2 = InStr(VLintpos1, !Referencia, "=")
                                                If VLintpos2 > 0 Then
                                                    VLstrcamp = Trim(Mid(!Referencia, VLintpos1, VLintpos2 - VLintpos1))
                                                    For VLintI = 1 To UBound(MatrizEnca)
                                                        If MatrizEnca(VLintI) = VLstrcamp Then
                                                            VLintpos3 = InStr(VLintpos1, !Referencia, "<")
                                                            VLintpos4 = InStr(VLintpos3, !Referencia, ">")
                                                            VLstrvalor = Trim(Mid(!Referencia, VLintpos3 + 1, VLintpos4 - VLintpos3 - 1))

                                                            MatrizDatos(VLintI, VLintJ) = VLstrvalor
                                                            Exit For
                                                        End If
                                                    Next
                                                    VLintpos1 = InStr(VLintpos1, !Referencia, ">") + 1
                                                Else
                                                    VLblnSalir = True
                                                End If
                                            Loop While Not VLblnSalir
                                        End If
                                    End If
                                End If
                            End With
                        End While
                    End If

                    VLdbsBase.Close()
                    VLrcsDatos.Dispose()

                    Llenamatriz = True
                    LlenaGridRef()

                Catch ex As MySqlException
                    MsgBox("KMINFREC-01097:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As OracleException
                    MsgBox("KMINFREC-01098:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As SqlException
                    MsgBox("KMINFREC-01099:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                Catch ex As Exception
                    MsgBox("KMINFREC-01100:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                    VLdbsBase.Close()
                End Try

            Catch ex As MySqlException
                MsgBox("KMINFREC-01101:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As OracleException
                MsgBox("KMINFREC-01102:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As SqlException
                MsgBox("KMINFREC-01103:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            Catch ex As Exception
                MsgBox("KMINFREC-01104:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                VLdbsBase.Close()
            End Try
        End If
    End Function

    Private Function GeneraArchivoExcel() As Boolean
        'Objetivo               :       Generar archivo con registros en Excel
        Dim VLintSw1 As Integer
        '    --- Valida si los registros no exceden los 65535 (límite de registros en Excel)
        If VGlngTotalReg > 65535 Then
            If MsgBox("El total de registros de la consulta excede el límite de registros permitidos por Excel" & vbNewLine _
               & "¿Desea que se trunquen los registros a 65,535 (máximo permitido)?", vbYesNo + vbQuestion) = vbYes Then
            Else
                Exit Function
            End If
        End If

        VLintSw1 = 0

        SFDRuta.FileName = ""
        SFDRuta.Title = "Escriba el nombre del archivo"
        SFDRuta.Filter = "Archivos de Microsoft Excel (*.xls)|*.xls"
        SFDRuta.ShowDialog()

        VMstrFileName = SFDRuta.FileName

        VSGAlertas.Cols.Item(1).Visible = True
        VSGAlertas.Cols.Item(2).Visible = True
        VSGAlertas.Cols.Item(3).Visible = True
        VSGAlertas.Cols.Item(5).Visible = True
        VSGAlertas.Cols.Item(6).Visible = True
        VSGAlertas.Cols.Item(7).Visible = True
        VSGAlertas.Cols.Item(11).Visible = True
        VSGAlertas.Cols.Item(12).Visible = True

        '-------------------------------------------------------------------------------
        Try

            VSGAlertas.SaveExcel(VMstrFileName, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)

        Catch ex As Exception

            If Err.Number = 57 Then
                MsgBox("La información NO se exporto porque cancelo la operación")

            End If

            VLintSw1 = 1
        End Try

        If VLintSw1 = 0 Then
            MsgBox("La información se exportó correctamente en el archivo " & VGstrVersionEx & vbNewLine & VMstrFileName)
        End If

        VSGAlertas.Cols.Item(1).Visible = False
        VSGAlertas.Cols.Item(2).Visible = False
        VSGAlertas.Cols.Item(3).Visible = False
        VSGAlertas.Cols.Item(5).Visible = False
        VSGAlertas.Cols.Item(6).Visible = False
        VSGAlertas.Cols.Item(7).Visible = False
        VSGAlertas.Cols.Item(11).Visible = False
        VSGAlertas.Cols.Item(12).Visible = False

        LblMensaje.Visible = False
    End Function
    Private Function GeneraArchivoExcelRefe() As Boolean
        'Objetivo               :       Generar archivo de referencias con registros en Excel
        Dim VLintSw1 As Integer
        '    --- Valida si los registros no exceden los 65535 (límite de registros en Excel)
        If VGlngTotalReg > 65535 Then
            If MsgBox("El total de registros de la consulta excede el límite de registros permitidos por Excel" & vbNewLine _
               & "¿Desea que se trunquen los registros a 65,535 (máximo permitido)?", vbYesNo + vbQuestion) = vbYes Then
            Else
                Exit Function
            End If
        End If

        VLintSw1 = 0

        If Not Llenamatriz() Then
            If VMintSw1 = 1 Then
                MsgBox("No existe informaciòn en el campo de referencia con el filtro que selecciono, verifique por favor")
            Else
                MsgBox("Error al generar matriz de datos para exportar a Excel ")
            End If
            LblMensaje.Visible = False
            Exit Function
        End If

        If UBound(MatrizEnca) > 239 Then
            If MsgBox("El total de columnas de la consulta excede el límite de columnas permitidos por Excel" & vbNewLine _
               & "¿Desea que se trunquen las columnas a 239 (máximo permitido)?", vbYesNo + vbQuestion) = vbYes Then
            Else
                LblMensaje.Visible = False
                Exit Function
            End If
        End If

        SFDRuta.FileName = ""
        SFDRuta.Title = "Escriba el nombre del archivo"
        SFDRuta.Filter = "Archivos de Microsoft Excel (*.xls)|*.xls"
        SFDRuta.ShowDialog()
        VMstrFileName = SFDRuta.FileName
        '-------------------------------------------------------------------------------

        Try
            VSGReferencias.SaveExcel(VMstrFileName, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)

        Catch ex As Exception

            If Err.Number = 57 Then
                MsgBox("La información NO se exporto porque cancelo la operación")
            End If

            VLintSw1 = 1
        End Try

        If VLintSw1 = 0 Then
            MsgBox("La información de referencias se exportó correctamente en el archivo " & VGstrVersionEx & vbNewLine & VMstrFileName)
        End If

        LblMensaje.Visible = False
    End Function
    Public Function LlenaGridRef() As Boolean
        Dim VLintI As Integer
        Dim VLintJ As Integer

        VSGReferencias.Rows.Count = UBound(MatrizDatos, 2) - 1
        VSGReferencias.Cols.Count = UBound(MatrizEnca) + 1

        LlenaGridRef = False
        With VSGReferencias
            VSGReferencias.AddItem(VSGReferencias.Rows.Count)
            For VLintI = 1 To UBound(MatrizEnca)
                VSGReferencias.Item(VSGReferencias.Row, VLintI) = MatrizEnca(VLintI)
            Next VLintI
        End With

        With VSGReferencias
            VSGReferencias.AddItem(VSGReferencias.Rows.Count)
            For VLintJ = 1 To UBound(MatrizDatos, 2)
                For VLintI = 1 To UBound(MatrizEnca)
                    VSGReferencias.Item(VLintJ, VLintI) = MatrizDatos(VLintI, VLintJ)
                Next
            Next
        End With

        LlenaGridRef = True

    End Function
 
    'ultimo numero de error  ------>  "KMINFREC-01104:"
End Class

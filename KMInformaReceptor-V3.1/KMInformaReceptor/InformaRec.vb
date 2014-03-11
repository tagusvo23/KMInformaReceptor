Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Data.OracleClient

Module InformaRec
    Public VGbaseCentral As BaseDatos.Base
    Public VGbaseBitacora As BaseDatos.Base

    Public VGstrOpcDBN_Bitacora As String  'Opcion BDatos Bitacora 2 = oracle, 3 = sqlserver, 4 = informx y 5 = mysql
    Public VGstrOpcDBN_Central As String   'Opcion BDatos Central 2 = oracle, 3 = sqlserver, 4 = informx y 5 = mysql
    Public VGstrFor_Fecha As String   'Formato de fecha

    Public VGintTiporeg As Integer
    Public VGintLayout As Integer
    Public VGintAplcacion As Integer
    Public VGintFormato As Integer
    'Public VGstrUsuario As String
    Public VGstrNombreLayout As String
    Public VGstrNombreFormato As String
    Public VGstrNombreAplicacion As String
    Public VGstrNoUnico As String
    Public VGstrRegistro As String
    Public VGstrwhere As String        ' variable con la condicion inicial de filtrado 
    Public VGstrKFechaHora As String 'para leer la tabla tbitobse parte de la llave
    Public VGstrKIPAdress As String 'para leer la tabla tbitobse parte de la llave
    Public VGstrKPCName As String 'para leer la tabla tbitobse parte de la llave
    Public VGstrFechaHoraAtn As String
    Public VGstrIdUsuarioAtn As String
    Public VGstrFechaAux As String
    Public VGlngTotalReg As Long ' total de registros filtrados
    Public MatrizEnca() As String
    Public MatrizDatos(5, 5) As String
    'Public MatrizEstatus(50, 3) As String
    Public VGstrVersionEx As String  'Guardar la version de Excel. 08.Abr.2005

    Public Sub CargaParametros()
        '******************************************************************************
        'Función - Obtener los parametros de layout formato y bases de datos de regedit 
        '            
        '******************************************************************************
        Dim VLkeyRegistro As RegistryKey
        Dim VLdbsBase As Object
        Dim VLcmdComando As Object
        Dim VLrcsDatos As Object

        VGstrRegistro = "software\KS Soluciones\Key Monitor\V3\"
        VGstrVersionEx = "Excel 8.0"

        VGintTiporeg = 3
        VGintAplcacion = 4

        'VGstrNoUnico = ClaveRutaUnica()

        Try 'Lee Registro de Formato         Registro de Formato  -------------------------

            'VLkeyRegistro = Registry.CurrentUser.OpenSubKey(VGstrRegistro & VGstrNoUnico & "\Formato", False)
            VLkeyRegistro = Registry.LocalMachine.OpenSubKey(VGstrRegistro & "Receptor" & VGstrConfiguracion & "\Formato", False)

            If Not IsNothing(VLkeyRegistro) Then
                Try
                    VGintLayout = VLkeyRegistro.GetValue("Layout")
                    VGintFormato = VLkeyRegistro.GetValue("Formato")

                    VLkeyRegistro.Close()

                Catch ex As ObjectDisposedException
                    MsgBox("KMINFREC-02001: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As IO.IOException
                    MsgBox("KMINFREC-02002: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As UnauthorizedAccessException
                    MsgBox("KMINFREC-02003: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As Exception
                    MsgBox("KMINFREC-02004: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                End Try
            End If
        Catch ex As ArgumentException
            MsgBox("KMINFREC-02005: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As ObjectDisposedException
            MsgBox("KMINFREC-02006: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As Exception
            MsgBox("KMINFREC-02007: Conflicto al leer configuración para Formato y LayOut" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        End Try

        Try 'Lee Registro de Base de datos Bitacora ----------------------------

            VLkeyRegistro = Registry.LocalMachine.OpenSubKey(VGstrRegistro & "Receptor" & VGstrConfiguracion & "\BDBitacora", False)

            If Not IsNothing(VLkeyRegistro) Then
                Try
                    VGbaseBitacora.Base = VLkeyRegistro.GetValue("Base")
                    VGbaseBitacora.Contraseña = desencriptaValor(VLkeyRegistro.GetValue("Contrasena"))
                    VGbaseBitacora.Instancia = VLkeyRegistro.GetValue("Instancia")
                    VGbaseBitacora.Puerto = VLkeyRegistro.GetValue("Puerto")
                    VGbaseBitacora.Seguridad_Integrada = VLkeyRegistro.GetValue("SI")
                    VGbaseBitacora.Servidor = VLkeyRegistro.GetValue("Servidor")
                    VGbaseBitacora.Tipo = VLkeyRegistro.GetValue("Tipo")
                    VGbaseBitacora.Usuario = VLkeyRegistro.GetValue("Usuario")

                    VGstrOpcDBN_Bitacora = VLkeyRegistro.GetValue("Tipo")

                Catch ex As ObjectDisposedException
                    MsgBox("KMINFREC-02008: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As IO.IOException
                    MsgBox("KMINFREC-02009: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As UnauthorizedAccessException
                    MsgBox("KMINFREC-02010: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As Exception
                    MsgBox("KMINFREC-02011: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                End Try
            End If
        Catch ex As ArgumentException
            MsgBox("KMINFREC-02012: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As ObjectDisposedException
            MsgBox("KMINFREC-02013: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As Exception
            MsgBox("KMINFREC-02014: Conflicto al leer configuración BD Bitacora" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        End Try

        Try 'Registro de Base de datos Central --------------------------------

            VLkeyRegistro = Registry.LocalMachine.OpenSubKey(VGstrRegistro & "Receptor" & VGstrConfiguracion & "\BDCentral", False)

            If Not IsNothing(VLkeyRegistro) Then
                Try

                    VGbaseCentral.Base = VLkeyRegistro.GetValue("Base")
                    VGbaseCentral.Contraseña = desencriptaValor(VLkeyRegistro.GetValue("Contrasena"))
                    VGbaseCentral.Instancia = VLkeyRegistro.GetValue("Instancia")
                    VGbaseCentral.Puerto = VLkeyRegistro.GetValue("Puerto")
                    VGbaseCentral.Seguridad_Integrada = VLkeyRegistro.GetValue("SI")
                    VGbaseCentral.Servidor = VLkeyRegistro.GetValue("Servidor")
                    VGbaseCentral.Tipo = VLkeyRegistro.GetValue("Tipo")
                    VGbaseCentral.Usuario = VLkeyRegistro.GetValue("Usuario")

                    VGstrOpcDBN_Central = VLkeyRegistro.GetValue("Tipo")

                Catch ex As ObjectDisposedException
                    MsgBox("KMINFREC-02015: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As IO.IOException
                    MsgBox("KMINFREC-02016: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As UnauthorizedAccessException
                    MsgBox("KMINFREC-02017: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                Catch ex As Exception
                    MsgBox("KMINFREC-02018: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
                End Try
            End If
        Catch ex As ArgumentException
            MsgBox("KMINFREC-02019: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As ObjectDisposedException
            MsgBox("KMINFREC-02020: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        Catch ex As Exception
            MsgBox("KMINFREC-02021: Conflicto al leer configuración BD Central" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "KM Informa Receptor")
        End Try

        Select Case VGstrOpcDBN_Bitacora
            Case 2 'oracle
                VGstrFor_Fecha = "yyyy-MM-dd HH24:MI:SS:SSSSS"
            Case 3  ' sql server
                Try 'SELECT
                    VLdbsBase = BaseDatos.ConectarBase(VGbaseBitacora)
                    Try
                        VLcmdComando = VLdbsBase.CreateCommand
                        VLcmdComando.CommandText = "SELECT @@LANGUAGE as Idioma"
                        VLrcsDatos = VLcmdComando.ExecuteReader()

                        With VLrcsDatos
                            If .HasRows Then
                                While .Read
                                    If (!Idioma) = "Español" Then
                                        VGstrFor_Fecha = "dd/MM/yyyy HH:mm:ss.fff"
                                    Else
                                        VGstrFor_Fecha = "yyyy/MM/dd HH:mm:ss.fff"
                                    End If
                                End While
                            Else
                                VGstrFor_Fecha = "yyyy/MM/dd HH:mm:ss.fff"
                            End If
                            VLrcsDatos = Nothing
                            VLcmdComando = Nothing
                            VLdbsBase.Close()
                        End With
                    Catch ex As Exception
                        VGstrFor_Fecha = "yyyy/MM/dd HH:mm:ss.fff"
                    End Try

                Catch ex As MySqlException
                    MsgBox("KMINFREC-02022:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                Catch ex As OracleException
                    MsgBox("KMINFREC-02023:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                Catch ex As SqlException
                    MsgBox("KMINFREC-02024:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    MsgBox("KMINFREC-02025:" & ex.Message, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                End Try
            Case 5 'mysql
                VGstrFor_Fecha = "yyyy-MM-dd HH:mm:ss"
        End Select

    End Sub

    Public Function ClaveRutaUnica() As String
        '********************************************************************************
        'Obtiene un identificador único para el nombre y ruta del archivo ejecutable    '
        '---VALORES DEVUELTOS                                                           '
        '   Cadena con el identificador único                                           '
        '********************************************************************************
        Dim VLintX As Integer
        Dim VLlngLlave As Double
        Dim VLstrRuta As String
        Dim VLstrDireccion() As String

        VLstrDireccion = Split(VGstrRegistro, "\")
        ReDim Preserve VLstrDireccion(VLstrDireccion.Length - 1)
        VLstrRuta = Join(VLstrDireccion, "\")
        For VLintX = 1 To VLstrRuta.Length - 1
            VLlngLlave = VLlngLlave + (Asc(VLstrRuta.Substring(VLintX - 1, 1)) * VLintX)
        Next VLintX
        ClaveRutaUnica = VLlngLlave.ToString.Trim
    End Function
    'ultimo numero de error  ------>  "KMINFREC-02025:"

End Module

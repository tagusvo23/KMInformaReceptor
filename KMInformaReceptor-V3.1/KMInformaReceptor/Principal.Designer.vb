<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.CMSMnuventana = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMExportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMExportarExcelRefe = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMOcultarMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMOcultarColCondi = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMMostrarColCondi = New System.Windows.Forms.ToolStripMenuItem()
        Me.SFDRuta = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdAlta = New System.Windows.Forms.Button()
        Me.CmdCambio = New System.Windows.Forms.Button()
        Me.CmdFiltrarAlertas = New System.Windows.Forms.Button()
        Me.CmdCancelar = New System.Windows.Forms.Button()
        Me.vseFondo = New C1.Win.C1Sizer.C1Sizer()
        Me.VSGAlertasAtendidas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.VSGAlertas = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.vseMenu2 = New C1.Win.C1Sizer.C1Sizer()
        Me.vseMenu1 = New C1.Win.C1Sizer.C1Sizer()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.PgrBarra = New System.Windows.Forms.ProgressBar()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.CmbestadoF = New System.Windows.Forms.ComboBox()
        Me.TxtTotalAlertas = New System.Windows.Forms.TextBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.ChkReferencia = New System.Windows.Forms.CheckBox()
        Me.ChkEstado = New System.Windows.Forms.CheckBox()
        Me.ChkMensaje = New System.Windows.Forms.CheckBox()
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.VSGReferencias = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.lbltitulos = New System.Windows.Forms.Label()
        Me.TxtMensaje = New System.Windows.Forms.TextBox()
        Me.CMSMnuventana.SuspendLayout()
        CType(Me.vseFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vseFondo.SuspendLayout()
        CType(Me.VSGAlertasAtendidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VSGAlertas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vseMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vseMenu2.SuspendLayout()
        CType(Me.vseMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vseMenu1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.VSGReferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMSMnuventana
        '
        Me.CMSMnuventana.BackColor = System.Drawing.SystemColors.Control
        Me.CMSMnuventana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMSMnuventana.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMExportar, Me.TSMOcultarMostrar})
        Me.CMSMnuventana.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.CMSMnuventana.Name = "CMSMnuventana"
        Me.CMSMnuventana.Size = New System.Drawing.Size(209, 48)
        '
        'TSMExportar
        '
        Me.TSMExportar.BackColor = System.Drawing.SystemColors.Control
        Me.TSMExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMExportarExcel, Me.TSMExportarExcelRefe})
        Me.TSMExportar.Name = "TSMExportar"
        Me.TSMExportar.Size = New System.Drawing.Size(208, 22)
        Me.TSMExportar.Text = "Exportar"
        '
        'TSMExportarExcel
        '
        Me.TSMExportarExcel.Name = "TSMExportarExcel"
        Me.TSMExportarExcel.Size = New System.Drawing.Size(162, 22)
        Me.TSMExportarExcel.Text = "Excel"
        '
        'TSMExportarExcelRefe
        '
        Me.TSMExportarExcelRefe.Name = "TSMExportarExcelRefe"
        Me.TSMExportarExcelRefe.Size = New System.Drawing.Size(162, 22)
        Me.TSMExportarExcelRefe.Text = "Excel Referencias"
        '
        'TSMOcultarMostrar
        '
        Me.TSMOcultarMostrar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMOcultarColCondi, Me.TSMMostrarColCondi})
        Me.TSMOcultarMostrar.Name = "TSMOcultarMostrar"
        Me.TSMOcultarMostrar.Size = New System.Drawing.Size(208, 22)
        Me.TSMOcultarMostrar.Text = "Ocultar y Mostrar Columnas"
        '
        'TSMOcultarColCondi
        '
        Me.TSMOcultarColCondi.Name = "TSMOcultarColCondi"
        Me.TSMOcultarColCondi.Size = New System.Drawing.Size(161, 22)
        Me.TSMOcultarColCondi.Text = "Ocultar Condición"
        '
        'TSMMostrarColCondi
        '
        Me.TSMMostrarColCondi.Enabled = False
        Me.TSMMostrarColCondi.Name = "TSMMostrarColCondi"
        Me.TSMMostrarColCondi.Size = New System.Drawing.Size(161, 22)
        Me.TSMMostrarColCondi.Text = "Mostrar Condiciòn"
        '
        'SFDRuta
        '
        Me.SFDRuta.ShowHelp = True
        '
        'CmdAlta
        '
        Me.CmdAlta.Enabled = False
        Me.CmdAlta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAlta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAlta.Image = Global.KMInformaReceptor.My.Resources.Resources.pencil_add
        Me.CmdAlta.Location = New System.Drawing.Point(4, 4)
        Me.CmdAlta.Name = "CmdAlta"
        Me.CmdAlta.Size = New System.Drawing.Size(75, 32)
        Me.CmdAlta.TabIndex = 15
        Me.CmdAlta.Tag = "alta"
        Me.ToolTip1.SetToolTip(Me.CmdAlta, "Agregar  Observación")
        Me.CmdAlta.UseVisualStyleBackColor = True
        '
        'CmdCambio
        '
        Me.CmdCambio.Enabled = False
        Me.CmdCambio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCambio.Image = Global.KMInformaReceptor.My.Resources.Resources.text_signature
        Me.CmdCambio.Location = New System.Drawing.Point(83, 4)
        Me.CmdCambio.Name = "CmdCambio"
        Me.CmdCambio.Size = New System.Drawing.Size(76, 32)
        Me.CmdCambio.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.CmdCambio, "Cambio de Observación")
        Me.CmdCambio.UseVisualStyleBackColor = True
        '
        'CmdFiltrarAlertas
        '
        Me.CmdFiltrarAlertas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdFiltrarAlertas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFiltrarAlertas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFiltrarAlertas.Image = Global.KMInformaReceptor.My.Resources.Resources.tick
        Me.CmdFiltrarAlertas.Location = New System.Drawing.Point(4, 4)
        Me.CmdFiltrarAlertas.Name = "CmdFiltrarAlertas"
        Me.CmdFiltrarAlertas.Size = New System.Drawing.Size(78, 27)
        Me.CmdFiltrarAlertas.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdFiltrarAlertas, "Actualizar Presentación de Alertas")
        Me.CmdFiltrarAlertas.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancelar.Image = Global.KMInformaReceptor.My.Resources.Resources.cross
        Me.CmdCancelar.Location = New System.Drawing.Point(86, 4)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(78, 27)
        Me.CmdCancelar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar Presentación de Alertas")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'vseFondo
        '
        Me.vseFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.vseFondo.Controls.Add(Me.VSGAlertasAtendidas)
        Me.vseFondo.Controls.Add(Me.VSGAlertas)
        Me.vseFondo.Controls.Add(Me.label4)
        Me.vseFondo.Controls.Add(Me.label3)
        Me.vseFondo.Controls.Add(Me.vseMenu2)
        Me.vseFondo.Controls.Add(Me.vseMenu1)
        Me.vseFondo.Controls.Add(Me.panel2)
        Me.vseFondo.Controls.Add(Me.CmbEstado)
        Me.vseFondo.Controls.Add(Me.TxtObservaciones)
        Me.vseFondo.Controls.Add(Me.label2)
        Me.vseFondo.Controls.Add(Me.panel1)
        Me.vseFondo.Controls.Add(Me.VSGReferencias)
        Me.vseFondo.Controls.Add(Me.LblMensaje)
        Me.vseFondo.Controls.Add(Me.lbltitulos)
        Me.vseFondo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vseFondo.GridDefinition = resources.GetString("vseFondo.GridDefinition")
        Me.vseFondo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.vseFondo.Location = New System.Drawing.Point(0, 0)
        Me.vseFondo.Name = "vseFondo"
        Me.vseFondo.Padding = New System.Windows.Forms.Padding(0)
        Me.vseFondo.Size = New System.Drawing.Size(854, 504)
        Me.vseFondo.SplitterWidth = 0
        Me.vseFondo.TabIndex = 6
        Me.vseFondo.TabStop = False
        '
        'VSGAlertasAtendidas
        '
        Me.VSGAlertasAtendidas.AllowEditing = False
        Me.VSGAlertasAtendidas.BackColor = System.Drawing.Color.DarkGray
        Me.VSGAlertasAtendidas.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.VSGAlertasAtendidas.ColumnInfo = resources.GetString("VSGAlertasAtendidas.ColumnInfo")
        Me.VSGAlertasAtendidas.ExtendLastCol = True
        Me.VSGAlertasAtendidas.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.VSGAlertasAtendidas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VSGAlertasAtendidas.Location = New System.Drawing.Point(0, 315)
        Me.VSGAlertasAtendidas.Name = "VSGAlertasAtendidas"
        Me.VSGAlertasAtendidas.Rows.Count = 1
        Me.VSGAlertasAtendidas.Rows.DefaultSize = 17
        Me.VSGAlertasAtendidas.Size = New System.Drawing.Size(854, 104)
        Me.VSGAlertasAtendidas.StyleInfo = resources.GetString("VSGAlertasAtendidas.StyleInfo")
        Me.VSGAlertasAtendidas.TabIndex = 12
        '
        'VSGAlertas
        '
        Me.VSGAlertas.AllowEditing = False
        Me.VSGAlertas.AutoResize = True
        Me.VSGAlertas.BackColor = System.Drawing.Color.DarkGray
        Me.VSGAlertas.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.VSGAlertas.ColumnInfo = resources.GetString("VSGAlertas.ColumnInfo")
        Me.VSGAlertas.ContextMenuStrip = Me.CMSMnuventana
        Me.VSGAlertas.ExtendLastCol = True
        Me.VSGAlertas.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.VSGAlertas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VSGAlertas.ForeColor = System.Drawing.SystemColors.InfoText
        Me.VSGAlertas.Location = New System.Drawing.Point(0, 147)
        Me.VSGAlertas.Name = "VSGAlertas"
        Me.VSGAlertas.Rows.Count = 1
        Me.VSGAlertas.Rows.DefaultSize = 17
        Me.VSGAlertas.Size = New System.Drawing.Size(854, 149)
        Me.VSGAlertas.StyleInfo = resources.GetString("VSGAlertas.StyleInfo")
        Me.VSGAlertas.TabIndex = 11
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.Color.Silver
        Me.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(0, 419)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(854, 19)
        Me.label4.TabIndex = 15
        Me.label4.Text = "Observaciones"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.Color.Silver
        Me.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(0, 296)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(854, 19)
        Me.label3.TabIndex = 14
        Me.label3.Text = "Seguimiento"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vseMenu2
        '
        Me.vseMenu2.BackColor = System.Drawing.SystemColors.Control
        Me.vseMenu2.Controls.Add(Me.CmdAlta)
        Me.vseMenu2.Controls.Add(Me.CmdCambio)
        Me.vseMenu2.GridDefinition = "80:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "46.0122699386503:False:False;46.6257668711656:False:False;"
        Me.vseMenu2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.vseMenu2.Location = New System.Drawing.Point(691, 464)
        Me.vseMenu2.Name = "vseMenu2"
        Me.vseMenu2.Size = New System.Drawing.Size(163, 40)
        Me.vseMenu2.TabIndex = 53
        Me.vseMenu2.TabStop = False
        '
        'vseMenu1
        '
        Me.vseMenu1.BackColor = System.Drawing.SystemColors.Control
        Me.vseMenu1.Controls.Add(Me.CmdFiltrarAlertas)
        Me.vseMenu1.Controls.Add(Me.CmdCancelar)
        Me.vseMenu1.GridDefinition = "77.1428571428571:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "46.4285714285714:False:False;46.4285714285714:False" & _
    ":False;"
        Me.vseMenu1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.vseMenu1.Location = New System.Drawing.Point(686, 93)
        Me.vseMenu1.Name = "vseMenu1"
        Me.vseMenu1.Size = New System.Drawing.Size(168, 35)
        Me.vseMenu1.TabIndex = 52
        Me.vseMenu1.TabStop = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.SystemColors.Control
        Me.panel2.Controls.Add(Me.PgrBarra)
        Me.panel2.Location = New System.Drawing.Point(0, 93)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(686, 35)
        Me.panel2.TabIndex = 19
        '
        'PgrBarra
        '
        Me.PgrBarra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgrBarra.ForeColor = System.Drawing.Color.RoyalBlue
        Me.PgrBarra.Location = New System.Drawing.Point(17, 6)
        Me.PgrBarra.Name = "PgrBarra"
        Me.PgrBarra.Size = New System.Drawing.Size(624, 18)
        Me.PgrBarra.Step = 1
        Me.PgrBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PgrBarra.TabIndex = 0
        Me.PgrBarra.Visible = False
        '
        'CmbEstado
        '
        Me.CmbEstado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(691, 438)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(163, 21)
        Me.CmbEstado.TabIndex = 14
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtObservaciones.Enabled = False
        Me.TxtObservaciones.Location = New System.Drawing.Point(0, 438)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(686, 66)
        Me.TxtObservaciones.TabIndex = 13
        Me.TxtObservaciones.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & " "
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Silver
        Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(0, 128)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(854, 19)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Alertas"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.TxtMensaje)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.CmbestadoF)
        Me.panel1.Controls.Add(Me.TxtTotalAlertas)
        Me.panel1.Controls.Add(Me.TxtReferencia)
        Me.panel1.Controls.Add(Me.ChkReferencia)
        Me.panel1.Controls.Add(Me.ChkEstado)
        Me.panel1.Controls.Add(Me.ChkMensaje)
        Me.panel1.Controls.Add(Me.DtpFechaFin)
        Me.panel1.Controls.Add(Me.DtpFechaIni)
        Me.panel1.Controls.Add(Me.ChkFechas)
        Me.panel1.Location = New System.Drawing.Point(0, 20)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(854, 73)
        Me.panel1.TabIndex = 12
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(670, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(102, 24)
        Me.label1.TabIndex = 11
        Me.label1.Text = "Total de Alertas :"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbestadoF
        '
        Me.CmbestadoF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbestadoF.Enabled = False
        Me.CmbestadoF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbestadoF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbestadoF.FormattingEnabled = True
        Me.CmbestadoF.Location = New System.Drawing.Point(423, 7)
        Me.CmbestadoF.MaxDropDownItems = 20
        Me.CmbestadoF.Name = "CmbestadoF"
        Me.CmbestadoF.Size = New System.Drawing.Size(218, 22)
        Me.CmbestadoF.TabIndex = 4
        '
        'TxtTotalAlertas
        '
        Me.TxtTotalAlertas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtTotalAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalAlertas.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAlertas.ForeColor = System.Drawing.Color.Red
        Me.TxtTotalAlertas.Location = New System.Drawing.Point(771, 7)
        Me.TxtTotalAlertas.MaxLength = 7
        Me.TxtTotalAlertas.Name = "TxtTotalAlertas"
        Me.TxtTotalAlertas.ReadOnly = True
        Me.TxtTotalAlertas.Size = New System.Drawing.Size(67, 24)
        Me.TxtTotalAlertas.TabIndex = 9
        Me.TxtTotalAlertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtReferencia
        '
        Me.TxtReferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtReferencia.Enabled = False
        Me.TxtReferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferencia.Location = New System.Drawing.Point(423, 39)
        Me.TxtReferencia.MaxLength = 50
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(218, 20)
        Me.TxtReferencia.TabIndex = 8
        '
        'ChkReferencia
        '
        Me.ChkReferencia.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ChkReferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkReferencia.Location = New System.Drawing.Point(331, 37)
        Me.ChkReferencia.Name = "ChkReferencia"
        Me.ChkReferencia.Size = New System.Drawing.Size(86, 21)
        Me.ChkReferencia.TabIndex = 7
        Me.ChkReferencia.Text = "Referencia"
        Me.ChkReferencia.UseVisualStyleBackColor = False
        '
        'ChkEstado
        '
        Me.ChkEstado.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ChkEstado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEstado.Location = New System.Drawing.Point(331, 7)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(86, 21)
        Me.ChkEstado.TabIndex = 3
        Me.ChkEstado.Text = "       Estado"
        Me.ChkEstado.UseVisualStyleBackColor = False
        '
        'ChkMensaje
        '
        Me.ChkMensaje.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ChkMensaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkMensaje.Location = New System.Drawing.Point(17, 37)
        Me.ChkMensaje.Name = "ChkMensaje"
        Me.ChkMensaje.Size = New System.Drawing.Size(75, 21)
        Me.ChkMensaje.TabIndex = 5
        Me.ChkMensaje.Text = "Mensaje"
        Me.ChkMensaje.UseVisualStyleBackColor = False
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke
        Me.DtpFechaFin.Checked = False
        Me.DtpFechaFin.CustomFormat = "yyyy-MM-dd"
        Me.DtpFechaFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DtpFechaFin.Enabled = False
        Me.DtpFechaFin.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaFin.Location = New System.Drawing.Point(198, 7)
        Me.DtpFechaFin.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.DtpFechaFin.MinDate = New Date(2009, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaFin.TabIndex = 2
        Me.DtpFechaFin.Value = New Date(2013, 7, 5, 0, 0, 0, 0)
        '
        'DtpFechaIni
        '
        Me.DtpFechaIni.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIni.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke
        Me.DtpFechaIni.CustomFormat = "yyyy-MM-dd"
        Me.DtpFechaIni.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DtpFechaIni.Enabled = False
        Me.DtpFechaIni.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaIni.Location = New System.Drawing.Point(93, 7)
        Me.DtpFechaIni.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.DtpFechaIni.MinDate = New Date(2009, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaIni.Name = "DtpFechaIni"
        Me.DtpFechaIni.Size = New System.Drawing.Size(95, 20)
        Me.DtpFechaIni.TabIndex = 1
        Me.DtpFechaIni.Value = New Date(2013, 7, 5, 0, 0, 0, 0)
        '
        'ChkFechas
        '
        Me.ChkFechas.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ChkFechas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFechas.Location = New System.Drawing.Point(17, 7)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(75, 21)
        Me.ChkFechas.TabIndex = 0
        Me.ChkFechas.Text = "Fechas"
        Me.ChkFechas.UseVisualStyleBackColor = False
        '
        'VSGReferencias
        '
        Me.VSGReferencias.ColumnInfo = "0,0,0,0,0,100,Columns:"
        Me.VSGReferencias.Location = New System.Drawing.Point(0, 464)
        Me.VSGReferencias.Name = "VSGReferencias"
        Me.VSGReferencias.Rows.Count = 0
        Me.VSGReferencias.Rows.DefaultSize = 20
        Me.VSGReferencias.Rows.Fixed = 0
        Me.VSGReferencias.Size = New System.Drawing.Size(686, 40)
        Me.VSGReferencias.StyleInfo = resources.GetString("VSGReferencias.StyleInfo")
        Me.VSGReferencias.TabIndex = 55
        '
        'LblMensaje
        '
        Me.LblMensaje.BackColor = System.Drawing.Color.Gainsboro
        Me.LblMensaje.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.Location = New System.Drawing.Point(0, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(854, 20)
        Me.LblMensaje.TabIndex = 54
        Me.LblMensaje.Text = "                      "
        Me.LblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblMensaje.Visible = False
        '
        'lbltitulos
        '
        Me.lbltitulos.BackColor = System.Drawing.Color.Silver
        Me.lbltitulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltitulos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulos.Location = New System.Drawing.Point(0, 0)
        Me.lbltitulos.Name = "lbltitulos"
        Me.lbltitulos.Size = New System.Drawing.Size(854, 20)
        Me.lbltitulos.TabIndex = 11
        Me.lbltitulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMensaje
        '
        Me.TxtMensaje.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMensaje.Enabled = False
        Me.TxtMensaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMensaje.Location = New System.Drawing.Point(93, 39)
        Me.TxtMensaje.MaxLength = 50
        Me.TxtMensaje.Name = "TxtMensaje"
        Me.TxtMensaje.Size = New System.Drawing.Size(200, 20)
        Me.TxtMensaje.TabIndex = 12
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 504)
        Me.Controls.Add(Me.vseFondo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(870, 540)
        Me.MinimumSize = New System.Drawing.Size(870, 540)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.CMSMnuventana.ResumeLayout(False)
        CType(Me.vseFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vseFondo.ResumeLayout(False)
        Me.vseFondo.PerformLayout()
        CType(Me.VSGAlertasAtendidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VSGAlertas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vseMenu2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vseMenu2.ResumeLayout(False)
        CType(Me.vseMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vseMenu1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.VSGReferencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents vseFondo As C1.Win.C1Sizer.C1Sizer
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents vseMenu2 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents vseMenu1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents CmdFiltrarAlertas As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents PgrBarra As System.Windows.Forms.ProgressBar
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents TxtTotalAlertas As System.Windows.Forms.TextBox
    Private WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Private WithEvents ChkReferencia As System.Windows.Forms.CheckBox
    Private WithEvents ChkEstado As System.Windows.Forms.CheckBox
    Private WithEvents ChkMensaje As System.Windows.Forms.CheckBox
    Private WithEvents ChkFechas As System.Windows.Forms.CheckBox
    Private WithEvents lbltitulos As System.Windows.Forms.Label
    Public WithEvents VSGAlertasAtendidas As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents CmbestadoF As System.Windows.Forms.ComboBox
    Public WithEvents label3 As System.Windows.Forms.Label
    Public WithEvents CmdAlta As System.Windows.Forms.Button
    Public WithEvents CmdCambio As System.Windows.Forms.Button
    Public WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Public WithEvents CmbEstado As System.Windows.Forms.ComboBox
    Public WithEvents VSGAlertas As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CMSMnuventana As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMExportar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMExportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMExportarExcelRefe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMOcultarMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMOcultarColCondi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMMostrarColCondi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents VSGReferencias As C1.Win.C1FlexGrid.C1FlexGrid
    Public WithEvents SFDRuta As System.Windows.Forms.SaveFileDialog
    Public WithEvents DtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Private WithEvents TxtMensaje As System.Windows.Forms.TextBox

End Class

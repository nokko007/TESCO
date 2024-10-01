<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCounting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCounting))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.CmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Datagridview1 = New System.Windows.Forms.DataGridView
        Me.Cmbweek = New System.Windows.Forms.ComboBox
        Me.TxtPickupDate = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbDC = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtStoreId = New System.Windows.Forms.TextBox
        Me.CmbStore = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtSeal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtApp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNobc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDate = New System.Windows.Forms.TextBox
        Me.cmdCarlendar1 = New System.Windows.Forms.Button
        Me.TxtMailbagID = New System.Windows.Forms.TextBox
        Me.CmbMailbag = New System.Windows.Forms.ComboBox
        Me.CmbEnvelope = New System.Windows.Forms.ComboBox
        Me.Optsign = New System.Windows.Forms.RadioButton
        Me.OptUnsign = New System.Windows.Forms.RadioButton
        Me.TxtClubcard = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txtqty = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSign = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Txtunsign = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdDelete, Me.CmdExit, Me.CmdNew, Me.CmdAdd, Me.CmdEdit, Me.CmdSearch})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.WindowsApplication1.My.Resources.Resources._exit
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(55, 20)
        Me.CmdExit.Text = "Exit"
        '
        'CmdNew
        '
        Me.CmdNew.Image = Global.WindowsApplication1.My.Resources.Resources._new
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(60, 20)
        Me.CmdNew.Text = "New"
        Me.CmdNew.Visible = False
        '
        'CmdAdd
        '
        Me.CmdAdd.Image = Global.WindowsApplication1.My.Resources.Resources.add
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(57, 20)
        Me.CmdAdd.Text = "Add"
        Me.CmdAdd.Visible = False
        '
        'CmdEdit
        '
        Me.CmdEdit.Image = Global.WindowsApplication1.My.Resources.Resources.save
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(56, 20)
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.Visible = False
        '
        'CmdDelete
        '
        Me.CmdDelete.Image = Global.WindowsApplication1.My.Resources.Resources.delete
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(71, 20)
        Me.CmdDelete.Text = "Delete"
        '
        'CmdSearch
        '
        Me.CmdSearch.Image = Global.WindowsApplication1.My.Resources.Resources.search
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(72, 20)
        Me.CmdSearch.Text = "Search"
        Me.CmdSearch.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(100, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Week No. :"
        '
        'Datagridview1
        '
        Me.Datagridview1.AllowUserToAddRows = False
        Me.Datagridview1.AllowUserToDeleteRows = False
        Me.Datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datagridview1.Location = New System.Drawing.Point(83, 427)
        Me.Datagridview1.Name = "Datagridview1"
        Me.Datagridview1.ReadOnly = True
        Me.Datagridview1.Size = New System.Drawing.Size(833, 248)
        Me.Datagridview1.TabIndex = 1
        '
        'Cmbweek
        '
        Me.Cmbweek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbweek.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Cmbweek.FormattingEnabled = True
        Me.Cmbweek.Location = New System.Drawing.Point(176, 32)
        Me.Cmbweek.Name = "Cmbweek"
        Me.Cmbweek.Size = New System.Drawing.Size(75, 22)
        Me.Cmbweek.TabIndex = 0
        '
        'TxtPickupDate
        '
        Me.TxtPickupDate.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtPickupDate.Enabled = False
        Me.TxtPickupDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtPickupDate.Location = New System.Drawing.Point(257, 32)
        Me.TxtPickupDate.Name = "TxtPickupDate"
        Me.TxtPickupDate.Size = New System.Drawing.Size(126, 22)
        Me.TxtPickupDate.TabIndex = 76
        Me.TxtPickupDate.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "DC :"
        '
        'CmbDC
        '
        Me.CmbDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmbDC.FormattingEnabled = True
        Me.CmbDC.Location = New System.Drawing.Point(176, 61)
        Me.CmbDC.Name = "CmbDC"
        Me.CmbDC.Size = New System.Drawing.Size(207, 22)
        Me.CmbDC.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(97, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 14)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Mailbag No :"
        '
        'TxtStoreId
        '
        Me.TxtStoreId.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtStoreId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtStoreId.Location = New System.Drawing.Point(176, 90)
        Me.TxtStoreId.Name = "TxtStoreId"
        Me.TxtStoreId.Size = New System.Drawing.Size(75, 22)
        Me.TxtStoreId.TabIndex = 2
        '
        'CmbStore
        '
        Me.CmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStore.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmbStore.FormattingEnabled = True
        Me.CmbStore.Location = New System.Drawing.Point(257, 90)
        Me.CmbStore.Name = "CmbStore"
        Me.CmbStore.Size = New System.Drawing.Size(340, 22)
        Me.CmbStore.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(114, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Seal No :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(86, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Envelope No :"
        '
        'TxtSeal
        '
        Me.TxtSeal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtSeal.Enabled = False
        Me.TxtSeal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtSeal.Location = New System.Drawing.Point(176, 178)
        Me.TxtSeal.Name = "TxtSeal"
        Me.TxtSeal.Size = New System.Drawing.Size(138, 22)
        Me.TxtSeal.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(93, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "App Inform :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(62, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 14)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "No Barcode App  :"
        '
        'TxtApp
        '
        Me.TxtApp.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtApp.Enabled = False
        Me.TxtApp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtApp.Location = New System.Drawing.Point(176, 206)
        Me.TxtApp.Name = "TxtApp"
        Me.TxtApp.Size = New System.Drawing.Size(138, 22)
        Me.TxtApp.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(125, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 14)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Store :"
        '
        'TxtNobc
        '
        Me.TxtNobc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtNobc.Enabled = False
        Me.TxtNobc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtNobc.Location = New System.Drawing.Point(176, 235)
        Me.TxtNobc.Name = "TxtNobc"
        Me.TxtNobc.Size = New System.Drawing.Size(138, 22)
        Me.TxtNobc.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 14)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Date in frontof Letter :"
        '
        'TxtDate
        '
        Me.TxtDate.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtDate.Enabled = False
        Me.TxtDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtDate.Location = New System.Drawing.Point(176, 264)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(138, 22)
        Me.TxtDate.TabIndex = 9
        '
        'cmdCarlendar1
        '
        Me.cmdCarlendar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmdCarlendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCarlendar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarlendar1.Image = CType(resources.GetObject("cmdCarlendar1.Image"), System.Drawing.Image)
        Me.cmdCarlendar1.Location = New System.Drawing.Point(807, 12)
        Me.cmdCarlendar1.Name = "cmdCarlendar1"
        Me.cmdCarlendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCarlendar1.Size = New System.Drawing.Size(25, 25)
        Me.cmdCarlendar1.TabIndex = 78
        Me.cmdCarlendar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCarlendar1.UseVisualStyleBackColor = False
        Me.cmdCarlendar1.Visible = False
        '
        'TxtMailbagID
        '
        Me.TxtMailbagID.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtMailbagID.Enabled = False
        Me.TxtMailbagID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtMailbagID.Location = New System.Drawing.Point(320, 118)
        Me.TxtMailbagID.Name = "TxtMailbagID"
        Me.TxtMailbagID.Size = New System.Drawing.Size(44, 22)
        Me.TxtMailbagID.TabIndex = 76
        Me.TxtMailbagID.TabStop = False
        '
        'CmbMailbag
        '
        Me.CmbMailbag.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmbMailbag.FormattingEnabled = True
        Me.CmbMailbag.Location = New System.Drawing.Point(176, 119)
        Me.CmbMailbag.Name = "CmbMailbag"
        Me.CmbMailbag.Size = New System.Drawing.Size(138, 22)
        Me.CmbMailbag.TabIndex = 4
        '
        'CmbEnvelope
        '
        Me.CmbEnvelope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEnvelope.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmbEnvelope.FormattingEnabled = True
        Me.CmbEnvelope.Location = New System.Drawing.Point(176, 150)
        Me.CmbEnvelope.Name = "CmbEnvelope"
        Me.CmbEnvelope.Size = New System.Drawing.Size(138, 22)
        Me.CmbEnvelope.TabIndex = 5
        '
        'Optsign
        '
        Me.Optsign.AutoSize = True
        Me.Optsign.Checked = True
        Me.Optsign.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Optsign.Location = New System.Drawing.Point(176, 295)
        Me.Optsign.Name = "Optsign"
        Me.Optsign.Size = New System.Drawing.Size(62, 18)
        Me.Optsign.TabIndex = 10
        Me.Optsign.TabStop = True
        Me.Optsign.Text = "Signed"
        Me.Optsign.UseVisualStyleBackColor = True
        '
        'OptUnsign
        '
        Me.OptUnsign.AutoSize = True
        Me.OptUnsign.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.OptUnsign.Location = New System.Drawing.Point(244, 295)
        Me.OptUnsign.Name = "OptUnsign"
        Me.OptUnsign.Size = New System.Drawing.Size(75, 18)
        Me.OptUnsign.TabIndex = 11
        Me.OptUnsign.TabStop = True
        Me.OptUnsign.Text = "Unsigned"
        Me.OptUnsign.UseVisualStyleBackColor = True
        '
        'TxtClubcard
        '
        Me.TxtClubcard.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtClubcard.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtClubcard.Location = New System.Drawing.Point(176, 320)
        Me.TxtClubcard.Name = "TxtClubcard"
        Me.TxtClubcard.Size = New System.Drawing.Size(207, 22)
        Me.TxtClubcard.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(62, 323)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 14)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Clubcard Number :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(50, 351)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 14)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "¨Ó¹Ç¹ãºÊÁÑ¤Ãã¹«Í§ :"
        '
        'Txtqty
        '
        Me.Txtqty.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Txtqty.Enabled = False
        Me.Txtqty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Txtqty.Location = New System.Drawing.Point(176, 348)
        Me.Txtqty.Name = "Txtqty"
        Me.Txtqty.Size = New System.Drawing.Size(64, 22)
        Me.Txtqty.TabIndex = 13
        Me.Txtqty.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(254, 352)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 14)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "ãº"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox1.Controls.Add(Me.Txtunsign)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtSign)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Cmbweek)
        Me.GroupBox1.Controls.Add(Me.OptUnsign)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Optsign)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmbEnvelope)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmbMailbag)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtPickupDate)
        Me.GroupBox1.Controls.Add(Me.CmbDC)
        Me.GroupBox1.Controls.Add(Me.TxtMailbagID)
        Me.GroupBox1.Controls.Add(Me.CmbStore)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtStoreId)
        Me.GroupBox1.Controls.Add(Me.TxtClubcard)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Txtqty)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtDate)
        Me.GroupBox1.Controls.Add(Me.TxtSeal)
        Me.GroupBox1.Controls.Add(Me.TxtNobc)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtApp)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(83, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(833, 378)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Application Counting"
        '
        'txtSign
        '
        Me.txtSign.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSign.Enabled = False
        Me.txtSign.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSign.Location = New System.Drawing.Point(328, 349)
        Me.txtSign.Name = "txtSign"
        Me.txtSign.Size = New System.Drawing.Size(64, 22)
        Me.txtSign.TabIndex = 77
        Me.txtSign.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(398, 352)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 14)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "ãº"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(565, 352)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 14)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "ãº"
        '
        'Txtunsign
        '
        Me.Txtunsign.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Txtunsign.Enabled = False
        Me.Txtunsign.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Txtunsign.Location = New System.Drawing.Point(487, 348)
        Me.Txtunsign.Name = "Txtunsign"
        Me.Txtunsign.Size = New System.Drawing.Size(64, 22)
        Me.Txtunsign.TabIndex = 77
        Me.Txtunsign.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.Location = New System.Drawing.Point(280, 352)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "signed"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.Location = New System.Drawing.Point(425, 352)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 14)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "unsigned"
        '
        'FrmCounting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCarlendar1)
        Me.Controls.Add(Me.Datagridview1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCounting"
        Me.Text = "Chk digit"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Datagridview1 As System.Windows.Forms.DataGridView
    Friend WithEvents Cmbweek As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPickupDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtStoreId As System.Windows.Forms.TextBox
    Friend WithEvents CmbStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSeal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNobc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
    Public WithEvents cmdCarlendar1 As System.Windows.Forms.Button
    Friend WithEvents TxtMailbagID As System.Windows.Forms.TextBox
    Friend WithEvents CmbMailbag As System.Windows.Forms.ComboBox
    Friend WithEvents CmbEnvelope As System.Windows.Forms.ComboBox
    Friend WithEvents Optsign As System.Windows.Forms.RadioButton
    Friend WithEvents OptUnsign As System.Windows.Forms.RadioButton
    Friend WithEvents TxtClubcard As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txtqty As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtunsign As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSign As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class

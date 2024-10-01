<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMailbag
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMailbag))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.CmdNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.CmdExit = New System.Windows.Forms.ToolStripMenuItem
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
        Me.TxtMailbag = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtSeal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtEnvelope = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtApp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNobc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDate = New System.Windows.Forms.TextBox
        Me.cmdCarlendar1 = New System.Windows.Forms.Button
        Me.TxtMailbagID = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtQty = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdNew, Me.CmdAdd, Me.CmdEdit, Me.CmdDelete, Me.CmdSearch, Me.CmdExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CmdNew
        '
        Me.CmdNew.Image = Global.WindowsApplication1.My.Resources.Resources._new
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(60, 20)
        Me.CmdNew.Text = "New"
        '
        'CmdAdd
        '
        Me.CmdAdd.Image = Global.WindowsApplication1.My.Resources.Resources.add
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(57, 20)
        Me.CmdAdd.Text = "Add"
        '
        'CmdEdit
        '
        Me.CmdEdit.Image = Global.WindowsApplication1.My.Resources.Resources.save
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(56, 20)
        Me.CmdEdit.Text = "Edit"
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
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.WindowsApplication1.My.Resources.Resources._exit
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(55, 20)
        Me.CmdExit.Text = "Exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 29)
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
        Me.Datagridview1.Location = New System.Drawing.Point(83, 373)
        Me.Datagridview1.Name = "Datagridview1"
        Me.Datagridview1.ReadOnly = True
        Me.Datagridview1.Size = New System.Drawing.Size(833, 304)
        Me.Datagridview1.TabIndex = 2
        '
        'Cmbweek
        '
        Me.Cmbweek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbweek.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Cmbweek.FormattingEnabled = True
        Me.Cmbweek.Location = New System.Drawing.Point(162, 26)
        Me.Cmbweek.Name = "Cmbweek"
        Me.Cmbweek.Size = New System.Drawing.Size(75, 22)
        Me.Cmbweek.TabIndex = 0
        '
        'TxtPickupDate
        '
        Me.TxtPickupDate.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtPickupDate.Enabled = False
        Me.TxtPickupDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtPickupDate.Location = New System.Drawing.Point(243, 26)
        Me.TxtPickupDate.Name = "TxtPickupDate"
        Me.TxtPickupDate.Size = New System.Drawing.Size(126, 22)
        Me.TxtPickupDate.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(126, 58)
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
        Me.CmbDC.Location = New System.Drawing.Point(162, 55)
        Me.CmbDC.Name = "CmbDC"
        Me.CmbDC.Size = New System.Drawing.Size(207, 22)
        Me.CmbDC.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 14)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Mailbag No :"
        '
        'TxtStoreId
        '
        Me.TxtStoreId.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtStoreId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtStoreId.Location = New System.Drawing.Point(162, 84)
        Me.TxtStoreId.Name = "TxtStoreId"
        Me.TxtStoreId.Size = New System.Drawing.Size(75, 22)
        Me.TxtStoreId.TabIndex = 2
        '
        'CmbStore
        '
        Me.CmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStore.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CmbStore.FormattingEnabled = True
        Me.CmbStore.Location = New System.Drawing.Point(243, 84)
        Me.CmbStore.Name = "CmbStore"
        Me.CmbStore.Size = New System.Drawing.Size(340, 22)
        Me.CmbStore.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(100, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Seal No :"
        '
        'TxtMailbag
        '
        Me.TxtMailbag.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtMailbag.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtMailbag.Location = New System.Drawing.Point(162, 113)
        Me.TxtMailbag.Name = "TxtMailbag"
        Me.TxtMailbag.Size = New System.Drawing.Size(138, 22)
        Me.TxtMailbag.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(72, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Envelope No :"
        '
        'TxtSeal
        '
        Me.TxtSeal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtSeal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtSeal.Location = New System.Drawing.Point(162, 142)
        Me.TxtSeal.Name = "TxtSeal"
        Me.TxtSeal.Size = New System.Drawing.Size(138, 22)
        Me.TxtSeal.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "App Inform :"
        '
        'TxtEnvelope
        '
        Me.TxtEnvelope.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtEnvelope.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtEnvelope.Location = New System.Drawing.Point(162, 171)
        Me.TxtEnvelope.Name = "TxtEnvelope"
        Me.TxtEnvelope.Size = New System.Drawing.Size(138, 22)
        Me.TxtEnvelope.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 14)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "No Barcode App  :"
        '
        'TxtApp
        '
        Me.TxtApp.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtApp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtApp.Location = New System.Drawing.Point(162, 200)
        Me.TxtApp.Name = "TxtApp"
        Me.TxtApp.Size = New System.Drawing.Size(138, 22)
        Me.TxtApp.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(111, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 14)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Store :"
        '
        'TxtNobc
        '
        Me.TxtNobc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtNobc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtNobc.Location = New System.Drawing.Point(162, 229)
        Me.TxtNobc.Name = "TxtNobc"
        Me.TxtNobc.Size = New System.Drawing.Size(138, 22)
        Me.TxtNobc.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 261)
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
        Me.TxtDate.Location = New System.Drawing.Point(162, 258)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(107, 22)
        Me.TxtDate.TabIndex = 9
        '
        'cmdCarlendar1
        '
        Me.cmdCarlendar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmdCarlendar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCarlendar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarlendar1.Image = CType(resources.GetObject("cmdCarlendar1.Image"), System.Drawing.Image)
        Me.cmdCarlendar1.Location = New System.Drawing.Point(275, 255)
        Me.cmdCarlendar1.Name = "cmdCarlendar1"
        Me.cmdCarlendar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCarlendar1.Size = New System.Drawing.Size(25, 25)
        Me.cmdCarlendar1.TabIndex = 10
        Me.cmdCarlendar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCarlendar1.UseVisualStyleBackColor = False
        '
        'TxtMailbagID
        '
        Me.TxtMailbagID.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TxtMailbagID.Enabled = False
        Me.TxtMailbagID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtMailbagID.Location = New System.Drawing.Point(306, 112)
        Me.TxtMailbagID.Name = "TxtMailbagID"
        Me.TxtMailbagID.Size = New System.Drawing.Size(44, 22)
        Me.TxtMailbagID.TabIndex = 76
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LavenderBlush
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdCarlendar1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmbDC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmbStore)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cmbweek)
        Me.GroupBox1.Controls.Add(Me.TxtPickupDate)
        Me.GroupBox1.Controls.Add(Me.TxtDate)
        Me.GroupBox1.Controls.Add(Me.TxtMailbagID)
        Me.GroupBox1.Controls.Add(Me.TxtQty)
        Me.GroupBox1.Controls.Add(Me.TxtNobc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtApp)
        Me.GroupBox1.Controls.Add(Me.TxtStoreId)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtEnvelope)
        Me.GroupBox1.Controls.Add(Me.TxtMailbag)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtSeal)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(83, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(833, 324)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mailbag Setup"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(65, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 14)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "�ӹǹ Mailbag :"
        '
        'TxtQty
        '
        Me.TxtQty.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtQty.Enabled = False
        Me.TxtQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(162, 286)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(75, 22)
        Me.TxtQty.TabIndex = 8
        '
        'FrmMailbag
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 706)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Datagridview1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMailbag"
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
    Friend WithEvents TxtMailbag As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSeal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtEnvelope As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNobc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
    Public WithEvents cmdCarlendar1 As System.Windows.Forms.Button
    Friend WithEvents TxtMailbagID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class

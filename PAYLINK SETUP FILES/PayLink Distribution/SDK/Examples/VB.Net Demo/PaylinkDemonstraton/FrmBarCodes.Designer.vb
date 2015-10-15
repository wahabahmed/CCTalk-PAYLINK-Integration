<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBarCodes
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBarCodes))
        Me.TxtBCHeld = New System.Windows.Forms.TextBox
        Me.LblBCEscrow = New System.Windows.Forms.Label
        Me.BtnBCAccept = New System.Windows.Forms.Button
        Me.BtnBCReturn = New System.Windows.Forms.Button
        Me.GrpBCEscrow = New System.Windows.Forms.GroupBox
        Me.GrpBCPrint = New System.Windows.Forms.GroupBox
        Me.BtnBCChangeAmount = New System.Windows.Forms.Button
        Me.BtnTicketPrint = New System.Windows.Forms.Button
        Me.LblBCValue = New System.Windows.Forms.Label
        Me.TxtBCValue = New System.Windows.Forms.TextBox
        Me.TxtBCWordAmount = New System.Windows.Forms.TextBox
        Me.LblBCWordAmount = New System.Windows.Forms.Label
        Me.LblBCTime = New System.Windows.Forms.Label
        Me.LblBCMachine = New System.Windows.Forms.Label
        Me.LblBCDate = New System.Windows.Forms.Label
        Me.LblBCAmount = New System.Windows.Forms.Label
        Me.TxtBCMachine = New System.Windows.Forms.TextBox
        Me.TxtBCTime = New System.Windows.Forms.TextBox
        Me.TxtBCDate = New System.Windows.Forms.TextBox
        Me.TxtBCAmount = New System.Windows.Forms.TextBox
        Me.TmrBarcodesOne = New System.Windows.Forms.Timer(Me.components)
        Me.TmrBarcodesTwo = New System.Windows.Forms.Timer(Me.components)
        Me.TmrBCDate = New System.Windows.Forms.Timer(Me.components)
        Me.GrpBCEscrow.SuspendLayout()
        Me.GrpBCPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtBCHeld
        '
        Me.TxtBCHeld.Location = New System.Drawing.Point(94, 22)
        Me.TxtBCHeld.Name = "TxtBCHeld"
        Me.TxtBCHeld.Size = New System.Drawing.Size(165, 20)
        Me.TxtBCHeld.TabIndex = 3
        '
        'LblBCEscrow
        '
        Me.LblBCEscrow.AutoSize = True
        Me.LblBCEscrow.Location = New System.Drawing.Point(4, 22)
        Me.LblBCEscrow.Name = "LblBCEscrow"
        Me.LblBCEscrow.Size = New System.Drawing.Size(62, 13)
        Me.LblBCEscrow.TabIndex = 4
        Me.LblBCEscrow.Text = "Ticket Held"
        '
        'BtnBCAccept
        '
        Me.BtnBCAccept.Location = New System.Drawing.Point(283, 22)
        Me.BtnBCAccept.Name = "BtnBCAccept"
        Me.BtnBCAccept.Size = New System.Drawing.Size(59, 27)
        Me.BtnBCAccept.TabIndex = 5
        Me.BtnBCAccept.Text = "Accept"
        Me.BtnBCAccept.UseVisualStyleBackColor = True
        '
        'BtnBCReturn
        '
        Me.BtnBCReturn.Location = New System.Drawing.Point(365, 22)
        Me.BtnBCReturn.Name = "BtnBCReturn"
        Me.BtnBCReturn.Size = New System.Drawing.Size(59, 27)
        Me.BtnBCReturn.TabIndex = 6
        Me.BtnBCReturn.Text = "Return"
        Me.BtnBCReturn.UseVisualStyleBackColor = True
        '
        'GrpBCEscrow
        '
        Me.GrpBCEscrow.Controls.Add(Me.BtnBCReturn)
        Me.GrpBCEscrow.Controls.Add(Me.BtnBCAccept)
        Me.GrpBCEscrow.Controls.Add(Me.LblBCEscrow)
        Me.GrpBCEscrow.Controls.Add(Me.TxtBCHeld)
        Me.GrpBCEscrow.Location = New System.Drawing.Point(8, 12)
        Me.GrpBCEscrow.Name = "GrpBCEscrow"
        Me.GrpBCEscrow.Size = New System.Drawing.Size(438, 63)
        Me.GrpBCEscrow.TabIndex = 7
        Me.GrpBCEscrow.TabStop = False
        Me.GrpBCEscrow.Text = "Escrow"
        '
        'GrpBCPrint
        '
        Me.GrpBCPrint.Controls.Add(Me.BtnBCChangeAmount)
        Me.GrpBCPrint.Controls.Add(Me.BtnTicketPrint)
        Me.GrpBCPrint.Controls.Add(Me.LblBCValue)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCValue)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCWordAmount)
        Me.GrpBCPrint.Controls.Add(Me.LblBCWordAmount)
        Me.GrpBCPrint.Controls.Add(Me.LblBCTime)
        Me.GrpBCPrint.Controls.Add(Me.LblBCMachine)
        Me.GrpBCPrint.Controls.Add(Me.LblBCDate)
        Me.GrpBCPrint.Controls.Add(Me.LblBCAmount)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCMachine)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCTime)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCDate)
        Me.GrpBCPrint.Controls.Add(Me.TxtBCAmount)
        Me.GrpBCPrint.Location = New System.Drawing.Point(8, 81)
        Me.GrpBCPrint.Name = "GrpBCPrint"
        Me.GrpBCPrint.Size = New System.Drawing.Size(438, 172)
        Me.GrpBCPrint.TabIndex = 9
        Me.GrpBCPrint.TabStop = False
        Me.GrpBCPrint.Text = "Ticket To Print"
        '
        'BtnBCChangeAmount
        '
        Me.BtnBCChangeAmount.Location = New System.Drawing.Point(109, 139)
        Me.BtnBCChangeAmount.Name = "BtnBCChangeAmount"
        Me.BtnBCChangeAmount.Size = New System.Drawing.Size(96, 25)
        Me.BtnBCChangeAmount.TabIndex = 13
        Me.BtnBCChangeAmount.Text = "Change Amount"
        Me.BtnBCChangeAmount.UseVisualStyleBackColor = True
        '
        'BtnTicketPrint
        '
        Me.BtnTicketPrint.Location = New System.Drawing.Point(7, 139)
        Me.BtnTicketPrint.Name = "BtnTicketPrint"
        Me.BtnTicketPrint.Size = New System.Drawing.Size(96, 25)
        Me.BtnTicketPrint.TabIndex = 7
        Me.BtnTicketPrint.Text = "Print Ticket"
        Me.BtnTicketPrint.UseVisualStyleBackColor = True
        '
        'LblBCValue
        '
        Me.LblBCValue.AutoSize = True
        Me.LblBCValue.Location = New System.Drawing.Point(4, 105)
        Me.LblBCValue.Name = "LblBCValue"
        Me.LblBCValue.Size = New System.Drawing.Size(76, 13)
        Me.LblBCValue.TabIndex = 12
        Me.LblBCValue.Text = "Barcode value"
        '
        'TxtBCValue
        '
        Me.TxtBCValue.Location = New System.Drawing.Point(94, 105)
        Me.TxtBCValue.Name = "TxtBCValue"
        Me.TxtBCValue.Size = New System.Drawing.Size(330, 20)
        Me.TxtBCValue.TabIndex = 11
        '
        'TxtBCWordAmount
        '
        Me.TxtBCWordAmount.Location = New System.Drawing.Point(94, 79)
        Me.TxtBCWordAmount.Name = "TxtBCWordAmount"
        Me.TxtBCWordAmount.Size = New System.Drawing.Size(330, 20)
        Me.TxtBCWordAmount.TabIndex = 10
        '
        'LblBCWordAmount
        '
        Me.LblBCWordAmount.AutoSize = True
        Me.LblBCWordAmount.Location = New System.Drawing.Point(4, 79)
        Me.LblBCWordAmount.Name = "LblBCWordAmount"
        Me.LblBCWordAmount.Size = New System.Drawing.Size(85, 13)
        Me.LblBCWordAmount.TabIndex = 10
        Me.LblBCWordAmount.Text = "Amount in words"
        '
        'LblBCTime
        '
        Me.LblBCTime.AutoSize = True
        Me.LblBCTime.Location = New System.Drawing.Point(262, 54)
        Me.LblBCTime.Name = "LblBCTime"
        Me.LblBCTime.Size = New System.Drawing.Size(30, 13)
        Me.LblBCTime.TabIndex = 10
        Me.LblBCTime.Text = "Time"
        '
        'LblBCMachine
        '
        Me.LblBCMachine.AutoSize = True
        Me.LblBCMachine.Location = New System.Drawing.Point(262, 27)
        Me.LblBCMachine.Name = "LblBCMachine"
        Me.LblBCMachine.Size = New System.Drawing.Size(48, 13)
        Me.LblBCMachine.TabIndex = 9
        Me.LblBCMachine.Text = "Machine"
        '
        'LblBCDate
        '
        Me.LblBCDate.AutoSize = True
        Me.LblBCDate.Location = New System.Drawing.Point(4, 53)
        Me.LblBCDate.Name = "LblBCDate"
        Me.LblBCDate.Size = New System.Drawing.Size(30, 13)
        Me.LblBCDate.TabIndex = 8
        Me.LblBCDate.Text = "Date"
        '
        'LblBCAmount
        '
        Me.LblBCAmount.AutoSize = True
        Me.LblBCAmount.Location = New System.Drawing.Point(4, 28)
        Me.LblBCAmount.Name = "LblBCAmount"
        Me.LblBCAmount.Size = New System.Drawing.Size(85, 13)
        Me.LblBCAmount.TabIndex = 7
        Me.LblBCAmount.Text = "Numeric Amount"
        '
        'TxtBCMachine
        '
        Me.TxtBCMachine.Location = New System.Drawing.Point(345, 27)
        Me.TxtBCMachine.Name = "TxtBCMachine"
        Me.TxtBCMachine.Size = New System.Drawing.Size(79, 20)
        Me.TxtBCMachine.TabIndex = 6
        '
        'TxtBCTime
        '
        Me.TxtBCTime.Location = New System.Drawing.Point(345, 53)
        Me.TxtBCTime.Name = "TxtBCTime"
        Me.TxtBCTime.Size = New System.Drawing.Size(79, 20)
        Me.TxtBCTime.TabIndex = 5
        '
        'TxtBCDate
        '
        Me.TxtBCDate.Location = New System.Drawing.Point(94, 51)
        Me.TxtBCDate.Name = "TxtBCDate"
        Me.TxtBCDate.Size = New System.Drawing.Size(79, 20)
        Me.TxtBCDate.TabIndex = 4
        '
        'TxtBCAmount
        '
        Me.TxtBCAmount.Location = New System.Drawing.Point(94, 25)
        Me.TxtBCAmount.Name = "TxtBCAmount"
        Me.TxtBCAmount.Size = New System.Drawing.Size(79, 20)
        Me.TxtBCAmount.TabIndex = 3
        '
        'TmrBarcodesOne
        '
        '
        'TmrBarcodesTwo
        '
        '
        'TmrBCDate
        '
        '
        'FrmBarCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 270)
        Me.Controls.Add(Me.GrpBCPrint)
        Me.Controls.Add(Me.GrpBCEscrow)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBarCodes"
        Me.Text = "Barcodes"
        Me.GrpBCEscrow.ResumeLayout(False)
        Me.GrpBCEscrow.PerformLayout()
        Me.GrpBCPrint.ResumeLayout(False)
        Me.GrpBCPrint.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtBCHeld As System.Windows.Forms.TextBox
    Friend WithEvents LblBCEscrow As System.Windows.Forms.Label
    Friend WithEvents BtnBCAccept As System.Windows.Forms.Button
    Friend WithEvents BtnBCReturn As System.Windows.Forms.Button
    Friend WithEvents GrpBCEscrow As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBCPrint As System.Windows.Forms.GroupBox
    Friend WithEvents LblBCTime As System.Windows.Forms.Label
    Friend WithEvents LblBCMachine As System.Windows.Forms.Label
    Friend WithEvents LblBCDate As System.Windows.Forms.Label
    Friend WithEvents LblBCAmount As System.Windows.Forms.Label
    Friend WithEvents TxtBCMachine As System.Windows.Forms.TextBox
    Friend WithEvents TxtBCTime As System.Windows.Forms.TextBox
    Friend WithEvents TxtBCDate As System.Windows.Forms.TextBox
    Friend WithEvents TxtBCAmount As System.Windows.Forms.TextBox
    Friend WithEvents LblBCWordAmount As System.Windows.Forms.Label
    Friend WithEvents LblBCValue As System.Windows.Forms.Label
    Friend WithEvents TxtBCValue As System.Windows.Forms.TextBox
    Friend WithEvents TxtBCWordAmount As System.Windows.Forms.TextBox
    Friend WithEvents BtnTicketPrint As System.Windows.Forms.Button
    Friend WithEvents TmrBarcodesOne As System.Windows.Forms.Timer
    Friend WithEvents TmrBarcodesTwo As System.Windows.Forms.Timer
    Friend WithEvents TmrBCDate As System.Windows.Forms.Timer
    Friend WithEvents BtnBCChangeAmount As System.Windows.Forms.Button
End Class

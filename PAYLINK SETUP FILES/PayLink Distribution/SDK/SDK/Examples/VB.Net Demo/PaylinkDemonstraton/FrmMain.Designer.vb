<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LblTitleOne = New System.Windows.Forms.Label
        Me.PctLogo = New System.Windows.Forms.PictureBox
        Me.LblAmountRead = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.TxtAmountRead = New System.Windows.Forms.TextBox
        Me.TxtTotalAmount = New System.Windows.Forms.TextBox
        Me.BtnResetAmount = New System.Windows.Forms.Button
        Me.LblPayout = New System.Windows.Forms.Label
        Me.TxtPayout = New System.Windows.Forms.TextBox
        Me.LblTotalPayout = New System.Windows.Forms.Label
        Me.TxtTotalPayout = New System.Windows.Forms.TextBox
        Me.BtnPayout = New System.Windows.Forms.Button
        Me.BtnAcceptors = New System.Windows.Forms.Button
        Me.BtnDispensers = New System.Windows.Forms.Button
        Me.BtnSwitches = New System.Windows.Forms.Button
        Me.BtnBarCodes = New System.Windows.Forms.Button
        Me.BtnMeter = New System.Windows.Forms.Button
        Me.LblAmountEscrow = New System.Windows.Forms.Label
        Me.TxtAmountEscrow = New System.Windows.Forms.TextBox
        Me.BtnAcceptEscrow = New System.Windows.Forms.Button
        Me.BtnReturnEscrow = New System.Windows.Forms.Button
        Me.TmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.ChkEscrow = New System.Windows.Forms.CheckBox
        Me.TxtPriorReset = New System.Windows.Forms.TextBox
        Me.LblAmountPriorReset = New System.Windows.Forms.Label
        Me.GrpForms = New System.Windows.Forms.GroupBox
        Me.GrpAmounts = New System.Windows.Forms.GroupBox
        Me.GrpPayout = New System.Windows.Forms.GroupBox
        Me.TxtPayStatus = New System.Windows.Forms.TextBox
        Me.LblPayStatus = New System.Windows.Forms.Label
        Me.LblTtleTwo = New System.Windows.Forms.Label
        Me.GrpEscrow = New System.Windows.Forms.GroupBox
        CType(Me.PctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpForms.SuspendLayout()
        Me.GrpAmounts.SuspendLayout()
        Me.GrpPayout.SuspendLayout()
        Me.GrpEscrow.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitleOne
        '
        Me.LblTitleOne.AutoSize = True
        Me.LblTitleOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitleOne.Location = New System.Drawing.Point(8, 6)
        Me.LblTitleOne.Name = "LblTitleOne"
        Me.LblTitleOne.Size = New System.Drawing.Size(143, 20)
        Me.LblTitleOne.TabIndex = 0
        Me.LblTitleOne.Text = "Paylink Interface"
        '
        'PctLogo
        '
        Me.PctLogo.Image = CType(resources.GetObject("PctLogo.Image"), System.Drawing.Image)
        Me.PctLogo.InitialImage = CType(resources.GetObject("PctLogo.InitialImage"), System.Drawing.Image)
        Me.PctLogo.Location = New System.Drawing.Point(175, 6)
        Me.PctLogo.Name = "PctLogo"
        Me.PctLogo.Size = New System.Drawing.Size(75, 73)
        Me.PctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PctLogo.TabIndex = 1
        Me.PctLogo.TabStop = False
        '
        'LblAmountRead
        '
        Me.LblAmountRead.AutoSize = True
        Me.LblAmountRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmountRead.Location = New System.Drawing.Point(3, 16)
        Me.LblAmountRead.Name = "LblAmountRead"
        Me.LblAmountRead.Size = New System.Drawing.Size(94, 13)
        Me.LblAmountRead.TabIndex = 2
        Me.LblAmountRead.Text = "Amount Just Read"
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.Location = New System.Drawing.Point(3, 68)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(99, 13)
        Me.LblTotalAmount.TabIndex = 3
        Me.LblTotalAmount.Text = "Total Amount Read"
        '
        'TxtAmountRead
        '
        Me.TxtAmountRead.Enabled = False
        Me.TxtAmountRead.Location = New System.Drawing.Point(6, 35)
        Me.TxtAmountRead.Name = "TxtAmountRead"
        Me.TxtAmountRead.Size = New System.Drawing.Size(87, 20)
        Me.TxtAmountRead.TabIndex = 4
        Me.TxtAmountRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalAmount
        '
        Me.TxtTotalAmount.Enabled = False
        Me.TxtTotalAmount.Location = New System.Drawing.Point(6, 87)
        Me.TxtTotalAmount.Name = "TxtTotalAmount"
        Me.TxtTotalAmount.Size = New System.Drawing.Size(87, 20)
        Me.TxtTotalAmount.TabIndex = 5
        Me.TxtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnResetAmount
        '
        Me.BtnResetAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResetAmount.Location = New System.Drawing.Point(6, 179)
        Me.BtnResetAmount.Name = "BtnResetAmount"
        Me.BtnResetAmount.Size = New System.Drawing.Size(87, 25)
        Me.BtnResetAmount.TabIndex = 6
        Me.BtnResetAmount.Text = "Reset"
        Me.BtnResetAmount.UseVisualStyleBackColor = True
        '
        'LblPayout
        '
        Me.LblPayout.AutoSize = True
        Me.LblPayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPayout.Location = New System.Drawing.Point(6, 16)
        Me.LblPayout.Name = "LblPayout"
        Me.LblPayout.Size = New System.Drawing.Size(40, 13)
        Me.LblPayout.TabIndex = 7
        Me.LblPayout.Text = "Payout"
        '
        'TxtPayout
        '
        Me.TxtPayout.Location = New System.Drawing.Point(6, 35)
        Me.TxtPayout.Name = "TxtPayout"
        Me.TxtPayout.Size = New System.Drawing.Size(87, 20)
        Me.TxtPayout.TabIndex = 8
        Me.TxtPayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalPayout
        '
        Me.LblTotalPayout.AutoSize = True
        Me.LblTotalPayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPayout.Location = New System.Drawing.Point(3, 68)
        Me.LblTotalPayout.Name = "LblTotalPayout"
        Me.LblTotalPayout.Size = New System.Drawing.Size(75, 13)
        Me.LblTotalPayout.TabIndex = 9
        Me.LblTotalPayout.Text = "Total Paid Out"
        '
        'TxtTotalPayout
        '
        Me.TxtTotalPayout.Enabled = False
        Me.TxtTotalPayout.Location = New System.Drawing.Point(6, 87)
        Me.TxtTotalPayout.Name = "TxtTotalPayout"
        Me.TxtTotalPayout.Size = New System.Drawing.Size(87, 20)
        Me.TxtTotalPayout.TabIndex = 10
        Me.TxtTotalPayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnPayout
        '
        Me.BtnPayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPayout.Location = New System.Drawing.Point(6, 179)
        Me.BtnPayout.Name = "BtnPayout"
        Me.BtnPayout.Size = New System.Drawing.Size(87, 25)
        Me.BtnPayout.TabIndex = 11
        Me.BtnPayout.Text = "Dispense"
        Me.BtnPayout.UseVisualStyleBackColor = True
        '
        'BtnAcceptors
        '
        Me.BtnAcceptors.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcceptors.Location = New System.Drawing.Point(11, 19)
        Me.BtnAcceptors.Name = "BtnAcceptors"
        Me.BtnAcceptors.Size = New System.Drawing.Size(67, 43)
        Me.BtnAcceptors.TabIndex = 12
        Me.BtnAcceptors.Text = "Acceptors"
        Me.BtnAcceptors.UseVisualStyleBackColor = True
        '
        'BtnDispensers
        '
        Me.BtnDispensers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDispensers.Location = New System.Drawing.Point(11, 70)
        Me.BtnDispensers.Name = "BtnDispensers"
        Me.BtnDispensers.Size = New System.Drawing.Size(67, 43)
        Me.BtnDispensers.TabIndex = 13
        Me.BtnDispensers.Text = "Dispensers"
        Me.BtnDispensers.UseVisualStyleBackColor = True
        '
        'BtnSwitches
        '
        Me.BtnSwitches.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSwitches.Location = New System.Drawing.Point(84, 19)
        Me.BtnSwitches.Name = "BtnSwitches"
        Me.BtnSwitches.Size = New System.Drawing.Size(67, 43)
        Me.BtnSwitches.TabIndex = 14
        Me.BtnSwitches.Text = "Switches/ LEDs"
        Me.BtnSwitches.UseVisualStyleBackColor = True
        '
        'BtnBarCodes
        '
        Me.BtnBarCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBarCodes.Location = New System.Drawing.Point(84, 70)
        Me.BtnBarCodes.Name = "BtnBarCodes"
        Me.BtnBarCodes.Size = New System.Drawing.Size(67, 43)
        Me.BtnBarCodes.TabIndex = 15
        Me.BtnBarCodes.Text = "Barcodes"
        Me.BtnBarCodes.UseVisualStyleBackColor = True
        '
        'BtnMeter
        '
        Me.BtnMeter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMeter.Location = New System.Drawing.Point(157, 19)
        Me.BtnMeter.Name = "BtnMeter"
        Me.BtnMeter.Size = New System.Drawing.Size(67, 43)
        Me.BtnMeter.TabIndex = 16
        Me.BtnMeter.Text = "Meter"
        Me.BtnMeter.UseVisualStyleBackColor = True
        '
        'LblAmountEscrow
        '
        Me.LblAmountEscrow.AutoSize = True
        Me.LblAmountEscrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmountEscrow.Location = New System.Drawing.Point(3, 19)
        Me.LblAmountEscrow.Name = "LblAmountEscrow"
        Me.LblAmountEscrow.Size = New System.Drawing.Size(68, 13)
        Me.LblAmountEscrow.TabIndex = 24
        Me.LblAmountEscrow.Text = "Amount Held"
        '
        'TxtAmountEscrow
        '
        Me.TxtAmountEscrow.Location = New System.Drawing.Point(6, 35)
        Me.TxtAmountEscrow.Name = "TxtAmountEscrow"
        Me.TxtAmountEscrow.Size = New System.Drawing.Size(72, 20)
        Me.TxtAmountEscrow.TabIndex = 25
        Me.TxtAmountEscrow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAcceptEscrow
        '
        Me.BtnAcceptEscrow.Location = New System.Drawing.Point(84, 20)
        Me.BtnAcceptEscrow.Name = "BtnAcceptEscrow"
        Me.BtnAcceptEscrow.Size = New System.Drawing.Size(67, 43)
        Me.BtnAcceptEscrow.TabIndex = 26
        Me.BtnAcceptEscrow.Text = "Accept"
        Me.BtnAcceptEscrow.UseVisualStyleBackColor = True
        '
        'BtnReturnEscrow
        '
        Me.BtnReturnEscrow.Location = New System.Drawing.Point(157, 19)
        Me.BtnReturnEscrow.Name = "BtnReturnEscrow"
        Me.BtnReturnEscrow.Size = New System.Drawing.Size(67, 43)
        Me.BtnReturnEscrow.TabIndex = 27
        Me.BtnReturnEscrow.Text = "Return"
        Me.BtnReturnEscrow.UseVisualStyleBackColor = True
        '
        'TmrMain
        '
        '
        'ChkEscrow
        '
        Me.ChkEscrow.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkEscrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEscrow.Location = New System.Drawing.Point(157, 70)
        Me.ChkEscrow.Name = "ChkEscrow"
        Me.ChkEscrow.Size = New System.Drawing.Size(67, 43)
        Me.ChkEscrow.TabIndex = 28
        Me.ChkEscrow.Text = "Escrow On"
        Me.ChkEscrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkEscrow.UseVisualStyleBackColor = True
        '
        'TxtPriorReset
        '
        Me.TxtPriorReset.Enabled = False
        Me.TxtPriorReset.Location = New System.Drawing.Point(6, 139)
        Me.TxtPriorReset.Name = "TxtPriorReset"
        Me.TxtPriorReset.Size = New System.Drawing.Size(87, 20)
        Me.TxtPriorReset.TabIndex = 29
        Me.TxtPriorReset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAmountPriorReset
        '
        Me.LblAmountPriorReset.AutoSize = True
        Me.LblAmountPriorReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmountPriorReset.Location = New System.Drawing.Point(3, 120)
        Me.LblAmountPriorReset.Name = "LblAmountPriorReset"
        Me.LblAmountPriorReset.Size = New System.Drawing.Size(104, 13)
        Me.LblAmountPriorReset.TabIndex = 30
        Me.LblAmountPriorReset.Text = "Amount Since Reset"
        '
        'GrpForms
        '
        Me.GrpForms.Controls.Add(Me.ChkEscrow)
        Me.GrpForms.Controls.Add(Me.BtnMeter)
        Me.GrpForms.Controls.Add(Me.BtnBarCodes)
        Me.GrpForms.Controls.Add(Me.BtnSwitches)
        Me.GrpForms.Controls.Add(Me.BtnDispensers)
        Me.GrpForms.Controls.Add(Me.BtnAcceptors)
        Me.GrpForms.Location = New System.Drawing.Point(12, 79)
        Me.GrpForms.Name = "GrpForms"
        Me.GrpForms.Size = New System.Drawing.Size(238, 125)
        Me.GrpForms.TabIndex = 31
        Me.GrpForms.TabStop = False
        Me.GrpForms.Text = "Details"
        '
        'GrpAmounts
        '
        Me.GrpAmounts.Controls.Add(Me.LblAmountPriorReset)
        Me.GrpAmounts.Controls.Add(Me.TxtPriorReset)
        Me.GrpAmounts.Controls.Add(Me.BtnResetAmount)
        Me.GrpAmounts.Controls.Add(Me.TxtTotalAmount)
        Me.GrpAmounts.Controls.Add(Me.TxtAmountRead)
        Me.GrpAmounts.Controls.Add(Me.LblTotalAmount)
        Me.GrpAmounts.Controls.Add(Me.LblAmountRead)
        Me.GrpAmounts.Location = New System.Drawing.Point(12, 210)
        Me.GrpAmounts.Name = "GrpAmounts"
        Me.GrpAmounts.Size = New System.Drawing.Size(115, 218)
        Me.GrpAmounts.TabIndex = 32
        Me.GrpAmounts.TabStop = False
        Me.GrpAmounts.Text = "Credit"
        '
        'GrpPayout
        '
        Me.GrpPayout.Controls.Add(Me.TxtPayStatus)
        Me.GrpPayout.Controls.Add(Me.LblPayStatus)
        Me.GrpPayout.Controls.Add(Me.BtnPayout)
        Me.GrpPayout.Controls.Add(Me.TxtTotalPayout)
        Me.GrpPayout.Controls.Add(Me.LblTotalPayout)
        Me.GrpPayout.Controls.Add(Me.TxtPayout)
        Me.GrpPayout.Controls.Add(Me.LblPayout)
        Me.GrpPayout.Location = New System.Drawing.Point(133, 210)
        Me.GrpPayout.Name = "GrpPayout"
        Me.GrpPayout.Size = New System.Drawing.Size(117, 218)
        Me.GrpPayout.TabIndex = 33
        Me.GrpPayout.TabStop = False
        Me.GrpPayout.Text = "Payout"
        '
        'TxtPayStatus
        '
        Me.TxtPayStatus.Enabled = False
        Me.TxtPayStatus.Location = New System.Drawing.Point(6, 139)
        Me.TxtPayStatus.Name = "TxtPayStatus"
        Me.TxtPayStatus.Size = New System.Drawing.Size(87, 20)
        Me.TxtPayStatus.TabIndex = 31
        Me.TxtPayStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPayStatus
        '
        Me.LblPayStatus.AutoSize = True
        Me.LblPayStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPayStatus.Location = New System.Drawing.Point(6, 120)
        Me.LblPayStatus.Name = "LblPayStatus"
        Me.LblPayStatus.Size = New System.Drawing.Size(58, 13)
        Me.LblPayStatus.TabIndex = 31
        Me.LblPayStatus.Text = "Pay Status"
        '
        'LblTtleTwo
        '
        Me.LblTtleTwo.AutoSize = True
        Me.LblTtleTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTtleTwo.Location = New System.Drawing.Point(8, 26)
        Me.LblTtleTwo.Name = "LblTtleTwo"
        Me.LblTtleTwo.Size = New System.Drawing.Size(127, 20)
        Me.LblTtleTwo.TabIndex = 35
        Me.LblTtleTwo.Text = "Demonstration"
        '
        'GrpEscrow
        '
        Me.GrpEscrow.Controls.Add(Me.BtnReturnEscrow)
        Me.GrpEscrow.Controls.Add(Me.BtnAcceptEscrow)
        Me.GrpEscrow.Controls.Add(Me.TxtAmountEscrow)
        Me.GrpEscrow.Controls.Add(Me.LblAmountEscrow)
        Me.GrpEscrow.Location = New System.Drawing.Point(12, 450)
        Me.GrpEscrow.Name = "GrpEscrow"
        Me.GrpEscrow.Size = New System.Drawing.Size(238, 75)
        Me.GrpEscrow.TabIndex = 36
        Me.GrpEscrow.TabStop = False
        Me.GrpEscrow.Text = "Escrow"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 549)
        Me.Controls.Add(Me.GrpEscrow)
        Me.Controls.Add(Me.LblTtleTwo)
        Me.Controls.Add(Me.GrpPayout)
        Me.Controls.Add(Me.GrpAmounts)
        Me.Controls.Add(Me.GrpForms)
        Me.Controls.Add(Me.PctLogo)
        Me.Controls.Add(Me.LblTitleOne)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.Text = "Aardvark Embedded Solutions"
        CType(Me.PctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpForms.ResumeLayout(False)
        Me.GrpAmounts.ResumeLayout(False)
        Me.GrpAmounts.PerformLayout()
        Me.GrpPayout.ResumeLayout(False)
        Me.GrpPayout.PerformLayout()
        Me.GrpEscrow.ResumeLayout(False)
        Me.GrpEscrow.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitleOne As System.Windows.Forms.Label
    Friend WithEvents PctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents LblAmountRead As System.Windows.Forms.Label
    Friend WithEvents LblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents TxtAmountRead As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents BtnResetAmount As System.Windows.Forms.Button
    Friend WithEvents LblPayout As System.Windows.Forms.Label
    Friend WithEvents TxtPayout As System.Windows.Forms.TextBox
    Friend WithEvents LblTotalPayout As System.Windows.Forms.Label
    Friend WithEvents TxtTotalPayout As System.Windows.Forms.TextBox
    Friend WithEvents BtnPayout As System.Windows.Forms.Button
    Friend WithEvents BtnAcceptors As System.Windows.Forms.Button
    Friend WithEvents BtnDispensers As System.Windows.Forms.Button
    Friend WithEvents BtnSwitches As System.Windows.Forms.Button
    Friend WithEvents BtnBarCodes As System.Windows.Forms.Button
    Friend WithEvents BtnMeter As System.Windows.Forms.Button
    Friend WithEvents LblAmountEscrow As System.Windows.Forms.Label
    Friend WithEvents TxtAmountEscrow As System.Windows.Forms.TextBox
    Friend WithEvents BtnAcceptEscrow As System.Windows.Forms.Button
    Friend WithEvents BtnReturnEscrow As System.Windows.Forms.Button
    Friend WithEvents TmrMain As System.Windows.Forms.Timer
    Friend WithEvents ChkEscrow As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPriorReset As System.Windows.Forms.TextBox
    Friend WithEvents LblAmountPriorReset As System.Windows.Forms.Label
    Friend WithEvents GrpForms As System.Windows.Forms.GroupBox
    Friend WithEvents GrpAmounts As System.Windows.Forms.GroupBox
    Friend WithEvents GrpPayout As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPayStatus As System.Windows.Forms.TextBox
    Friend WithEvents LblPayStatus As System.Windows.Forms.Label
    Friend WithEvents LblTtleTwo As System.Windows.Forms.Label
    Friend WithEvents GrpEscrow As System.Windows.Forms.GroupBox

End Class

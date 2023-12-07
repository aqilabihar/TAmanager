<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Logindosen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(84, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Login Dosen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(39, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "password"
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(97, 109)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(100, 20)
        Me.txtpassword.TabIndex = 9
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(97, 83)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(100, 20)
        Me.txtusername.TabIndex = 8
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(97, 155)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "login"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(51, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "NIP"
        '
        'Logindosen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(273, 225)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Logindosen"
        Me.Text = "Logindosen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents txtusername As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
End Class

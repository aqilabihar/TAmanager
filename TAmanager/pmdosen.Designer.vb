<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pmdosen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Lblwelkum = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lblwelkum
        '
        Me.Lblwelkum.AutoSize = True
        Me.Lblwelkum.Location = New System.Drawing.Point(219, 136)
        Me.Lblwelkum.Name = "Lblwelkum"
        Me.Lblwelkum.Size = New System.Drawing.Size(39, 13)
        Me.Lblwelkum.TabIndex = 0
        Me.Lblwelkum.Text = "Label1"
        '
        'pmdosen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 333)
        Me.Controls.Add(Me.Lblwelkum)
        Me.Name = "pmdosen"
        Me.Text = "pmdosen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lblwelkum As Label
End Class

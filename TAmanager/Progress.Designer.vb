<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Progress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Progress))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tahapan = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcatatan = New System.Windows.Forms.TextBox()
        Me.input = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.nama = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 110)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(207, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tahapan"
        '
        'tahapan
        '
        Me.tahapan.Location = New System.Drawing.Point(286, 54)
        Me.tahapan.Margin = New System.Windows.Forms.Padding(2)
        Me.tahapan.Name = "tahapan"
        Me.tahapan.Size = New System.Drawing.Size(243, 20)
        Me.tahapan.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 97)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "catatan"
        '
        'txtcatatan
        '
        Me.txtcatatan.Location = New System.Drawing.Point(286, 97)
        Me.txtcatatan.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcatatan.Name = "txtcatatan"
        Me.txtcatatan.Size = New System.Drawing.Size(243, 20)
        Me.txtcatatan.TabIndex = 6
        '
        'input
        '
        Me.input.Location = New System.Drawing.Point(327, 159)
        Me.input.Margin = New System.Windows.Forms.Padding(2)
        Me.input.Name = "input"
        Me.input.Size = New System.Drawing.Size(71, 39)
        Me.input.TabIndex = 9
        Me.input.Text = "Input"
        Me.input.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(286, 134)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'nama
        '
        Me.nama.AutoSize = True
        Me.nama.Location = New System.Drawing.Point(283, 15)
        Me.nama.Name = "nama"
        Me.nama.Size = New System.Drawing.Size(39, 13)
        Me.nama.TabIndex = 11
        Me.nama.Text = "Label4"
        '
        'Progress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 446)
        Me.Controls.Add(Me.nama)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.input)
        Me.Controls.Add(Me.txtcatatan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tahapan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Progress"
        Me.Text = "Progress"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tahapan As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcatatan As TextBox
    Friend WithEvents input As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents nama As Label
End Class

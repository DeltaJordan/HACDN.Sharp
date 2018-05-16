<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TitleID_Label = New System.Windows.Forms.Label()
        Me.TitleID_Input = New System.Windows.Forms.TextBox()
        Me.DownloadButton = New System.Windows.Forms.Button()
        Me.DID_Label = New System.Windows.Forms.Label()
        Me.DID_Input = New System.Windows.Forms.TextBox()
        Me.Version_Input = New System.Windows.Forms.TextBox()
        Me.Version_Label = New System.Windows.Forms.Label()
        Me.Status_Bar = New System.Windows.Forms.StatusStrip()
        Me.AmountDownloaded = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Seperator1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalFileSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Seperator2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PercentDownloaded = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_Bar.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleID_Label
        '
        Me.TitleID_Label.AutoSize = True
        Me.TitleID_Label.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TitleID_Label.Location = New System.Drawing.Point(12, 7)
        Me.TitleID_Label.Name = "TitleID_Label"
        Me.TitleID_Label.Size = New System.Drawing.Size(123, 36)
        Me.TitleID_Label.TabIndex = 3
        Me.TitleID_Label.Text = "Title ID:"
        '
        'TitleID_Input
        '
        Me.TitleID_Input.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TitleID_Input.Location = New System.Drawing.Point(141, 1)
        Me.TitleID_Input.Name = "TitleID_Input"
        Me.TitleID_Input.Size = New System.Drawing.Size(300, 44)
        Me.TitleID_Input.TabIndex = 0
        '
        'DownloadButton
        '
        Me.DownloadButton.Font = New System.Drawing.Font("Arial", 28.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadButton.Location = New System.Drawing.Point(588, 5)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(409, 99)
        Me.DownloadButton.TabIndex = 19
        Me.DownloadButton.Text = "Download"
        Me.DownloadButton.UseVisualStyleBackColor = True
        '
        'DID_Label
        '
        Me.DID_Label.AutoSize = True
        Me.DID_Label.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.DID_Label.Location = New System.Drawing.Point(-3, 63)
        Me.DID_Label.Name = "DID_Label"
        Me.DID_Label.Size = New System.Drawing.Size(142, 32)
        Me.DID_Label.TabIndex = 21
        Me.DID_Label.Text = "Device ID:"
        '
        'DID_Input
        '
        Me.DID_Input.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.DID_Input.Location = New System.Drawing.Point(141, 52)
        Me.DID_Input.Name = "DID_Input"
        Me.DID_Input.Size = New System.Drawing.Size(300, 44)
        Me.DID_Input.TabIndex = 20
        '
        'Version_Input
        '
        Me.Version_Input.Enabled = False
        Me.Version_Input.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Version_Input.Location = New System.Drawing.Point(452, 52)
        Me.Version_Input.Name = "Version_Input"
        Me.Version_Input.Size = New System.Drawing.Size(123, 44)
        Me.Version_Input.TabIndex = 22
        Me.Version_Input.Text = "0"
        '
        'Version_Label
        '
        Me.Version_Label.AutoSize = True
        Me.Version_Label.Enabled = False
        Me.Version_Label.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Version_Label.Location = New System.Drawing.Point(457, 13)
        Me.Version_Label.Name = "Version_Label"
        Me.Version_Label.Size = New System.Drawing.Size(129, 36)
        Me.Version_Label.TabIndex = 23
        Me.Version_Label.Text = "Version:"
        '
        'Status_Bar
        '
        Me.Status_Bar.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Status_Bar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AmountDownloaded, Me.Seperator1, Me.TotalFileSize, Me.Seperator2, Me.PercentDownloaded})
        Me.Status_Bar.Location = New System.Drawing.Point(0, 111)
        Me.Status_Bar.Name = "Status_Bar"
        Me.Status_Bar.Size = New System.Drawing.Size(998, 38)
        Me.Status_Bar.SizingGrip = False
        Me.Status_Bar.TabIndex = 27
        Me.Status_Bar.Text = "Status_Bar"
        Me.Status_Bar.Visible = False
        '
        'AmountDownloaded
        '
        Me.AmountDownloaded.Name = "AmountDownloaded"
        Me.AmountDownloaded.Size = New System.Drawing.Size(82, 33)
        Me.AmountDownloaded.Text = "0.0MB"
        '
        'Seperator1
        '
        Me.Seperator1.Name = "Seperator1"
        Me.Seperator1.Size = New System.Drawing.Size(24, 33)
        Me.Seperator1.Text = "/"
        '
        'TotalFileSize
        '
        Me.TotalFileSize.Name = "TotalFileSize"
        Me.TotalFileSize.Size = New System.Drawing.Size(82, 33)
        Me.TotalFileSize.Text = "0.0MB"
        '
        'Seperator2
        '
        Me.Seperator2.Name = "Seperator2"
        Me.Seperator2.Size = New System.Drawing.Size(24, 33)
        Me.Seperator2.Text = "/"
        '
        'PercentDownloaded
        '
        Me.PercentDownloaded.Name = "PercentDownloaded"
        Me.PercentDownloaded.Size = New System.Drawing.Size(66, 33)
        Me.PercentDownloaded.Text = "0.0%"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 149)
        Me.Controls.Add(Me.Status_Bar)
        Me.Controls.Add(Me.Version_Label)
        Me.Controls.Add(Me.Version_Input)
        Me.Controls.Add(Me.DID_Label)
        Me.Controls.Add(Me.DID_Input)
        Me.Controls.Add(Me.DownloadButton)
        Me.Controls.Add(Me.TitleID_Label)
        Me.Controls.Add(Me.TitleID_Input)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "HACDN"
        Me.Status_Bar.ResumeLayout(False)
        Me.Status_Bar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TitleID_Label As Label
    Friend WithEvents TitleID_Input As TextBox
    Friend WithEvents DownloadButton As Button
    Friend WithEvents DID_Label As Label
    Friend WithEvents DID_Input As TextBox
    Friend WithEvents Version_Input As TextBox
    Friend WithEvents Version_Label As Label
    Friend WithEvents Status_Bar As StatusStrip
    Friend WithEvents AmountDownloaded As ToolStripStatusLabel
    Friend WithEvents Seperator1 As ToolStripStatusLabel
    Friend WithEvents TotalFileSize As ToolStripStatusLabel
    Friend WithEvents Seperator2 As ToolStripStatusLabel
    Friend WithEvents PercentDownloaded As ToolStripStatusLabel
End Class

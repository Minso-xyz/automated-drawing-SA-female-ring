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
        Me.textbox_internalDiameter = New System.Windows.Forms.TextBox()
        Me.label_internalDiameter = New System.Windows.Forms.Label()
        Me.label_first = New System.Windows.Forms.Label()
        Me.label_externalDiameter = New System.Windows.Forms.Label()
        Me.textbox_externalDiameter = New System.Windows.Forms.TextBox()
        Me.label_slash = New System.Windows.Forms.Label()
        Me.label_per = New System.Windows.Forms.Label()
        Me.label_height = New System.Windows.Forms.Label()
        Me.textbox_height = New System.Windows.Forms.TextBox()
        Me.button_ok = New System.Windows.Forms.Button()
        Me.radiobutton_rodSplit1 = New System.Windows.Forms.RadioButton()
        Me.radiobutton_rodSplit2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textbox_drawingNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textbox_object = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textbox_signature = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboBox_materialType = New System.Windows.Forms.ComboBox()
        Me.checkBox_thirdParty = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comboBox_revision = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textbox_description = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.textbox_housingHeight = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.radiobutton_pisEndless = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'textbox_internalDiameter
        '
        Me.textbox_internalDiameter.Location = New System.Drawing.Point(11, 64)
        Me.textbox_internalDiameter.Margin = New System.Windows.Forms.Padding(2)
        Me.textbox_internalDiameter.Name = "textbox_internalDiameter"
        Me.textbox_internalDiameter.Size = New System.Drawing.Size(60, 20)
        Me.textbox_internalDiameter.TabIndex = 0
        '
        'label_internalDiameter
        '
        Me.label_internalDiameter.AutoSize = True
        Me.label_internalDiameter.Location = New System.Drawing.Point(9, 48)
        Me.label_internalDiameter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_internalDiameter.Name = "label_internalDiameter"
        Me.label_internalDiameter.Size = New System.Drawing.Size(65, 13)
        Me.label_internalDiameter.TabIndex = 1
        Me.label_internalDiameter.Text = "Int. diameter"
        '
        'label_first
        '
        Me.label_first.AutoSize = True
        Me.label_first.Location = New System.Drawing.Point(9, 16)
        Me.label_first.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_first.Name = "label_first"
        Me.label_first.Size = New System.Drawing.Size(200, 13)
        Me.label_first.TabIndex = 2
        Me.label_first.Text = "Please fill the below form and click ""OK""."
        '
        'label_externalDiameter
        '
        Me.label_externalDiameter.AutoSize = True
        Me.label_externalDiameter.Location = New System.Drawing.Point(84, 48)
        Me.label_externalDiameter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_externalDiameter.Name = "label_externalDiameter"
        Me.label_externalDiameter.Size = New System.Drawing.Size(68, 13)
        Me.label_externalDiameter.TabIndex = 3
        Me.label_externalDiameter.Text = "Ext. diameter"
        '
        'textbox_externalDiameter
        '
        Me.textbox_externalDiameter.Location = New System.Drawing.Point(87, 64)
        Me.textbox_externalDiameter.Margin = New System.Windows.Forms.Padding(2)
        Me.textbox_externalDiameter.Name = "textbox_externalDiameter"
        Me.textbox_externalDiameter.Size = New System.Drawing.Size(60, 20)
        Me.textbox_externalDiameter.TabIndex = 4
        '
        'label_slash
        '
        Me.label_slash.AutoSize = True
        Me.label_slash.Location = New System.Drawing.Point(73, 67)
        Me.label_slash.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_slash.Name = "label_slash"
        Me.label_slash.Size = New System.Drawing.Size(12, 13)
        Me.label_slash.TabIndex = 5
        Me.label_slash.Text = "/"
        '
        'label_per
        '
        Me.label_per.AutoSize = True
        Me.label_per.Location = New System.Drawing.Point(151, 68)
        Me.label_per.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_per.Name = "label_per"
        Me.label_per.Size = New System.Drawing.Size(11, 13)
        Me.label_per.TabIndex = 6
        Me.label_per.Text = "*"
        '
        'label_height
        '
        Me.label_height.AutoSize = True
        Me.label_height.Location = New System.Drawing.Point(164, 48)
        Me.label_height.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label_height.Name = "label_height"
        Me.label_height.Size = New System.Drawing.Size(38, 13)
        Me.label_height.TabIndex = 7
        Me.label_height.Text = "Height"
        '
        'textbox_height
        '
        Me.textbox_height.Location = New System.Drawing.Point(166, 64)
        Me.textbox_height.Margin = New System.Windows.Forms.Padding(2)
        Me.textbox_height.Name = "textbox_height"
        Me.textbox_height.Size = New System.Drawing.Size(60, 20)
        Me.textbox_height.TabIndex = 8
        '
        'button_ok
        '
        Me.button_ok.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.button_ok.Location = New System.Drawing.Point(154, 349)
        Me.button_ok.Margin = New System.Windows.Forms.Padding(2)
        Me.button_ok.Name = "button_ok"
        Me.button_ok.Size = New System.Drawing.Size(69, 35)
        Me.button_ok.TabIndex = 9
        Me.button_ok.Text = "OK"
        Me.button_ok.UseVisualStyleBackColor = False
        '
        'radiobutton_rodSplit1
        '
        Me.radiobutton_rodSplit1.AutoSize = True
        Me.radiobutton_rodSplit1.Location = New System.Drawing.Point(11, 101)
        Me.radiobutton_rodSplit1.Margin = New System.Windows.Forms.Padding(2)
        Me.radiobutton_rodSplit1.Name = "radiobutton_rodSplit1"
        Me.radiobutton_rodSplit1.Size = New System.Drawing.Size(85, 17)
        Me.radiobutton_rodSplit1.TabIndex = 11
        Me.radiobutton_rodSplit1.TabStop = True
        Me.radiobutton_rodSplit1.Text = "ROD - 1 split"
        Me.radiobutton_rodSplit1.UseVisualStyleBackColor = True
        '
        'radiobutton_rodSplit2
        '
        Me.radiobutton_rodSplit2.AutoSize = True
        Me.radiobutton_rodSplit2.Location = New System.Drawing.Point(11, 123)
        Me.radiobutton_rodSplit2.Margin = New System.Windows.Forms.Padding(2)
        Me.radiobutton_rodSplit2.Name = "radiobutton_rodSplit2"
        Me.radiobutton_rodSplit2.Size = New System.Drawing.Size(90, 17)
        Me.radiobutton_rodSplit2.TabIndex = 12
        Me.radiobutton_rodSplit2.TabStop = True
        Me.radiobutton_rodSplit2.Text = "ROD - 2 splits"
        Me.radiobutton_rodSplit2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Drawing N° :"
        '
        'textbox_drawingNumber
        '
        Me.textbox_drawingNumber.AcceptsReturn = True
        Me.textbox_drawingNumber.Location = New System.Drawing.Point(83, 180)
        Me.textbox_drawingNumber.Name = "textbox_drawingNumber"
        Me.textbox_drawingNumber.Size = New System.Drawing.Size(141, 20)
        Me.textbox_drawingNumber.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Object :"
        '
        'textbox_object
        '
        Me.textbox_object.Location = New System.Drawing.Point(83, 207)
        Me.textbox_object.Name = "textbox_object"
        Me.textbox_object.Size = New System.Drawing.Size(141, 20)
        Me.textbox_object.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Signature :"
        '
        'textbox_signature
        '
        Me.textbox_signature.Location = New System.Drawing.Point(176, 262)
        Me.textbox_signature.Name = "textbox_signature"
        Me.textbox_signature.Size = New System.Drawing.Size(48, 20)
        Me.textbox_signature.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Material :"
        '
        'comboBox_materialType
        '
        Me.comboBox_materialType.FormattingEnabled = True
        Me.comboBox_materialType.Items.AddRange(New Object() {"Nylon 6/6", "PTFE", "POM", "PEEK"})
        Me.comboBox_materialType.Location = New System.Drawing.Point(83, 233)
        Me.comboBox_materialType.Name = "comboBox_materialType"
        Me.comboBox_materialType.Size = New System.Drawing.Size(141, 21)
        Me.comboBox_materialType.TabIndex = 23
        '
        'checkBox_thirdParty
        '
        Me.checkBox_thirdParty.AutoSize = True
        Me.checkBox_thirdParty.Location = New System.Drawing.Point(15, 349)
        Me.checkBox_thirdParty.Name = "checkBox_thirdParty"
        Me.checkBox_thirdParty.Size = New System.Drawing.Size(138, 17)
        Me.checkBox_thirdParty.TabIndex = 25
        Me.checkBox_thirdParty.Text = "Drawing for a third party"
        Me.checkBox_thirdParty.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Rev. :"
        '
        'comboBox_revision
        '
        Me.comboBox_revision.FormattingEnabled = True
        Me.comboBox_revision.Items.AddRange(New Object() {"0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "X", "Y", "Z"})
        Me.comboBox_revision.Location = New System.Drawing.Point(54, 262)
        Me.comboBox_revision.Name = "comboBox_revision"
        Me.comboBox_revision.Size = New System.Drawing.Size(54, 21)
        Me.comboBox_revision.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Modification :"
        '
        'textbox_description
        '
        Me.textbox_description.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.textbox_description.Location = New System.Drawing.Point(16, 312)
        Me.textbox_description.Name = "textbox_description"
        Me.textbox_description.Size = New System.Drawing.Size(207, 20)
        Me.textbox_description.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(201, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "[mm]"
        '
        'textbox_housingHeight
        '
        Me.textbox_housingHeight.Location = New System.Drawing.Point(166, 112)
        Me.textbox_housingHeight.Name = "textbox_housingHeight"
        Me.textbox_housingHeight.Size = New System.Drawing.Size(60, 20)
        Me.textbox_housingHeight.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(151, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Housing height"
        '
        'radiobutton_pisEndless
        '
        Me.radiobutton_pisEndless.AutoSize = True
        Me.radiobutton_pisEndless.Location = New System.Drawing.Point(11, 145)
        Me.radiobutton_pisEndless.Name = "radiobutton_pisEndless"
        Me.radiobutton_pisEndless.Size = New System.Drawing.Size(158, 17)
        Me.radiobutton_pisEndless.TabIndex = 34
        Me.radiobutton_pisEndless.TabStop = True
        Me.radiobutton_pisEndless.Text = "PIS - Endless (Coming soon)"
        Me.radiobutton_pisEndless.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(239, 397)
        Me.Controls.Add(Me.radiobutton_pisEndless)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.textbox_housingHeight)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.textbox_description)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.comboBox_revision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.checkBox_thirdParty)
        Me.Controls.Add(Me.comboBox_materialType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textbox_signature)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.textbox_object)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textbox_drawingNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.radiobutton_rodSplit2)
        Me.Controls.Add(Me.radiobutton_rodSplit1)
        Me.Controls.Add(Me.button_ok)
        Me.Controls.Add(Me.textbox_height)
        Me.Controls.Add(Me.label_height)
        Me.Controls.Add(Me.label_per)
        Me.Controls.Add(Me.label_slash)
        Me.Controls.Add(Me.textbox_externalDiameter)
        Me.Controls.Add(Me.label_externalDiameter)
        Me.Controls.Add(Me.label_first)
        Me.Controls.Add(Me.label_internalDiameter)
        Me.Controls.Add(Me.textbox_internalDiameter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "SA female ring creator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textbox_internalDiameter As TextBox
    Friend WithEvents label_internalDiameter As Label
    Friend WithEvents label_first As Label
    Friend WithEvents label_externalDiameter As Label
    Friend WithEvents textbox_externalDiameter As TextBox
    Friend WithEvents label_slash As Label
    Friend WithEvents label_per As Label
    Friend WithEvents label_height As Label
    Friend WithEvents textbox_height As TextBox
    Friend WithEvents button_ok As Button
    Friend WithEvents radiobutton_rodSplit1 As RadioButton
    Friend WithEvents radiobutton_rodSplit2 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents textbox_drawingNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents textbox_object As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents textbox_signature As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents comboBox_materialType As ComboBox
    Friend WithEvents checkBox_thirdParty As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents comboBox_revision As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents textbox_description As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents textbox_housingHeight As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents radiobutton_pisEndless As RadioButton
End Class

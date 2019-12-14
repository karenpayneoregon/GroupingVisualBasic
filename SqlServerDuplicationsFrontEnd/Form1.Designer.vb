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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataTableCheckedButton = New System.Windows.Forms.Button()
        Me.ExitApplicationButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CustomerListDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListCheckedButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.CustomerListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DataTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListCheckedButton)
        Me.Panel1.Controls.Add(Me.DataTableCheckedButton)
        Me.Panel1.Controls.Add(Me.ExitApplicationButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 536)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(647, 61)
        Me.Panel1.TabIndex = 0
        '
        'DataTableCheckedButton
        '
        Me.DataTableCheckedButton.Location = New System.Drawing.Point(165, 15)
        Me.DataTableCheckedButton.Name = "DataTableCheckedButton"
        Me.DataTableCheckedButton.Size = New System.Drawing.Size(147, 23)
        Me.DataTableCheckedButton.TabIndex = 3
        Me.DataTableCheckedButton.Text = "DataTable Checked"
        Me.DataTableCheckedButton.UseVisualStyleBackColor = True
        '
        'ExitApplicationButton
        '
        Me.ExitApplicationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitApplicationButton.Location = New System.Drawing.Point(560, 15)
        Me.ExitApplicationButton.Name = "ExitApplicationButton"
        Me.ExitApplicationButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitApplicationButton.TabIndex = 2
        Me.ExitApplicationButton.Text = "Exit"
        Me.ExitApplicationButton.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CustomerListDataGridView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataTableDataGridView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Size = New System.Drawing.Size(647, 536)
        Me.SplitContainer1.SplitterDistance = 275
        Me.SplitContainer1.TabIndex = 1
        '
        'CustomerListDataGridView
        '
        Me.CustomerListDataGridView.AllowUserToAddRows = False
        Me.CustomerListDataGridView.AllowUserToDeleteRows = False
        Me.CustomerListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CustomerListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomerListDataGridView.Location = New System.Drawing.Point(0, 33)
        Me.CustomerListDataGridView.Name = "CustomerListDataGridView"
        Me.CustomerListDataGridView.Size = New System.Drawing.Size(647, 242)
        Me.CustomerListDataGridView.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(647, 33)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "List DataGridView"
        '
        'DataTableDataGridView
        '
        Me.DataTableDataGridView.AllowUserToAddRows = False
        Me.DataTableDataGridView.AllowUserToDeleteRows = False
        Me.DataTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataTableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataTableDataGridView.Location = New System.Drawing.Point(0, 33)
        Me.DataTableDataGridView.Name = "DataTableDataGridView"
        Me.DataTableDataGridView.Size = New System.Drawing.Size(647, 224)
        Me.DataTableDataGridView.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(647, 33)
        Me.Panel3.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DataTable DataGridView"
        '
        'ListCheckedButton
        '
        Me.ListCheckedButton.Location = New System.Drawing.Point(12, 15)
        Me.ListCheckedButton.Name = "ListCheckedButton"
        Me.ListCheckedButton.Size = New System.Drawing.Size(147, 23)
        Me.ListCheckedButton.TabIndex = 4
        Me.ListCheckedButton.Text = "List Checked"
        Me.ListCheckedButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 597)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicate locator for DataTable and List(Of T)"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.CustomerListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CustomerListDataGridView As DataGridView
    Friend WithEvents DataTableDataGridView As DataGridView
    Friend WithEvents ExitApplicationButton As Button
    Friend WithEvents DataTableCheckedButton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ListCheckedButton As Button
End Class

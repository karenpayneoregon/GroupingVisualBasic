<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProductCatagoryGroupSortButton = New System.Windows.Forms.Button()
        Me.GroupProductByCategoryButton = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupProductByCategoryButton)
        Me.Panel1.Controls.Add(Me.ProductCatagoryGroupSortButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 386)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(405, 64)
        Me.Panel1.TabIndex = 0
        '
        'ProductCatagoryGroupSortButton
        '
        Me.ProductCatagoryGroupSortButton.Location = New System.Drawing.Point(199, 20)
        Me.ProductCatagoryGroupSortButton.Name = "ProductCatagoryGroupSortButton"
        Me.ProductCatagoryGroupSortButton.Size = New System.Drawing.Size(181, 23)
        Me.ProductCatagoryGroupSortButton.TabIndex = 0
        Me.ProductCatagoryGroupSortButton.Text = "Product Catagory group/sort"
        Me.ProductCatagoryGroupSortButton.UseVisualStyleBackColor = True
        '
        'GroupProductByCategoryButton
        '
        Me.GroupProductByCategoryButton.Location = New System.Drawing.Point(12, 20)
        Me.GroupProductByCategoryButton.Name = "GroupProductByCategoryButton"
        Me.GroupProductByCategoryButton.Size = New System.Drawing.Size(181, 23)
        Me.GroupProductByCategoryButton.TabIndex = 1
        Me.GroupProductByCategoryButton.Text = "Product Catagory group"
        Me.GroupProductByCategoryButton.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(405, 386)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Catagory"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Product"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 450)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EF6 Group/sort examples"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ProductCatagoryGroupSortButton As Button
    Friend WithEvents GroupProductByCategoryButton As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class

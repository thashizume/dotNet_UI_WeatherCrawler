Public Class ucPrefectureBlock

    Private Sub ucPrefectureBlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim p As New jp.polestar.weather.Prefecture
        cbPrefecture.DataSource = p.Prefecture
        cbPrefecture.DisplayMember = p.Prefecture.Columns(0).ColumnName
        cbPrefecture.ValueMember = p.Prefecture.Columns(0).ColumnName

        clearScreen()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearScreen()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click


        ' TODO:  Add Error Provider

        '   Flush to File
        Dim pb As New jp.polestar.weather.PrefectureBlock
        pb.Add(cbPrefecture.Text, txtBlockNumber.Text, txtBlockName.Text)
        DataGridView1.DataSource = pb.PrefectureBlock

        clearScreen()


    End Sub

    Private Sub clearScreen()
        Dim p As New jp.polestar.weather.Prefecture
        cbPrefecture.DataSource = p.Prefecture
        cbPrefecture.DisplayMember = p.Prefecture.Columns(1).ColumnName
        cbPrefecture.ValueMember = p.Prefecture.Columns(1).ColumnName

        txtBlockNumber.Text = String.Empty
        txtBlockName.Text = String.Empty

        Dim pb As New jp.polestar.weather.PrefectureBlock
        DataGridView1.DataSource = pb.PrefectureBlock

        updateTreeNode()

    End Sub

    Private Sub updateTreeNode()

        ' Dim tv As New TreeView
        CType(Me.Parent.Parent.Controls(0).Controls(0), System.Windows.Forms.TreeView).Nodes.Clear()

        For Each row1 As DataRow In (New jp.polestar.weather.Prefecture).Prefecture.Rows
            Dim tvn As New TreeNode(row1(1).ToString)
            For Each row2 As DataRow In (New jp.polestar.weather.PrefectureBlock).PrefectureBlock.Rows
                If row1(1) = row2(0) Then
                    tvn.Nodes.Add(New TreeNode(row2(2)))
                End If
            Next

            CType(Me.Parent.Parent.Controls(0).Controls(0), System.Windows.Forms.TreeView).Nodes.Add(tvn)
        Next


    End Sub

End Class

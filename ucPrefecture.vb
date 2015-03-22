Public Class ucPrefecture

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        ' TODO:  Add Error Provider
        
        '   Flush to File
        Dim p As New jp.polestar.weather.Prefecture
        p.Add(txtPrefectureName.Text, txtPrefectureNumber.Text)
        DataGridView1.DataSource = p.Prefecture

        clearScreen()


    End Sub




    Private Sub ucPrefecture_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim p As New jp.polestar.weather.Prefecture
        p.LoadFile()
        DataGridView1.DataSource = p.Prefecture

        clearScreen()

    End Sub


    Private Sub clearScreen()

        txtPrefectureName.Text = String.Empty
        txtPrefectureNumber.Text = String.Empty

        updateTreeNode()

    End Sub


    Private Sub updateTreeNode()

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

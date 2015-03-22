Public Class Form1

    Private _p As List(Of String)
    Private _dv As System.Data.DataView = Nothing

    Private Sub PrefectureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrefectureToolStripMenuItem.Click

        SplitContainer1.Panel2.Controls.Clear()
        SplitContainer1.Panel2.Controls.Add(New ucPrefecture)


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()

    End Sub

    Private Sub BlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockToolStripMenuItem.Click

        SplitContainer1.Panel2.Controls.Clear()
        SplitContainer1.Panel2.Controls.Add(New ucPrefectureBlock)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        _dv = New System.Data.DataView((New jp.polestar.weather.WeatherPoint).WeatherPoint)
        DataGridView1.DataSource = _dv








        updateTreeNode()

    End Sub


    Private Sub updateTreeNode()



        Dim tv As New TreeView
        Dim wp As New jp.polestar.weather.WeatherPoint

        '_p = wp.getPrefectureList()
        'TreeView1.Nodes.Clear()

        'For Each p As String In _p
        '    TreeView1.Nodes.Add(p.ToString, p.ToString)

        '    Dim tvn As New TreeNode



        '    Dim dp As Dictionary(Of String, String)
        '    dp = wp.getPointList(p.ToString)

        '    For Each key As String In dp.Keys
        '        tvn.Nodes.Add(dp(key))
        '    Next

        '    TreeView1.Nodes(p.ToString).Nodes.Add(tvn)

        '    'TreeView1.Nodes.Add(tvn)
        'Next





        'For Each row1 As DataRow In (New jp.polestar.weather.Prefecture).Prefecture.Rows
        '    Dim tvn As New TreeNode(row1(1).ToString)
        '    For Each row2 As DataRow In (New jp.polestar.weather.PrefectureBlock).PrefectureBlock.Rows
        '        If row1(1) = row2(0) Then
        '            tvn.Nodes.Add(New TreeNode(row2(2)))
        '        End If
        '    Next

        '    TreeView1.Nodes.Add(tvn)
        'Next


    End Sub

    Private Sub DebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugToolStripMenuItem.Click

        Dim c As New jp.polestar.weather.Crawl
        Dim cc As New jp.polestar.weather.WeatherPoint


        SplitContainer1.Panel2.Controls.Clear()
        Dim dgv As New DataGridView

        cc.CrawlBlock("49", "1024", "1995", 20)

        dgv.DataSource = c.getWeather("49", "1024", "2014", "1")
        dgv.Dock = DockStyle.Fill
        dgv.Refresh()

        SplitContainer1.Panel2.Controls.Add(dgv)
    End Sub



    Private Sub DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DToolStripMenuItem.Click
        Dim a As New jp.polestar.weather.Crawl
        a.margeFile()
    End Sub

    Private Sub DddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DddToolStripMenuItem.Click
        Dim a As New jp.polestar.weather.Crawl
        a.margeFile()
    End Sub
End Class

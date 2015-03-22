Public Class ucCrawler

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim c As New jp.polestar.weather.WeatherPoint
        c.CrawlBlock(txtPN.Text, txtBN.Text, txtBY.Text, txtY.Text)


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim dt As System.Data.DataTable
        Dim c As New jp.polestar.weather.WeatherPoint
        dt = c.WeatherPoint

        For Each row As System.Data.DataRow In c.WeatherPoint.Rows
            c.CrawlBlock(row("PREFECTURE_NUMBER"), row("BLOCK_NUMBER"), txtBY.Text, txtY.Text)
            Application.DoEvents()
        Next


    End Sub
End Class

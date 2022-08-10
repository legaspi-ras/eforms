Imports System.Net
Imports System.Net.Mail
Imports System.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class WebForm6
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '' save yung for approval na pdf sa for approval folder


        Dim directory As String

        directory = Server.MapPath("~/pdf_files/" + lblFilename.Text)

        '  Label6.Text = directory for validation lang ito

        If File.Exists(directory) Then

            '' delete muna ang lumang file na guston paltan. --------------------------------
            '' MsgBox(" ok proceed" + directory)

            File.Delete(directory)

            ''end of deleteing --------------------------------------------------------------

            '' start saving young edited file -----------------------------------------------

            Dim contentType As String = FileUpload1.PostedFile.ContentType
            Using fs As Stream = FileUpload1.PostedFile.InputStream


                FileUpload1.SaveAs(Server.MapPath("~/for_approval/" + lblFilename.Text))


            End Using


            MsgBox("File Updated.")

            Response.Redirect(Request.Url.AbsoluteUri)

            ' end -----  upload (save) pdf file to mysql database

        Else


            Dim contentType As String = FileUpload1.PostedFile.ContentType
            Using fs As Stream = FileUpload1.PostedFile.InputStream


                FileUpload1.SaveAs(Server.MapPath("~/for_approval/" + lblFilename.Text))


            End Using
            ''MsgBox("Please select a file for upload! ")

        End If

        ''sending email na ito ------------------------------------------------------------------

        'Dim item = ListBox1.Items.Count
        'Dim counter As Integer
        'counter = 0

        'While item > counter

        '    '' label1.text = listbox1.items(counter).tostring


        '    Dim smtp_server As New SmtpClient
        '    Dim e_mail As New MailMessage()
        '    smtp_server.UseDefaultCredentials = False
        '    smtp_server.Credentials = New Net.NetworkCredential("legaspi.ras@gmail.com", "kkgqczltrqitzjag")
        '    smtp_server.Port = 587
        '    smtp_server.EnableSsl = True
        '    smtp_server.Host = "smtp.gmail.com"

        '    e_mail = New MailMessage()
        '    e_mail.From = New MailAddress("legaspi.ras@gmail.com")
        '    e_mail.To.Add(ListBox1.Items(counter).ToString)
        '    e_mail.Subject = "email sending for multiple receivers"
        '    e_mail.IsBodyHtml = False
        '    e_mail.Body = "https://www.tutorialspoint.com/vb.net/vb.net_while_loops.htm"
        '    smtp_server.Send(e_mail)
        '    MsgBox("mail sent")

        '    counter = counter + 1
        'End While




    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex())
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ListBox1.Items.Clear()
    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        '' display nya yung galing sa search data ------------------------------------------------------------
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist WHERE applicableSpecs LIKE '" & txtSearch.Text & "%'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        TextBox1.Text = reader(1)
        TextBox3.Text = reader(2)
        TextBox4.Text = reader(3)
        TextBox5.Text = reader(4)
        TextBox6.Text = reader(5)
        TextBox7.Text = reader(6)
        lblFilename.Text = reader(7)

        reader.Close()
        connection.Close()


    End Sub
End Class
Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient


Public Class Contact
    Inherits Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click


        '' dislpaying existing data ------------------------------------------------------------
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist WHERE applicableSpecs LIKE '" & txtSearch.Text & "%'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        If reader.FieldCount > 0 Then

            txtDeptarea.Enabled = True
            txtFormctrlnum.Enabled = True
            txtFormtitle.Enabled = True
            txtApplicablespecs.Enabled = True
            txtRevisionnum.Enabled = True
            txtRevdate.Enabled = True
            FileUpload1.Enabled = True
            btnUpdate.Enabled = True

            txtDeptarea.Text = reader(1)
            txtFormctrlnum.Text = reader(2)
            txtFormtitle.Text = reader(3)
            txtApplicablespecs.Text = reader(4)
            txtRevisionnum.Text = reader(5)
            txtRevdate.Text = reader(6)
            lblFilename.Text = reader(7)

        End If
        connection.Close()
        ''---------------------------------------------------------------------------------------


    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


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

                Using br As New BinaryReader(fs)

                    Dim deptarea As String
                    Dim formctrlnum As String
                    Dim frmtitle As String
                    ' Dim revdate = calDateupload.SelectedDate.ToString("yyyy-MM-dd")
                    Dim revdate
                    Dim appspecs As String
                    '' Dim pdfname As String
                    Dim revnum As String
                    Dim pdfbytes() As Byte


                    deptarea = txtDeptarea.Text
                    formctrlnum = txtFormctrlnum.Text
                    frmtitle = txtFormtitle.Text
                    appspecs = txtApplicablespecs.Text
                    ''pdfname = txtFormtitle.Text
                    '' revnum = txtRevisionnum.Text.Replace("*", "0")
                    revnum = txtRevisionnum.Text
                    revdate = txtRevdate.Text '' may error sa saving ng date dapat ang susundin na format ay (yyyy-mm-dd)
                    pdfbytes = br.ReadBytes(fs.Length)

                    Dim query As String

                    connection = New MySqlConnection
                    connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

                    query = ("UPDATE tblmasterlist SET pdfFilename = '" & lblFilename.Text & "', contentType = '" & contentType & "', pdfData = '" & pdfbytes(0) & "' WHERE applicableSpecs = '" & appspecs & "' AND formControlNum = '" & formctrlnum & "'")
                    command = New MySqlCommand(query, connection)

                    Dim reader As MySqlDataReader
                    connection.Open()
                    reader = command.ExecuteReader()
                    reader.Read()

                    FileUpload1.SaveAs(Server.MapPath("~/pdf_files/" + lblFilename.Text))

                End Using
            End Using


            MsgBox("File Updated.")

            Response.Redirect(Request.Url.AbsoluteUri)

            ' end -----  upload (save) pdf file to mysql database

        Else

            MsgBox("Please select a file for upload! ")

        End If

    End Sub
End Class
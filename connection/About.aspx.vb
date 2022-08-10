Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class About
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        '' txtDeptarea.Attributes.Add("placeholder", "i.e. MIS")
        txtFormctrlnum.Attributes.Add("placeholder", "i.e. MIS-01")
        txtFormtitle.Attributes.Add("placeholder", "i.e. Computer/Laptop Peripherals Issuance Slip")
        txtApplicablespecs.Attributes.Add("placeholder", "i.e. TFP06-001")
        txtRevisionnum.Attributes.Add("placeholder", " i.e. EL")
        txtRevdate.Attributes.Add("placeholder", "i.e yyyy-mm-dd")



    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        Dim sampletext As String

        sampletext = "*A"

        Label6.Text = sampletext.Replace("*", "0")


        Dim filename As String
        filename = Path.GetFileName(FileUpload1.FileName)

        Dim directory As String

        directory = Server.MapPath("~/pdf_files/" + filename)

        '  Label6.Text = directory for validation lang ito

        If File.Exists(directory) Then

            MsgBox("The file exists")
            Label7.Text = filename + "already existing!"

        ElseIf (FileUpload1.HasFile) Then

            ' start -----  upload (save) pdf file to mysql database

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


                    deptarea = ddlDepartment.SelectedItem.Text
                    formctrlnum = txtFormctrlnum.Text.Trim().ToUpper()
                    frmtitle = txtFormtitle.Text
                    appspecs = txtApplicablespecs.Text.Trim().ToUpper()
                    ''pdfname = txtFormtitle.Text
                    '' revnum = txtRevisionnum.Text.Replace("*", "0")
                    revnum = txtRevisionnum.Text
                    revdate = txtRevdate.Text '' may error sa saving ng date dapat ang susundin na format ay (yyyy-mm-dd)
                    pdfbytes = br.ReadBytes(fs.Length)

                    Dim query As String

                    connection = New MySqlConnection
                    connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

                    query = ("INSERT INTO tblmasterlist (departmentArea, formControlnum, formTitle, applicableSpecs, revisionNum, revisionDate, pdfFilename, contentType, pdfData) VALUES ('" & deptarea & "', '" & formctrlnum & "', '" & frmtitle & "', '" & appspecs & "', '" & revnum & "', '" & revdate & "', '" & filename & "', '" & contentType & "', '" & pdfbytes(0) & "')")

                    command = New MySqlCommand(query, connection)

                    Dim reader As MySqlDataReader
                    connection.Open()
                    reader = command.ExecuteReader()
                    reader.Read()

                    FileUpload1.SaveAs(Server.MapPath("~/pdf_files/" + filename))

                    reader.Close()
                    connection.Close()
                End Using
            End Using


            MsgBox("File Uploaded.")
            Label6.Text = filename + " has been uploaded."

            Response.Redirect(Request.Url.AbsoluteUri)

            ' end -----  upload (save) pdf file to mysql database

        Else

            MsgBox("Please select a file for upload! ")

        End If


    End Sub

    Protected Sub ddlDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepartment.SelectedIndexChanged



    End Sub
End Class
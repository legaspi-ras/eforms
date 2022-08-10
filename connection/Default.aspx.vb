Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ''call function Searchfile for loading data gridview
        If Not Me.IsPostBack Then
            Me.Searchfile()
        End If


    End Sub

    Private Sub Searchfile()
        ''function that loads all the file information in data gridview

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            gvfiles.DataSource = dt
            gvfiles.DataBind()
        End Using

        connection.Close()

    End Sub

    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        '' displaying the other data in next page

        gvfiles.PageIndex = e.NewPageIndex
        Me.Searchfile()

    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        '' search the file and display in datagridview based on the applicable specification 
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


        query = ("SELECT * FROM tblmasterlist WHERE applicableSpecs LIKE '" & txtsearch.Text & "%'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            gvfiles.DataSource = dt
            gvfiles.DataBind()
        End Using

        connection.Close()

    End Sub

    Protected Sub gvfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvfiles.SelectedIndexChanged

        ''getting the value of seleted index in grid view
        Dim formtitle As String = gvfiles.SelectedRow.Cells(2).Text
        Dim applicablespecs As String = gvfiles.SelectedRow.Cells(3).Text

        Dim filename As String

        ''create a connection to database
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        'mysql query that select the file based on the formtitle and applicable specifications
        Dim query As String
        query = ("select * from tblmasterlist where  formTitle = '" & formtitle & "' and applicableSpecs = '" & applicablespecs & "'")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        '' Dim kuha As String
        ''kuha = gvfiles.PageIndex.ToString

        '' Label1.Text = formtitle + " " + applicablespecs
        ''  Label2.Text = kuha
        ''  CustomersGridView.PageIndex = pageList.SelectedIndex

        filename = reader(7) 'getting the filename of the form

        ''Label1.Text = String.Format(ResolveUrl("~/pdf_files/" + filename + ""))

        ''Dim directory As String

        ''  Directory = Server.MapPath("~/pdf_files/" + filename)

        ''  Label2.Text = directory

        'open pdf in same page ------------------------------------------------------------------------------------------------------------

        Dim embed As String
        embed = " "
        embed = "<object data=""{0}"" type=""application/pdf"" width=""700px"" height=""700px"" > </object>"
        HyperLink1.Text = String.Format(embed, ResolveUrl("~/pdf_files/" + filename))

        Label3.Text = String.Format(ResolveUrl("~/pdf_files/" + filename))

        ''open din pdf kaso napapatungan si system-----------------------------------------------------------------------------------------

        'Dim path As String = Server.MapPath("~/pdf_files/" + filename)
        'Dim client As New WebClient()
        'Dim buffer As [Byte]() = client.DownloadData(path)

        'If buffer IsNot Nothing Then
        '    Response.ContentType = "application/pdf"
        '    Response.AddHeader("content-length", buffer.Length.ToString())
        '    Response.BinaryWrite(buffer)
        '    Response.End()

        'End If


        reader.Close()



    End Sub
End Class
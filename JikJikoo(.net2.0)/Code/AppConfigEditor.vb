'from Peter A. Bromberg, http://www.eggheadcafe.com/articles/20030907.asp
'Edited By Me

Imports System
Imports System.Xml
Imports System.Configuration
Imports System.Collections
Imports System.Reflection
Imports System.Diagnostics


Public Enum ConfigFileType
    WebConfig = 0
    AppConfig = 1
End Enum


Public Class AppConfig
    'Inherits System.Configuration.AppSettingsReader
    Public docName As String = [String].Empty
    Private node As XmlNode = Nothing
    Private _configType As Integer

  

    Public Property ConfigType() As Integer
        Get
            Return _configType
        End Get
        Set(ByVal value As Integer)
            _configType = value
        End Set
    End Property

    Public Sub New()
        Me.ConfigType = ConfigFileType.AppConfig
    End Sub

    Public Function GetValue(ByVal key As String) As String
        Dim cfgDoc As New XmlDocument()
        loadConfigDoc(cfgDoc)
        ' retrieve the appSettings node
        node = cfgDoc.SelectSingleNode("//appSettings")

        If node Is Nothing Then
            Throw New System.InvalidOperationException("appSettings section not found")
        End If

        ' XPath select setting "add" element that contains this key
        Dim addElem As XmlElement = DirectCast(node.SelectSingleNode("//add[@key='" & key & "']"), XmlElement)
        If addElem IsNot Nothing Then
            Return addElem.GetAttribute("value")
        Else
            Throw New System.InvalidOperationException("key not found")
        End If
        'save it
        saveConfigDoc(cfgDoc, docName)

    End Function



    Public Function SetValue(ByVal key As String, ByVal value As String) As Boolean
        Dim cfgDoc As New XmlDocument()
        loadConfigDoc(cfgDoc)
        ' retrieve the appSettings node
        node = cfgDoc.SelectSingleNode("//appSettings")

        If node Is Nothing Then
            Throw New System.InvalidOperationException("appSettings section not found")
        End If

        Try
            ' XPath select setting "add" element that contains this key
            Dim addElem As XmlElement = DirectCast(node.SelectSingleNode("//add[@key='" & key & "']"), XmlElement)
            If addElem IsNot Nothing Then
                addElem.SetAttribute("value", value)
            Else
                ' not found, so we need to add the element, key and value
                Dim entry As XmlElement = cfgDoc.CreateElement("add")
                entry.SetAttribute("key", key)
                entry.SetAttribute("value", value)
                node.AppendChild(entry)
            End If
            'save it
            saveConfigDoc(cfgDoc, docName)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub saveConfigDoc(ByVal cfgDoc As XmlDocument, ByVal cfgDocPath As String)
        Try
            Dim writer As New XmlTextWriter(cfgDocPath, Nothing)
            writer.Formatting = Formatting.Indented
            cfgDoc.WriteTo(writer)
            writer.Flush()
            writer.Close()
            Exit Sub
        Catch
            Throw
        End Try
    End Sub

    Public Function removeElement(ByVal elementKey As String) As Boolean
        Try
            Dim cfgDoc As New XmlDocument()
            loadConfigDoc(cfgDoc)
            ' retrieve the appSettings node
            node = cfgDoc.SelectSingleNode("//appSettings")
            If node Is Nothing Then
                Throw New System.InvalidOperationException("appSettings section not found")
            End If
            ' XPath select setting "add" element that contains this key to remove
            node.RemoveChild(node.SelectSingleNode("//add[@key='" & elementKey & "']"))

            saveConfigDoc(cfgDoc, docName)
            Return True
        Catch
            Return False
        End Try
    End Function


    Private Function loadConfigDoc(ByVal cfgDoc As XmlDocument) As XmlDocument
        ' load the config file
        If Convert.ToInt32(ConfigType) = Convert.ToInt32(ConfigFileType.AppConfig) Then

            ' docName = ((Assembly.GetEntryAssembly()).GetName()).Name
            docName = "jikjikoo.config"
        Else
            'docName = System.Web.HttpContext.Current.Server.MapPath("web.config")
        End If
        cfgDoc.Load(docName)
        Return cfgDoc
    End Function

End Class

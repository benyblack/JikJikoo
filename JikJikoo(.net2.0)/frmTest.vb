Public Class frmTest
    Dim o As New oAuthExample.oAuthTwitter(twa)

    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'o.ConsumerKey = "Um0Z859qORQgTkN4ehyqdw"
        'o.ConsumerSecret = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"
        'o.Token = "19531113-8TOSwoAKRiaSCib3sFHvbJJzodiwhPTV3DggVml2p"
        'o.TokenSecret = "sXRaGQr8SeQybNX6epQkiSwR8JUXj8SRiOXXpswwNg"
        OldLoad()

    End Sub

    Private Sub OldLoad()
        o.ConsumerKey = "Um0Z859qORQgTkN4ehyqdw"
        o.ConsumerSecret = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"



        Dim strTimestamp As String = o.GenerateTimeStamp()
        Dim strNonce As String = o.GenerateNonce()

        'Dim sign As String = o.GenerateSignature(New Uri("http://twitter.com/"), o.ConsumerKey, _
        '    o.ConsumerSecret, Nothing, Nothing, "POST", strTimestamp, strNonce, _
        '    oAuthExample.OAuthBase.SignatureTypes.HMACSHA1, "", "")
        RichTextBox1.Text = o.AuthorizationLinkGet()
        o.Token = RichTextBox1.Text.Split("=")(1)
        '  o.AccessTokenGet(RichTextBox1.Text.Split("=")(1))

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        o.AccessTokenGet(RichTextBox2.Text)
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(oAuthExample.oAuthTwitter))
        Dim sw As New IO.StringWriter()
        xs.Serialize(sw, o)
        o.ToString()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim url As String = "http://twitter.com/statuses/user_timeline.xml"
        Dim normurl As String = ""
        Dim normparam As String = ""

        o.GenerateSignature(New Uri(url), o.ConsumerKey, o.ConsumerSecret, o.Token, o.TokenSecret, "GET", o.GenerateTimeStamp(), _
                            o.GenerateNonce(), normurl, normparam)
        RichTextBox2.Text += vbCrLf & normurl & vbCrLf & normparam


    End Sub
End Class
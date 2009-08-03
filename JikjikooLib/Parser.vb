Imports System.Collections.ObjectModel
Imports System.Xml

Imports DNE.Twitter
Imports Newtonsoft.Json

Namespace DNE.JikJikoo

    ''' <summary>
    ''' Deserialize xml to twitter object
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Parser

#Region " XML "

        Public Function ParsStatusXML(ByVal s As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/statuses/status")
            Dim sc As New ObjectModel.Collection(Of DNE.Twitter.Status)

            For i As Int32 = 0 To xnl.Count - 1
                Dim st As New DNE.Twitter.Status()
                st.Favorited = xdoc.SelectNodes("/statuses/status/favorited")(i).InnerText
                st.Created_At = xdoc.SelectNodes("/statuses/status/created_at")(i).InnerText
                st.Id = xdoc.SelectNodes("/statuses/status/id")(i).InnerText
                st.In_reply_to_screen_name = xdoc.SelectNodes("/statuses/status/in_reply_to_screen_name")(i).InnerText
                st.In_reply_to_status_id = xdoc.SelectNodes("/statuses/status/in_reply_to_status_id")(i).InnerText
                st.In_reply_to_user_id = xdoc.SelectNodes("/statuses/status/in_reply_to_user_id")(i).InnerText
                st.Source = xdoc.SelectNodes("/statuses/status/source")(i).InnerText
                st.Text = xdoc.SelectNodes("/statuses/status/text")(i).InnerText
                st.Truncated = xdoc.SelectNodes("/statuses/status/truncated")(i).InnerText

                Dim u As New DNE.Twitter.User()
                u.Created_at = xdoc.SelectNodes("/statuses/status/user/created_at")(i).InnerText
                u.Description = xdoc.SelectNodes("/statuses/status/user/description")(i).InnerText
                u.Favourites_count = xdoc.SelectNodes("/statuses/status/user/favourites_count")(i).InnerText
                u.Followers_count = xdoc.SelectNodes("/statuses/status/user/followers_count")(i).InnerText
                u.Following = xdoc.SelectNodes("/statuses/status/user/following")(i).InnerText
                u.Friends_count = xdoc.SelectNodes("/statuses/status/user/friends_count")(i).InnerText
                u.Id = xdoc.SelectNodes("/statuses/status/user/id")(i).InnerText
                u.Location = xdoc.SelectNodes("/statuses/status/user/location")(i).InnerText
                u.Name = xdoc.SelectNodes("/statuses/status/user/name")(i).InnerText
                u.Notifications = xdoc.SelectNodes("/statuses/status/user/notifications")(i).InnerText
                u.Profile_background_color = xdoc.SelectNodes("/statuses/status/user/profile_background_color")(i).InnerText
                u.Profile_background_image_url = xdoc.SelectNodes("/statuses/status/user/profile_background_image_url")(i).InnerText
                u.Profile_background_tile = xdoc.SelectNodes("/statuses/status/user/profile_background_tile")(i).InnerText
                u.Profile_image_url = xdoc.SelectNodes("/statuses/status/user/profile_image_url")(i).InnerText
                u.Profile_link_color = xdoc.SelectNodes("/statuses/status/user/profile_link_color")(i).InnerText
                u.Profile_sidebar_border_color = xdoc.SelectNodes("/statuses/status/user/profile_sidebar_border_color")(i).InnerText
                u.Profile_sidebar_fill_color = xdoc.SelectNodes("/statuses/status/user/profile_sidebar_fill_color")(i).InnerText
                u.Profile_text_color = xdoc.SelectNodes("/statuses/status/user/profile_text_color")(i).InnerText
                u.Protected = xdoc.SelectNodes("/statuses/status/user/protected")(i).InnerText
                u.Screen_Name = xdoc.SelectNodes("/statuses/status/user/screen_name")(i).InnerText
                u.Statuses_count = xdoc.SelectNodes("/statuses/status/user/statuses_count")(i).InnerText
                u.Time_zone = xdoc.SelectNodes("/statuses/status/user/time_zone")(i).InnerText
                u.Url = xdoc.SelectNodes("/statuses/status/user/url")(i).InnerText
                u.Utc_offset = xdoc.SelectNodes("/statuses/status/user/utc_offset")(i).InnerText
                u.Verified = xdoc.SelectNodes("/statuses/status/user/verified")(i).InnerText
                st.User = u

                sc.Add(st)

            Next
            Return sc

        End Function

        Public Function ParsDirectmessageXML(ByVal s As String) As ObjectModel.Collection(Of DNE.Twitter.DirectMessage)
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/direct-messages/direct_message/id")
            Dim dmc As New ObjectModel.Collection(Of DNE.Twitter.DirectMessage)

            For i As Int32 = 0 To xnl.Count - 1
                Dim dm As New DNE.Twitter.DirectMessage()
                dm.created_at = xdoc.SelectNodes("/direct-messages/direct_message/created_at")(i).InnerText
                dm.id = xdoc.SelectNodes("/direct-messages/direct_message/id")(i).InnerText
                dm.recipient_id = xdoc.SelectNodes("/direct-messages/direct_message/recipient_id")(i).InnerText
                dm.recipient_screen_name = xdoc.SelectNodes("/direct-messages/direct_message/recipient_screen_name")(i).InnerText
                dm.sender_id = xdoc.SelectNodes("/direct-messages/direct_message/sender_id")(i).InnerText
                dm.sender_screen_name = xdoc.SelectNodes("/direct-messages/direct_message/sender_screen_name")(i).InnerText
                dm.text = xdoc.SelectNodes("/direct-messages/direct_message/text")(i).InnerText

                'Sender Info
                Dim u As New DNE.Twitter.User()
                u.Created_at = xdoc.SelectNodes("/direct-messages/direct_message/sender/created_at")(i).InnerText
                u.Description = xdoc.SelectNodes("/direct-messages/direct_message/sender/description")(i).InnerText
                u.Favourites_count = xdoc.SelectNodes("/direct-messages/direct_message/sender/favourites_count")(i).InnerText
                u.Followers_count = xdoc.SelectNodes("/direct-messages/direct_message/sender/followers_count")(i).InnerText
                u.Following = xdoc.SelectNodes("/direct-messages/direct_message/sender/following")(i).InnerText
                u.Friends_count = xdoc.SelectNodes("/direct-messages/direct_message/sender/friends_count")(i).InnerText
                u.Id = xdoc.SelectNodes("/direct-messages/direct_message/sender/id")(i).InnerText
                u.Location = xdoc.SelectNodes("/direct-messages/direct_message/sender/location")(i).InnerText
                u.Name = xdoc.SelectNodes("/direct-messages/direct_message/sender/name")(i).InnerText
                u.Notifications = xdoc.SelectNodes("/direct-messages/direct_message/sender/notifications")(i).InnerText
                u.Profile_background_color = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_background_color")(i).InnerText
                u.Profile_background_image_url = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_background_image_url")(i).InnerText
                u.Profile_background_tile = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_background_tile")(i).InnerText
                u.Profile_image_url = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_image_url")(i).InnerText
                u.Profile_link_color = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_link_color")(i).InnerText
                u.Profile_sidebar_border_color = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_sidebar_border_color")(i).InnerText
                u.Profile_sidebar_fill_color = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_sidebar_fill_color")(i).InnerText
                u.Profile_text_color = xdoc.SelectNodes("/direct-messages/direct_message/sender/profile_text_color")(i).InnerText
                u.Protected = xdoc.SelectNodes("/direct-messages/direct_message/sender/protected")(i).InnerText
                u.Screen_Name = xdoc.SelectNodes("/direct-messages/direct_message/sender/screen_name")(i).InnerText
                u.Statuses_count = xdoc.SelectNodes("/direct-messages/direct_message/sender/statuses_count")(i).InnerText
                u.Time_zone = xdoc.SelectNodes("/direct-messages/direct_message/sender/time_zone")(i).InnerText
                u.Url = xdoc.SelectNodes("/direct-messages/direct_message/sender/url")(i).InnerText
                u.Utc_offset = xdoc.SelectNodes("/direct-messages/direct_message/sender/utc_offset")(i).InnerText
                u.Verified = xdoc.SelectNodes("/direct-messages/direct_message/sender/verified")(i).InnerText

                'recipient Info
                Dim u2 As New DNE.Twitter.User()
                u2.Created_at = xdoc.SelectNodes("/direct-messages/direct_message/recipient/created_at")(i).InnerText
                u2.Description = xdoc.SelectNodes("/direct-messages/direct_message/recipient/description")(i).InnerText
                u2.Favourites_count = xdoc.SelectNodes("/direct-messages/direct_message/recipient/favourites_count")(i).InnerText
                u2.Followers_count = xdoc.SelectNodes("/direct-messages/direct_message/recipient/followers_count")(i).InnerText
                u2.Following = xdoc.SelectNodes("/direct-messages/direct_message/recipient/following")(i).InnerText
                u2.Friends_count = xdoc.SelectNodes("/direct-messages/direct_message/recipient/friends_count")(i).InnerText
                u2.Id = xdoc.SelectNodes("/direct-messages/direct_message/recipient/id")(i).InnerText
                u2.Location = xdoc.SelectNodes("/direct-messages/direct_message/recipient/location")(i).InnerText
                u2.Name = xdoc.SelectNodes("/direct-messages/direct_message/recipient/name")(i).InnerText
                u2.Notifications = xdoc.SelectNodes("/direct-messages/direct_message/recipient/notifications")(i).InnerText
                u2.Profile_background_color = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_background_color")(i).InnerText
                u2.Profile_background_image_url = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_background_image_url")(i).InnerText
                u2.Profile_background_tile = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_background_tile")(i).InnerText
                u2.Profile_image_url = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_image_url")(i).InnerText
                u2.Profile_link_color = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_link_color")(i).InnerText
                u2.Profile_sidebar_border_color = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_sidebar_border_color")(i).InnerText
                u2.Profile_sidebar_fill_color = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_sidebar_fill_color")(i).InnerText
                u2.Profile_text_color = xdoc.SelectNodes("/direct-messages/direct_message/recipient/profile_text_color")(i).InnerText
                u2.Protected = xdoc.SelectNodes("/direct-messages/direct_message/recipient/protected")(i).InnerText
                u2.Screen_Name = xdoc.SelectNodes("/direct-messages/direct_message/recipient/screen_name")(i).InnerText
                u2.Statuses_count = xdoc.SelectNodes("/direct-messages/direct_message/recipient/statuses_count")(i).InnerText
                u2.Time_zone = xdoc.SelectNodes("/direct-messages/direct_message/recipient/time_zone")(i).InnerText
                u2.Url = xdoc.SelectNodes("/direct-messages/direct_message/recipient/url")(i).InnerText
                u2.Utc_offset = xdoc.SelectNodes("/direct-messages/direct_message/recipient/utc_offset")(i).InnerText
                u2.Verified = xdoc.SelectNodes("/direct-messages/direct_message/recipient/verified")(i).InnerText

                dm.Sender = u
                dm.Recipient = u2

                dmc.Add(dm)

            Next
            Return dmc

        End Function

        Public Function ParsUserXML(ByVal s As String) As DNE.Twitter.User
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/user")
            If xnl Is Nothing OrElse xnl.Count = 0 Then Return Nothing

            Dim u As New DNE.Twitter.User()
            u.Created_at = xdoc.SelectSingleNode("/user/created_at").InnerText
            u.Description = xdoc.SelectSingleNode("/user/description").InnerText
            u.Favourites_count = xdoc.SelectSingleNode("/user/favourites_count").InnerText
            u.Followers_count = xdoc.SelectSingleNode("/user/followers_count").InnerText
            u.Following = xdoc.SelectSingleNode("/user/following").InnerText
            u.Friends_count = xdoc.SelectSingleNode("/user/friends_count").InnerText
            u.Id = xdoc.SelectSingleNode("/user/id").InnerText
            u.Location = xdoc.SelectSingleNode("/user/location").InnerText
            u.Name = xdoc.SelectSingleNode("/user/name").InnerText
            u.Notifications = xdoc.SelectSingleNode("/user/notifications").InnerText
            u.Profile_background_color = xdoc.SelectSingleNode("/user/profile_background_color").InnerText
            u.Profile_background_image_url = xdoc.SelectSingleNode("/user/profile_background_image_url").InnerText
            u.Profile_background_tile = xdoc.SelectSingleNode("/user/profile_background_tile").InnerText
            u.Profile_image_url = xdoc.SelectSingleNode("/user/profile_image_url").InnerText
            u.Profile_link_color = xdoc.SelectSingleNode("/user/profile_link_color").InnerText
            u.Profile_sidebar_border_color = xdoc.SelectSingleNode("/user/profile_sidebar_border_color").InnerText
            u.Profile_sidebar_fill_color = xdoc.SelectSingleNode("/user/profile_sidebar_fill_color").InnerText
            u.Profile_text_color = xdoc.SelectSingleNode("/user/profile_text_color").InnerText
            u.Protected = xdoc.SelectSingleNode("/user/protected").InnerText
            u.Screen_Name = xdoc.SelectSingleNode("/user/screen_name").InnerText
            u.Statuses_count = xdoc.SelectSingleNode("/user/statuses_count").InnerText
            u.Time_zone = xdoc.SelectSingleNode("/user/time_zone").InnerText
            u.Url = xdoc.SelectSingleNode("/user/url").InnerText
            u.Utc_offset = xdoc.SelectSingleNode("/user/utc_offset").InnerText
            u.Verified = xdoc.SelectSingleNode("/user/verified").InnerText

            Dim st As New DNE.Twitter.StatusBase()
            If xdoc.SelectSingleNode("/user/status/favorited") IsNot Nothing Then
                st.Favorited = xdoc.SelectSingleNode("/user/status/favorited").InnerText
                st.Created_At = xdoc.SelectSingleNode("/user/status/created_at").InnerText
                st.Id = xdoc.SelectSingleNode("/user/status/id").InnerText
                st.In_reply_to_screen_name = xdoc.SelectSingleNode("/user/status/in_reply_to_screen_name").InnerText
                st.In_reply_to_status_id = xdoc.SelectSingleNode("/user/status/in_reply_to_status_id").InnerText
                st.In_reply_to_user_id = xdoc.SelectSingleNode("/user/status/in_reply_to_user_id").InnerText
                st.Source = xdoc.SelectSingleNode("/user/status/source").InnerText
                st.Text = xdoc.SelectSingleNode("/user/status/text").InnerText
                st.Truncated = xdoc.SelectSingleNode("/user/status/truncated").InnerText

                u.Status = st

            End If


            Return u

        End Function

        Public Function ParsUsersXML(ByVal s As String) As Collection(Of DNE.Twitter.User)
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/users/user")
            If xnl Is Nothing OrElse xnl.Count = 0 Then Return Nothing

            Dim uc As New Collection(Of DNE.Twitter.User)
            For i As Int32 = 0 To xnl.Count - 1
                Dim u As New DNE.Twitter.User()
                u.Created_at = xdoc.SelectNodes("/users/user/created_at")(i).InnerText
                u.Description = xdoc.SelectNodes("/users/user/description")(i).InnerText
                u.Favourites_count = xdoc.SelectNodes("/users/user/favourites_count")(i).InnerText
                u.Followers_count = xdoc.SelectNodes("/users/user/followers_count")(i).InnerText
                u.Following = xdoc.SelectNodes("/users/user/following")(i).InnerText
                u.Friends_count = xdoc.SelectNodes("/users/user/friends_count")(i).InnerText
                u.Id = xdoc.SelectNodes("/users/user/id")(i).InnerText
                u.Location = xdoc.SelectNodes("/users/user/location")(i).InnerText
                u.Name = xdoc.SelectNodes("/users/user/name")(i).InnerText
                u.Notifications = xdoc.SelectNodes("/users/user/notifications")(i).InnerText
                u.Profile_background_color = xdoc.SelectNodes("/users/user/profile_background_color")(i).InnerText
                u.Profile_background_image_url = xdoc.SelectNodes("/users/user/profile_background_image_url")(i).InnerText
                u.Profile_background_tile = xdoc.SelectNodes("/users/user/profile_background_tile")(i).InnerText
                u.Profile_image_url = xdoc.SelectNodes("/users/user/profile_image_url")(i).InnerText
                u.Profile_link_color = xdoc.SelectNodes("/users/user/profile_link_color")(i).InnerText
                u.Profile_sidebar_border_color = xdoc.SelectNodes("/users/user/profile_sidebar_border_color")(i).InnerText
                u.Profile_sidebar_fill_color = xdoc.SelectNodes("/users/user/profile_sidebar_fill_color")(i).InnerText
                u.Profile_text_color = xdoc.SelectNodes("/users/user/profile_text_color")(i).InnerText
                u.Protected = xdoc.SelectNodes("/users/user/protected")(i).InnerText
                u.Screen_Name = xdoc.SelectNodes("/users/user/screen_name")(i).InnerText
                u.Statuses_count = xdoc.SelectNodes("/users/user/statuses_count")(i).InnerText
                u.Time_zone = xdoc.SelectNodes("/users/user/time_zone")(i).InnerText
                u.Url = xdoc.SelectNodes("/users/user/url")(i).InnerText
                u.Utc_offset = xdoc.SelectNodes("/users/user/utc_offset")(i).InnerText
                u.Verified = xdoc.SelectNodes("/users/user/verified")(i).InnerText

                Dim st As New DNE.Twitter.StatusBase()
                If xdoc.SelectNodes("/users/user/status/favorited")(i) IsNot Nothing Then
                    st.Favorited = xdoc.SelectNodes("/users/user/status/favorited")(i).InnerText
                    st.Created_At = xdoc.SelectNodes("/users/user/status/created_at")(i).InnerText
                    st.Id = xdoc.SelectNodes("/users/user/status/id")(i).InnerText
                    st.In_reply_to_screen_name = xdoc.SelectNodes("/users/user/status/in_reply_to_screen_name")(i).InnerText
                    st.In_reply_to_status_id = xdoc.SelectNodes("/users/user/status/in_reply_to_status_id")(i).InnerText
                    st.In_reply_to_user_id = xdoc.SelectNodes("/users/user/status/in_reply_to_user_id")(i).InnerText
                    st.Source = xdoc.SelectNodes("/users/user/status/source")(i).InnerText
                    st.Text = xdoc.SelectNodes("/users/user/status/text")(i).InnerText
                    st.Truncated = xdoc.SelectNodes("/users/user/status/truncated")(i).InnerText
                    u.Status = st

                End If
                uc.Add(u)

            Next
            Return uc

        End Function

        Public Function ParsIdsXML(ByVal s As String) As String()
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/ids/id")
            If xnl Is Nothing OrElse xnl.Count = 0 Then Return Nothing
            Dim al As New ArrayList()
            For i As Int32 = 0 To xnl.Count - 1
                al.Add(xnl(i).InnerText)

            Next
            Return al.ToArray(GetType(String))

        End Function

#End Region

#Region " JSON "

        Public Function ParsJsonSearchResults(ByVal s As String) As DNE.Twitter.SearchResults
            Dim j As New JsonSerializer()

            Dim jr As New JsonReader(New IO.StringReader(s))
            Dim o As DNE.Twitter.SearchResults = j.Deserialize(jr, GetType(DNE.Twitter.SearchResults))
            Return o

        End Function

#End Region

    End Class

End Namespace



Namespace DNE.Twitter

    Public Enum StatusListType
        FriendsTimeLine = 0
        UserUpdates = 1
        DirectMessages = 2
        SentMessages = 3
        Favorites = 4
        Mentions = 5
        MyUpdates = 6
        SearchResults = 7
        Friends = 8
        Followers = 9

    End Enum

    Public Enum TwitterXmlTypes
        User = 0
        Users = 3
        Status = 1
        DirectMessage = 2

    End Enum

    Public Enum ProxyType As Int32
        None = 0
        HTTP = 1
        SOCKS4 = 2
        SOCKS5 = 3

    End Enum

    Public Enum AuthType
        Basic = 0
        oAuth = 1

    End Enum

End Namespace


Namespace DNE.JikJikoo

    Public Enum ShortenServers
        bit_ly
        'is_gd
        'tinyurl_com

    End Enum

    Public Enum StatusListType
        FriendsTimeLine = 0
        UserUpdates = 1
        DirectMessages = 2
        Favorites = 3
        Mentions = 4
        MyUpdates = 5
        SearchResults = 6
        Friends = 7

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

'   <relationship>
'        <source>
'            <id>123</id>
'            <screen_name>bob</screen_name>
'            <following>true</following>
'            <followed_by>false</followed_by>
'            <notifications_enabled>false</notifications_enabled>
'        </source>
'       <target>
'           <id>456</id>
'           <screen_name>jack</screen_name>
'           <following>false</following>
'           <followed_by>true</followed_by>
'           <notifications_enabled></notifications_enabled>
'       </target>
'   </relationship>


Namespace DNE.Twitter
    Public Class RelationshipNode

        Private _id As String = ""
        Private _screen_name As String = ""
        Private _following As String = ""
        Private _followed_by As String = ""
        Private _notifications_enabled As String = ""

        Public Sub New()

        End Sub

#Region "   Properties   "

        Public Property [id]() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        Public Property screen_name() As String
            Get
                Return _screen_name
            End Get
            Set(ByVal Value As String)
                _screen_name = Value
            End Set
        End Property

        Public Property following() As String
            Get
                Return _following
            End Get
            Set(ByVal Value As String)
                _following = Value
            End Set
        End Property

        Public Property followed_by() As String
            Get
                Return _followed_by
            End Get
            Set(ByVal Value As String)
                _followed_by = Value
            End Set
        End Property

        Public Property notifications_enabled() As String
            Get
                Return _notifications_enabled
            End Get
            Set(ByVal Value As String)
                _notifications_enabled = Value
            End Set
        End Property

#End Region

    End Class

    Public Class Relationship

        Private _source As RelationshipNode = Nothing
        Private _target As RelationshipNode = Nothing

        Public Sub New()
            _source = New RelationshipNode()
            _target = New RelationshipNode()
        End Sub

        Public Sub New(ByVal rnSource As RelationshipNode, ByVal rnTarget As RelationshipNode)
            _source = rnSource
            _target = rnTarget

        End Sub

        Public Property source() As RelationshipNode
            Get
                Return _source
            End Get
            Set(ByVal value As RelationshipNode)
                _source = value
            End Set
        End Property

        Public Property target() As RelationshipNode
            Get
                Return _target
            End Get
            Set(ByVal value As RelationshipNode)
                _target = value
            End Set
        End Property

    End Class

End Namespace

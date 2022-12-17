Imports DevExpress.Utils.Serializing
Imports DevExpress.Xpf.Core.Serialization
Imports System.ComponentModel
Imports System.IO
Imports System.Windows

Namespace DXSample

    Public Partial Class MainWindow
        Inherits Window
        Implements INotifyPropertyChanged

        Const LayoutFilePath As String = "Layout.xml"

        Const AppName As String = "TestApplication"

        Private _testProperty As String

        <XtraSerializableProperty>
        Public Property TestProperty As String
            Get
                Return _testProperty
            End Get

            Set(ByVal value As String)
                _testProperty = value
                RaisePropertyChanged(NameOf(MainWindow.TestProperty))
            End Set
        End Property

        Public Sub New()
            DataContext = Me
            DXSerializer.SetSerializationID(Me, "test")
            Call DXSerializer.AddCustomGetSerializablePropertiesHandler(Me, New CustomGetSerializablePropertiesEventHandler(AddressOf CustomGetSerializableProperties))
            Me.InitializeComponent()
        End Sub

        Private Sub CustomGetSerializableProperties(ByVal sender As Object, ByVal e As CustomGetSerializablePropertiesEventArgs)
            e.SetPropertySerializable(WidthProperty, New DXSerializable())
            e.SetPropertySerializable(HeightProperty, New DXSerializable())
        End Sub

        Private Overloads Sub OnInitialized(ByVal sender As Object, ByVal e As System.EventArgs)
            If File.Exists(LayoutFilePath) Then Call DXSerializer.Deserialize(Me, LayoutFilePath, AppName, New DXOptionsLayout())
        End Sub

        Private Overloads Sub OnClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
            Call DXSerializer.Serialize(Me, LayoutFilePath, AppName, New DXOptionsLayout())
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace

Imports DevExpress.Utils.Serializing
Imports DevExpress.Xpf.Core.Serialization
Imports System.ComponentModel
Imports System.IO
Imports System.Windows

Namespace DXSample
    Partial Public Class MainWindow
        Inherits Window
        Implements INotifyPropertyChanged

        Private Const LayoutFilePath As String = "Layout.xml"
        Private Const AppName As String = "TestApplication"

        Private _testProperty As String
        <XtraSerializableProperty> _
        Public Property TestProperty() As String
            Get
                Return _testProperty
            End Get
            Set(ByVal value As String)
                _testProperty = value
                RaisePropertyChanged(NameOf(TestProperty))
            End Set
        End Property

        Public Sub New()
            DataContext = Me
            DXSerializer.SetSerializationID(Me, "test")
            DXSerializer.AddCustomGetSerializablePropertiesHandler(Me, AddressOf CustomGetSerializableProperties)
            InitializeComponent()
        End Sub

        Private Sub CustomGetSerializableProperties(ByVal sender As Object, ByVal e As CustomGetSerializablePropertiesEventArgs)
            e.SetPropertySerializable(WidthProperty, New DXSerializable())
            e.SetPropertySerializable(HeightProperty, New DXSerializable())
        End Sub

        Private Overloads Sub OnInitialized(ByVal sender As Object, ByVal e As System.EventArgs)
            If File.Exists(LayoutFilePath) Then
                DXSerializer.Deserialize(Me, LayoutFilePath, AppName, New DXOptionsLayout())
            End If
        End Sub
        Private Overloads Sub OnClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
            DXSerializer.Serialize(Me, LayoutFilePath, AppName, New DXOptionsLayout())
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            PropertyChangedEvent?.Invoke(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
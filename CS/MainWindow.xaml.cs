using DevExpress.Utils.Serializing;
using DevExpress.Xpf.Core.Serialization;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace DXSample {
    public partial class MainWindow : Window, INotifyPropertyChanged {
        const string LayoutFilePath = "Layout.xml";
        const string AppName = "TestApplication";

        string _testProperty;
        [XtraSerializableProperty]
        public string TestProperty {
            get { return _testProperty; }
            set {
                _testProperty = value;
                RaisePropertyChanged(nameof(TestProperty));
            }
        }

        public MainWindow() {
            DataContext = this;
            DXSerializer.SetSerializationID(this, "test");
            DXSerializer.AddCustomGetSerializablePropertiesHandler(this, CustomGetSerializableProperties);
            InitializeComponent();
        }

        private void CustomGetSerializableProperties(object sender, CustomGetSerializablePropertiesEventArgs e) {
            e.SetPropertySerializable(WidthProperty, new DXSerializable());
            e.SetPropertySerializable(HeightProperty, new DXSerializable());
        }

        void OnInitialized(object sender, System.EventArgs e) {
            if (File.Exists(LayoutFilePath))
                DXSerializer.Deserialize(this, LayoutFilePath, AppName, new DXOptionsLayout());
        }
        void OnClosing(object sender, CancelEventArgs e) {
            DXSerializer.Serialize(this, LayoutFilePath, AppName, new DXOptionsLayout());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
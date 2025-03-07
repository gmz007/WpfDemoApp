using System.Windows;
using System.Windows.Controls;

namespace DemoApp.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsTreeViewItem.xaml
    /// </summary>
    public partial class SettingsTreeViewItem : UserControl
    {
        public string IconCode
        {
            get => (string)GetValue(IconCodeProperty);
            set => SetValue(IconCodeProperty, value);
        }

        // Using a DependencyProperty as the backing store for IconCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconCodeProperty =
            DependencyProperty.Register(nameof(IconCode), typeof(string), typeof(SettingsTreeViewItem), new PropertyMetadata(string.Empty));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(SettingsTreeViewItem), new PropertyMetadata(string.Empty));

        public SettingsTreeViewItem()
        {
            InitializeComponent();
        }
    }
}

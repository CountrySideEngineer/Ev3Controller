using Ev3Controller.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ev3Controller.UserControlView
{
    /// <summary>
    /// Ev3PortView.xaml の相互作用ロジック
    /// </summary>
    public partial class Ev3PortView : UserControl
    {
        public Ev3PortView()
        {
            InitializeComponent();
        }

        #region Public read-only static fields
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(IEnumerable),
                typeof(Ev3PortView),
                new PropertyMetadata(null));
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Property of selected port item in ComboBox.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = 
            DependencyProperty.Register(
                "SelectedItem",
                typeof(object),
                typeof(Ev3PortView),
                new PropertyMetadata(null, SelectedItemChangeCallback));
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Index of property of selected port item in ComboBox.
        /// </summary>
        public static readonly DependencyProperty SelectedItemIndexProperty =
            DependencyProperty.Register(
                "SelectedItemIndex",
                typeof(int),
                typeof(Ev3PortView),
                new PropertyMetadata(2));
        public int SelectedItemIndex
        {
            get { return (int)GetValue(SelectedItemIndexProperty); }
            set { SetValue(SelectedItemIndexProperty, value); }
        }
        #endregion

        #region Other methods and private properties in calling order
        private static void SelectedItemChangeCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
    }
}

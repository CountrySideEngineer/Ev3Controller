using System;
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
    /// Ev3SafeStateView.xaml の相互作用ロジック
    /// </summary>
    public partial class Ev3SafeStateView : UserControl
    {
        public Ev3SafeStateView()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
        }
        #region Public read-only static fields
        /// <summary>
        /// Property of SafeState, string.
        /// </summary>
        public static readonly DependencyProperty SafeStateProperty =
            DependencyProperty.Register(
                "SafeState",
                typeof(string),
                typeof(Ev3SafeStateView),
                new PropertyMetadata(""));
        public string SafeState
        {
            get { return (string)GetValue(SafeStateProperty); }
            set { SetValue(SafeStateProperty, value); }
        }

        /// <summary>
        /// Property of IsConnected, boolean type.
        /// </summary>
        public static readonly DependencyProperty IsConnectedProperty =
            DependencyProperty.Register(
                "IsConnected",
                typeof(bool),
                typeof(Ev3SafeStateView),
                new PropertyMetadata(false));
        public bool IsConnected
        {
            get { return (bool)GetValue(IsConnectedProperty); }
            set { SetValue(IsConnectedProperty, value); }
        }

        protected void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            bool NewValue = (bool)e.NewValue;
            if (NewValue)
            {
                this.Visibility = Visibility.Visible;
            }
            else
            {
                this.Visibility = Visibility.Hidden;
            }
        }
        #endregion
    }
}

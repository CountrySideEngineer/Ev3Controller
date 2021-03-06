﻿using System;
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
    /// Ev3SensorDeviceView.xaml の相互作用ロジック
    /// </summary>
    public partial class Ev3SensorDeviceView : UserControl
    {
        public Ev3SensorDeviceView()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
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
    }
}

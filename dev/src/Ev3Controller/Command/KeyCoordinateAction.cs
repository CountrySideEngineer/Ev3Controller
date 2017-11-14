using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Ev3Controller.Command
{
    public class KeyCoordinateAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(KeyCoordinateAction),
            new UIPropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            var e = parameter as KeyEventArgs;
            if ((null == this.Command) || (null == e))
            {
                return;
            }
            this.Execute(e);
        }

        protected void Execute(object Key)
        {
            if (this.Command.CanExecute(Key)) { this.Command.Execute(Key); }
        }

        
    }
}

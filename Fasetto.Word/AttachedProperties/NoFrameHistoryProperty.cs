using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fasetto.Word
{
    public class NoFrameHistoryProperty:BaseAttachedProperty<NoFrameHistoryProperty,bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            //frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            frame.Navigated += (ss, ee) => ((Frame) ss).NavigationService.RemoveBackEntry();
        }

    }
}

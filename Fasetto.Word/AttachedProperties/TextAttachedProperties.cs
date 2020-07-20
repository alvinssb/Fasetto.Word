using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            control.Loaded += (s, se) => control.Focus();
        }
    }

    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            if ((bool) e.NewValue)
                control.Focus();
        }
    }
}

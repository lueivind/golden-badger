using System.Windows;
using System.Windows.Controls;

namespace DrawingTool
{
    public class FocusBehavior
    {
        public static bool GetHasFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasFocusProperty);
        }

        public static void SetHasFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(HasFocusProperty, value);
        }

        // Using a DependencyProperty as the backing store for HasFocus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasFocusProperty =
            DependencyProperty.RegisterAttached("HasFocus", typeof(bool), typeof(FocusBehavior), new PropertyMetadata(false, OnHasFocusChanged));

        private static void OnHasFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // focus on element
            if (d is UIElement element)
            {
                // if the new value of the has focus property is true
                if ((bool)e.NewValue)
                {
                    element.Focus();
                    element.LostFocus += Element_LostFocus;
                    element.KeyDown += Element_KeyDown;
                    
                }
            }
            // if textbox, select all text.
            if (d is TextBox textbox)
            {
                if ((bool)e.NewValue)
                {
                    textbox.SelectAll();          
                }
            }
        }

        /// <summary>
        /// Enter pressed on element, complete renaming.
        /// </summary>
        private static void Element_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                (sender as UIElement).SetCurrentValue(FocusBehavior.HasFocusProperty, false);

            }
        }

        /// <summary>
        /// Element lost focus, complete renaming.
        /// </summary>
        private static void Element_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as UIElement).SetCurrentValue(FocusBehavior.HasFocusProperty, false);
        }
    }
}

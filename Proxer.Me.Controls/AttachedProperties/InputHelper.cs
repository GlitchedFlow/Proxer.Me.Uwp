using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Proxer.Me.Controls.AttachedProperties
{
	public static class InputHelper
	{
		public static bool GetEnterCommandEnabled(DependencyObject obj)
		{
			return (bool)obj.GetValue(EnterCommandEnabledProperty);
		}

		public static void SetEnterCommandEnabled(DependencyObject obj, bool value)
		{
			obj.SetValue(EnterCommandEnabledProperty, value);
		}

		// Using a DependencyProperty as the backing store for EnterCommandEnabled. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty EnterCommandEnabledProperty =
			DependencyProperty.RegisterAttached("EnterCommandEnabled", typeof(bool), typeof(InputHelper), new PropertyMetadata(false, enterCommandEnabledChanged));

		private static void enterCommandEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Control control = d as Control;
			if (control != null)
			{
				bool enabled = GetEnterCommandEnabled(control);
				if (enabled)
					control.KeyDown += Control_KeyDown;
				else
					control.KeyDown -= Control_KeyDown;
			}
		}

		private static void Control_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
		{
			if (e.Key == Windows.System.VirtualKey.Enter)
			{
				ICommand command = GetEnterCommand(sender as DependencyObject);
				object commandParameter = GetCommandParameter(sender as DependencyObject);
				if (command != null)
				{
					if (command.CanExecute(commandParameter))
					{
						command.Execute(null);
					}
				}
				e.Handled = true;
			}
		}

		public static ICommand GetEnterCommand(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(EnterCommandProperty);
		}

		public static void SetEnterCommand(DependencyObject obj, ICommand value)
		{
			obj.SetValue(EnterCommandProperty, value);
		}

		// Using a DependencyProperty as the backing store for EnterCommand. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty EnterCommandProperty =
			DependencyProperty.RegisterAttached("EnterCommand", typeof(ICommand), typeof(InputHelper), new PropertyMetadata(null));

		public static object GetCommandParameter(DependencyObject obj)
		{
			return (object)obj.GetValue(CommandParameterProperty);
		}

		public static void SetCommandParameter(DependencyObject obj, object value)
		{
			obj.SetValue(CommandParameterProperty, value);
		}

		// Using a DependencyProperty as the backing store for CommandParameter. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty CommandParameterProperty =
			DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(InputHelper), new PropertyMetadata(null));
	}
}
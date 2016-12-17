using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Proxer.Me.Controls
{
	[TemplateVisualState(Name = "ContentExpandedAbove", GroupName = "ContentStates")]
	[TemplateVisualState(Name = "ContentCollapsedAbove", GroupName = "ContentStates")]
	[TemplateVisualState(Name = "ContentExpandedBelow", GroupName = "ContentStates")]
	[TemplateVisualState(Name = "ContentCollapsedBelow", GroupName = "ContentStates")]
	[TemplateVisualState(Name = "ShowHeaderBorder", GroupName = "HeaderBorderStates")]
	[TemplateVisualState(Name = "HideHeaderBorder", GroupName = "HeaderBorderStates")]
	[TemplatePart(Name = "PART_ExpanderToggleButton", Type = typeof(ToggleButton))]
	[TemplatePart(Name = "PART_HeaderButton", Type = typeof(ButtonBase))]
	[ContentProperty(Name = "Content")]
	public sealed class Expander : Control
	{
		#region Public Fields

		// Using a DependencyProperty as the backing store for ContentLineBrush. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty ContentLineBrushProperty =
			DependencyProperty.Register("ContentLineBrush", typeof(Brush), typeof(Expander), new PropertyMetadata(new SolidColorBrush(Colors.White)));

		// Using a DependencyProperty as the backing store for ContentLineVisibility. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty ContentLineVisibilityProperty =
			DependencyProperty.Register("ContentLineVisibility", typeof(Visibility), typeof(Expander), new PropertyMetadata(Visibility.Visible));

		// Using a DependencyProperty as the backing store for Content. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.Register("Content", typeof(object), typeof(Expander), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for Direction. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty ExpandDirectionProperty =
			DependencyProperty.Register("ExpandDirection", typeof(ExpanderDirection), typeof(Expander), new PropertyMetadata(ExpanderDirection.Down, DirectionChanged));

		// Using a DependencyProperty as the backing store for ExpanderButtonVisibility. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty ExpanderButtonVisibilityProperty =
			DependencyProperty.Register("ExpanderButtonVisibility", typeof(Visibility), typeof(Expander), new PropertyMetadata(Visibility.Visible));

		// Using a DependencyProperty as the backing store for HeaderBorderBackground. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderBorderBackgroundProperty =
			DependencyProperty.Register("HeaderBorderBackground", typeof(Brush), typeof(Expander), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for HeaderBorderBrush. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderBorderBrushProperty =
			DependencyProperty.Register("HeaderBorderBrush", typeof(Brush), typeof(Expander), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for HeaderBorderThickness. This enables
		// animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderBorderThicknessProperty =
			DependencyProperty.Register("HeaderBorderThickness", typeof(Thickness), typeof(Expander), new PropertyMetadata(new Thickness(1)));

		// Using a DependencyProperty as the backing store for HeaderContentHorizontalAlignment. This
		// enables animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderContentHorizontalAlignmentProperty =
			DependencyProperty.Register("HeaderContentHorizontalAlignment", typeof(HorizontalAlignment), typeof(Expander), new PropertyMetadata(HorizontalAlignment.Left));

		// Using a DependencyProperty as the backing store for HeaderContentVerticalAlignment. This
		// enables animation, styling, binding, etc...
		public static readonly DependencyProperty HeaderContentVerticalAlignmentProperty =
			DependencyProperty.Register("HeaderContentVerticalAlignment", typeof(VerticalAlignment), typeof(Expander), new PropertyMetadata(VerticalAlignment.Center));

		// Using a DependencyProperty as the backing store for Header. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register("Header", typeof(object), typeof(Expander), new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for IsExpanded. This enables animation,
		// styling, binding, etc...
		public static readonly DependencyProperty IsExpandedProperty =
			DependencyProperty.Register("IsExpanded", typeof(bool), typeof(Expander), new PropertyMetadata(false, IsExpandedPropertyChanged));

		private static void IsExpandedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		// Using a DependencyProperty as the backing store for ShowHeaderBorderWhenExpanded. This
		// enables animation, styling, binding, etc...
		public static readonly DependencyProperty ShowHeaderBorderOnlyWhenExpandedProperty =
			DependencyProperty.Register("ShowHeaderBorderOnlyWhenExpanded", typeof(bool), typeof(Expander), new PropertyMetadata(true, ShowHeaderBorderWhenExpandedChanged));

		#endregion Public Fields

		#region Public Enums

		public enum ExpanderDirection
		{
			Down,
			Up
		}

		#endregion Public Enums

		#region Public Properties

		public object Content
		{
			get { return (object)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

		public Brush ContentLineBrush
		{
			get { return (Brush)GetValue(ContentLineBrushProperty); }
			set { SetValue(ContentLineBrushProperty, value); }
		}

		public Visibility ContentLineVisibility
		{
			get { return (Visibility)GetValue(ContentLineVisibilityProperty); }
			set { SetValue(ContentLineVisibilityProperty, value); }
		}

		public ExpanderDirection ExpandDirection
		{
			get { return (ExpanderDirection)GetValue(ExpandDirectionProperty); }
			set { SetValue(ExpandDirectionProperty, value); }
		}

		public Visibility ExpanderButtonVisibility
		{
			get { return (Visibility)GetValue(ExpanderButtonVisibilityProperty); }
			set { SetValue(ExpanderButtonVisibilityProperty, value); }
		}

		public object Header
		{
			get { return (object)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}

		public Brush HeaderBorderBackground
		{
			get { return (Brush)GetValue(HeaderBorderBackgroundProperty); }
			set { SetValue(HeaderBorderBackgroundProperty, value); }
		}

		public Brush HeaderBorderBrush
		{
			get { return (Brush)GetValue(HeaderBorderBrushProperty); }
			set { SetValue(HeaderBorderBrushProperty, value); }
		}

		public Thickness HeaderBorderThickness
		{
			get { return (Thickness)GetValue(HeaderBorderThicknessProperty); }
			set { SetValue(HeaderBorderThicknessProperty, value); }
		}

		public HorizontalAlignment HeaderContentHorizontalAlignment
		{
			get { return (HorizontalAlignment)GetValue(HeaderContentHorizontalAlignmentProperty); }
			set { SetValue(HeaderContentHorizontalAlignmentProperty, value); }
		}

		public VerticalAlignment HeaderContentVerticalAlignment
		{
			get { return (VerticalAlignment)GetValue(HeaderContentVerticalAlignmentProperty); }
			set { SetValue(HeaderContentVerticalAlignmentProperty, value); }
		}

		public bool IsExpanded
		{
			get { return (bool)GetValue(IsExpandedProperty); }
			set { SetValue(IsExpandedProperty, value); }
		}

		public bool ShowHeaderBorderOnlyWhenExpanded
		{
			get { return (bool)GetValue(ShowHeaderBorderOnlyWhenExpandedProperty); }
			set { SetValue(ShowHeaderBorderOnlyWhenExpandedProperty, value); }
		}

		#endregion Public Properties

		#region Private Methods

		private static void DirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Expander expander = d as Expander;
			if (expander.IsExpanded)
			{
				if (expander.ExpandDirection == ExpanderDirection.Down)
					VisualStateManager.GoToState(expander, "ContentExpandedBelow", true);
				else
					VisualStateManager.GoToState(expander, "ContentExpandedAbove", true);
			}
			else
			{
				if (expander.ExpandDirection == ExpanderDirection.Down)
					VisualStateManager.GoToState(expander, "ContentCollapsedBelow", true);
				else
					VisualStateManager.GoToState(expander, "ContentCollapsedAbove", true);
			}
		}

		private static void ShowHeaderBorderWhenExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Expander expander = d as Expander;
			if (expander.ShowHeaderBorderOnlyWhenExpanded)
			{
				if (expander.IsExpanded)
					VisualStateManager.GoToState(expander, "ShowHeaderBorder", true);
				else
					VisualStateManager.GoToState(expander, "HideHeaderBorder", true);
			}
			else
				VisualStateManager.GoToState(expander, "ShowHeaderBorder", true);
		}

		private void CollapseControl()
		{
			expanderButton.IsChecked = false;
			if (ExpandDirection == ExpanderDirection.Down)
				VisualStateManager.GoToState(this, "ContentCollapsedBelow", true);
			else
				VisualStateManager.GoToState(this, "ContentCollapsedAbove", true);

			if (ShowHeaderBorderOnlyWhenExpanded)
				VisualStateManager.GoToState(this, "HideHeaderBorder", true);
			else
				VisualStateManager.GoToState(this, "ShowHeaderBorder", true);
		}

		private void ExpandControl()
		{
			expanderButton.IsChecked = true;
			if (ExpandDirection == ExpanderDirection.Down)
				VisualStateManager.GoToState(this, "ContentExpandedBelow", true);
			else
				VisualStateManager.GoToState(this, "ContentExpandedAbove", true);

			VisualStateManager.GoToState(this, "ShowHeaderBorder", true);
		}

		private void OnExpanderButtonChecked(object sender, RoutedEventArgs e)
		{
			IsExpanded = true;
			ExpandControl();
		}

		private void OnExpanderButtonUnChecked(object sender, RoutedEventArgs e)
		{
			IsExpanded = false;
			CollapseControl();
		}

		private void OnHeaderButtonClick(object sender, TappedRoutedEventArgs e)
		{
			IsExpanded = !IsExpanded;
			if (IsExpanded)
			{
				ExpandControl();
			}
			else
			{
				CollapseControl();
			}
		}

		#endregion Private Methods

		#region Protected Methods

		protected override void OnApplyTemplate()
		{
			headerBorder = GetTemplateChild("PART_HeaderBorder") as Border;
			expanderButton = GetTemplateChild("PART_ExpanderToggleButton") as ToggleButton;

			if (expanderButton != null)
			{
				expanderButton.Checked += OnExpanderButtonChecked;
				expanderButton.Unchecked += OnExpanderButtonUnChecked;
				expanderButton.IsChecked = IsExpanded;
				expanderButton.Visibility = ExpanderButtonVisibility;

				if (IsExpanded)
					ExpandControl();
				else
					CollapseControl();
			}

			if (headerBorder != null)
			{
				headerBorder.Tapped += OnHeaderButtonClick;
			}
		}

		#endregion Protected Methods

		#region Private Fields

		private ToggleButton expanderButton;
		private Border headerBorder;

		#endregion Private Fields
	}
}
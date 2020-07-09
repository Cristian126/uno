#pragma warning disable 109

using System;
using System.Collections.Generic;
using System.Text;
using Uno.UI.Helpers.WinUI;
using Windows.Globalization.NumberFormatting;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class NumberBox : Control
	{
		public double Minimum
		{
			get => (double)GetValue(MinimumProperty);
			set => SetValue(MinimumProperty, value);
		}

		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty.Register(
				name: nameof(Minimum),
				propertyType: typeof(double),
				ownerType: typeof(NumberBox),
				typeMetadata: new FrameworkPropertyMetadata(
					defaultValue: -double.MaxValue,
					propertyChangedCallback: (s, e) => (s as NumberBox)?.OnMinimumPropertyChanged(e)));


		public double Maximum
		{
			get => (double)GetValue(MaximumProperty);
			set => SetValue(MaximumProperty, value);
		}

		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty.Register("Maximum", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(double.MaxValue, (s, e) => (s as NumberBox)?.OnMaximumPropertyChanged(e)));

		public double Value
		{
			get => (double)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(0.0, (s, e) => (s as NumberBox)?.OnValuePropertyChanged(e)));



		public double SmallChange
		{
			get => (double)GetValue(SmallChangeProperty);
			set => SetValue(SmallChangeProperty, value);
		}

		public static readonly DependencyProperty SmallChangeProperty =
			DependencyProperty.Register("SmallChange", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(1.0, (s, e) => (s as NumberBox)?.OnSmallChangePropertyChanged(e)));

		public double LargeChange
		{
			get => (double)GetValue(LargeChangeProperty);
			set => SetValue(LargeChangeProperty, value);
		}

		public static readonly DependencyProperty LargeChangeProperty =
			DependencyProperty.Register("LargeChange", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(10.0));

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(NumberBox), new FrameworkPropertyMetadata("", (s, e) => (s as NumberBox)?.OnTextPropertyChanged(e)));

		// TextBox properties

		public object Header
		{
			get => (object)GetValue(HeaderProperty);
			set => SetValue(HeaderProperty, value);
		}

		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register("Header", typeof(object), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public DataTemplate HeaderTemplate
		{
			get => (DataTemplate)GetValue(HeaderTemplateProperty);
			set => SetValue(HeaderTemplateProperty, value);
		}

		public static readonly DependencyProperty HeaderTemplateProperty =
			DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(NumberBox), new FrameworkPropertyMetadata(null, options: FrameworkPropertyMetadataOptions.ValueDoesNotInheritDataContext));

		public string PlaceholderText
		{
			get => (string)GetValue(PlaceholderTextProperty);
			set => SetValue(PlaceholderTextProperty, value);
		}

		public static readonly DependencyProperty PlaceholderTextProperty =
			DependencyProperty.Register("PlaceholderText", typeof(string), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public FlyoutBase SelectionFlyout
		{
			get => (FlyoutBase)GetValue(SelectionFlyoutProperty);
			set => SetValue(SelectionFlyoutProperty, value);
		}

		public static readonly DependencyProperty SelectionFlyoutProperty =
			DependencyProperty.Register("SelectionFlyout", typeof(FlyoutBase), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public SolidColorBrush SelectionHighlightColor
		{
			get => (SolidColorBrush)GetValue(SelectionHighlightColorProperty);
			set => SetValue(SelectionHighlightColorProperty, value);
		}

		public static readonly DependencyProperty SelectionHighlightColorProperty =
			DependencyProperty.Register("SelectionHighlightColor", typeof(SolidColorBrush), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public TextReadingOrder TextReadingOrder
		{
			get => (TextReadingOrder)GetValue(TextReadingOrderProperty);
			set => SetValue(TextReadingOrderProperty, value);
		}

		public static readonly DependencyProperty TextReadingOrderProperty =
			DependencyProperty.Register("TextReadingOrder", typeof(TextReadingOrder), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public bool PreventKeyboardDisplayOnProgrammaticFocus
		{
			get => (bool)GetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty);
			set => SetValue(PreventKeyboardDisplayOnProgrammaticFocusProperty, value);
		}

		public static readonly DependencyProperty PreventKeyboardDisplayOnProgrammaticFocusProperty =
			DependencyProperty.Register("PreventKeyboardDisplayOnProgrammaticFocus", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public new object Description
		{
			get => (object)GetValue(DescriptionProperty);
			set => SetValue(DescriptionProperty, value);
		}

		public static readonly DependencyProperty DescriptionProperty =
			DependencyProperty.Register("Description", typeof(object), typeof(NumberBox), new FrameworkPropertyMetadata(null));

		public NumberBoxValidationMode ValidationMode
		{
			get => (NumberBoxValidationMode)GetValue(ValidationModeProperty);
			set => SetValue(ValidationModeProperty, value);
		}

		public static readonly DependencyProperty ValidationModeProperty =
			DependencyProperty.Register("ValidationMode", typeof(NumberBoxValidationMode), typeof(NumberBox), new FrameworkPropertyMetadata(NumberBoxValidationMode.InvalidInputOverwritten, (s, e) => (s as NumberBox)?.OnValidationModePropertyChanged(e)));

		public NumberBoxSpinButtonPlacementMode SpinButtonPlacementMode
		{
			get => (NumberBoxSpinButtonPlacementMode)GetValue(SpinButtonPlacementModeProperty);
			set => SetValue(SpinButtonPlacementModeProperty, value);
		}

		public static readonly DependencyProperty SpinButtonPlacementModeProperty =
			DependencyProperty.Register("SpinButtonPlacementMode", typeof(NumberBoxSpinButtonPlacementMode), typeof(NumberBox), new FrameworkPropertyMetadata(NumberBoxSpinButtonPlacementMode.Hidden, (s, e) => (s as NumberBox)?.OnSpinButtonPlacementModePropertyChanged(e)));

		public bool IsWrapEnabled
		{
			get => (bool)GetValue(IsWrapEnabledProperty);
			set => SetValue(IsWrapEnabledProperty, value);
		}

		public static readonly DependencyProperty IsWrapEnabledProperty =
			DependencyProperty.Register("IsWrapEnabled", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(false, (s, e) => (s as NumberBox)?.OnIsWrapEnabledPropertyChanged(e)));

		public bool AcceptsExpression
		{
			get => (bool)GetValue(AcceptsExpressionProperty);
			set => SetValue(AcceptsExpressionProperty, value);
		}

		public static readonly DependencyProperty AcceptsExpressionProperty =
			DependencyProperty.Register("AcceptsExpression", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(false /* ,UNO TODO (s, e) => (s as NumberBox)?.OnAcceptsExpressionPropertyChanged(e)*/));

		public INumberFormatter2 NumberFormatter
		{
			get => (INumberFormatter2)GetValue(NumberFormatterProperty);
			set => SetValue(NumberFormatterProperty, value);
		}

		public static readonly DependencyProperty NumberFormatterProperty =
			DependencyProperty.Register("NumberFormatter", typeof(INumberFormatter2), typeof(NumberBox), new FrameworkPropertyMetadata(null, (s, e) => (s as NumberBox)?.OnNumberFormatterPropertyChanged(e)));

		public event Windows.Foundation.TypedEventHandler<NumberBox, NumberBoxValueChangedEventArgs> ValueChanged;
	}
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UITests.Shared.Windows_UI_Xaml.MarkupExtensionTests.Behaviors
{
	public static class MarkupExtensionBehaviors
	{
		public static string GetCustomText(TextBlock obj) => (string)obj.GetValue(CustomTextProperty);

		public static void SetCustomText(TextBlock obj, string value) => obj.SetValue(CustomTextProperty, value);

		public static readonly DependencyProperty CustomTextProperty =
			DependencyProperty.RegisterAttached(
				"CustomText",
				typeof(string),
				typeof(MarkupExtensionBehaviors),
				new FrameworkPropertyMetadata(string.Empty, OnCustomTextChanged));

		private static void OnCustomTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (dependencyObject is TextBlock tb)
			{
				tb.Text = GetCustomText(tb);
			}
		}
	}
}

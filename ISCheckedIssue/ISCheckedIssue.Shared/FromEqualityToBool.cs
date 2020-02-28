using System;
using System.Collections.Generic;
using System.Text;
using Uno.Extensions;
using Uno.Logging;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ISCheckedIssue.Shared
{
	public class FromEqualityToBool : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
            {
                return Return(false);
            }

            string checkValue = value.ToString();
            string targetValue = parameter.ToString();

            return Return(checkValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase));

            bool Return(bool returnValue)
            {
                var message = $"FromEqualityToBool.Convert: {value} + {parameter} -> {returnValue}";
                //var data = new DataPackage();
                //data.SetText(message);
                //Clipboard.SetContent(data);

                this.Log().Debug(message);
                return returnValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
            {
                return Return(null);
            }

            if ((bool)value)
            {
                return Return(parameter);
            }

            //On UWP it will not go through here, but on iOS/Android/WASM it will return null.
            //If we throw a new InvalidOperationException instead of returning null, we don't have the issue of tapping twice the tab to correctly select it.
            return null;

            object Return(object returnValue)
            {
                var message = $"FromEqualityToBool.ConvertBack: {value} + {parameter} -> {returnValue ?? "null"}";
                //var data = new DataPackage();
                //data.SetText(message);
                //Clipboard.SetContent(data);

                this.Log().Debug(message);
                return returnValue;
            }
        }
    }
}

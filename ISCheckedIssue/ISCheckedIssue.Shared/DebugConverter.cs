using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Uno.Extensions;
using Uno.Logging;
using Windows.UI.Xaml.Data;

namespace ISCheckedIssue.Shared
{
	public class DebugConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //if (Debugger.IsAttached) Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //if (Debugger.IsAttached) Debugger.Break();
            return value;
        }
    }
}

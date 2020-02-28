using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ISCheckedIssue
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			this.DataContext = new MainViewModel() { SelectedTab = "TAB1" };
		}
	}

	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _SelectedTab;

		public string SelectedTab
		{
			get { return _SelectedTab; }
			set => RaiseAndSetPropertyChanged(ref _SelectedTab, value);
		}

		public void RaiseAndSetPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (backingField?.Equals(value) != true)
			{
				backingField = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

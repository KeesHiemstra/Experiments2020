﻿using MaintJournal.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaintJournal.Views
{
	/// <summary>
	/// Interaction logic for CoffeeUsageWindow.xaml
	/// </summary>
	public partial class CoffeeUsageWindow : Window
	{
		public CoffeeUsageWindow(CoffeeUsageViewModel coffeeUsageViewModel)
		{
			InitializeComponent();
		}
	}
}

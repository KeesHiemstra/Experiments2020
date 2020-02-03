﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Timer2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    private DateTime currentTime = DateTime.Now;
    public DateTime CurrentTime 
    { 
      get => currentTime;
      set
      {
        if (currentTime != value)
        {
          currentTime = value;
          NotifyPropertyChanged("CurrentTime");
        }
      }
    }
    public DispatcherTimer timer = new DispatcherTimer();

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public MainWindow()
    {
      InitializeComponent();

      DataContext = this;

      timer.Tick += Timer_Tick;

      StartTimer();
    }

    public void Timer_Tick(object sender, EventArgs e)
    {
      CurrentTime = DateTime.Now;
    }

    public void StartTimer()
    {
      timer.Interval = TimeSpan.FromMilliseconds(1000);
      timer.IsEnabled = true;
    }
  }
}
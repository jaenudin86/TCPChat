﻿using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using UI.Infrastructure;

namespace UI.View
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      KeyBoard.SetHook();    
    }

    protected override void OnClosed(EventArgs e)
    {
      KeyBoard.UnsetHook();

      base.OnClosed(e);
    }

    #region alert
    [DllImport("user32.dll")]
    private static extern bool FlashWindow(IntPtr handle, bool invert);

    public void Alert()
    {
      if ((IsActive && !(WindowState == WindowState.Minimized)) || !Settings.Current.Alerts)
        return;

      WindowInteropHelper intertopHelper = new WindowInteropHelper(this);
      FlashWindow(intertopHelper.Handle, true);
    }

    #endregion
  }
}
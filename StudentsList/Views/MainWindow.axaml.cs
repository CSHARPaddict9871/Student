using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using StudentsList.ViewModels;
using System;

using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsList.Views;

public partial class MainWindow : Window 

{



    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <exception cref="Exception">Throws if named controls cannot be found</exception>
    public MainWindow() 
    {
        InitializeComponent();

       
    }

    #endregion

   
         
}
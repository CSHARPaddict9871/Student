using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using StudentsList.ViewModels;
using System;

namespace StudentsList.Views;

public partial class MainWindow : Window 

{
    #region Private Members

    private Control mMainGrid;
    private Control mAddNewStudentButton;
    private Control mAddNewStudentPopup;

    #endregion


    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <exception cref="Exception">Throws if named controls cannot be found</exception>
    public MainWindow() 
    {
        InitializeComponent();

        // Gather the named controls
        mAddNewStudentButton = this.FindControl<Control>("AddNewStudentButton") ?? throw new Exception("Cannot find AddNewStudentButton by name");
        mAddNewStudentPopup = this.FindControl<Control>("AddNewStudentPopup") ?? throw new Exception("Cannot find AddNewStudentPopup by name");
        mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");
    }

    #endregion

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            // Get relative position of button, in relation to main grid
            var position = mAddNewStudentButton.TranslatePoint(new Point(), mMainGrid) ??
                           throw new Exception("Cannot get TranslatePoint from Configuration Button");

            // Set margin of popup so it appears bottom left of button
            mAddNewStudentPopup.Margin = new Thickness(
                position.X,
                0,
                0,
                mMainGrid.Bounds.Height - position.Y - mAddNewStudentButton.Bounds.Height);
        });
    }

    private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        ((MainViewModel)DataContext).AddNewStudentButtonPressedCommand.Execute(null);
    }
         
}
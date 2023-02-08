using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
//using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using StudentsList.ViewModels;
using System;

namespace StudentsList.Views
{
    public partial class MainView : UserControl
    {

        #region Private Members

        private Control mMainGrid;
        private Control mAddNewStudentButton;
        private Control mAddNewStudentPopup;

        protected bool isDragging;
        private Point clickPosition;
        private Point releasePosition;
        private TranslateTransform originTT;



        #endregion


        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            // Gather the named controls
            mAddNewStudentButton = this.FindControl<Control>("AddNewStudentButton") ?? throw new Exception("Cannot find AddNewStudentButton by name");
            mAddNewStudentPopup = this.FindControl<Control>("AddNewStudentPopup") ?? throw new Exception("Cannot find AddNewStudentPopup by name");
            mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");
        }

        private void Canvas_MouseLeftButtonDown(object sender, PointerPressedEventArgs e)
        {
            var draggableControl = sender as Shape;
            originTT = draggableControl.RenderTransform as TranslateTransform ?? new TranslateTransform();
            isDragging = true;
            clickPosition = e.GetPosition(this);
            //draggableControl.CapturePointer();
        }

        private void Canvas_MouseLeftButtonUp(object sender, PointerReleasedEventArgs e)
        {
            //isDragging = false;
            var draggable = sender as Shape;
            releasePosition = e.GetPosition(this);

            var distance = clickPosition.X - releasePosition.X;
            //draggable.ReleaseMouseCapture();
        }



        // Overrides the View's OnLoaded event
        //protected override async void OnLoaded()
        //{
        //    if (DataContext != null)
        //    {
        //        await((MainViewModel) DataContext).LoadSettingsCommand.ExecuteAsync(null);
        //    }



        //    base.OnLoaded();
        //}

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

        //private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
        //{
        //    ((MainViewModel)DataContext).AddNewStudentButtonPressedCommand.Execute(null);
        //}


    }
}


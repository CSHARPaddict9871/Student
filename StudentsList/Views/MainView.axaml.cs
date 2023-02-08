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

        private Point clickPosition;

        public Thickness RedRectangleMargin { get; set; } = new();

        private bool ButtonPressed = false;

        private Rectangle SelectedRectangle;

        private Thickness SelectedRectangleMargin;

        private double redRectangleCanvasLeft = 0;

        private double blueRectangleCanvasLeft = 200;

        private double greenRectangleCanvasLeft = 600;

        private double pinkRectangleCanvasLeft = 400;

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
            ButtonPressed = true;

            clickPosition = e.GetPosition(canvas);

            canvas.PointerMoved += Canvas_PointerMoved;

            SelectedRectangle = sender as Rectangle;

            SelectedRectangleMargin = SelectedRectangle.Margin;

            
        }

        private void Canvas_PointerMoved(object sender, PointerEventArgs e)
        {

             
            if (ButtonPressed)
            {
                Point mousePosition = e.GetPosition(canvas);

                var m = mousePosition.X;

                var distance = mousePosition.X - clickPosition.X;

                var left = clickPosition.X + distance;

                //switch (SelectedRectangle)
                //{
                //    case 
                //}

                double offset = 0;

                if (SelectedRectangle.Name == "BlueRectangle")
                {
                    offset = 200;
                }

                if (SelectedRectangle.Name == "PinkRectangle")
                {
                    offset = 400;
                }

                if (SelectedRectangle.Name == "GreenRectangle")
                {
                    offset = 600;
                }


                var leftOffset = left ;

                SelectedRectangle.Margin = new Thickness(left - offset, SelectedRectangleMargin.Top, SelectedRectangleMargin.Right, SelectedRectangleMargin.Bottom);
            }

        }

        private void Canvas_MouseLeftButtonUp(object sender, PointerReleasedEventArgs e)
        {
            ButtonPressed = false;
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


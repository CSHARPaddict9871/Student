using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using StudentsList.DataModels;
using StudentsList.Services;

namespace StudentsList.ViewModels;

public partial class MainViewModel : ObservableObject
{

    #region Public Properties and their backing members

    // Backing Member.  Sets initial value to string.Empty
    private string titleName = string.Empty;

    /// <summary>
    /// The Text that is displayed in the Title Textblock
    /// </summary>
    public string TitleName { get; set; }

    // Backing member
    private string descriptionName = string.Empty;

    /// <summary>
    /// The Text that is displayed in the Description Textblock
    /// </summary>
    public string DescriptionName { get; set; }


    /// <summary>
    /// The list of students to display
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<StudentViewModel> students = new();

    /// <summary>
    /// The Student selected in the collection of the listbox
    /// </summary>
    private StudentViewModel selectedStudent;
    public StudentViewModel SelectedStudent
    {
        get { return selectedStudent; }

        set
        {
            // If we already have a previously selected student,
            // set it's ShowDelete property to false
            if (selectedStudent != null)
            {
                foreach (var student in Students)
                {
                    if (student.ShowDelete == true) student.ShowDelete = false;
                }
            }

            selectedStudent = value;

            // Set the selected student's Show Delete property to true
            foreach (var student in Students)
            {
                if (selectedStudent == student) student.ShowDelete = true;
            }
        }
    }

    /// <summary>
    /// The first name entered in the textbox
    /// </summary>
    [ObservableProperty] private string firstName = string.Empty;

    /// <summary>
    /// The last name entered in the textbox
    /// </summary>
    [ObservableProperty] private string lastName = string.Empty;

    /// <summary>
    /// Flag to indicate if the add new student popup is open
    /// </summary>
    [ObservableProperty]
    private bool addNewStudentPopupIsOpen = false;

    /// <summary>
    /// Flag to indicate if we are currently adding a new student
    /// ... TODO:  I don't think this is working
    /// </summary>
    [ObservableProperty] private bool addingNewStudent = false;

    /// <summary>
    /// The toggle to show the Add Student overlay
    /// </summary>
    [ObservableProperty] private bool addStudentOverlayIsVisible = false;

    #endregion


    #region Default Constructor

    /// <summary>
    /// The default Constructor
    /// </summary>
    public MainViewModel()
    {
        Students = new DummyData().ReturnDummyData();

        
        SetTitle();
        SetDescription();
    }

    #endregion


    #region Relay Commands

    /// <summary>
    /// Sets the Add Student overlay toggle to true to show the overlay
    /// </summary>
    [RelayCommand]
    public void AddStudentButtonPressed()
    {
        AddStudentOverlayIsVisible = true;
    }

    /// <summary>
    /// Close the Add New Student overlay
    /// </summary>
    [RelayCommand]
    public void CloseAddNewStudent()
    {
        AddStudentOverlayIsVisible = false;
    }

    /// <summary>
    /// Save the New Student as long and first and last name are not blank
    /// </summary>
    [RelayCommand]
    public void SaveStudent()
    {
        // If the first and last name are not blank, add the student to Students list
        if (FirstName != string.Empty && LastName != string.Empty)
        {
            Students.Add(new StudentViewModel() { FirstName = FirstName, LastName = LastName, ShowDelete = false });
        }

        // Set the First and Last name properties to blank
        FirstName = string.Empty;
        LastName = string.Empty;

        // Close the Add new student overlay
        AddStudentOverlayIsVisible = false;
    }

    /// <summary>
    /// The CommunityToolkitMethod that gets ran after the view is loaded and running
    /// </summary>
    /// <returns>Returns a null task ???? TODO: what should this comment be???</returns>
    [RelayCommand]
    public async Task LoadSettingsAsync()
    {
        //ValidUsers = new ObservableCollection<UserModel>(await mValidUsersService.GetValidUsersAsync());

        await Task.Delay(500);
    }

    /// <summary>
    /// Remove Student from the TextBox
    /// </summary>
    /// <param name="student">The Student to Remove</param>
    [RelayCommand]
    public void RemoveStudent(StudentViewModel student)
    {
        Students.Remove(student);
    }

    /// <summary>
    /// Toggles when the popup TODO:  This isn't used, because we have no popup working
    /// </summary>
    [RelayCommand]
    public void AddNewStudentButtonPressed()
    {
        addNewStudentPopupIsOpen ^= true;
    }

    #endregion


    #region Private methods

    /// <summary>
    /// Define the Title : See Line 28 in MainWindow.axaml
    /// </summary>
    private void SetTitle()
    {
        TitleName = "Students List";
    }

    /// <summary>
    /// Define a description in the second Border 
    /// </summary>
    private void SetDescription()
    {
        DescriptionName = "Go to scholl !!!";
    }

    #endregion

}
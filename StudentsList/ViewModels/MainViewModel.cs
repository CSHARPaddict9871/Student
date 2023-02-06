using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using StudentsList.DataModels;

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

    

    [ObservableProperty]
    private ObservableCollection<Student> students = new();

    /// <summary>
    /// The Student selected in the collection of the listbox
    /// </summary>

    private Student selectedStudent;

    public Student SelectedStudent
    {
        get { return selectedStudent; }

        set
        {
            if (selectedStudent != null)
            {
                foreach (var student in Students)
                {
                    if (student.ShowDelete == true) student.ShowDelete = false;
                }
            }

            selectedStudent = value;

            foreach (var student in Students)
            {
                if (selectedStudent == student) student.ShowDelete = true;
            }
        }

    }

    [ObservableProperty] private string firstName = string.Empty;

    [ObservableProperty] private string lastName = string.Empty;

    [ObservableProperty]
    private bool addNewStudentPopupIsOpen = false;

    [ObservableProperty] private bool addingNewStudent = false;

    [ObservableProperty] private bool addStudentOverlayIsVisible = false;

    #endregion



    #region Default Constructor

    public MainViewModel()
    {
        Students.Add(new Student() { FirstName = "John", LastName = "MacGyver", ShowDelete = false });
        Students.Add(new Student() { FirstName = "Jason", LastName = "Statham", ShowDelete = false });
        Students.Add(new Student() { FirstName = "Francis", LastName = "Ngannou", ShowDelete = false });
        SetTitle();
        SetDescription();
    }

    #endregion

    #region Relay Commands

    [RelayCommand]
    public void AddStudentButtonPressed()
    {
        AddStudentOverlayIsVisible = true;
    }

    [RelayCommand]
    public void SaveStudent()
    {
        if (FirstName != string.Empty  && LastName != string.Empty) 
        {
            Students.Add(new Student() { FirstName = FirstName, LastName = LastName, ShowDelete = false });
        }

        FirstName = string.Empty;
        LastName = string.Empty;

        AddStudentOverlayIsVisible= false;
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






    // Add Student to the TextBox
    [RelayCommand]
    public void AddButton()
    {
        Students.Add(new Student() { FirstName = "John", LastName = "Doe", ShowDelete = false });
    }

    // Remove Student from the TextBox

    [RelayCommand]
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    [RelayCommand]
    public void AddNewStudentButtonPressed()
    {
        addNewStudentPopupIsOpen ^= true;
    }

    [RelayCommand]
    public void CloseAddNewStudent()
    {
        AddStudentOverlayIsVisible = false;
    }

#endregion


#region Private methods

// Define the Title : See Line 28 in MainWindow.axaml
private void SetTitle()
    {
        TitleName = "Students List";
    }

    // Define a description in the second Border 
    private void SetDescription()
    {
        DescriptionName = "Go to scholl !!!";
    }

    #endregion

}
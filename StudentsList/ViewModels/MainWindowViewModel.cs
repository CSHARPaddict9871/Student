using System.Collections.ObjectModel;
using System.Linq;
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
                var t = new ObservableCollection<Student>();

                foreach (var student in Students)
                {
                    if (student == selectedStudent)
                        student.ShowDelete = false;

                    t.Add(student);
                }

                Students = t;
            }

            selectedStudent = value;

            var temp = new ObservableCollection<Student>();

            foreach (var student in Students)
            {
                if (student == selectedStudent)
                    student.ShowDelete = true;

                temp.Add(student);
            }

            Students = temp;

        }
    }

    [ObservableProperty]
    private ObservableCollection<Student> students = new();

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

    // Add Student to the TextBox
    [RelayCommand]
    public void AddButton()
    {
        Students.Add(new Student() { FirstName = "John", LastName = "Doe", ShowDelete = false });
    }

    // Remove Student from the TextBox

    [RelayCommand]
    public void RemoveButton()
    {  
        // Now I am going to get this working... I will commit what I have.  Maybe you want to put a button under the student list to add a new student... we can add first and last name in the right hand box
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
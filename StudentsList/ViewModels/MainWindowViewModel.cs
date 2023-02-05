using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsList.DataModels;

namespace StudentsList.ViewModels;

public partial class MainViewModel : ObservableObject {

    private ObservableCollection<Student> students = new();

    private string titleName = string.Empty;
    public string TitleName {get; set;}

    private string descriptionName = string.Empty;
    public string DescriptionName { get; set; }
    
    
    [ObservableProperty]
    private Student selectedStudent;
    
    
    public ObservableCollection<Student> Students {
        get {
            return students;
        }
        set {

            SetProperty(ref students, value);
        }
    }

    // Define the Title : See Line 28 in MainWindow.axaml
    public void SetTitle() {
        TitleName = "Students List";
    }

    // Define a description in the second Border 
    public void setDescription() {
        DescriptionName = "Go to scholl !!!";
    }

    
    // Add Student to the TextBox
    [RelayCommand]
    public void addButton() {
        Students.Add(new Student() { FirstName = "John", LastName = "Doe" });
    }
    
    // Remove Student from the TextBox

    [RelayCommand]
    public void removeButton() {
        Students.Remove(new Student() { FirstName = "John", LastName = "Doe" });
    } 

    public MainViewModel() { 
        Students.Add(new Student() { FirstName = "John", LastName = "MacGyver" });
        Students.Add(new Student() { FirstName = "Jason", LastName = "Statham" });
        Students.Add(new Student() { FirstName = "Francis", LastName = "Ngannou" });    
        SetTitle();
        setDescription();
    }

}
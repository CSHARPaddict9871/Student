using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using StudentsList.DataModels;

namespace StudentsList.ViewModels;

public partial class MainViewModel : ObservableObject {

    private ObservableCollection<Student> students = new();

    private string titleName = string.Empty;
    public string TitleName {get; set;}

    private string descriptionName = string.Empty;
    public string DescriptionName { get; set; }
    
    public ObservableCollection<Student> Students {
        get {
            return students;
        }
        set {

            SetProperty(ref students, value);
        }
    }

    public MainViewModel() { // it is the path ?
        Students.Add(new Student() { FirstName = "John", LastName = "Doe" });
        SetTitle();
        setDescription();
    }

    public void SetTitle() {
        TitleName = "Students List";
    }

    public void setDescription() {
        DescriptionName = "Allez à l'école !!!";
    }
}
using StudentsList.DataModels;
using StudentsList.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsList.Services
{
    public class DummyData
    {

        public DummyData()
        {

        }

        public ObservableCollection<StudentViewModel> ReturnDummyData()
        {

         


            var students = new ObservableCollection<StudentViewModel>();

            students.Add(new StudentViewModel() { FirstName = "John", LastName = "MacGyver", ShowDelete = false });
            students.Add(new StudentViewModel() { FirstName = "Jason", LastName = "Statham", ShowDelete = false });
            students.Add(new StudentViewModel() { FirstName = "Francis", LastName = "Ngannou", ShowDelete = false });

            return students;
        }
       
    }
}

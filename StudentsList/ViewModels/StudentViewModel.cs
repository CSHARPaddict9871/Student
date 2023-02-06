using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsList.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        // Backing Member
        private string firstName;

        /// <summary>
        /// The First name of the student
        /// </summary>
        public string FirstName
        {
            get { return firstName; }

            set
            {
                // Set the first name to the new value
                firstName = value;
                // Update the Full name property
                FullName = string.Format("{0} {1}", firstName, LastName);
            }
        }

        // Backing member
        private string lastName;

        /// <summary>
        /// The last name of the student
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                // Set the last name to the new value
                lastName = value;
                // Update the FullName property with the new last name
                FullName = string.Format("{0} {1}", FirstName, lastName);
            }

        }

        /// <summary>
        /// The full name of the student (includes a space in between first and last name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The students grade between 0 and 5
        /// </summary>
        private double grade = 9.9;
        public double Grade
        {
            get { return grade; }
            set
            {
                grade = value;
            }
        }


        [ObservableProperty]
        private bool showDelete;

    }
}

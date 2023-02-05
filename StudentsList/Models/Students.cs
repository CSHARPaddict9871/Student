namespace StudentsList.DataModels {
    public class Student {
        
        private string firstName;

        public string FirstName
        {

            get { return firstName; }
            set
            {
                firstName = value;
                FullName = firstName + LastName;
            }
        }

        private string lastName;

        public string LastName {
            get { return lastName; }
            set {
                lastName = value;
                FullName = FirstName + lastName;
            }




        }

        public string FullName { get; set; }

        }
    }

using System.Reflection;

namespace RestForCD
{
    public class Teacher
    {
        public string? Name { get; set; }
        public int Salary { get; set; }
        public int Id { get; set; }


       

        public void ValidateName()
        {
            if (Name.Length <= 2 || Name.Length >= 15) throw new ArgumentOutOfRangeException();
        }

        public void ValidateSalary()
        {
            if (Salary < 1) throw new ArgumentOutOfRangeException();
        }

        public void Validate()
        {
           ValidateName();
           ValidateSalary();
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Salary + " ";
        }
    }
}
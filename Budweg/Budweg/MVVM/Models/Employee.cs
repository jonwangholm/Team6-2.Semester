namespace Budweg.MVVM.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsHR { get; set; }

        public Employee(string name, string email, bool isHr)
        {
            Name = name;
            Email = email;
            IsHR = isHr;
        }

        public string GetEmail(string email)
        {
            Email = email;
            return Email;
        }

    }
}

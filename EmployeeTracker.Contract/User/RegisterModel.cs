namespace EmployeeTracker.Contract.User
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
}
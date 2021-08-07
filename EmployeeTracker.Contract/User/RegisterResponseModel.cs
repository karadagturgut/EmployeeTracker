namespace EmployeeTracker.Contract.User
{
    public class RegisterResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string UserName { get; set; }
    }
}
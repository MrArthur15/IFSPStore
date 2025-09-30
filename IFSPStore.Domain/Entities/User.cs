using IFSPStore.Domain.Base;


namespace IFSPStore.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public User(int id, string name, string password, string login, string email, DateTime registrarionDate, DateTime loginDate, bool active):base(id) 
        {
            Name = name;
            Password = password;
            Login = login;
            Email = email;
            RegistrarionDate = registrarionDate;
            LoginDate = loginDate;
            Active = active;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime RegistrarionDate { get; set; }
        public DateTime LoginDate { get; set; }
        public bool Active { get; set; }
    }
}

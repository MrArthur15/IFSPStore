using IFSPStore.app.Infra;
using IFSPStore.app.Register;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;


namespace IFSPStore.app.Others
{
    public partial class Login : MaterialForm
    {
        private readonly IBaseService<User> _userService;
        public Login(IBaseService<User> userService)
        {
            _userService = userService;
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            User user = GetUser(txtLogin.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid username and/or password!", "IFSP Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!user.Active)
            {
                MessageBox.Show("Inactive user!", "IFSP Store",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                user.LoginDate = DateTime.Now;
                user = _userService.Update<User, User, UserValidator>(user);
                MainForm.User = user;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private User? GetUser(string login, string password)
        {
            CheckUserExistence();
            var user = _userService.Get<User>().Where(x => x.Login == login).FirstOrDefault();
            if (user == null)
                return null;
            return user.Password != password ? null : user;
        }
        private void CheckUserExistence()
        {
            var users = _userService.Get<User>().ToList();
            if (!users.Any())
            {
                var user = new User
                {
                    Login = "admin",
                    Password = "Admin@123",
                    Name = "Admnistrador",
                    Active = true,
                    RegistrationDate = DateTime.Now,
                    Email = "admin@gmail.com"
                };
                _userService.Add<User, User, UserValidator>(user);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var form = ConfigureDI.serviceProvider!.GetService<UserForm>();
            form.ShowDialog();
        }
    }
}

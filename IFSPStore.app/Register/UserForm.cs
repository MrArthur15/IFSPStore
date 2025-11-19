using IFSPStore.app.Base;
using IFSPStore.app.ViewModel;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Validatorrs;

namespace IFSPStore.app.Register
{
    public partial class UserForm : BaseForm
    {
        private IBaseService<User> _userService;
        private List<UserViewModel> users;
        public UserForm(IBaseService<User> userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void FormToObject(User user)
        {
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.Login = txtLogin.Text;
            user.Active = chkActive.Checked;
        }

        protected override void Save()
        {
            try
            {
                if (IsEditMode)
                {
                    if(int.TryParse(txtId.Text, out var id)) 
                    { 
                        var user = _userService.GetById<User>(id);
                        FormToObject(user);
                        user = _userService.Update<User, User, UserValidator>(user);
                    }
                    
                }

                else
                {
                    var user = new User();
                    FormToObject(user);
                    _userService.Add<User, User, UserValidator>(user);
                }
                tabControlRegister.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Delete(int id)
        {
            try
            {
                _userService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"IFSP Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void PopulateGrid()
        {
            users = _userService.Get<UserViewModel>().ToList();
            dataGridViewList.DataSource = users;
            dataGridViewList.Columns["Password"].Visible = false;
            dataGridViewList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected override void GridToForm(DataGridViewRow? record)
        {
            txtId.Text = record?.Cells["Id"].Value.ToString();
            txtName.Text = record?.Cells["Name"].Value.ToString();
            txtEmail.Text = record?.Cells["Email"].Value.ToString();
            txtLogin.Text = record?.Cells["Login"].Value.ToString();
            txtPassword.Text = record?.Cells["Password"].Value.ToString();
            chkActive.Checked = (bool)(record?.Cells["Active"].Value ?? false);

            txtRegistrationDate.Text = DateTime.TryParse(record?.Cells["RegistrationDate"].Value.ToString(), out var dataC)
                ? dataC.ToString("g")
                : "";

            txtLoginDate.Text = DateTime.TryParse(record?.Cells["LoginDate"].Value.ToString(), out var dataL)
                ? dataL.ToString("g")
                : "";
        }

       
    }
}

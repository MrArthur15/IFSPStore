
using IFSPStore.app.Infra;
using IFSPStore.app.Others;
using IFSPStore.app.Register;
using IFSPStore.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;

namespace IFSPStore.app
{
    public partial class MainForm : MaterialForm
    {
        public static User User { get; set; }
        public MainForm()
        {
            InitializeComponent();
            LoadLogin();
        }
        private void LoadLogin()
        {
            var login = ConfigureDI.serviceProvider!.GetService<Login>();
            if (login != null && !login.IsDisposed)
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                else
                {
                    lblUser.Text = $"User: {User.Name}";
                }
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<CategoryForm>();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<UserForm>();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
        }

        

        private void ShowForm<TFormulario>() where TFormulario : Form
        {
            var cad = ConfigureDI.serviceProvider!.GetService<TFormulario>();
            if (cad != null && !cad.IsDisposed)
            {
                cad.MdiParent = this;
                cad.Show();
            }
        }


    }
}

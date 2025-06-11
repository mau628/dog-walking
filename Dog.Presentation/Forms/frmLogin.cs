namespace Dog.Presentation.Forms;

using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmLogin : Form, IBaseForm
{
  private readonly IDataService<User> _userService;
  private readonly IFormFactory _formFactory;
  public frmLogin(IDataService<User> userService, IFormFactory formFactory)
  {
    _userService = userService;
    _formFactory = formFactory;
    InitializeComponent();
  }

  private void btnLogin_Click(object sender, EventArgs e)
  {
    _userService.Upsert(new User
    {
      Username = txtUsername.Text,
      Password = txtPassword.Text
    });

    var result = _userService.GetFiltered(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);
    if (!result.Any())
    {
      MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    _formFactory.Create<frmMain>().ShowForm(this);
  }

  public bool ShowForm(object? owner, params object[] args)
  {
    return false;
  }

}

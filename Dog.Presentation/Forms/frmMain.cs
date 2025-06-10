using Dog.Domain;

namespace Dog.Presentation.Forms
{
  public partial class frmMain : Form, IBaseForm
  {
    private IFormFactory _formFactory;
    public frmMain(IFormFactory formFactory)
    {
      InitializeComponent();
      _formFactory = formFactory;
    }

    private void btnClients_Click(object sender, EventArgs e)
    {
      _formFactory.Create<frmClient>().ShowForm(this);
    }


    public void ShowForm(object? owner, params object[] args) { }
  }
}

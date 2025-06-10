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
      _formFactory.Create<frmClient>().ShowForm(this, "152BB7B9-49F9-416D-B538-939F680A6BB6");
    }


    public void ShowForm(IWin32Window? owner, params object[] args) { }
  }
}

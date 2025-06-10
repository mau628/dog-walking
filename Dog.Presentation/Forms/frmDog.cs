namespace Dog.Presentation.Forms;
using System.Windows.Forms;

public partial class frmDog : Form, IBaseForm
{
  public frmDog()
  {
    InitializeComponent();
  }

  public void ShowForm(IWin32Window? owner, params object[] args)
  {
    this.ShowDialog(owner);
  }
}

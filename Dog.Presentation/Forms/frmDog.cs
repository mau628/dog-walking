namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Domain;

public partial class frmDog : Form, IBaseForm
{
  public frmDog()
  {
    InitializeComponent();
  }

  public void ShowForm(object owner, params object[] args)
  {
    this.ShowDialog(owner as IWin32Window);
  }
}

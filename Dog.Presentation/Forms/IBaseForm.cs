namespace Dog.Presentation.Forms;
public interface IBaseForm
{
  public void ShowForm(IWin32Window? owner, params object[] args);
}

namespace Dog.Domain;
public interface IBaseForm
{
  public bool ShowForm(object owner, params object[] args);
}

namespace Dog.Domain;

public interface IFormFactory
{
  T? Create<T>() where T : IBaseForm;
}

namespace Dog.Domain;

/// <summary>
/// Factory interface for creating forms in the dog walking management system.
/// </summary>
public interface IFormFactory
{
  /// <summary>
  /// Creates an instance of a form of type T.
  /// </summary>
  /// <typeparam name="T">The type of the form to create, must implement IBaseForm.</typeparam>
  /// <returns>An instance of the specified form type, or null if creation fails.</returns>
  T? Create<T>() where T : IBaseForm;
}

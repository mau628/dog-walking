namespace Dog.Domain;

/// <summary>
/// Interface for forms in the dog walking management system.
/// </summary>
public interface IBaseForm
{
  /// <summary>
  /// Shows the form with the specified owner and arguments.
  /// </summary>
  /// <param name="owner">The owner of the form, typically a parent window or control.</param>
  /// <param name="args">Optional arguments to pass to the form, can be used for initialization or configuration.</param>
  /// <returns>Returns true if the form saved successfully, otherwise false.</returns>
  public bool ShowForm(object owner, params object[] args);
}

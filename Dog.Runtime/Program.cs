namespace Dog.Runtime;

using Dog.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Main entry point for the Dog application.
/// </summary>
internal static class Program
{
  public static IServiceProvider ServiceProvider { get; private set; }

  /// <summary>
  ///  The main entry point for the application.
  /// </summary>
  [STAThread]
  static void Main()
  {
    ApplicationConfiguration.Initialize();
    ServiceProvider = ComponentRegistration.CreateHostBuilder().Build().Services;
    Application.Run(ServiceProvider.GetService<frmLogin>()!);
  }
}
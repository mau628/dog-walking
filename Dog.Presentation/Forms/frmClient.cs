namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmClient : Form, IBaseForm
{
  private Client _client = new();
  private readonly IClientService _clientService;
  public frmClient(
    IClientService clientService
  )
  {
    InitializeComponent();
    _clientService = clientService;
  }

  public void ShowForm(object owner, params object[] args)
  {
    var idParam = args.FirstOrDefault()?.ToString();
    Guid.TryParse(idParam, out var id);
    _client = _clientService.GetClientOrDefault(id);

    BindData();
    this.ShowDialog(owner as IWin32Window);
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    try
    {
      _clientService.Upsert(_client);
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    this.Close();
  }

  private void BindData()
  {
    txtName.BindData(_client, nameof(_client.Name));
    txtEmail.BindData(_client, nameof(_client.Email));
    txtPhone.BindData(_client, nameof(_client.PhoneNumber));

    tblDogs.BindData(
      _clientService.GetDogsByClientId(_client.Id),
      new Dictionary<string, string>
      {
        { nameof(Dog.Name), "Name" },
        { nameof(Dog.Breed), "Breed" }
      }
    );
  }
}

namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmClient : Form, IBaseForm
{
  private Client _client = new();
  private readonly IRepository<Client> _clientRepository;
  private readonly IRepository<Dog> _dogRepository;
  public frmClient(
    IRepository<Client> clientRepository,
    IRepository<Dog> dogRepository
  )
  {
    InitializeComponent();
    _clientRepository = clientRepository;
    _dogRepository = dogRepository;
  }

  public void ShowForm(IWin32Window? owner, params object[] args)
  {
    BindData();

    var clientId = Guid.Parse(args[0]?.ToString() ?? string.Empty);
    if (clientId != default)
    {
      _client = _clientRepository.Find(clientId) ?? new Client();
    }

    this.ShowDialog(owner);
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    if (_client.Id != default)
    {
      _clientRepository.Edit(_client);
    }
    else
    {
      _clientRepository.Add(_client);
    }
    this.Close();
  }

  private void BindData()
  {
    txtName.DataBindings.Add("Text", _client, nameof(_client.Name), true, DataSourceUpdateMode.OnPropertyChanged);
    txtEmail.DataBindings.Add("Text", _client, nameof(_client.Email), true, DataSourceUpdateMode.OnPropertyChanged);
    txtPhone.DataBindings.Add("Text", _client, nameof(_client.PhoneNumber), true, DataSourceUpdateMode.OnPropertyChanged);
  }
}

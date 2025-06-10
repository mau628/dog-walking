namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Domain;
using Dog.Domain.Models;
using XPTable.Models;

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

  public void ShowForm(object owner, params object[] args)
  {
    var idParam = args.FirstOrDefault()?.ToString();
    Guid.TryParse(idParam, out var id);
    _client = _clientRepository.Find(id) ?? new Client();

    BindData();
    this.ShowDialog(owner as IWin32Window);
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

    var columnModel = new ColumnModel();
    var tableModel = new TableModel();

    tblDogs.ColumnModel = columnModel;
    tblDogs.TableModel = tableModel;
    columnModel.Columns.Add(new TextColumn("Name"));
    columnModel.Columns.Add(new TextColumn("Breed"));
    foreach (var dog in _client.Dogs)
    {
      var row = new Row();
      row.Cells.Add(new Cell(dog.Name));
      row.Cells.Add(new Cell(dog.Breed));
      tableModel.Rows.Add(row);
    }
  }
}

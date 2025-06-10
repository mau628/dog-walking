namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;
using XPTable.Models;

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

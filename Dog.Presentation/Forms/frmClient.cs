namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmClient : Form, IBaseForm
{
  private Client _client = new();
  private readonly IDataService<Client> _clientService;
  private IFormFactory _formFactory;
  private bool _result;

  public frmClient(
    IDataService<Client> clientService,
    IFormFactory formFactory
  )
  {
    InitializeComponent();
    _clientService = clientService;
    _formFactory = formFactory;
  }

  public bool ShowForm(object owner, params object[] args)
  {
    _result = false;
    var idParam = args.FirstOrDefault()?.ToString();
    Guid.TryParse(idParam, out var id);
    BindData(id);

    this.btnClear.Enabled = _client.Id == default;
    this.btnDelete.Enabled = _client.Id != default;
    this.btnDogs.Enabled = _client.Id != default;
    this.ShowDialog(owner as IWin32Window);
    return _result;
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    try
    {
      _client = _clientService.Upsert(_client);
      _result = true;
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    MessageBox.Show("Client saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    this.Close();
  }

  private void BindData(Guid id)
  {
    _client = _clientService.GetEntityOrDefault(id);

    txtName.BindData(_client, nameof(_client.Name));
    txtEmail.BindData(_client, nameof(_client.Email));
    txtPhone.BindData(_client, nameof(_client.PhoneNumber));

    dgvDogs.BindData(
      _client.Dogs,
      new Dictionary<string, string>
      {
        { nameof(Dog.Id), "ID" },
        { nameof(Dog.Name), "Name" },
        { nameof(Dog.Breed), "Breed" }
      }
    );
  }

  private void btnClear_Click(object sender, EventArgs e)
  {
    txtName.Clear();
    txtEmail.Clear();
    txtPhone.Clear();
  }

  private void btnDelete_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
    {
      return;
    }
    _clientService.Delete(_client.Id);
    this.Close();
  }

  private void dgvDogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
    var senderGrid = (DataGridView)sender;

    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        e.RowIndex >= 0)
    {
      Guid.TryParse(dgvDogs.Rows[e.RowIndex].Cells[nameof(Dog.Id)].Value.ToString(), out var id);

      if (_formFactory.Create<frmDog>().ShowForm(this, id))
      {
        BindData(id);
      }
    }
  }

  private void btnDogs_Click(object sender, EventArgs e)
  {
    _formFactory.Create<frmDog>().ShowForm(this);
  }
}

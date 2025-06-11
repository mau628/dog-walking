using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

namespace Dog.Presentation.Forms
{
  public partial class frmMain : Form, IBaseForm
  {
    private readonly IDataService<Client> _clientService;
    private IFormFactory _formFactory;

    public frmMain(IFormFactory formFactory,
      IDataService<Client> clientService
      )
    {
      InitializeComponent();
      _formFactory = formFactory;
      _clientService = clientService;
      BindData();
    }

    private void btnClients_Click(object sender, EventArgs e)
    {
      if (_formFactory.Create<frmClient>().ShowForm(this))
      {
        BindData();
      }
    }

    private void BindData()
    {
      var clients = _clientService.GetFiltered(c => true).ToList();
      dgvClients.BindData(clients, new Dictionary<string, string>
      {
        { nameof(Client.Id), "ID" },
        { nameof(Client.Name), "Name" },
        { nameof(Client.PhoneNumber), "Phone" },
        { nameof(Client.Email), "Email" }
      });
    }

    public bool ShowForm(object? owner, params object[] args)
    {
      this.ShowDialog(owner as IWin32Window);
      return false;
    }

    private void btnDogs_Click(object sender, EventArgs e)
    {
      _formFactory.Create<frmDog>().ShowForm(this);
    }

    private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;

      if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
          e.RowIndex >= 0)
      {
        var id = dgvClients.Rows[e.RowIndex].Cells[nameof(Client.Id)].Value;
        if (_formFactory.Create<frmClient>().ShowForm(this, id))
        {
          BindData();
        }
      }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Application.Exit();
      }
    }
  }
}

namespace Dog.Presentation.Forms;

using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmSearch : Form, IBaseForm
{
  private readonly IDataService<Dog> _dogService;
  private readonly IDataService<Client> _clientService;
  private readonly IFormFactory _formFactory;
  public frmSearch(IDataService<Client> clientService, IDataService<Dog> dogService, IFormFactory formFactory)
  {
    InitializeComponent();
    _dogService = dogService;
    _clientService = clientService;
    _formFactory = formFactory;
  }

  private void btnClose_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  public bool ShowForm(object? owner, params object[] args)
  {
    this.ShowDialog(owner as IWin32Window);
    return false;
  }

  private void btnSearch_Click(object sender, EventArgs e)
  {
    if (rbDog.Checked)
    {
      var dogs = _dogService.GetFiltered(d => d.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
      dgvResults.BindData(dogs, new Dictionary<string, string>
      {
        { nameof(Dog.Id), "ID" },
        { nameof(Dog.Name), "Name" },
        { nameof(Dog.Breed), "Breed" },
      },
      false);
    }
    else if (rbClient.Checked)
    {
      var clients = _clientService.GetFiltered(c => c.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
      dgvResults.BindData(clients, new Dictionary<string, string>
      {
        { nameof(Client.Id), "ID" },
        { nameof(Client.Name), "Name" },
        { nameof(Client.PhoneNumber), "Phone" },
        { nameof(Client.Email), "Email" }
      },
      false);
    }
    else
    {
      MessageBox.Show("Please select a search type (Dog or Client).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}

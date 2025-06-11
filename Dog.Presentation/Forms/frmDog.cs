namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmDog : Form, IBaseForm
{
  private Dog _dog = new();
  private readonly IDataService<Dog> _dogService;
  private readonly IDataService<Client> _clientService;
  private IFormFactory _formFactory;
  private bool _result;

  public frmDog(
    IDataService<Dog> dogService,
    IDataService<Client> clientService,
    IFormFactory formFactory
  )
  {
    InitializeComponent();
    _dogService = dogService;
    _clientService = clientService;
    _formFactory = formFactory;
  }

  public bool ShowForm(object owner, params object[] args)
  {
    _result = false;
    var idParam = args.FirstOrDefault()?.ToString();
    Guid.TryParse(idParam, out var id);
    BindData(id);

    this.btnClear.Enabled = _dog.Id == default;
    this.btnDelete.Enabled = _dog.Id != default;
    this.ShowDialog(owner as IWin32Window);
    return _result;
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    _dog.Owner = _clientService.GetEntityOrDefault(Guid.Parse(cmbOwner.SelectedValue.ToString()));
    try
    {
      _dog = _dogService.Upsert(_dog);
      _result = true;
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    MessageBox.Show("Dog saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    this.Close();
  }

  private void BindData(Guid id)
  {
    _dog = _dogService.GetEntityOrDefault(id);

    cmbOwner.DataSource = _clientService.GetFiltered(c => true).ToList();
    cmbOwner.DisplayMember = nameof(Client.Name);
    cmbOwner.ValueMember = nameof(Client.Id);

    txtName.BindData(_dog, nameof(_dog.Name));
    txtBreed.BindData(_dog, nameof(_dog.Breed));
    dtpDOB.BindData(_dog, nameof(_dog.DateOfBirth));
    cmbOwner.SelectedIndex = -1;
    if (_dog.Owner != null)
    {
      cmbOwner.SelectedValue = _dog.Owner.Id;
    }

    dgvWalks.BindData(
      _dog.Walks,
      new Dictionary<string, string>
      {
        { nameof(Walk.Id), "ID" },
        { nameof(Walk.Date), "Date" },
        { nameof(Walk.DurationInMinutes), "Duration" },
        { nameof(Walk.Notes), "Notes" }
      }
    );
  }

  private void btnClear_Click(object sender, EventArgs e)
  {
    txtName.Clear();
    txtBreed.Clear();
    dtpDOB.Value = DateTime.Now;
    cmbOwner.SelectedIndex = -1;
  }

  private void btnDelete_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Are you sure you want to delete this dog?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
    {
      return;
    }
    _dogService.Delete(_dog.Id);
    this.Close();
  }

  private void btnWalks_Click(object sender, EventArgs e)
  {
    _formFactory.Create<frmWalk>().ShowForm(this);
  }
}

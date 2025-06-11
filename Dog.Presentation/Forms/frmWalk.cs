namespace Dog.Presentation.Forms;

using System.Windows.Forms;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;

public partial class frmWalk : Form, IBaseForm
{
  private Walk _walk = new();
  private readonly IDataService<Walk> _walkService;
  private readonly IDataService<Dog> _dogService;
  private bool _result;

  public frmWalk(
    IDataService<Walk> walkService,
    IDataService<Dog> dogService
  )
  {
    InitializeComponent();
    _walkService = walkService;
    _dogService = dogService;
  }

  public bool ShowForm(object owner, params object[] args)
  {
    _result = false;
    var idParam = args.FirstOrDefault()?.ToString();
    Guid.TryParse(idParam, out var id);
    BindData(id);

    this.btnClear.Enabled = _walk.Id == default;
    this.btnDelete.Enabled = _walk.Id != default;
    this.ShowDialog(owner as IWin32Window);
    return _result;
  }

  private void btnCancel_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    _walk.Dog = _dogService.GetEntityOrDefault(Guid.Parse(cmbDog.SelectedValue.ToString()));
    try
    {
      _walk = _walkService.Upsert(_walk);
      _result = true;
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    MessageBox.Show("Walk saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    this.Close();
  }

  private void BindData(Guid id)
  {
    _walk = _walkService.GetEntityOrDefault(id);

    cmbDog.DataSource = _dogService.GetFiltered(c => true).ToList();
    cmbDog.DisplayMember = nameof(Dog.Name);
    cmbDog.ValueMember = nameof(Dog.Id);

    dtpWalkDate.BindData(_walk, nameof(_walk.Date));
    nudDuration.BindData(_walk, nameof(_walk.DurationInMinutes));
    txtNotes.BindData(_walk, nameof(_walk.Notes));

    cmbDog.SelectedIndex = -1;
    if (_walk.Dog != null)
    {
      cmbDog.SelectedValue = _walk.Dog.Id;
    }
  }

  private void btnClear_Click(object sender, EventArgs e)
  {
    txtNotes.Clear();
    dtpWalkDate.Value = DateTime.Now;
    nudDuration.Value = 0;
    cmbDog.SelectedIndex = -1;
  }

  private void btnDelete_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Are you sure you want to delete this walk?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
    {
      return;
    }
    _walkService.Delete(_walk.Id);
    this.Close();
  }
}

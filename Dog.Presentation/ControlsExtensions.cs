using Dog.Domain;

namespace Dog.Presentation;
public static class ControlsExtensions
{
  public static void BindData<T>(this DataGridView grid, ICollection<T> data, IDictionary<string, string> columns)
  {
    grid.Columns.Clear();
    grid.Rows.Clear();
    grid.RowHeadersVisible = false;
    grid.AutoGenerateColumns = false;
    grid.AllowUserToAddRows = false;
    grid.AllowUserToDeleteRows = false;
    grid.ShowEditingIcon = true;
    grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    //grid.MultiSelect = true;
    //grid.ReadOnly = true;
    grid.EditMode = DataGridViewEditMode.EditProgrammatically;
    grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    grid.ScrollBars = ScrollBars.Both;
    grid.DataSource = null;

    foreach (var column in columns)
    {
      grid.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = column.Key,
        HeaderText = column.Value,
        DataPropertyName = column.Key,
        Visible = column.Key != nameof(BaseEntity.Id)
      });
    }
    grid.Columns.Add(new DataGridViewButtonColumn
    {
      Name = "Actions",
      HeaderText = "Actions",
      Text = "Details...",
      UseColumnTextForButtonValue = true,
      Width = 100
    });

    foreach (var item in data)
    {
      var row = new DataGridViewRow();
      foreach (var column in columns)
      {
        var value = typeof(T).GetProperty(column.Key)?.GetValue(item, null)?.ToString() ?? string.Empty;
        var cell = new DataGridViewTextBoxCell { Value = value };
        row.Cells.Add(cell);
      }
      row.Cells.Add(new DataGridViewButtonCell { Value = "Details..." });

      grid.Rows.Add(row);
    }
  }


  public static void BindData(this TextBox textBox, object dataSource, string propertyName, bool formattingEnabled = true, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    textBox.DataBindings.Clear();
    textBox.DataBindings.Add("Text", dataSource, propertyName, formattingEnabled, updateMode);
  }

  public static void BindData(this DateTimePicker textBox, object dataSource, string propertyName, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    textBox.DataBindings.Clear();
    textBox.DataBindings.Add("Value", dataSource, propertyName, false, updateMode);
  }

  public static void BindData(this ComboBox comboBox, object dataSource, string propertyName, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    comboBox.DataBindings.Clear();
    comboBox.DataBindings.Add("SelectedValue", dataSource, propertyName, false, updateMode);
  }
}

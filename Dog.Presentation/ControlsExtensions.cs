using Dog.Domain;

namespace Dog.Presentation;

/// <summary>
/// Provides extension methods for binding data to various controls in a Windows Forms application.
/// </summary>
public static class ControlsExtensions
{
  /// <summary>
  /// Binds a collection of data to a DataGridView control.
  /// </summary>
  /// <typeparam name="T">Type of the data items in the collection.</typeparam>
  /// <param name="grid">The DataGridView control to bind the data to.</param>
  /// <param name="data">The collection of data items to bind.</param>
  /// <param name="columns">A dictionary mapping property names to column headers.</param>
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
    grid.MultiSelect = false;
    grid.ReadOnly = true;
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
        var prop = typeof(T).GetProperty(column.Key);
        var value = prop?.GetValue(item, null)?.ToString() ?? string.Empty;
        if (prop?.PropertyType == typeof(DateTime))
        {
          var dateValue = (DateTime?)prop.GetValue(item, null);
          value = dateValue.HasValue ? dateValue.Value.ToShortDateString() : string.Empty;
        }


        var cell = new DataGridViewTextBoxCell { Value = value };
        row.Cells.Add(cell);
      }
      var buttonCell = new DataGridViewButtonCell { Value = "Details..." };
      buttonCell.Style.BackColor = Color.LightBlue;
      buttonCell.Style.Font = new Font(grid.Font, FontStyle.Bold);
      row.Cells.Add(buttonCell);

      grid.Rows.Add(row);
    }
  }

  /// <summary>
  /// Binds a TextBox control to a property of a data source.
  /// </summary>
  /// <param name="textBox">The TextBox control to bind.</param>
  /// <param name="dataSource">The data source object containing the property to bind to.</param>
  /// <param name="propertyName">The name of the property in the data source to bind to.</param>
  /// <param name="formattingEnabled">Indicates whether formatting is enabled for the binding.</param>
  /// <param name="updateMode">Indicates when the data source should be updated.</param>
  public static void BindData(this TextBox textBox, object dataSource, string propertyName, bool formattingEnabled = true, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    textBox.DataBindings.Clear();
    textBox.DataBindings.Add("Text", dataSource, propertyName, formattingEnabled, updateMode);
  }

  /// <summary>
  /// Binds a DateTimePicker control to a property of a data source.
  /// </summary>
  /// <param name="textBox">The DateTimePicker control to bind.</param>
  /// <param name="dataSource">The data source object containing the property to bind to.</param>
  /// <param name="propertyName">The name of the property in the data source to bind to.</param>
  /// <param name="formattingEnabled">Indicates whether formatting is enabled for the binding.</param>
  /// <param name="updateMode">Indicates when the data source should be updated.</param>
  public static void BindData(this DateTimePicker textBox, object dataSource, string propertyName, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    textBox.DataBindings.Clear();
    textBox.DataBindings.Add("Value", dataSource, propertyName, false, updateMode);
    textBox.Format = DateTimePickerFormat.Short;
  }

  /// <summary>
  /// Binds a ComboBox control to a property of a data source.
  /// </summary>
  /// <param name="comboBox">The ComboBox control to bind.</param>
  /// <param name="dataSource">The data source object containing the property to bind to.</param>
  /// <param name="propertyName">The name of the property in the data source to bind to.</param>
  /// <param name="formattingEnabled">Indicates whether formatting is enabled for the binding.</param>
  /// <param name="updateMode">Indicates when the data source should be updated.</param>
  public static void BindData(this ComboBox comboBox, object dataSource, string propertyName, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    comboBox.DataBindings.Clear();
    comboBox.DataBindings.Add("SelectedValue", dataSource, propertyName, false, updateMode);
  }

  /// <summary>
  /// Binds a NumericUpDown control to a property of a data source.
  /// </summary>
  /// <param name="numericUpDown">The NumericUpDown control to bind.</param>
  /// <param name="dataSource">The data source object containing the property to bind to.</param>
  /// <param name="propertyName">The name of the property in the data source to bind to.</param>
  /// <param name="formattingEnabled">Indicates whether formatting is enabled for the binding.</param>
  /// <param name="updateMode">Indicates when the data source should be updated.</param>
  public static void BindData(this NumericUpDown numericUpDown, object dataSource, string propertyName, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    numericUpDown.DataBindings.Clear();
    numericUpDown.DataBindings.Add("Value", dataSource, propertyName, false, updateMode);
  }
}

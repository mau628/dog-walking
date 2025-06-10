using XPTable.Models;

namespace Dog.Presentation;
public static class ControlsExtensions
{
  public static void BindData<T>(this Table table, ICollection<T> data, IDictionary<string, string> columns)
  {
    var columnModel = new ColumnModel();
    var tableModel = new TableModel();

    table.ColumnModel = columnModel;
    table.TableModel = tableModel;
    tableModel.Rows.Clear();

    foreach (var column in columns)
    {
      columnModel.Columns.Add(new TextColumn(column.Value));
    }

    foreach (var item in data)
    {
      var row = new Row();
      foreach (var column in columns)
      {
        row.Cells.Add(new Cell(GetPropertyValue(item, column.Key)));
      }
      tableModel.Rows.Add(row);
    }

    static string GetPropertyValue(T obj, string propertyName)
    {
      var prop = typeof(T).GetProperty(propertyName);
      if (prop == null)
      {
        return string.Empty;
      }
      return prop.GetValue(obj)?.ToString() ?? string.Empty;
    }
  }

  public static void BindData(this TextBox textBox, object dataSource, string propertyName, bool formattingEnabled = true, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
  {
    textBox.DataBindings.Clear();
    textBox.DataBindings.Add("Text", dataSource, propertyName, formattingEnabled, updateMode);
  }
}

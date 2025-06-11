namespace Dog.Presentation.Forms
{
  partial class frmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      btnClients = new Button();
      btnDogs = new Button();
      dgvClients = new DataGridView();
      ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
      SuspendLayout();
      // 
      // btnClients
      // 
      btnClients.Location = new Point(686, 217);
      btnClients.Name = "btnClients";
      btnClients.Size = new Size(102, 23);
      btnClients.TabIndex = 0;
      btnClients.Text = "Add Client...";
      btnClients.UseVisualStyleBackColor = true;
      btnClients.Click += btnClients_Click;
      // 
      // btnDogs
      // 
      btnDogs.Location = new Point(164, 288);
      btnDogs.Name = "btnDogs";
      btnDogs.Size = new Size(102, 23);
      btnDogs.TabIndex = 1;
      btnDogs.Text = "Add Dog...";
      btnDogs.UseVisualStyleBackColor = true;
      btnDogs.Click += btnDogs_Click;
      // 
      // dgvClients
      // 
      dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvClients.Location = new Point(12, 12);
      dgvClients.Name = "dgvClients";
      dgvClients.Size = new Size(776, 199);
      dgvClients.TabIndex = 2;
      dgvClients.CellContentClick += dgvClients_CellContentClick;
      // 
      // frmMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(dgvClients);
      Controls.Add(btnDogs);
      Controls.Add(btnClients);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MaximizeBox = false;
      Name = "frmMain";
      StartPosition = FormStartPosition.CenterParent;
      Text = "Dog Walking";
      ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Button btnClients;
    private Button btnDogs;
    private DataGridView dgvClients;
  }
}
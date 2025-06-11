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
      dgvClients = new DataGridView();
      btnExit = new Button();
      btnSearch = new Button();
      ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
      SuspendLayout();
      // 
      // btnClients
      // 
      btnClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnClients.Location = new Point(12, 422);
      btnClients.Name = "btnClients";
      btnClients.Size = new Size(102, 23);
      btnClients.TabIndex = 0;
      btnClients.Text = "Add Client...";
      btnClients.UseVisualStyleBackColor = true;
      btnClients.Click += btnClients_Click;
      // 
      // dgvClients
      // 
      dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvClients.Location = new Point(12, 12);
      dgvClients.Name = "dgvClients";
      dgvClients.Size = new Size(776, 404);
      dgvClients.TabIndex = 1;
      dgvClients.CellContentClick += dgvClients_CellContentClick;
      // 
      // btnExit
      // 
      btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnExit.Location = new Point(686, 422);
      btnExit.Name = "btnExit";
      btnExit.Size = new Size(102, 23);
      btnExit.TabIndex = 2;
      btnExit.Text = "EXIT";
      btnExit.UseVisualStyleBackColor = true;
      btnExit.Click += btnExit_Click;
      // 
      // btnSearch
      // 
      btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnSearch.Location = new Point(344, 422);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new Size(102, 23);
      btnSearch.TabIndex = 3;
      btnSearch.Text = "Search...";
      btnSearch.UseVisualStyleBackColor = true;
      btnSearch.Click += btnSearch_Click;
      // 
      // frmMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 457);
      Controls.Add(btnSearch);
      Controls.Add(btnExit);
      Controls.Add(dgvClients);
      Controls.Add(btnClients);
      Name = "frmMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Dog Walking";
      ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Button btnClients;
    private DataGridView dgvClients;
    private Button btnExit;
    private Button btnSearch;
  }
}
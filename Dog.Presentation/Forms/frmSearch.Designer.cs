namespace Dog.Presentation.Forms
{
  partial class frmSearch
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
      gbType = new GroupBox();
      rbDog = new RadioButton();
      rbClient = new RadioButton();
      label1 = new Label();
      txtSearch = new TextBox();
      dgvResults = new DataGridView();
      btnClose = new Button();
      btnSearch = new Button();
      gbType.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
      SuspendLayout();
      // 
      // gbType
      // 
      gbType.Controls.Add(rbDog);
      gbType.Controls.Add(rbClient);
      gbType.Location = new Point(12, 12);
      gbType.Name = "gbType";
      gbType.Size = new Size(122, 52);
      gbType.TabIndex = 0;
      gbType.TabStop = false;
      gbType.Text = "Search Type";
      // 
      // rbDog
      // 
      rbDog.AutoSize = true;
      rbDog.Location = new Point(68, 22);
      rbDog.Name = "rbDog";
      rbDog.Size = new Size(47, 19);
      rbDog.TabIndex = 1;
      rbDog.TabStop = true;
      rbDog.Text = "Dog";
      rbDog.UseVisualStyleBackColor = true;
      // 
      // rbClient
      // 
      rbClient.AutoSize = true;
      rbClient.Location = new Point(6, 22);
      rbClient.Name = "rbClient";
      rbClient.Size = new Size(56, 19);
      rbClient.TabIndex = 0;
      rbClient.TabStop = true;
      rbClient.Text = "Client";
      rbClient.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(140, 34);
      label1.Name = "label1";
      label1.Size = new Size(42, 15);
      label1.TabIndex = 1;
      label1.Text = "Name:";
      // 
      // txtSearch
      // 
      txtSearch.Location = new Point(188, 31);
      txtSearch.Name = "txtSearch";
      txtSearch.Size = new Size(244, 23);
      txtSearch.TabIndex = 1;
      // 
      // dgvResults
      // 
      dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvResults.Location = new Point(12, 70);
      dgvResults.Name = "dgvResults";
      dgvResults.Size = new Size(501, 258);
      dgvResults.TabIndex = 3;
      // 
      // btnClose
      // 
      btnClose.Location = new Point(438, 334);
      btnClose.Name = "btnClose";
      btnClose.Size = new Size(75, 23);
      btnClose.TabIndex = 3;
      btnClose.Text = "Close";
      btnClose.UseVisualStyleBackColor = true;
      btnClose.Click += btnClose_Click;
      // 
      // btnSearch
      // 
      btnSearch.Location = new Point(438, 32);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new Size(75, 23);
      btnSearch.TabIndex = 2;
      btnSearch.Text = "Search";
      btnSearch.UseVisualStyleBackColor = true;
      btnSearch.Click += btnSearch_Click;
      // 
      // frmSearch
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(525, 367);
      Controls.Add(btnSearch);
      Controls.Add(btnClose);
      Controls.Add(dgvResults);
      Controls.Add(txtSearch);
      Controls.Add(label1);
      Controls.Add(gbType);
      Name = "frmSearch";
      StartPosition = FormStartPosition.CenterParent;
      Text = "frmSearch";
      gbType.ResumeLayout(false);
      gbType.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private GroupBox gbType;
    private RadioButton rbClient;
    private RadioButton rbDog;
    private Label label1;
    private TextBox txtSearch;
    private DataGridView dgvResults;
    private Button btnClose;
    private Button btnSearch;
  }
}
namespace Dog.Presentation.Forms
{
  partial class frmClient
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
      txtName = new TextBox();
      label1 = new Label();
      label2 = new Label();
      txtPhone = new TextBox();
      label3 = new Label();
      txtEmail = new TextBox();
      btnSave = new Button();
      btnCancel = new Button();
      label4 = new Label();
      btnClear = new Button();
      btnDelete = new Button();
      dgvDogs = new DataGridView();
      btnDogs = new Button();
      ((System.ComponentModel.ISupportInitialize)dgvDogs).BeginInit();
      SuspendLayout();
      // 
      // txtName
      // 
      txtName.Location = new Point(56, 6);
      txtName.Name = "txtName";
      txtName.Size = new Size(382, 23);
      txtName.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 9);
      label1.Name = "label1";
      label1.Size = new Size(39, 15);
      label1.TabIndex = 1;
      label1.Text = "Name";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(12, 38);
      label2.Name = "label2";
      label2.Size = new Size(41, 15);
      label2.TabIndex = 3;
      label2.Text = "Phone";
      // 
      // txtPhone
      // 
      txtPhone.Location = new Point(56, 35);
      txtPhone.Name = "txtPhone";
      txtPhone.Size = new Size(100, 23);
      txtPhone.TabIndex = 2;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(162, 38);
      label3.Name = "label3";
      label3.Size = new Size(36, 15);
      label3.TabIndex = 5;
      label3.Text = "Email";
      // 
      // txtEmail
      // 
      txtEmail.Location = new Point(204, 35);
      txtEmail.Name = "txtEmail";
      txtEmail.Size = new Size(234, 23);
      txtEmail.TabIndex = 4;
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnSave.Location = new Point(66, 320);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(75, 23);
      btnSave.TabIndex = 6;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnCancel.Location = new Point(309, 320);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 9;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(12, 73);
      label4.Name = "label4";
      label4.Size = new Size(75, 15);
      label4.TabIndex = 9;
      label4.Text = "Owned Dogs";
      // 
      // btnClear
      // 
      btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnClear.Location = new Point(147, 320);
      btnClear.Name = "btnClear";
      btnClear.Size = new Size(75, 23);
      btnClear.TabIndex = 7;
      btnClear.Text = "Clear";
      btnClear.UseVisualStyleBackColor = true;
      btnClear.Click += btnClear_Click;
      // 
      // btnDelete
      // 
      btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnDelete.Location = new Point(228, 320);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new Size(75, 23);
      btnDelete.TabIndex = 8;
      btnDelete.Text = "Delete";
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // dgvDogs
      // 
      dgvDogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvDogs.Location = new Point(12, 91);
      dgvDogs.Name = "dgvDogs";
      dgvDogs.Size = new Size(426, 176);
      dgvDogs.TabIndex = 10;
      dgvDogs.CellContentClick += dgvDogs_CellContentClick;
      // 
      // btnDogs
      // 
      btnDogs.Location = new Point(12, 273);
      btnDogs.Name = "btnDogs";
      btnDogs.Size = new Size(102, 23);
      btnDogs.TabIndex = 11;
      btnDogs.Text = "Add Dog...";
      btnDogs.UseVisualStyleBackColor = true;
      btnDogs.Click += btnDogs_Click;
      // 
      // frmClient
      // 
      AcceptButton = btnSave;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 352);
      ControlBox = false;
      Controls.Add(btnDogs);
      Controls.Add(dgvDogs);
      Controls.Add(btnDelete);
      Controls.Add(btnClear);
      Controls.Add(label4);
      Controls.Add(btnCancel);
      Controls.Add(btnSave);
      Controls.Add(label3);
      Controls.Add(txtEmail);
      Controls.Add(label2);
      Controls.Add(txtPhone);
      Controls.Add(label1);
      Controls.Add(txtName);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Name = "frmClient";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Client";
      ((System.ComponentModel.ISupportInitialize)dgvDogs).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtName;
    private Label label1;
    private Label label2;
    private TextBox txtPhone;
    private Label label3;
    private TextBox txtEmail;
    private Button btnSave;
    private Button btnCancel;
    private Label label4;
    private Button btnClear;
    private Button btnDelete;
    private DataGridView dgvDogs;
    private Button btnDogs;
  }
}
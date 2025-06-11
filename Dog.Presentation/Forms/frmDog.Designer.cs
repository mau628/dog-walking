namespace Dog.Presentation.Forms
{
  partial class frmDog
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
      txtBreed = new TextBox();
      label3 = new Label();
      btnSave = new Button();
      btnCancel = new Button();
      label4 = new Label();
      btnClear = new Button();
      btnDelete = new Button();
      dtpDOB = new DateTimePicker();
      cmbOwner = new ComboBox();
      label5 = new Label();
      dgvWalks = new DataGridView();
      btnWalks = new Button();
      ((System.ComponentModel.ISupportInitialize)dgvWalks).BeginInit();
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
      label1.Location = new Point(9, 9);
      label1.Name = "label1";
      label1.Size = new Size(39, 15);
      label1.TabIndex = 1;
      label1.Text = "Name";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(9, 38);
      label2.Name = "label2";
      label2.Size = new Size(37, 15);
      label2.TabIndex = 3;
      label2.Text = "Breed";
      // 
      // txtBreed
      // 
      txtBreed.Location = new Point(56, 35);
      txtBreed.Name = "txtBreed";
      txtBreed.Size = new Size(100, 23);
      txtBreed.TabIndex = 1;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(162, 38);
      label3.Name = "label3";
      label3.Size = new Size(31, 15);
      label3.TabIndex = 5;
      label3.Text = "DOB";
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnSave.Location = new Point(63, 302);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(75, 23);
      btnSave.TabIndex = 4;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnCancel.Location = new Point(306, 302);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(9, 95);
      label4.Name = "label4";
      label4.Size = new Size(38, 15);
      label4.TabIndex = 9;
      label4.Text = "Walks";
      // 
      // btnClear
      // 
      btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnClear.Location = new Point(144, 302);
      btnClear.Name = "btnClear";
      btnClear.Size = new Size(75, 23);
      btnClear.TabIndex = 5;
      btnClear.Text = "Clear";
      btnClear.UseVisualStyleBackColor = true;
      btnClear.Click += btnClear_Click;
      // 
      // btnDelete
      // 
      btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnDelete.Location = new Point(225, 302);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new Size(75, 23);
      btnDelete.TabIndex = 6;
      btnDelete.Text = "Delete";
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // dtpDOB
      // 
      dtpDOB.Format = DateTimePickerFormat.Short;
      dtpDOB.Location = new Point(199, 35);
      dtpDOB.Name = "dtpDOB";
      dtpDOB.Size = new Size(239, 23);
      dtpDOB.TabIndex = 2;
      // 
      // cmbOwner
      // 
      cmbOwner.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbOwner.FormattingEnabled = true;
      cmbOwner.Location = new Point(56, 64);
      cmbOwner.Name = "cmbOwner";
      cmbOwner.Size = new Size(382, 23);
      cmbOwner.TabIndex = 3;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(9, 67);
      label5.Name = "label5";
      label5.Size = new Size(42, 15);
      label5.TabIndex = 13;
      label5.Text = "Owner";
      // 
      // dgvWalks
      // 
      dgvWalks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvWalks.Location = new Point(12, 113);
      dgvWalks.Name = "dgvWalks";
      dgvWalks.Size = new Size(426, 150);
      dgvWalks.TabIndex = 9;
      dgvWalks.CellContentClick += dgvWalks_CellContentClick;
      // 
      // btnWalks
      // 
      btnWalks.Location = new Point(12, 269);
      btnWalks.Name = "btnWalks";
      btnWalks.Size = new Size(102, 23);
      btnWalks.TabIndex = 8;
      btnWalks.Text = "Add Walks...";
      btnWalks.UseVisualStyleBackColor = true;
      btnWalks.Click += btnWalks_Click;
      // 
      // frmDog
      // 
      AcceptButton = btnSave;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 334);
      ControlBox = false;
      Controls.Add(btnWalks);
      Controls.Add(dgvWalks);
      Controls.Add(label5);
      Controls.Add(cmbOwner);
      Controls.Add(dtpDOB);
      Controls.Add(btnDelete);
      Controls.Add(btnClear);
      Controls.Add(label4);
      Controls.Add(btnCancel);
      Controls.Add(btnSave);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(txtBreed);
      Controls.Add(label1);
      Controls.Add(txtName);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Name = "frmDog";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Dog";
      ((System.ComponentModel.ISupportInitialize)dgvWalks).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtName;
    private Label label1;
    private Label label2;
    private TextBox txtBreed;
    private Label label3;
    private Button btnSave;
    private Button btnCancel;
    private Label label4;
    private Button btnClear;
    private Button btnDelete;
    private DateTimePicker dtpDOB;
    private ComboBox cmbOwner;
    private Label label5;
    private DataGridView dgvWalks;
    private Button btnWalks;
  }
}
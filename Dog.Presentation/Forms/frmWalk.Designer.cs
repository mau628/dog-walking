namespace Dog.Presentation.Forms
{
  partial class frmWalk
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
      txtNotes = new TextBox();
      label1 = new Label();
      label3 = new Label();
      btnSave = new Button();
      btnCancel = new Button();
      btnClear = new Button();
      btnDelete = new Button();
      dtpWalkDate = new DateTimePicker();
      cmbDog = new ComboBox();
      label5 = new Label();
      label4 = new Label();
      label2 = new Label();
      nudDuration = new NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
      SuspendLayout();
      // 
      // txtNotes
      // 
      txtNotes.Location = new Point(64, 99);
      txtNotes.Multiline = true;
      txtNotes.Name = "txtNotes";
      txtNotes.Size = new Size(374, 46);
      txtNotes.TabIndex = 3;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(20, 102);
      label1.Name = "label1";
      label1.Size = new Size(38, 15);
      label1.TabIndex = 1;
      label1.Text = "Notes";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(27, 47);
      label3.Name = "label3";
      label3.Size = new Size(31, 15);
      label3.TabIndex = 5;
      label3.Text = "Date";
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnSave.Location = new Point(63, 161);
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
      btnCancel.Location = new Point(306, 161);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnClear
      // 
      btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      btnClear.Location = new Point(144, 161);
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
      btnDelete.Location = new Point(225, 161);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new Size(75, 23);
      btnDelete.TabIndex = 6;
      btnDelete.Text = "Delete";
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // dtpWalkDate
      // 
      dtpWalkDate.Location = new Point(64, 41);
      dtpWalkDate.Name = "dtpWalkDate";
      dtpWalkDate.Size = new Size(239, 23);
      dtpWalkDate.TabIndex = 1;
      // 
      // cmbDog
      // 
      cmbDog.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbDog.FormattingEnabled = true;
      cmbDog.Location = new Point(64, 12);
      cmbDog.Name = "cmbDog";
      cmbDog.Size = new Size(374, 23);
      cmbDog.TabIndex = 0;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(29, 15);
      label5.Name = "label5";
      label5.Size = new Size(29, 15);
      label5.TabIndex = 13;
      label5.Text = "Dog";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(5, 74);
      label4.Name = "label4";
      label4.Size = new Size(53, 15);
      label4.TabIndex = 15;
      label4.Text = "Duration";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(190, 74);
      label2.Name = "label2";
      label2.Size = new Size(85, 15);
      label2.TabIndex = 16;
      label2.Text = "hh:mm format";
      // 
      // nudDuration
      // 
      nudDuration.Location = new Point(63, 70);
      nudDuration.Name = "nudDuration";
      nudDuration.Size = new Size(121, 23);
      nudDuration.TabIndex = 2;
      // 
      // frmWalk
      // 
      AcceptButton = btnSave;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 193);
      ControlBox = false;
      Controls.Add(nudDuration);
      Controls.Add(label2);
      Controls.Add(label4);
      Controls.Add(label5);
      Controls.Add(cmbDog);
      Controls.Add(dtpWalkDate);
      Controls.Add(btnDelete);
      Controls.Add(btnClear);
      Controls.Add(btnCancel);
      Controls.Add(btnSave);
      Controls.Add(label3);
      Controls.Add(label1);
      Controls.Add(txtNotes);
      FormBorderStyle = FormBorderStyle.FixedDialog;
      Name = "frmWalk";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Walk";
      ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtNotes;
    private Label label1;
    private Label label3;
    private Button btnSave;
    private Button btnCancel;
    private Button btnClear;
    private Button btnDelete;
    private DateTimePicker dtpWalkDate;
    private ComboBox cmbDog;
    private Label label5;
    private Label label4;
    private Label label2;
    private NumericUpDown nudDuration;
  }
}
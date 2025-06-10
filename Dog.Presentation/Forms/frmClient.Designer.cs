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
      btnSave.Location = new Point(140, 322);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(75, 23);
      btnSave.TabIndex = 6;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(221, 322);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // frmClient
      // 
      AcceptButton = btnSave;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 357);
      ControlBox = false;
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
  }
}
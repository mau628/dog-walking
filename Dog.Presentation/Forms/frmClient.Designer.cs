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
      XPTable.Models.DataSourceColumnBinder dataSourceColumnBinder2 = new XPTable.Models.DataSourceColumnBinder();
      XPTable.Renderers.DragDropRenderer dragDropRenderer2 = new XPTable.Renderers.DragDropRenderer();
      txtName = new TextBox();
      label1 = new Label();
      label2 = new Label();
      txtPhone = new TextBox();
      label3 = new Label();
      txtEmail = new TextBox();
      btnSave = new Button();
      btnCancel = new Button();
      tblDogs = new XPTable.Models.Table();
      label4 = new Label();
      ((System.ComponentModel.ISupportInitialize)tblDogs).BeginInit();
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
      // tblDogs
      // 
      tblDogs.BorderColor = Color.Black;
      tblDogs.DataMember = null;
      tblDogs.DataSourceColumnBinder = dataSourceColumnBinder2;
      dragDropRenderer2.ForeColor = Color.Red;
      tblDogs.DragDropRenderer = dragDropRenderer2;
      tblDogs.GridLinesContrainedToData = false;
      tblDogs.Location = new Point(12, 91);
      tblDogs.Name = "tblDogs";
      tblDogs.Size = new Size(426, 150);
      tblDogs.TabIndex = 8;
      tblDogs.Text = "table1";
      tblDogs.UnfocusedBorderColor = Color.Black;
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
      // frmClient
      // 
      AcceptButton = btnSave;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 357);
      ControlBox = false;
      Controls.Add(label4);
      Controls.Add(tblDogs);
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
      ((System.ComponentModel.ISupportInitialize)tblDogs).EndInit();
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
    private XPTable.Models.Table tblDogs;
    private Label label4;
  }
}
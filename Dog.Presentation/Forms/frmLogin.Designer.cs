namespace Dog.Presentation.Forms
{
  partial class frmLogin
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
      txtUsername = new TextBox();
      txtPassword = new TextBox();
      btnLogin = new Button();
      label1 = new Label();
      label2 = new Label();
      btnCancel = new Button();
      SuspendLayout();
      // 
      // txtUsername
      // 
      txtUsername.Location = new Point(87, 12);
      txtUsername.Name = "txtUsername";
      txtUsername.Size = new Size(197, 23);
      txtUsername.TabIndex = 0;
      // 
      // txtPassword
      // 
      txtPassword.Location = new Point(87, 41);
      txtPassword.Name = "txtPassword";
      txtPassword.PasswordChar = '•';
      txtPassword.Size = new Size(197, 23);
      txtPassword.TabIndex = 1;
      // 
      // btnLogin
      // 
      btnLogin.Location = new Point(87, 70);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(93, 23);
      btnLogin.TabIndex = 2;
      btnLogin.Text = "Login";
      btnLogin.UseVisualStyleBackColor = true;
      btnLogin.Click += btnLogin_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(18, 15);
      label1.Name = "label1";
      label1.Size = new Size(63, 15);
      label1.TabIndex = 3;
      label1.Text = "Username:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(21, 44);
      label2.Name = "label2";
      label2.Size = new Size(60, 15);
      label2.TabIndex = 4;
      label2.Text = "Password:";
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(191, 70);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(93, 23);
      btnCancel.TabIndex = 5;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // frmLogin
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(302, 112);
      Controls.Add(btnCancel);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(btnLogin);
      Controls.Add(txtPassword);
      Controls.Add(txtUsername);
      FormBorderStyle = FormBorderStyle.FixedToolWindow;
      Name = "frmLogin";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Login";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label label1;
    private Label label2;
    private Button btnCancel;
  }
}
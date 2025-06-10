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
      SuspendLayout();
      // 
      // btnClients
      // 
      btnClients.Location = new Point(12, 12);
      btnClients.Name = "btnClients";
      btnClients.Size = new Size(102, 23);
      btnClients.TabIndex = 0;
      btnClients.Text = "Add Client...";
      btnClients.UseVisualStyleBackColor = true;
      btnClients.Click += btnClients_Click;
      // 
      // frmMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(btnClients);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MaximizeBox = false;
      Name = "frmMain";
      StartPosition = FormStartPosition.CenterParent;
      Text = "Dog Walking";
      ResumeLayout(false);
    }

    #endregion

    private Button btnClients;
  }
}
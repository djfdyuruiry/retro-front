using System.ComponentModel;
using System.Windows.Forms;

namespace RetroFront.Agent.Screens
{
  public partial class AgentSplashScreen
  {
    private IContainer components = null;

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
            this._banner = new System.Windows.Forms.Panel();
            this._header = new System.Windows.Forms.Label();
            this._ipAddress = new System.Windows.Forms.Label();
            this._prompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _banner
            // 
            this._banner.BackColor = System.Drawing.Color.SteelBlue;
            this._banner.Location = new System.Drawing.Point(-1, 97);
            this._banner.Name = "_banner";
            this._banner.Size = new System.Drawing.Size(620, 100);
            this._banner.TabIndex = 0;
            // 
            // _header
            // 
            this._header.AutoSize = true;
            this._header.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this._header.ForeColor = System.Drawing.Color.MintCream;
            this._header.Location = new System.Drawing.Point(12, 24);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(425, 56);
            this._header.TabIndex = 1;
            this._header.Text = "GameFront Agent";
            // 
            // _ipAddress
            // 
            this._ipAddress.AutoSize = true;
            this._ipAddress.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ipAddress.ForeColor = System.Drawing.Color.MintCream;
            this._ipAddress.Location = new System.Drawing.Point(16, 215);
            this._ipAddress.Name = "_ipAddress";
            this._ipAddress.Size = new System.Drawing.Size(167, 33);
            this._ipAddress.TabIndex = 2;
            this._ipAddress.Text = "IP Address:";
            // 
            // _prompt
            // 
            this._prompt.AutoSize = true;
            this._prompt.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prompt.ForeColor = System.Drawing.Color.MintCream;
            this._prompt.Location = new System.Drawing.Point(16, 286);
            this._prompt.Name = "_prompt";
            this._prompt.Size = new System.Drawing.Size(433, 66);
            this._prompt.TabIndex = 3;
            this._prompt.Text = "Connect to this agent using the\r\napp on the host machine";
            // 
            // AgentSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(618, 424);
            this.Controls.Add(this._prompt);
            this.Controls.Add(this._ipAddress);
            this.Controls.Add(this._header);
            this.Controls.Add(this._banner);
            this.Name = "AgentSplashScreen";
            this.Text = "AgentSplashScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgentSplashScreen_FormClosing);
            this.Load += new System.EventHandler(this.AgentSplashScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AgentSplashScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Panel _banner;

    private Label _header;
    private Label _ipAddress;
    private Label _prompt;
  }
}

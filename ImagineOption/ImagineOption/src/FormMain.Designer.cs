namespace ImagineOption
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWindowMode = new System.Windows.Forms.Label();
            this.cmbWindowMode = new System.Windows.Forms.ComboBox();
            this.lblDisplayAdapter = new System.Windows.Forms.Label();
            this.cmbDisplayAdapter = new System.Windows.Forms.ComboBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.cmbChatFontSize = new System.Windows.Forms.ComboBox();
            this.tblOptions = new System.Windows.Forms.TableLayoutPanel();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.chkJapLocale = new System.Windows.Forms.CheckBox();
            this.tblOptions.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWindowMode
            // 
            resources.ApplyResources(this.lblWindowMode, "lblWindowMode");
            this.lblWindowMode.Name = "lblWindowMode";
            // 
            // cmbWindowMode
            // 
            resources.ApplyResources(this.cmbWindowMode, "cmbWindowMode");
            this.cmbWindowMode.FormattingEnabled = true;
            this.cmbWindowMode.Name = "cmbWindowMode";
            this.cmbWindowMode.SelectedIndexChanged += new System.EventHandler(this.cmbWindowMode_SelectedIndexChanged);
            // 
            // lblDisplayAdapter
            // 
            resources.ApplyResources(this.lblDisplayAdapter, "lblDisplayAdapter");
            this.lblDisplayAdapter.Name = "lblDisplayAdapter";
            // 
            // cmbDisplayAdapter
            // 
            resources.ApplyResources(this.cmbDisplayAdapter, "cmbDisplayAdapter");
            this.cmbDisplayAdapter.FormattingEnabled = true;
            this.cmbDisplayAdapter.Name = "cmbDisplayAdapter";
            this.cmbDisplayAdapter.SelectedIndexChanged += new System.EventHandler(this.cmbDisplayAdapter_SelectedIndexChanged);
            // 
            // lblResolution
            // 
            resources.ApplyResources(this.lblResolution, "lblResolution");
            this.lblResolution.Name = "lblResolution";
            // 
            // cmbResolution
            // 
            resources.ApplyResources(this.cmbResolution, "cmbResolution");
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.SelectedIndexChanged += new System.EventHandler(this.cmbResolution_SelectedIndexChanged);
            // 
            // lblFontSize
            // 
            resources.ApplyResources(this.lblFontSize, "lblFontSize");
            this.lblFontSize.Name = "lblFontSize";
            // 
            // cmbChatFontSize
            // 
            resources.ApplyResources(this.cmbChatFontSize, "cmbChatFontSize");
            this.cmbChatFontSize.FormattingEnabled = true;
            this.cmbChatFontSize.Name = "cmbChatFontSize";
            this.cmbChatFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbChatFontSize_SelectedIndexChanged);
            // 
            // tblOptions
            // 
            resources.ApplyResources(this.tblOptions, "tblOptions");
            this.tblOptions.Controls.Add(this.lblWindowMode, 0, 0);
            this.tblOptions.Controls.Add(this.cmbChatFontSize, 1, 3);
            this.tblOptions.Controls.Add(this.lblDisplayAdapter, 0, 1);
            this.tblOptions.Controls.Add(this.cmbResolution, 1, 2);
            this.tblOptions.Controls.Add(this.lblFontSize, 0, 3);
            this.tblOptions.Controls.Add(this.cmbDisplayAdapter, 1, 1);
            this.tblOptions.Controls.Add(this.lblResolution, 0, 2);
            this.tblOptions.Controls.Add(this.cmbWindowMode, 1, 0);
            this.tblOptions.Name = "tblOptions";
            // 
            // grpClient
            // 
            resources.ApplyResources(this.grpClient, "grpClient");
            this.grpClient.Controls.Add(this.chkJapLocale);
            this.grpClient.Controls.Add(this.tblOptions);
            this.grpClient.Name = "grpClient";
            this.grpClient.TabStop = false;
            // 
            // chkJapLocale
            // 
            resources.ApplyResources(this.chkJapLocale, "chkJapLocale");
            this.chkJapLocale.Name = "chkJapLocale";
            this.chkJapLocale.UseVisualStyleBackColor = true;
            this.chkJapLocale.CheckedChanged += new System.EventHandler(this.chkJapLocale_CheckedChanged);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.tblOptions.ResumeLayout(false);
            this.tblOptions.PerformLayout();
            this.grpClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWindowMode;
        private System.Windows.Forms.ComboBox cmbWindowMode;
        private System.Windows.Forms.Label lblDisplayAdapter;
        private System.Windows.Forms.ComboBox cmbDisplayAdapter;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.ComboBox cmbChatFontSize;
        private System.Windows.Forms.TableLayoutPanel tblOptions;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.CheckBox chkJapLocale;
    }
}


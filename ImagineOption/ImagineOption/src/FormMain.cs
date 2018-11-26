using System;
using System.Windows.Forms;

namespace ImagineOption
{
    public partial class FormMain : Form
    {
        private Business business;

        public FormMain()
        {
            InitializeComponent();

            try
            {
                business = new Business();
                InitUI();
            }
            catch (Exception e)
            {
                onError(e);
                Close();
            }
        }

        private void InitUI()
        {
            var model = business.GetOptionsModel();
            UpdateFullscreen(model);
            UpdateChatFontSize(model);
            UpdateDisplayAdapterOutputAndResolutions();
            chkJapLocale.Checked = model.JapLocale;
        }

        private void UpdateFullscreen(OptionsModel model)
        {
            cmbWindowMode.Items.Add("Windowed");
            cmbWindowMode.Items.Add("Fullscreen");
            cmbWindowMode.SelectedIndex = model.FullScreen ? 1 : 0;
        }

        private void cmbWindowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            business.GetOptionsModel().FullScreen = cmbWindowMode.SelectedIndex == 1;
        }

        private void UpdateChatFontSize(OptionsModel model)
        {
            cmbChatFontSize.Items.Add("Small (12pt)");
            cmbChatFontSize.Items.Add("Medium (14pt)");
            cmbChatFontSize.Items.Add("Large (16pt)");
            cmbChatFontSize.Items.Add("Small (12pt) - No antialiasing");
            cmbChatFontSize.Items.Add("Medium (14pt) - No antialiasing");
            cmbChatFontSize.Items.Add("Large (16pt) - No antialiasing");
            cmbChatFontSize.SelectedIndex = model.ChatFontSizeType;
        }

        private void cmbChatFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            business.GetOptionsModel().ChatFontSizeType = cmbChatFontSize.SelectedIndex;
        }

        private void UpdateDisplayAdapterOutputAndResolutions()
        {
            cmbDisplayAdapter.Items.Clear();
            foreach (var name in business.GetAdapterOutputNames())
            {
                cmbDisplayAdapter.Items.Add(name);
            }
            cmbDisplayAdapter.SelectedIndex = business.GetSelectedAdapterOutputIndex();
        }
        
        private void cmbDisplayAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            business.SelectAdapterOutput(cmbDisplayAdapter.SelectedIndex);
            UpdateResolutions();
        }

        private void UpdateResolutions()
        {
            cmbResolution.Items.Clear();
            foreach (var name in business.GetResolutionNames())
            {
                cmbResolution.Items.Add(name);
            }
            cmbResolution.SelectedIndex = business.GetSeletedResolutionIndex();
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            business.SelectResolution(cmbResolution.SelectedIndex);
        }

        private void chkJapLocale_CheckedChanged(object sender, EventArgs e)
        {
            business.GetOptionsModel().JapLocale = chkJapLocale.Checked;
        }

        private void onError(Exception e)
        {
            //Properties.Resources.ResourceManager.GetString("");
            // TODO: Localize
            MessageBox.Show("Error: " + e.Message, "ImagineOption", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try {
                business.Save();
            } catch (Exception error)
            {
                onError(error);
            }            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

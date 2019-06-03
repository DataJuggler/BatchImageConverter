namespace DataJuggler.Core.Imaging.BatchImageConverter
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ConversionTypeControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.DirectoryControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.ResolutionControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.MoveSourceCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.StatusListView = new System.Windows.Forms.ListView();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MoveSourceInfoLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.OutputOptionControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.ItemsConvertedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConversionTypeControl
            // 
            this.ConversionTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.ConversionTypeControl.ComboBoxLeftMargin = 1;
            this.ConversionTypeControl.ComboBoxText = "";
            this.ConversionTypeControl.ComoboBoxFont = null;
            this.ConversionTypeControl.Editable = true;
            this.ConversionTypeControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConversionTypeControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ConversionTypeControl.HideLabel = false;
            this.ConversionTypeControl.LabelBottomMargin = 0;
            this.ConversionTypeControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ConversionTypeControl.LabelFont = null;
            this.ConversionTypeControl.LabelText = "Type:";
            this.ConversionTypeControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConversionTypeControl.LabelTopMargin = 0;
            this.ConversionTypeControl.LabelWidth = 160;
            this.ConversionTypeControl.List = null;
            this.ConversionTypeControl.Location = new System.Drawing.Point(61, 75);
            this.ConversionTypeControl.Name = "ConversionTypeControl";
            this.ConversionTypeControl.SelectedIndex = -1;
            this.ConversionTypeControl.SelectedIndexListener = null;
            this.ConversionTypeControl.Size = new System.Drawing.Size(360, 28);
            this.ConversionTypeControl.Sorted = true;
            this.ConversionTypeControl.Source = null;
            this.ConversionTypeControl.TabIndex = 0;
            // 
            // DirectoryControl
            // 
            this.DirectoryControl.BackColor = System.Drawing.Color.Transparent;
            this.DirectoryControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            this.DirectoryControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("DirectoryControl.ButtonImage")));
            this.DirectoryControl.ButtonWidth = 48;
            this.DirectoryControl.Filter = null;
            this.DirectoryControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.DirectoryControl.HideBrowseButton = false;
            this.DirectoryControl.Location = new System.Drawing.Point(61, 28);
            this.DirectoryControl.Name = "DirectoryControl";
            this.DirectoryControl.OpenCallback = null;
            this.DirectoryControl.SelectedPath = null;
            this.DirectoryControl.Size = new System.Drawing.Size(927, 32);
            this.DirectoryControl.StartPath = null;
            this.DirectoryControl.TabIndex = 1;
            // 
            // ResolutionControl
            // 
            this.ResolutionControl.BackColor = System.Drawing.Color.Transparent;
            this.ResolutionControl.BottomMargin = 0;
            this.ResolutionControl.Editable = true;
            this.ResolutionControl.Encrypted = false;
            this.ResolutionControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResolutionControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ResolutionControl.LabelBottomMargin = 0;
            this.ResolutionControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ResolutionControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular);
            this.ResolutionControl.LabelText = "Resolution:";
            this.ResolutionControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResolutionControl.LabelTopMargin = 0;
            this.ResolutionControl.LabelWidth = 160;
            this.ResolutionControl.Location = new System.Drawing.Point(61, 119);
            this.ResolutionControl.MultiLine = false;
            this.ResolutionControl.Name = "ResolutionControl";
            this.ResolutionControl.OnTextChangedListener = null;
            this.ResolutionControl.PasswordMode = false;
            this.ResolutionControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ResolutionControl.Size = new System.Drawing.Size(360, 32);
            this.ResolutionControl.TabIndex = 2;
            this.ResolutionControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ResolutionControl.TextBoxBottomMargin = 0;
            this.ResolutionControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ResolutionControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ResolutionControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.ResolutionControl.TextBoxTopMargin = 0;
            // 
            // MoveSourceCheckBox
            // 
            this.MoveSourceCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MoveSourceCheckBox.CheckBoxHorizontalOffSet = 0;
            this.MoveSourceCheckBox.CheckBoxVerticalOffSet = 4;
            this.MoveSourceCheckBox.CheckChangedListener = null;
            this.MoveSourceCheckBox.Checked = false;
            this.MoveSourceCheckBox.Editable = true;
            this.MoveSourceCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveSourceCheckBox.ForeColor = System.Drawing.Color.LemonChiffon;
            this.MoveSourceCheckBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.MoveSourceCheckBox.LabelFont = null;
            this.MoveSourceCheckBox.LabelText = "Move Source:";
            this.MoveSourceCheckBox.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MoveSourceCheckBox.LabelWidth = 160;
            this.MoveSourceCheckBox.Location = new System.Drawing.Point(61, 160);
            this.MoveSourceCheckBox.Name = "MoveSourceCheckBox";
            this.MoveSourceCheckBox.Size = new System.Drawing.Size(280, 28);
            this.MoveSourceCheckBox.TabIndex = 3;
            // 
            // StatusListView
            // 
            this.StatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status});
            this.StatusListView.LargeImageList = this.Images;
            this.StatusListView.Location = new System.Drawing.Point(61, 241);
            this.StatusListView.Name = "StatusListView";
            this.StatusListView.Size = new System.Drawing.Size(927, 312);
            this.StatusListView.SmallImageList = this.Images;
            this.StatusListView.TabIndex = 4;
            this.StatusListView.UseCompatibleStateImageBehavior = false;
            this.StatusListView.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 900;
            // 
            // Images
            // 
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "Failure.png");
            this.Images.Images.SetKeyName(1, "Success.png");
            this.Images.Images.SetKeyName(2, "Warning.png");
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(61, 566);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(927, 23);
            this.Graph.TabIndex = 5;
            this.Graph.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.StatusLabel.Location = new System.Drawing.Point(61, 214);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(379, 24);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status:";
            // 
            // MoveSourceInfoLabel
            // 
            this.MoveSourceInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoveSourceInfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.MoveSourceInfoLabel.Location = new System.Drawing.Point(245, 162);
            this.MoveSourceInfoLabel.Name = "MoveSourceInfoLabel";
            this.MoveSourceInfoLabel.Size = new System.Drawing.Size(719, 24);
            this.MoveSourceInfoLabel.TabIndex = 7;
            this.MoveSourceInfoLabel.Text = "(If checked the source images will be moved to a png or jpg sub folder)\r\n";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.BackgroundImage = global::DataJuggler.Core.Imaging.BatchImageConverter.Properties.Resources.DarkButton;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartButton.Enabled = false;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.DarkGray;
            this.StartButton.Location = new System.Drawing.Point(868, 618);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(120, 40);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            this.StartButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.StartButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // OutputOptionControl
            // 
            this.OutputOptionControl.BackColor = System.Drawing.Color.Transparent;
            this.OutputOptionControl.ComboBoxLeftMargin = 1;
            this.OutputOptionControl.ComboBoxText = "";
            this.OutputOptionControl.ComoboBoxFont = null;
            this.OutputOptionControl.Editable = true;
            this.OutputOptionControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputOptionControl.ForeColor = System.Drawing.Color.LemonChiffon;
            this.OutputOptionControl.HideLabel = false;
            this.OutputOptionControl.LabelBottomMargin = 0;
            this.OutputOptionControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.OutputOptionControl.LabelFont = null;
            this.OutputOptionControl.LabelText = "Output:";
            this.OutputOptionControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutputOptionControl.LabelTopMargin = 0;
            this.OutputOptionControl.LabelWidth = 160;
            this.OutputOptionControl.List = null;
            this.OutputOptionControl.Location = new System.Drawing.Point(436, 75);
            this.OutputOptionControl.Name = "OutputOptionControl";
            this.OutputOptionControl.SelectedIndex = -1;
            this.OutputOptionControl.SelectedIndexListener = null;
            this.OutputOptionControl.Size = new System.Drawing.Size(360, 28);
            this.OutputOptionControl.Sorted = true;
            this.OutputOptionControl.Source = null;
            this.OutputOptionControl.TabIndex = 9;
            // 
            // ItemsConvertedLabel
            // 
            this.ItemsConvertedLabel.BackColor = System.Drawing.Color.Transparent;
            this.ItemsConvertedLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ItemsConvertedLabel.Location = new System.Drawing.Point(57, 592);
            this.ItemsConvertedLabel.Name = "ItemsConvertedLabel";
            this.ItemsConvertedLabel.Size = new System.Drawing.Size(379, 24);
            this.ItemsConvertedLabel.TabIndex = 10;
            this.ItemsConvertedLabel.Text = "Items Converted: 0";
            this.ItemsConvertedLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DataJuggler.Core.Imaging.BatchImageConverter.Properties.Resources.RedTechBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.ItemsConvertedLabel);
            this.Controls.Add(this.OutputOptionControl);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.MoveSourceInfoLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.StatusListView);
            this.Controls.Add(this.MoveSourceCheckBox);
            this.Controls.Add(this.ResolutionControl);
            this.Controls.Add(this.DirectoryControl);
            this.Controls.Add(this.ConversionTypeControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Image Converter";
            this.ResumeLayout(false);

        }

        #endregion

        private Win.Controls.LabelComboBoxControl ConversionTypeControl;
        private Win.Controls.LabelTextBoxBrowserControl DirectoryControl;
        private Win.Controls.LabelTextBoxControl ResolutionControl;
        private Win.Controls.LabelCheckBoxControl MoveSourceCheckBox;
        private System.Windows.Forms.ListView StatusListView;
        private System.Windows.Forms.ProgressBar Graph;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label MoveSourceInfoLabel;
        private System.Windows.Forms.Button StartButton;
        private Win.Controls.LabelComboBoxControl OutputOptionControl;
        private System.Windows.Forms.Label ItemsConvertedLabel;
        private System.Windows.Forms.ImageList Images;
        private System.Windows.Forms.ColumnHeader Status;
    }
}


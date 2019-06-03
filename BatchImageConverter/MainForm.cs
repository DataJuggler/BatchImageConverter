

#region using statements

using DataJuggler.Core.Imaging.BatchImageConverter.Enumerations;
using DataJuggler.Core.Imaging.BatchImageConverter.Objects;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Core.Imaging.BatchImageConverter
{

    #region class MainForm
    /// <summary>
    /// This is the main form of this application
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener, ITextChanged, ICheckChangedListener
    {
        
        #region Private Variables
        private Options options;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // If the sender object exists
                if (NullHelper.Exists(sender, options))
                {
                    // if htis is the MoveSourceCheckBox
                    if (sender.Name == MoveSourceCheckBox.Name)
                    {
                        // Set the value for isChecked
                        Options.MoveSourceImage = isChecked;
                    }
                }
            }
            #endregion

            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            /// <param name="selectedItem"></param>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // If the control object exists
                if ((NullHelper.Exists(control, Options)) && (control.HasSelectedObject))
                {
                    // if this is the ConversionTypeControl
                    if (control.Name == ConversionTypeControl.Name)
                    {
                        // Set the conversionType
                        string conversionType = control.SelectedObject.ToString();

                        // Set the ConversionType on the Options object
                        Options.ConversionType = ParseConversionType(conversionType);
                    }
                    else if (control.Name == OutputOptionControl.Name)
                    {
                        // Set the outputOption
                        string outputOption = control.SelectedObject.ToString();

                        // Set the OutputOption on the Options object
                        Options.OutputOption = ParseOutputOption(outputOption);
                    }
                }

                // Enable or disable controls
                UIControl();
            }
            #endregion

            #region OnTextChanged(Control control  string text);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnTextChanged(Control control, string text)
            {
                // first attempt casting the control as LabelTextBoxControl
                LabelTextBoxControl sender = control as LabelTextBoxControl;

                // if the sender and Options objects both exist                
                if (NullHelper.Exists(sender, Options))
                {
                    // if this is the ResolutionControl                    
                    if (sender.Name == ResolutionControl.Name)
                    {
                        // Set the Resolution
                        Options.Resolution = NumericHelper.ParseInteger(text, 0, -1);
                    }
                }

                // now try LabelTextBoxBrowserControl
                LabelTextBoxBrowserControl sender2 = control as LabelTextBoxBrowserControl;

                // if the sender2 and Options objects both exist                
                if (NullHelper.Exists(sender2, Options))
                {
                    // verify we have the correct control
                    if (sender2.Name == DirectoryControl.Name)
                    {
                        // Set the Directory
                        Options.Directory = text;
                    }
                }

                // Enable or disable the StartButton    
                UIControl();
            }
            #endregion
            
            #region StartButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StartButton' is clicked.
            /// </summary>
            private void StartButton_Click(object sender, EventArgs e)
            {
                // Start the conversion
                Start();
            }
            #endregion
            
        #endregion

        #region Methods

            #region AddResult(string text, bool success, bool showWarning = false, bool showNoIcon = false)
            /// <summary>
            /// This method Adds a Result
            /// </summary>
            public void AddResult(string text, bool success, bool showWarning = false, bool showNoIcon = false)
            {
                // local
                int imageIndex = 0;

                // if showWarning
                if (showWarning)
                {
                    // Change to warning
                    imageIndex = 2;
                }
                // if success
                else if (success)
                {
                    // Change to success
                    imageIndex = 1;
                }

                // if the value for showNoIcon is true
                if (showNoIcon)
                {
                    // do not show an image
                    imageIndex = -1;
                }
                
                // Add this item
                this.StatusListView.Items.Add(text, imageIndex);
           
                // Scroll down to the bottom as new items are added
                this.StatusListView.Items[this.StatusListView.Items.Count - 1].EnsureVisible();
            }
            #endregion

            #region ConvertFile(string file)
            /// <summary>
            /// This method Convert File
            /// </summary>
            public bool ConvertFile(string file)
            {  
                // initial value
                bool converted = false;

                // locals
                Bitmap source = null;
                string outputFile = "";
                string outputFolder = "";
                FileInfo fileInfo = null;

                try
                {
                    // If the file exists and the Options exist
                    if ((TextHelper.Exists(file)) && (File.Exists(file)) && (HasOptions))
                    {
                        // Create a new instance of a 'FileInfo' object.
                        fileInfo = new FileInfo(file);

                        // load the source
                        source = new Bitmap(Bitmap.FromFile(file));

                        // Set the Resolution of the image
                        source.SetResolution(Options.Resolution, Options.Resolution);

                        // if this is a Png to Jpg conversion
                        if (Options.ConversionType == ConversionTypeEnum.Png_To_Jpg)
                        {  
                            // if Convert in place
                            if (Options.OutputOption == OutputOptionEnum.Convert_In_Place)
                            {
                                // get the output file
                                outputFile = Path.Combine(Options.Directory, fileInfo.Name.Replace(".png", ".jpg"));
                            }
                            else if (Options.OutputOption == OutputOptionEnum.Copy_To_Folder)
                            {
                                // get the output folder
                                outputFolder = Path.Combine(Options.Directory, "jpg");

                                // if the outputFolder does not already exist
                                if (!Directory.Exists(outputFolder))
                                {
                                    // Create the sub directory
                                    Directory.CreateDirectory(outputFolder);
                                }

                                // Set the outputFile in the jpg folder
                                outputFile = Path.Combine(outputFolder, fileInfo.Name.Replace(".png", ".jpg"));
                            }
                        
                            // Save the current image
                            source.Save(outputFile, ImageFormat.Jpeg);
                        }
                        // else if this is a Jpg to Png conversion
                        else if (Options.ConversionType == ConversionTypeEnum.Jpg_To_Png)
                        {
                           // if Convert in place
                            if (Options.OutputOption == OutputOptionEnum.Convert_In_Place)
                            {
                                // get the output file
                                outputFile = Path.Combine(Options.Directory, fileInfo.Name.Replace(".jpg", ".png"));          
                            }
                            else if (Options.OutputOption == OutputOptionEnum.Copy_To_Folder)
                            {
                                // get the output folder
                                outputFolder = Path.Combine(Options.Directory, "png");

                                // if the outputFolder does not already exist
                                if (!Directory.Exists(outputFolder))
                                {
                                    // Create the sub directory
                                    Directory.CreateDirectory(outputFolder);
                                }

                                // Set the outputFile in the PNG folder
                                outputFile = Path.Combine(outputFolder, fileInfo.Name.Replace(".jpg", ".png"));
                            }

                            // replace out .jpeg also just in case
                            outputFile = outputFile.Replace(".jpeg", ".png");
                        
                            // Save the current image
                            source.Save(outputFile, ImageFormat.Png);
                        }
                    }

                    // if the outputFile exists
                    if ((TextHelper.Exists(outputFile)) && (File.Exists(outputFile)))
                    {
                        // it worked
                        converted = true;

                        // Add this result
                        AddResult("The file " + fileInfo.Name + " was converted successfully", true);
                    }
                    else
                    {
                        // Add this result
                        AddResult("The file " + fileInfo.Name + " was not converted; reason unknown", false);
                    }
                }
                catch (Exception error)
                {
                    // Add this result
                    AddResult("An error occurred converting " + file, false);

                    // Write to the output window
                    DebugHelper.WriteDebugError("ConvertFile", "MainForm", error);
                }

                // return value
                return converted;
            }
            #endregion
            
            #region GetFiles()
            /// <summary>
            /// This method returns a list of Files
            /// </summary>
            public List<string> GetFiles()
            {
                // initial value
                List<string> files = new List<string>();

                // if the Options exists and the Options are valid
                if ((HasOptions) && (Options.IsValid()))
                {
                    // if the conversion type is Jpg to Png
                    if (Options.ConversionType == ConversionTypeEnum.Jpg_To_Png)
                    {
                        // load the Jpg's
                        files = FileHelper.GetFiles(Options.Directory, ".jpg");

                        // load the Jpg's
                        List<string> files2 = FileHelper.GetFiles(Options.Directory, ".jpeg");

                        // if there are one or more files2
                        if (ListHelper.HasOneOrMoreItems(files2))
                        {
                            // If the files collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(files))
                            {
                                // iteratre the string files
                                foreach (string file in files2)
                                {
                                    // Add this file
                                    files.Add(file);
                                }
                            }
                            else
                            {
                                // set the return value
                                files = files2;
                            }
                        }
                    }
                    else
                    {
                        // load the Jpeg's
                        files = FileHelper.GetFiles(Options.Directory, ".png");
                    }
                }
                
                // return value
                return files;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new instance of an 'Options' object.
                Options = new Options();

                // Setup the Directory control
                DirectoryControl.LabelText = "Directory:";
                DirectoryControl.LabelFont = new Font("Verdana", 12);
                DirectoryControl.LabelColor = Color.LemonChiffon;
                DirectoryControl.OnTextChangedListener = this;

                // Setup the ConversionTypeControl
                ConversionTypeControl.LoadItems(typeof(ConversionTypeEnum));
                ConversionTypeControl.Items.RemoveAt(2);
                ConversionTypeControl.SelectedIndex = 1;
                ConversionTypeControl.SelectedIndexListener = this;
                Options.ConversionType = ConversionTypeEnum.Png_To_Jpg;

                // Setup the ResolutionControl
                ResolutionControl.OnTextChangedListener = this;
                ResolutionControl.Text = "300";
                Options.Resolution = 300;

                // Setup the OutputOptionControl
                OutputOptionControl.LoadItems(typeof(OutputOptionEnum));
                OutputOptionControl.Items.RemoveAt(2);
                OutputOptionControl.SelectedIndex = 1;
                Options.OutputOption = OutputOptionEnum.Copy_To_Folder;
                OutputOptionControl.SelectedIndexListener = this;

                // Setup the MoveSourceCheckBox
                MoveSourceCheckBox.CheckChangedListener = this;
            }
            #endregion
            
            #region ParseConversionType(rawConversionType)
            /// <summary>
            /// This method returns the Conversion Type
            /// </summary>
            public ConversionTypeEnum ParseConversionType(string rawConversionType)
            {
                // initial value
                ConversionTypeEnum conversionType = ConversionTypeEnum.Unknown;

                // If the rawConversionType string exists
                if (TextHelper.Exists(rawConversionType))
                {
                    // Determine the action by the conversionType
                    switch (rawConversionType)
                    {
                        case "Png_To_Jpg":
                        case "Png To Jpg":

                            // set the return value
                            conversionType = ConversionTypeEnum.Png_To_Jpg;

                            // required
                            break;

                        case "Jpg_To_Png":
                        case "Jpg To Png":

                            // set the return value
                            conversionType = ConversionTypeEnum.Jpg_To_Png;

                            // required
                            break;
                    }
                }
                
                // return value
                return conversionType;
            }
            #endregion

            #region ParseOutputOption(string rawOutputOption)
            /// <summary>
            /// This method returns the Output Option
            /// </summary>
            public OutputOptionEnum ParseOutputOption(string rawOutputOption)
            {
                // initial value
                OutputOptionEnum outputOption = OutputOptionEnum.Unknown;

                // If the rawOutputOption string exists
                if (TextHelper.Exists(rawOutputOption))
                {
                    // Determine the action by the rawOutputOption
                    switch (rawOutputOption)
                    {
                        case "Convert_In_Place":
                        case "Convert In Place":

                            // set the return value
                            outputOption = OutputOptionEnum.Convert_In_Place;
                         
                            // required
                            break;

                        case "Copy_To_Folder":
                        case "Copy To Folder":

                             // set the return value
                            outputOption = OutputOptionEnum.Copy_To_Folder;

                            // required
                            break;
                    }
                }
                
                // return value
                return outputOption;
            }
            #endregion
            
            #region ProcessFiles(List<string> files)
            /// <summary>
            /// This method Process Files
            /// </summary>
            public void ProcessFiles(List<string> files)
            {
                // locals
                int count = 0;
                int totalCount = 0;
                bool converted = false;

                // If the files collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(files))
                {
                    // Set the ItemsConverted label
                    ItemsConvertedLabel.Text = count.ToString() + " of " + files.Count;
                    ItemsConvertedLabel.Visible = true;

                    // Iterate the collection of string objects
                    foreach (string file in files)
                    {
                        // update this every time so the graph is accurate
                        totalCount++;

                        // Convert this file
                        converted = ConvertFile(file);

                        // if the value for converted is true
                        if (converted)
                        {
                            // Increment the value for count
                            count++;

                            // Set the ItemsConverted label
                            ItemsConvertedLabel.Text = "Items Converted: " + count.ToString() + " of " + files.Count;
                        }

                        // Set the graphs value
                        Graph.Value = totalCount;

                        // Refresh everything
                        Refresh();
                        Application.DoEvents();
                    }
                }
            }
            #endregion
            
            #region SetupGraph(int maximum)
            /// <summary>
            /// This method Setup Graph
            /// </summary>
            public void SetupGraph(int maximum)
            {
                // Show the graph
                Graph.Maximum = maximum;
                Graph.Value = 0;
                Graph.Visible = true;
            }
            #endregion
            
            #region Start()
            /// <summary>
            /// This method Start
            /// </summary>
            public void Start()
            {
                // Clear the list
                StatusListView.Items.Clear();

                // Disable the start button
                StartButton.Enabled = false;
                StartButton.ForeColor = Color.DarkGray;
                StartButton.BackgroundImage = Properties.Resources.DarkButton;

                // Refresh everything before starting
                Refresh();
                Application.DoEvents();

                // get the files
                List<string> files = null;

                // if the Options exists and the Options are valid
                if ((HasOptions) && (Options.IsValid()))
                {
                    // Get the files
                    files = GetFiles();

                    // If the files collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(files))
                    {
                        // Starting conversion
                        AddResult("Starting conversion, found " + files.Count + " files.", true);

                        // Setup the Graph
                        SetupGraph(files.Count);

                        // Reset the ItemsConvertedLabel
                        ItemsConvertedLabel.Text = "Items Converted: 0";

                        // Process the files
                        ProcessFiles(files);

                        // Show the final conversion message
                        AddResult("Conversion complete.", true);
                    }
                    else
                    {
                        // Starting conversion
                        AddResult("No files were found in the directory listed matching your criteria." + files.Count + " files.", true);
                    }
                }

                // Disable the start button
                StartButton.Enabled = true;
                StartButton.ForeColor = Color.LemonChiffon;
                StartButton.BackgroundImage = Properties.Resources.DarkBlueButton;

                  // Refresh everything before starting
                Refresh();
                Application.DoEvents();
            }
            #endregion
            
            #region UIControl()
            /// <summary>
            /// This method is used to enable or disable the start button based upon if have valid Options
            /// </summary>
            public void UIControl()
            {
                // if the Options exist and are valid
                if ((HasOptions) && (Options.IsValid()))
                {
                    // Enable this button
                    StartButton.Enabled = true;
                    StartButton.BackgroundImage = Properties.Resources.DarkBlueButton;
                    StartButton.ForeColor = Color.LemonChiffon;
                }
                else
                {
                    // Enable this button
                    StartButton.Enabled = false;
                    StartButton.BackgroundImage = Properties.Resources.DarkButton;
                    StartButton.ForeColor = Color.DarkGray;
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasOptions
            /// <summary>
            /// This property returns true if this object has an 'Options'.
            /// </summary>
            public bool HasOptions
            {
                get
                {
                    // initial value
                    bool hasOptions = (this.Options != null);
                    
                    // return value
                    return hasOptions;
                }
            }
            #endregion
            
            #region Options
            /// <summary>
            /// This property gets or sets the value for 'Options'.
            /// </summary>
            public Options Options
            {
                get { return options; }
                set { options = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}

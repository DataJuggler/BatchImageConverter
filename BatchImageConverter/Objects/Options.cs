

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Core.Imaging.BatchImageConverter.Enumerations;

#endregion

namespace DataJuggler.Core.Imaging.BatchImageConverter.Objects
{

    #region class Options
    /// <summary>
    /// This class contains the options for how a conversion job operates
    /// </summary>
    public class Options
    {

        #region Private Variables
        private string directory;
        private ConversionTypeEnum conversionType;
        private int resolution;
        private bool moveSourceImage;
        private OutputOptionEnum outputOption;
        #endregion

        #region Methods

            #region IsValid()
            /// <summary>
            /// This method returns the Valid
            /// </summary>
            public bool IsValid()
            {
                // initial value
                bool isValid = false;

                // if the value for HasDirectory is true
                if ((HasDirectory) && (HasResolution) && (HasConversionType))
                {
                    // if the Directory exists
                    if (System.IO.Directory.Exists(Directory))
                    {
                        // set to true
                        isValid = true;
                    }
                }
                
                // return value
                return isValid;
            }
            #endregion

        #endregion

        #region Properties
        
            #region ConversionType
            /// <summary>
            /// This property gets or sets the value for 'ConversionType'.
            /// </summary>
            public ConversionTypeEnum ConversionType
            {
                get { return conversionType; }
                set { conversionType = value; }
            }
            #endregion
            
            #region Directory
            /// <summary>
            /// This property gets or sets the value for 'Directory'.
            /// </summary>
            public string Directory
            {
                get { return directory; }
                set { directory = value; }
            }
            #endregion
            
            #region HasConversionType
            /// <summary>
            /// This property returns true if this object has a 'ConversionType'.
            /// </summary>
            public bool HasConversionType
            {
                get
                {
                    // initial value
                    bool hasConversionType = (this.ConversionType != ConversionTypeEnum.Unknown);
                    
                    // return value
                    return hasConversionType;
                }
            }
            #endregion
            
            #region HasDirectory
            /// <summary>
            /// This property returns true if the 'Directory' exists.
            /// </summary>
            public bool HasDirectory
            {
                get
                {
                    // initial value
                    bool hasDirectory = (!String.IsNullOrEmpty(this.Directory));
                    
                    // return value
                    return hasDirectory;
                }
            }
            #endregion
            
            #region HasOutputOption
            /// <summary>
            /// This property returns true if this object has an 'OutputOption'.
            /// </summary>
            public bool HasOutputOption
            {
                get
                {
                    // initial value
                    bool hasOutputOption = (this.OutputOption != OutputOptionEnum.Unknown);
                    
                    // return value
                    return hasOutputOption;
                }
            }
            #endregion
            
            #region HasResolution
            /// <summary>
            /// This property returns true if the 'Resolution' is set.
            /// </summary>
            public bool HasResolution
            {
                get
                {
                    // initial value
                    bool hasResolution = (this.Resolution > 0);
                    
                    // return value
                    return hasResolution;
                }
            }
            #endregion
            
            #region MoveSourceImage
            /// <summary>
            /// This property gets or sets the value for 'MoveSourceImage'.
            /// </summary>
            public bool MoveSourceImage
            {
                get { return moveSourceImage; }
                set { moveSourceImage = value; }
            }
            #endregion
            
            #region OutputOption
            /// <summary>
            /// This property gets or sets the value for 'OutputOption'.
            /// </summary>
            public OutputOptionEnum OutputOption
            {
                get { return outputOption; }
                set { outputOption = value; }
            }
            #endregion
            
            #region Resolution
            /// <summary>
            /// This property gets or sets the value for 'Resolution'.
            /// </summary>
            public int Resolution
            {
                get { return resolution; }
                set { resolution = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

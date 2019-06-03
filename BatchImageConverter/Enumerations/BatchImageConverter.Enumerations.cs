#region using statements


#endregion

namespace DataJuggler.Core.Imaging.BatchImageConverter.Enumerations
{

    #region enum ConversionTypeEnum
    /// <summary>
    /// This enumerations specifies the conversion type Png to  or Jpg to Png
    /// </summary>
    public enum ConversionTypeEnum : int
    {
        Unknown = 0,
		Png_To_Jpg = 1,
		Jpg_To_Png = 2
	}
	#endregion

    #region enum OutputOptionEnum
    /// <summary>
    /// This enumerations specifies the conversion type Png to Jpg or Jpg to Png
    /// </summary>
    public enum OutputOptionEnum : int
    {
        Unknown = 0,
		Convert_In_Place = 1,
		Copy_To_Folder = 2
	}
	#endregion

}

namespace com.xcitestudios.Logging.Interfaces
{
    using global::com.xcitestudios.Generic.Data.Manipulation.Interfaces;

    /// <summary>
    /// A message to be logged and is serializable
    /// </summary>
    public interface ILogMessageSerializable : ILogMessage, ISerialization
    {
    }
}

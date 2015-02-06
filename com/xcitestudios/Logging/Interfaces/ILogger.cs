namespace com.xcitestudios.Logging.Interfaces
{
    /// <summary>
    /// Interface for a provider who can handle LogMessage's.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handle the provided log message however it needs to be handled.
        /// </summary>
        /// <param name="message">Message to handle</param>
        void Log(ILogMessage message);
    }
}

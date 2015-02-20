namespace com.xcitestudios.Logging.Interfaces
{
    using global::com.xcitestudios.Generic.Data.Manipulation.Interfaces;
    using System;

    /// <summary>
    /// A message to be logged.
    /// </summary>
    public interface ILogMessage: ISerialization
    {
        /// <summary>
        /// Set the severity of this log message. See <see cref="global::com.xcitestudios.Logging.LogSeverity"/>.
        /// </summary>
        LogSeverity Severity { get; set; }

        /// <summary>
        /// The datetime this log event occured (ISO8601 combined date/time format (including timezone) for storage).
        /// </summary>
        DateTime DateTime { get; set; }

        /// <summary>
        /// The identifier of the machine the log came from (IP, DNS name etc, any unique identifier).
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// Application that raised the log.
        /// </summary>
        string Application { get; set; }

        /// <summary>
        /// Optional module in the application that raised the log.
        /// </summary>
        string Module { get; set; }

        /// <summary>
        /// Message for the log but use printf standard for arguments where requirement <see cref="MessageArgs"/>.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Arguments to format into Message.
        /// </summary>
        object[] MessageArgs { get; set; }

        /// <summary>
        /// Gets Message using MessageArgs and printf.
        /// </summary>
        string FormattedMessage { get; }

        /// <summary>
        /// Any extra data to store alongside the log entry.
        /// </summary>
        string Extra { get; set; }
    }
}

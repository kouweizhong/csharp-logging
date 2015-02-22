namespace com.xcitestudios.Logging
{
    using global::com.xcitestudios.Generic.Data.Manipulation;
    using global::com.xcitestudios.Logging.Interfaces;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LogMessage : JsonSerializationHelper, ILogMessage
    {
        /// <summary>
        /// Set the severity of this log message. See <see cref="global::com.xcitestudios.Logging.LogSeverity"/>.
        /// </summary>
        public LogSeverity Severity { get; set; }

        /// <summary>
        /// This just exists for ease of JSON serialization of <see cref="Severity"/>.
        /// </summary>
        [DataMember(Name = "severity")]
        private string _Severity
        {
            get
            {
                return Severity.ToString();
            }
            set
            {
                LogSeverity sev;
                if (!Enum.TryParse<LogSeverity>(value, out sev))
                {
                    throw new InvalidCastException(String.Format("Could not parse %s to a valid %s", value, typeof(LogSeverity).ToString()));
                }
                Severity = sev;
            }
        }

        /// <summary>
        /// The datetime this log event occured (ISO8601 combined date/time format (including timezone) for storage).
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// This just exists for ease of JSON serialization of <see cref="DateTime"/>.
        /// </summary>
        [DataMember(Name="datetime")]
        private string _DateTime
        { 
            get
            {
                return DateTime.ToString(@"yyyy-MM-ddTHH\:mm\:sszzz");
            }
            set
            {
                DateTime = DateTime.Parse(value, null, DateTimeStyles.RoundtripKind);
            }
        }

        /// <summary>
        /// The identifier of the machine the log came from (IP, DNS name etc, any unique identifier).
        /// </summary>
        [DataMember(Name = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Application that raised the log.
        /// </summary>
        [DataMember(Name = "application")]
        public string Application { get; set; }

        /// <summary>
        /// Optional module in the application that raised the log.
        /// </summary>
        [DataMember(Name = "module")]
        public string Module { get; set; }

        /// <summary>
        /// Message for the log but use printf standard for arguments where requirement <see cref="MessageArgs"/>.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Arguments to format into Message.
        /// </summary>
        [DataMember(Name = "messageArgs")]
        public object[] MessageArgs { get; set; }

        /// <summary>
        /// Any extra data to store alongside the log entry.
        /// </summary>
        [DataMember(Name = "extra")]
        public string Extra { get; set; }

        /// <summary>
        /// Gets Message using MessageArgs and printf.
        /// </summary>
        public string FormattedMessage
        {
            get
            {
                return AT.MIN.Tools.sprintf(Message, MessageArgs);
            }
        }

        /// <summary>
        /// Updates the element implementing this interface using a JSON representation. 
        /// This means updating the state of this object with that defined in the JSON 
        /// as opposed to returning a new instance of this object.
        /// </summary>
        /// <param name="jsonString">Representation of the object</param>
        public void DeserializeJSON(string jsonString)
        {
            var obj = Deserialize<LogMessage>(jsonString);

            Severity = obj.Severity;
            DateTime = obj.DateTime;
            Source = obj.Source;
            Application = obj.Application;
            Module = obj.Module;
            Message = obj.Message;
            MessageArgs = obj.MessageArgs;
            Extra = obj.Extra;
        }

        /// <summary>
        /// Convert this object into JSON so it can be handled by anything that supports JSON.
        /// </summary>
        /// <returns>A JSON representation of this object</returns>
        public string SerializeJSON()
        {
            return Serialize<LogMessage>();
        }
    }
}

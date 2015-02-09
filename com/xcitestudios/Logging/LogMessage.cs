namespace com.xcitestudios.Logging
{
    using com.xcitestudios.Logging.Interfaces;
    using System;

    class LogMessage : ILogMessage
    {
        public LogSeverity Severity { get; set; }

        public DateTime DateTime { get; set; }

        public string Source { get; set; }

        public string Application { get; set; }

        public string Module { get; set; }

        public string Message { get; set; }

        public object[] MessageArgs { get; set; }

        public string FormattedMessage
        {
            get {
                return AT.MIN.Tools.sprintf(Message, MessageArgs);
            }
        }

        public string Extra { get; set; }

        public void Deserialize(string jsonString)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}

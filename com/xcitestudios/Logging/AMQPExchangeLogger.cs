namespace com.xcitestudios.Logging
{
    using com.xcitestudios.Logging.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Helper for AMPQ message loggers.
    /// </summary>
    public abstract class AMQPExchangeLogger
    {
        /// <summary>
        /// Generate an exchange key from the ILogMessage.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>dot seperated string</returns>
        protected string GenerateKey(ILogMessage message)
        {
            List<string> parts = new List<string>();

            parts.Add(message.Source);
            parts.Add(message.Application);

            if (message.Module != null)
            {
                parts.Add(message.Module);
            }

            parts.Add(message.Severity.ToString());

            return string.Join(".", parts.ToArray());
        }

        /// <summary>
        /// Convert the message to JSON.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected string GetMessageJSON(ILogMessage message)
        {
            return (message as ILogMessageSerializable).SerializeJSON();
        }
    }
}

namespace com.xcitestudios.Logging
{
    using com.xcitestudios.Logging.Interfaces;
    using RabbitMQ.Client;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class RabbitMQMessageLogger : AMQPExchangeLogger, ILogger
    {
        /// <summary>
        /// Channel to push using.
        /// </summary>
        protected IModel Channel { get; set; }

        /// <summary>
        /// Exchange to push to.
        /// </summary>
        protected string ExchangeName { get; set; }

        /// <summary>
        /// Create a new RabbitMQMessageLogger.
        /// </summary>
        /// <param name="channel">Channel connection</param>
        /// <param name="exchangeName">Exchange to work on</param>
        public RabbitMQMessageLogger(IModel channel, string exchangeName)
        {
            Channel = channel;
            ExchangeName = exchangeName;
        }

        /// <summary>
        /// Log the message to RabbitAMQP
        /// </summary>
        /// <param name="message">Message to Log</param>
        public void Log(Interfaces.ILogMessage message)
        {
            var bytes = Encoding.UTF8.GetBytes(this.GetMessageJSON(message));

            var properties = Channel.CreateBasicProperties();
            properties.Headers = (IDictionary<string, object>)new Dictionary<string, object>();
            properties.Headers.Add("content-type", "application/json");

            Channel.BasicPublish(ExchangeName, GenerateKey(message), properties, bytes);
        }
    }
}

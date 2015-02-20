namespace tests.com.xcitestudios.Logging
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using global::com.xcitestudios.Logging;
    using Newtonsoft.Json.Schema;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Net;
        
    [TestClass]
    public class LogMessageTest
    {
        [TestMethod]
        public void TestSerializationAdherance()
        {
            var logMessage = new LogMessage();
            logMessage.Message = "Test message %s for %d";
            logMessage.MessageArgs = new object[2] { "abc", 123 };
            logMessage.Source = "localhost";
            logMessage.Application = "testapp";
            logMessage.Module = "tests";
            logMessage.DateTime = DateTime.Now;
            logMessage.Severity = LogSeverity.error;

            var json = logMessage.Serialize();

            string textSchema;

            using(var client = new WebClient())
            {
                textSchema = client.DownloadString("https://cdn.rawgit.com/xcitestudios/json-schemas/cdn-tag-1/com/xcitestudios/schemas/Logging/LogMessage.json");
            }

            var schema = JSchema.Parse(textSchema);

            var jsonObject = JObject.Parse(json);

            IList<string> errorMessages = new List<string>();
            var isValid = jsonObject.IsValid(schema, out errorMessages);

            string errorMessage = "";

            if (!isValid)
            {
                for (var i = 0; i < errorMessages.Count; i++)
                {
                    errorMessage += errorMessages[i] + "\n";
                }
            }

            Assert.IsTrue(isValid, errorMessage);
        }

        [TestMethod]
        public void TestSerializationConsistency()
        {
            var logMessage = new LogMessage();
            logMessage.Message = "Test message %s for %d";
            logMessage.MessageArgs = new object[2] { "abc", 123 };
            logMessage.Source = "localhost";
            logMessage.Application = "testapp";
            logMessage.Module = "tests";
            logMessage.DateTime = DateTime.Now;
            logMessage.Severity = LogSeverity.error;

            var json = logMessage.Serialize();

            var newMessage = new LogMessage();
            newMessage.Deserialize(json);

            Assert.AreEqual(logMessage.Message, newMessage.Message);
            CollectionAssert.AreEquivalent(logMessage.MessageArgs, newMessage.MessageArgs);
            Assert.AreEqual(logMessage.Source, newMessage.Source);
            Assert.AreEqual(logMessage.Application, newMessage.Application);
            Assert.AreEqual(logMessage.Module, newMessage.Module);
            Assert.AreEqual(logMessage.DateTime.ToString(), newMessage.DateTime.ToString());
            Assert.AreEqual(logMessage.Severity, newMessage.Severity);
        }

        [TestMethod]
        public void TestFormattedMessage()
        {
            var logMessage = new LogMessage();
            logMessage.Message = "Test message %s for %d";
            logMessage.MessageArgs = new object[2] { "abc", 123 };
            logMessage.Source = "localhost";
            logMessage.Application = "testapp";
            logMessage.Module = "tests";
            logMessage.DateTime = DateTime.Now;
            logMessage.Severity = LogSeverity.error;

            Assert.AreEqual("Test message abc for 123", logMessage.FormattedMessage);
        }
    }
}

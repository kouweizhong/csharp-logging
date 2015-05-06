namespace com.xcitestudios.Logging
{
    using System;

    /// <summary>
    /// Log severities based on syslog.
    /// </summary>
    [Serializable]
    public enum LogSeverity
    {
        /// <summary>
        /// A "panic" condition usually affecting multiple apps/servers/sites. At this level it would usually 
        /// notify all tech staff on call.
        /// </summary>
        emergency = 0,

        /// <summary>
        /// Should be corrected immediately, therefore notify staff who can fix the problem. An example would be 
        /// the loss of a primary ISP connection.
        /// </summary>
        alert = 1,

        /// <summary>
        /// Should be corrected immediately, but indicates failure in a secondary system, an example is a loss 
        /// of a backup ISP connection.
        /// </summary>
        critical = 2,

        /// <summary>
        /// Non-urgent failures, these should be relayed to developers or admins; each item must be resolved 
        /// within a given time.
        /// </summary>
        error = 3,

        /// <summary>
        /// Warning messages, not an error, but indication that an error will occur if action is not taken, 
        /// e.g. file system 85% full - each item must be resolved within a given time.
        /// </summary>
        warning = 4,

        /// <summary>
        /// Events that are unusual but not error conditions - might be summarized in an email to developers 
        /// or admins to spot potential problems - no immediate action required.
        /// </summary>
        notice = 5,

        /// <summary>
        /// Normal operational messages - may be harvested for reporting, measuring throughput, etc. - no action required.
        /// </summary>
        informational = 6,

        /// <summary>
        /// Info useful to developers for debugging the application, not useful during operations.
        /// </summary>
        debug = 7
    }
}

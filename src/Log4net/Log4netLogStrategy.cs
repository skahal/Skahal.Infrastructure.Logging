using log4net;
using log4net.Config;
using Skahal.Infrastructure.Framework.Logging;

namespace Skahal.Infrastructure.Logging.Log4net
{
    /// <summary>
    /// An ILogStrategy's implementation using Log4net.
    /// </summary>
    public class Log4netLogStrategy : LogStrategyBase
    {
        #region Fields
        private readonly ILog m_logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="Log4netLogStrategy"/> class.
        /// </summary>
        static Log4netLogStrategy()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4netLogStrategy"/> class.
        /// </summary>
        /// <param name="loggerName">The name of the logger.</param>
        public Log4netLogStrategy(string loggerName = "Log4netLogStrategy")
        {
            m_logger = LogManager.GetLogger(loggerName);
        }
        #endregion

        #region implemented abstract members of LogStrategyBase
        /// <summary>
        /// Writes the debug log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteDebug(string message, params object[] args)
        {
            m_logger.DebugFormat(message, args);
            OnDebugWritten(new LogWrittenEventArgs(message, args));
        }

        /// <summary>
        /// Writes the warning log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteWarning(string message, params object[] args)
        {
            m_logger.WarnFormat(message, args);
            OnWarningWritten(new LogWrittenEventArgs(message, args));
        }

        /// <summary>
        /// Writes the error log level message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The message arguments.</param>
        public override void WriteError(string message, params object[] args)
        {
            m_logger.ErrorFormat(message, args);
            OnErrorWritten(new LogWrittenEventArgs(message, args));
        }

        #endregion
    }
}

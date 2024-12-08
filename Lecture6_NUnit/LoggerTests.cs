using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6_NUnit
{
    public interface ILogerWriter
    {
        void Writer(string message);
    }

    public class Logger
    {
        private readonly ILogerWriter _logerWriter;

        public Logger(ILogerWriter logerWriter)
        {
            _logerWriter = logerWriter;
        }

        public void LogMessage(string message)
        {
            _logerWriter.Writer(message);
        }
    }
    public class LoggerTests
    {
        [Test]
        public void Test()
        {
            Mock<ILogerWriter> mock = new Mock<ILogerWriter>();

            Logger logger  = new Logger(mock.Object);

            string captureMessage = null;

            mock.Setup(x => x.Writer(It.IsAny<string>())).Callback<string>(x => captureMessage = x);

            string expected = "TEST";

            logger.LogMessage(expected);

            

        }
    }
}

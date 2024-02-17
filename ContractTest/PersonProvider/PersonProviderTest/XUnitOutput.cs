
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;

namespace PersonProviderTest
{
    public class XUnitOutput : IOutput
    {
        private readonly ITestOutputHelper _outputHelper;
        public XUnitOutput(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }
        //public void Write(string? message, OutputLevel level)
        //{
        //    _outputHelper.WriteLine(message);
        //}

        //public void WriteLine(string? message, OutputLevel level)
        //{
        //    _outputHelper.WriteLine(message);
        //}

        public void WriteLine(string line)
        {
            _outputHelper.WriteLine(line);
        }
        //public void WriteLine(string line)
        //{
        //    _outputHelper.WriteLine(line);
        //}
    }
}
using System.Text;
using Xunit.Abstractions;


namespace AoCUtils
{
    public class Converter : TextWriter
    {
        readonly ITestOutputHelper _output;
        public Converter(ITestOutputHelper output)
        {
            _output = output;
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void WriteLine(string? value)
        {
            _output.WriteLine(value);
        }
        public override void WriteLine(string format, params object?[] arg)
        {
            _output.WriteLine(format, arg);
        }
    }
}

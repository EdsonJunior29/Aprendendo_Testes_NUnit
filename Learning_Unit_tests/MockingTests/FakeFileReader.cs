using TestesUnitários.Mocking;

namespace Learning_Unit_tests.MockingTests
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}

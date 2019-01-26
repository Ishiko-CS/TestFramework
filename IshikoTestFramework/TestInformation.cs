namespace Ishiko
{
    namespace TestFramework
    {
        public class TestInformation
        {
            public TestInformation(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }
        }
    }
}

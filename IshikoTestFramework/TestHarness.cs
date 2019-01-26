using System;

namespace Ishiko
{
    namespace TestFramework
    {
        public class TestHarness
        {
            public TestHarness(string title)
            {
                m_topSequence = new TopTestSequence(title);
            }

            public int Run()
            {
                Console.WriteLine("Test Suite: " + m_topSequence.Name());

                // Run the tests
                int result = RunTests();

                return (int)ETestApplicationReturnCodes.eConfigurationProblem;
            }

            public TestSequence AppendTestSequence(string name)
            {
                return new TestSequence(name, m_topSequence);
            }

            private int RunTests()
            {
                return (int)ETestApplicationReturnCodes.eConfigurationProblem;
            }

            private TopTestSequence m_topSequence;
        }
    }
}

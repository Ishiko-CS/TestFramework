using System;

namespace Ishiko
{
    namespace TestFramework
    {
        public class TestHarness
        {
            public TestHarness(string title)
            {
            }

            public int run()
            {
                Console.WriteLine("Test Suite: " + m_topSequence.name());

                // Run the tests
                int result = runTests();

                return (int)ETestApplicationReturnCodes.eConfigurationProblem;
            }

            private int runTests()
            {
                return (int)ETestApplicationReturnCodes.eConfigurationProblem;
            }

            private TopTestSequence m_topSequence = new TopTestSequence();
        }
    }
}

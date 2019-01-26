using System.Collections.Generic;

namespace Ishiko
{
    namespace TestFramework
    {
        public class TestSequence : Test
        {
            public TestSequence(string name)
                : base(name)
            {
            }

            public TestSequence(string name, TestSequence parentSequence)
                : base(name)
            {
                parentSequence.Append(this);
            }

            public void Append(Test test)
            {
                m_tests.Add(test);
            }

            protected override TestResult.EOutcome DoRun(TestObserver observer)
            {
                // By default the outcome is unknown
                TestResult.EOutcome result = TestResult.EOutcome.eUnknown;

                foreach (Test test in m_tests)
                {
                    test.Run(observer);
                }

                return result;
            }

            private List<Test> m_tests = new List<Test>();
        }
    }
}

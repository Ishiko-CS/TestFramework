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
                parentSequence.append(this);
            }

            public void append(Test test)
            {
                m_tests.Add(test);
            }

            private List<Test> m_tests = new List<Test>();
        }
    }
}

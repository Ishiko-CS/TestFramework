/*
    Copyright (c) 2019 Xavier Leclercq

    Permission is hereby granted, free of charge, to any person obtaining a
    copy of this software and associated documentation files (the "Software"),
    to deal in the Software without restriction, including without limitation
    the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
    IN THE SOFTWARE.
*/

using System.Collections.Generic;

namespace Ishiko
{
    namespace TestFramework
    {
        public class TestSequence : Test
        {
            public TestSequence(TestNumber number, string name)
                : base(number, name)
            {
            }

            public TestSequence(string name, TestSequence parentSequence)
                : base(new TestNumber(), name)
            {
                parentSequence.Append(this);
            }

            public void Append(Test test)
            {
                // We need to update the number of the test
                if (m_tests.Count == 0)
                {
                    TestNumber newNumber = new TestNumber();
                    test.Information.Number = newNumber.DeeperNumber();
                }
                else
                {
                    TestNumber newNumber = m_tests[m_tests.Count - 1].Number();
                    test.Information.Number = newNumber.Increment();
                }

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

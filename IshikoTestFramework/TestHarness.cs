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
                try
                {
                    TestProgressObserver progressObserver = new TestProgressObserver();
                    m_topSequence.Run(progressObserver);

                    return (int)ETestApplicationReturnCodes.eOk;
                }
                catch
                {
                    return (int)ETestApplicationReturnCodes.eException;
                }
            }

            private TopTestSequence m_topSequence;
        }
    }
}

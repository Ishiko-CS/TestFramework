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

namespace Ishiko
{
    namespace TestFramework
    {
        public abstract class Test
        {
            public Test(TestNumber number, string name)
            {
                Information = new TestInformation(number, name);
                Result = new TestResult();
            }

            public TestNumber Number()
            {
                return Information.Number;
            }

            public string Name()
            {
                return Information.Name;
            }

            public void Run()
            {
                TestObserver observer = new TestObserver();
                Run(observer);
            }

            public void Run(TestObserver observer)
            {
                Notify(TestObserver.EEventType.eTestStart, observer);

                TestResult.EOutcome outcome = TestResult.EOutcome.eFailed;
                try
                {
                    outcome = DoRun(observer);
                }
                catch
                {
                    outcome = TestResult.EOutcome.eException;
                }

                Result.Outcome = outcome;

                Notify(TestObserver.EEventType.eTestEnd, observer);
            }

            protected abstract TestResult.EOutcome DoRun(TestObserver observer);

            protected virtual void Notify(TestObserver.EEventType type, TestObserver observer)
            {
                observer.Notify(type, this);
            }

            public TestInformation Information { get; private set; }
            public TestResult Result { get; private set; }
    }
    }
}

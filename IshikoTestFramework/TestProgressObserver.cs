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
        public class TestProgressObserver : TestObserver
        {
            public override void Notify(EEventType type, Test test)
            {
                switch (type)
                {
                    case EEventType.eTestStart:
                        Console.WriteLine(m_nesting + FormatNumber(test.Number()) + " " + test.Name() + " started");
                        m_nesting += "\t";
                        break;

                    case EEventType.eTestEnd:
                        if (m_nesting.Length != 0)
                        {
                            m_nesting = m_nesting.Remove(m_nesting.Length - 1);
                        }

                        Console.WriteLine(m_nesting + FormatNumber(test.Number()) + " " + test.Name() +
                            " completed, result is " + FormatResult(test.Result));
                        break;
                }
            }

            private static string FormatNumber(TestNumber number)
            {
                string formattedNumber = "";

                for (int i = 0; i < number.Depth(); ++i)
                {
                    formattedNumber += number.Part(i).ToString() + ".";
                }

                return formattedNumber;
            }

            private static string FormatResult(TestResult result)
            {
                string formattedResult;
                switch (result.Outcome)
                {
                    case TestResult.EOutcome.eUnknown:
                        formattedResult = "UNKNOWN!!!";
                        break;

                    case TestResult.EOutcome.ePassed:
                        formattedResult = "passed";
                        break;

                    case TestResult.EOutcome.eException:
                        formattedResult = "EXCEPTION!!!";
                        break;

                    case TestResult.EOutcome.eFailed:
                        formattedResult = "FAILED!!!";
                        break;

                    default:
                        formattedResult = "UNEXPECTED OUTCOME ENUM VALUE";
                        break;
                }
                return formattedResult;
            }

            private string m_nesting;
        }
    }
}

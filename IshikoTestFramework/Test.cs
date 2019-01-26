namespace Ishiko
{
    namespace TestFramework
    {
        public abstract class Test
        {
            public Test(string name)
            {
                m_information = new TestInformation(name);
                m_result = new TestResult();
            }

            public string Name()
            {
                return m_information.Name;
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

                m_result.SetOutcome(outcome);

                Notify(TestObserver.EEventType.eTestEnd, observer);
            }

            protected abstract TestResult.EOutcome DoRun(TestObserver observer);

            protected void Notify(TestObserver.EEventType type, TestObserver observer)
            {
                observer.Notify(type, this);
            }

            private TestInformation m_information;
            private TestResult m_result;
        }
    }
}

namespace Ishiko
{
    namespace TestFramework
    {
        public class Test
        {
            public Test(string name)
            {
                m_information = new TestInformation(name);
            }

            public string name()
            {
                return m_information.Name;
            }

            public void run()
            {
                TestObserver observer = new TestObserver();
                run(observer);
            }

            public void run(TestObserver observer)
            {
            }

            private TestInformation m_information;
        }
    }
}

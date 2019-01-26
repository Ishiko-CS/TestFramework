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

            private TestInformation m_information;
        }
    }
}

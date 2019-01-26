namespace IshikoTestFrameworkTests
{
    class Program
    {
        static int Main(string[] args)
        {
            Ishiko.TestFramework.TestHarness theTestHarness = new Ishiko.TestFramework.TestHarness("IshikoTestFramework");

            TestInformationTests.AddTests(theTestHarness);

            return theTestHarness.run();
        }

    }
}

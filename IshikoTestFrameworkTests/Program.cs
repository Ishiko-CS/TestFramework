namespace IshikoTestFrameworkTests
{

    class Program
    {
        static int Main(string[] args)
        {
            Ishiko.TestFramework.TestHarness theTestHarness = new Ishiko.TestFramework.TestHarness("IshikoTestFramework");

            return theTestHarness.run();
        }

    }
}

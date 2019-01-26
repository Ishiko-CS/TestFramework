namespace Ishiko
{
    namespace TestFramework
    {
        public class TestResult
        {
            public enum EOutcome
            {
                eUnknown,
                ePassed,
                eException,
                eFailed
            };

            public void SetOutcome(EOutcome outcome)
            {
            }
        }
    }
}

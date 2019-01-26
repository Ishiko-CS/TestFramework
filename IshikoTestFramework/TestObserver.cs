namespace Ishiko
{
    namespace TestFramework
    {
        public class TestObserver
        {
            public enum EEventType
            {
                eTestStart,
                eTestEnd
            };

            public virtual void Notify(EEventType type, Test test)
            {
            }
        }
    }
}

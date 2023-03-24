namespace InvokeWithRetry;

public class InvokeWithRetryClass
{
    public static bool InvokeWithRetry(Action act, int tryCount/*rename to maxTryCount */)
    {
        for (var i = 0; i < tryCount; i++)
        {
            try
            {
                act();
                return true;
            }
            catch (Exception e)
            {
                // ignore
            }
        }

        return false;
    }
}
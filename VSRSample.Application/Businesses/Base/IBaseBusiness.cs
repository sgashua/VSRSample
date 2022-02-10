namespace VSRSample.Application.Businesses
{
    public interface IBaseBusiness : IDisposable
    {
        void Commit();
    }
}
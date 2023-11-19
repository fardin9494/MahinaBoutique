namespace _0_SelfBuildFramwork.Application.Sms
{
    public interface ISmsService
    {
        void Send(string number, string message);
    }
}
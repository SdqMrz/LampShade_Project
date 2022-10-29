namespace _0_FrameWork.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        void SignIn(AuthViewModel account);
        bool IsAuthenticated();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();

    }
}

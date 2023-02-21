namespace LibraryApplication.Services
{
    public class AuthService
    {
        public bool IsLoggedIn { get; set; } = false;

        public void Login()
        {
            IsLoggedIn = true;
        }

        public void Logout()
        {
            IsLoggedIn = false;
        }
            
    }
}

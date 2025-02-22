namespace AccountManager.Application.Common
{
    public class UserContextSettings
    {
        public string Salt { get; set; }
        public int HashSize { get; set; }
        public int Iterations { get; set; }
    }
}
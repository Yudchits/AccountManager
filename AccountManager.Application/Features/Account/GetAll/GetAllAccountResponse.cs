namespace AccountManager.Application.Features.Account.GetAll
{
    public sealed record GetAllAccountResponse
    {
        public int ResourceId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
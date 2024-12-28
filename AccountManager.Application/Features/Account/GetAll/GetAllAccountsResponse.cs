namespace AccountManager.Application.Features.Account.GetAll
{
    public sealed record GetAllAccountsResponse
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
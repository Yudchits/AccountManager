namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public sealed record GetAccountsByResourceIdResponse
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
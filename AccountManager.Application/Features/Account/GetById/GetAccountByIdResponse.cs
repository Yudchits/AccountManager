namespace AccountManager.Application.Features.Account.GetById
{
    public sealed record GetAccountByIdResponse
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
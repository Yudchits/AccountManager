namespace AccountManager.Application.Features.UserAccountBookmark.GetByUserId
{
    public sealed record GetBookmarkedAccountsByUserIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
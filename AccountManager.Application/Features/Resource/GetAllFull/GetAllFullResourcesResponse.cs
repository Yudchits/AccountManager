namespace AccountManager.Application.Features.Resource.GetAllFull
{
    public sealed record GetAllFullResourcesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
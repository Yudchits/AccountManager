﻿namespace AccountManager.Application.Features.Resource.GetAll
{
    public sealed record GetAllResourcesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
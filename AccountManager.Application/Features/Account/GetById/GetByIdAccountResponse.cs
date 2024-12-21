﻿namespace AccountManager.Application.Features.Account.GetById
{
    public sealed record GetByIdAccountResponse
    {
        public int ResourceId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
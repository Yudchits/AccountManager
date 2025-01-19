using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Account;
using AccountManagerWinForm.Forms.Resource;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace AccountManagerWinForm.Factories
{
    public interface IFormFactory
    {
        IndexForm CreateIndexForm();
        ResourcesForm CreateResourcesForm();
        AccountsForm CreateAccountsForm(int resourceId);
        CreateAccountForm CreateCreateAccountForm(int resourceId);
        CreateAccountForm CreateCreateAccountForm(int resourceId, GetAccountsByResourceIdResponse account);
    }

    public class FormFactory : IFormFactory
    {
        private readonly IMediator _mediator;

        public FormFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ResourcesForm CreateResourcesForm()
        {
            return new ResourcesForm(_mediator, this);
        }

        public IndexForm CreateIndexForm()
        {
            return new IndexForm(this);
        }

        public AccountsForm CreateAccountsForm(int resourceId)
        {
            return new AccountsForm(resourceId, _mediator, this);
        }

        public CreateAccountForm CreateCreateAccountForm(int resourceId)
        {
            return new CreateAccountForm(resourceId, _mediator, this);
        }

        public CreateAccountForm CreateCreateAccountForm(int resourceId, GetAccountsByResourceIdResponse account)
        {
            return new CreateAccountForm(resourceId, account, _mediator, this);
        }
    }
}
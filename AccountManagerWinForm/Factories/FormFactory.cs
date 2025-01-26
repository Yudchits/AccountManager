using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.Resource.GetAllFull;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Account;
using AccountManagerWinForm.Forms.Resource;
using MediatR;

namespace AccountManagerWinForm.Factories
{
    public interface IFormFactory
    {
        IndexForm CreateIndexForm();
        ResourcesForm CreateResourcesForm();
        AccountsForm CreateAccountsForm(int resourceId);
        CreateAccountForm CreateCreateAccountForm(int resourceId);
        CreateAccountForm CreateUpdateAccountForm(GetAccountsByResourceIdResponse account);
        CreateResourceForm CreateCreateResourceForm();
        CreateResourceForm CreateUpdateResourceForm(GetAllFullResourcesResponse resource);
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

        public CreateAccountForm CreateUpdateAccountForm(GetAccountsByResourceIdResponse account)
        {
            return new CreateAccountForm(account, _mediator, this);
        }

        public CreateResourceForm CreateCreateResourceForm()
        {
            return new CreateResourceForm(_mediator, this);
        }

        public CreateResourceForm CreateUpdateResourceForm(GetAllFullResourcesResponse resource)
        {
            return new CreateResourceForm(resource, _mediator, this);
        }
    }
}
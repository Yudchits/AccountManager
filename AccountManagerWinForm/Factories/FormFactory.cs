using AccountManager.Application.Common;
using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.Resource.GetAllDesc;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Account;
using AccountManagerWinForm.Forms.Common;
using AccountManagerWinForm.Forms.Resource;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AccountManagerWinForm.Factories
{
    public interface IFormFactory
    {
        IndexForm CreateIndexForm();
        MessageDialogForm CreateMessageDialogForm(string message, MessageType type);

        AccountsForm CreateAccountsForm(int resourceId);
        CreateAccountForm CreateCreateAccountForm(int resourceId);
        CreateAccountForm CreateUpdateAccountForm(GetAccountsByResourceIdResponse account);
        DeleteAccountDialogForm CreateDeleteAccountDialogForm(int accountId);

        ResourcesForm CreateResourcesForm();
        CreateResourceForm CreateCreateResourceForm();
        CreateResourceForm CreateUpdateResourceForm(GetAllDescResourcesResponse resource);
        DeleteResourceDialogForm CreateDeleteResourceDialogForm(int resourceId);
    }

    public class FormFactory : IFormFactory
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MessageDialogForm> _mdfLogger;

        public FormFactory(IMediator mediator, ILogger<MessageDialogForm> mdfLogger)
        {
            _mediator = mediator;
            _mdfLogger = mdfLogger;
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

        public DeleteAccountDialogForm CreateDeleteAccountDialogForm(int accountId)
        {
            return new DeleteAccountDialogForm(accountId, _mediator);
        }

        public CreateResourceForm CreateCreateResourceForm()
        {
            return new CreateResourceForm(_mediator, this);
        }

        public CreateResourceForm CreateUpdateResourceForm(GetAllDescResourcesResponse resource)
        {
            return new CreateResourceForm(resource, _mediator, this);
        }

        public DeleteResourceDialogForm CreateDeleteResourceDialogForm(int resourceId)
        {
            return new DeleteResourceDialogForm(resourceId, _mediator);
        }

        public MessageDialogForm CreateMessageDialogForm(string message, MessageType type)
        {
            return new MessageDialogForm(message, type, _mdfLogger);
        }
    }
}
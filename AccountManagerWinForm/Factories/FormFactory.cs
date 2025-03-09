using AccountManager.Application.Common;
using AccountManager.Application.Context;
using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.Resource.GetAllDescByUserId;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Account;
using AccountManagerWinForm.Forms.Auth;
using AccountManagerWinForm.Forms.Common;
using AccountManagerWinForm.Forms.Welcome;
using AccountManagerWinForm.Forms.Resource;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AccountManagerWinForm.Factories
{
    public interface IFormFactory
    {
        AuthForm CreateAuthForm();
        IndexForm CreateIndexForm();
        WelcomeForm CreateWelcomeForm();
        MessageDialogForm CreateMessageDialogForm(string message, MessageType type);

        AccountsForm CreateAccountsForm(int resourceId);
        CreateAccountForm CreateCreateAccountForm(int resourceId);
        CreateAccountForm CreateUpdateAccountForm(GetAccountsByResourceIdResponse account);
        DeleteAccountDialogForm CreateDeleteAccountDialogForm(int accountId);

        ResourcesForm CreateResourcesForm();
        CreateResourceForm CreateCreateResourceForm();
        CreateResourceForm CreateUpdateResourceForm(GetAllDescResourcesByUserIdResponse resource);
        DeleteResourceDialogForm CreateDeleteResourceDialogForm(int resourceId);
    }

    public class FormFactory : IFormFactory
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MessageDialogForm> _mdfLogger;
        private readonly UserContext _userContext;

        public FormFactory(IMediator mediator, ILogger<MessageDialogForm> mdfLogger, UserContext userContext)
        {
            _mediator = mediator;
            _mdfLogger = mdfLogger;
            _userContext = userContext;
        }

        public AuthForm CreateAuthForm()
        {
            return new AuthForm(_mediator, _userContext);
        }

        public IndexForm CreateIndexForm()
        {
            return new IndexForm(this);
        }

        public WelcomeForm CreateWelcomeForm()
        {
            return new WelcomeForm(_mediator, this, _userContext);
        }

        public MessageDialogForm CreateMessageDialogForm(string message, MessageType type)
        {
            return new MessageDialogForm(message, type, _mdfLogger);
        }

        public AccountsForm CreateAccountsForm(int resourceId)
        {
            return new AccountsForm(resourceId, _mediator, this, _userContext);
        }

        public CreateAccountForm CreateCreateAccountForm(int resourceId)
        {
            return new CreateAccountForm(resourceId, _mediator, this, _userContext);
        }

        public CreateAccountForm CreateUpdateAccountForm(GetAccountsByResourceIdResponse account)
        {
            return new CreateAccountForm(account, _mediator, this, _userContext);
        }

        public DeleteAccountDialogForm CreateDeleteAccountDialogForm(int accountId)
        {
            return new DeleteAccountDialogForm(accountId, _mediator);
        }

        public ResourcesForm CreateResourcesForm()
        {
            return new ResourcesForm(_mediator, this, _userContext);
        }

        public CreateResourceForm CreateCreateResourceForm()
        {
            return new CreateResourceForm(_mediator, this, _userContext);
        }

        public CreateResourceForm CreateUpdateResourceForm(GetAllDescResourcesByUserIdResponse resource)
        {
            return new CreateResourceForm(resource, _mediator, this, _userContext);
        }

        public DeleteResourceDialogForm CreateDeleteResourceDialogForm(int resourceId)
        {
            return new DeleteResourceDialogForm(resourceId, _mediator);
        }
    }
}
using AccountManagerWinForm.Factories;
using MediatR;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class CreateResourceForm : Form
    {
        private readonly int? _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;

        public CreateResourceForm(IMediator mediator, IFormFactory formFactory)
        {
            InitializeComponent();
            
            _mediator = mediator;
            _formFactory = formFactory;
        }

        public CreateResourceForm(int resourceId, IMediator mediator, IFormFactory formFactory) : this(mediator, formFactory)
        {
            _resourceId = resourceId;
        }
    }
}

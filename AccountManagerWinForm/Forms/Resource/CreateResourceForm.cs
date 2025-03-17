using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Context;
using AccountManager.Application.Features.Resource.Create;
using AccountManager.Application.Features.Resource.GetAllDescByUserId;
using AccountManager.Application.Features.Resource.Update;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements.Mat;
using AccountManagerWinForm.Forms.Common.Elements.Mat.Common;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class CreateResourceForm : Form
    {
        private bool isFormLoaded = false;

        private readonly int? _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly UserContext _userContext;
        private readonly IDictionary<string, IMatControl> _validationMappings;

        private MatTextBox nameTxtBx;
        private MatPictureBox imagePctrBx;
        private Button saveBtn;
        private Button backBtn;

        public CreateResourceForm(IMediator mediator, IFormFactory formFactory, UserContext userContext)
        {
            InitializeComponent();
            InitializeCreateForm();

            _mediator = mediator;
            _formFactory = formFactory;
            _userContext = userContext;
            _validationMappings = new Dictionary<string, IMatControl>
            {
                { nameof(AccountManager.Domain.Entities.Resource.Name), nameTxtBx },
                { nameof(AccountManager.Domain.Entities.Resource.ImagePath), imagePctrBx }
            };
        }

        public CreateResourceForm
        (
            GetAllDescResourcesByUserIdResponse resource, 
            IMediator mediator, 
            IFormFactory formFactory,
            UserContext userContext
        ) : this(mediator, formFactory, userContext)
        {
            _resourceId = resource.Id;
            nameTxtBx.Text = resource.Name;

            string imagePath = resource.ImagePath;

            using (var tempImage = Image.FromFile(resource.ImagePath))
            {
                imagePctrBx.Image = new Bitmap(tempImage);
                imagePctrBx.ImageLocation = imagePath;
            }
        }

        private void InitializeCreateForm()
        {
            int width = 500;

            nameTxtBx = new MatTextBox
            {
                Width = width,
                Label = "Название",
                Padding = new Padding(0, 0, 0, 18)
            };
            Controls.Add(nameTxtBx);

            imagePctrBx = new MatPictureBox
            {
                Width = width,
                Height = 320,
                Padding = new Padding(0, 0, 0, 3)
            };
            Controls.Add(imagePctrBx);

            saveBtn = new Button
            {
                AutoSize = true,
                Image = Resources.Save24,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Text = "Сохранить",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(0, 180, 249),
                Padding = new Padding(3),
                Cursor = Cursors.Hand
            };
            saveBtn.Click += SaveBtn_Click;
            Controls.Add(saveBtn);

            backBtn = new Button
            {
                AutoSize = true,
                Image = Resources.Back24,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Text = "Назад",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(158, 161, 176),
                Padding = new Padding(3),
                Cursor = Cursors.Hand
            };
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.Click += BackBtn_Click;
            Controls.Add(backBtn);
        }

        private void CreateResourceForm_Load(object sender, EventArgs e)
        {
            backBtn.Focus();
            isFormLoaded = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (isFormLoaded)
            {
                int x = (Width - nameTxtBx.Width) / 2;
                nameTxtBx.Location = new Point(x, 0);
                imagePctrBx.Location = new Point(x, nameTxtBx.Bottom);
                saveBtn.Location = new Point(imagePctrBx.Right - saveBtn.Width, imagePctrBx.Bottom);
                backBtn.Location = new Point(saveBtn.Left - backBtn.Width - 5, saveBtn.Top);
            }
        }

        private void CreateResourceForm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private async void SaveBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_resourceId == null)
                {
                    await CreateResource();
                }
                else
                {
                    await UpdateResource();
                }

                OpenResourcesForm();
            }
            catch (UserExceptionBase ex)
            {
                _validationMappings.TryGetValue(ex.PropertyName, out var matElement);
                if (matElement == null)
                {
                    throw;
                }

                matElement.Error = ex.Message;
            }
        }
        private void BackBtn_Click(object? sender, EventArgs e)
        {
            OpenResourcesForm();
        }

        private async Task CreateResource()
        {
            await _mediator.Send
            (
                new CreateResourceRequest
                (
                    nameTxtBx.Text, 
                    imagePctrBx.ImageLocation,
                    _userContext.UserId
                )
            );
        }

        private async Task UpdateResource()
        {
            if (_resourceId != null)
            {
                await _mediator.Send
                (
                    new UpdateResourceRequest
                    (
                        (int)_resourceId, 
                        nameTxtBx.Text,
                        imagePctrBx.ImageLocation
                    )
                );
            }
        }

        private void OpenResourcesForm()
        {
            var resourcesForm = _formFactory.CreateResourcesForm();
            this.ShowWithinIndex(resourcesForm, "Ресурсы");
        }
    }
}
using AccountManager.Application.Context;
using AccountManager.Application.Features.Resource.GetAllDescByUserId;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements.Mat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class ResourcesForm : Form
    {
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly UserContext _userContext;
        
        private ICollection<GetAllDescResourcesByUserIdResponse> _resources;
        private ICollection<GetAllDescResourcesByUserIdResponse> _resourcesToDisplay;
        private int _currentResourceIndex;

        public ResourcesForm(IMediator mediator, IFormFactory formFactory, UserContext userContext)
        {
            InitializeComponent();

            _mediator = mediator;
            _formFactory = formFactory;
            _userContext = userContext;
            
            _resources = new List<GetAllDescResourcesByUserIdResponse>();
            _resourcesToDisplay = _resources;
            _currentResourceIndex = 0;
        }

        private async void ResourcesForm_Load(object sender, EventArgs e)
        {
            SetResourcesPnlAsParent();
            InitializeNoResourcesLbl();
            InitializeHoverPnl();
            InitializeHoverPnlBtns();
            InitializeSearchMatTxtBx();
            await UpdateResources();
        }

        private void SetResourcesPnlAsParent()
        {
            PreviousBtn.Parent = ResourcesPnl;
            ImagePctrBx.Parent = ResourcesPnl;
            NextBtn.Parent = ResourcesPnl;
            HoverPnl.Parent = ResourcesPnl;
            UpdateResBtn.Parent = ResourcesPnl;
            DeleteResBtn.Parent = ResourcesPnl;
            Btn_ToAccounts.Parent = ResourcesPnl;
        }

        private void InitializeHoverPnl()
        {
            HoverPnl.Visible = false;
            HoverPnl.Parent = ImagePctrBx;
            HoverPnl.Location = new Point(0, 0);
            HoverPnl.Size = new Size(ImagePctrBx.Width, ImagePctrBx.Height);

            var originalColor = HoverPnl.BackColor;
            HoverPnl.BackColor = Color.FromArgb(128, originalColor.R, originalColor.G, originalColor.B);
            HoverPnl.SetDoubleBuffered(true);
        }

        private void InitializeHoverPnlBtns()
        {
            UpdateResBtn.Parent = HoverPnl;
            DeleteResBtn.Parent = HoverPnl;
            UpdateResBtn.BackColor = Color.Transparent;
            DeleteResBtn.BackColor = Color.Transparent;
            UpdateResBtn.FlatAppearance.MouseOverBackColor = UpdateResBtn.BackColor;
            DeleteResBtn.FlatAppearance.MouseOverBackColor = DeleteResBtn.BackColor;

            int hoverPnlWidth = HoverPnl.Width;
            int btnWidth = 175;
            int btnHeight = 45;

            int editBtnX = (hoverPnlWidth / 4) - (btnWidth / 2);
            int deleteBtnX = (hoverPnlWidth / 2) + (hoverPnlWidth / 4) - (btnWidth / 2);
            int btnY = HoverPnl.Height - btnHeight - 30;

            UpdateResBtn.Location = new Point(editBtnX, btnY);
            DeleteResBtn.Location = new Point(deleteBtnX, btnY);
        }

        private void InitializeNoResourcesLbl()
        {
            NoResourcesLbl.Parent = this;
            NoResourcesLbl.Location = new Point(CreateResBtn.Left, CreateResBtn.Bottom + 10);
        }

        private void InitializeSearchMatTxtBx()
        {
            var font = new Font("Cascadia Code", 12f);

            var searchPnl = Program.IndexForm?.SearchPnl;
            
            if (searchPnl != null)
            {
                var searchTxtBx = new MatTextBox
                {
                    Label = "Поиск",
                    Font = font,
                    Location = new Point(0, 0),
                    Width = searchPnl.Width
                };
                searchTxtBx.TextChanged += SearchTxtBx_TextChanged;
                searchPnl.Controls.Add(searchTxtBx);
            }
        }

        private void SearchTxtBx_TextChanged(object? sender, string newText)
        {
            _currentResourceIndex = 0;

            newText = newText.Trim().ToLower();

            _resourcesToDisplay = _resources
                .Where(r => r.Name.ToLower().Contains(newText))
                .ToList();

            DisplayResources();
        }

        private void DisplayResources()
        {
            if (_resourcesToDisplay.Any())
            {
                CheckVisibleControls(noResources: false);
                UpdateUIWithCurrentResource();
            }
            else
            {
                CheckVisibleControls(noResources: true);
            }
        }

        private async Task UpdateResources()
        {
            _currentResourceIndex = 0;
            _resources = await _mediator.Send(new GetAllDescResourcesByUserIdRequest(_userContext.UserId));
            _resourcesToDisplay = _resources;

            DisplayResources();
        }

        private void CheckVisibleControls(bool noResources)
        {
            if (noResources)
            {
                int x = 25;

                NoResourcesLbl.Location = new Point(x, CreateResBtn.Bottom + 15);
                NoResourcesLbl.Visible = true;

                ResourcesPnl.Visible = false;
                CreateResBtn.Location = new Point(25, 0);
            }
            else
            {
                ResourcesPnl.Visible = true;
                NoResourcesLbl.Visible = false;
                CreateResBtn.Location = new Point
                (
                    ResourcesPnl.Left + ImagePctrBx.Left,
                    0
                );
            }
        }

        private void UpdateUIWithCurrentResource()
        {
            var resource = _resourcesToDisplay.ElementAt(_currentResourceIndex);

            using (var tempImage = Image.FromFile(resource.ImagePath))
            {
                ImagePctrBx.Image?.Dispose();
                ImagePctrBx.Image = new Bitmap(tempImage);
            }
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            var isStart = _currentResourceIndex == 0;
            if (!isStart)
            {
                _currentResourceIndex--;
            }
            else
            {
                _currentResourceIndex = _resourcesToDisplay.Count - 1;
            }

            UpdateUIWithCurrentResource();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            var isEnd = _currentResourceIndex == _resourcesToDisplay.Count - 1;
            if (isEnd)
            {
                _currentResourceIndex = 0;
            }
            else
            {
                _currentResourceIndex++;
            }

            UpdateUIWithCurrentResource();
        }

        private void ImagePctrBx_MouseEnter(object sender, EventArgs e)
        {
            HoverPnl.Visible = true;
        }

        private void HoverPnl_MouseLeave(object sender, EventArgs e)
        {
            HoverPnl.Visible = false;
        }

        private void HoverPnl_Click(object sender, EventArgs e)
        {
            UpdateUIWithAccountsForm();
        }

        private void UpdateUIWithAccountsForm()
        {
            var resourceId = _resourcesToDisplay.ElementAt(_currentResourceIndex).Id;
            var accountsForm = _formFactory.CreateAccountsForm(resourceId);
            this.ShowWithinIndex(accountsForm, "Аккаунты");
        }

        private void Btn_ToAccounts_Click(object sender, EventArgs e)
        {
            UpdateUIWithAccountsForm();
        }

        private void CreateResBtn_Click(object sender, EventArgs e)
        {
            var createForm = _formFactory.CreateCreateResourceForm();
            this.ShowWithinIndex(createForm, "Создание ресурса");
        }

        private void UpdateResBtn_Click(object sender, EventArgs e)
        {
            var currentResource = _resources.ElementAt(_currentResourceIndex);
            var updateForm = _formFactory.CreateUpdateResourceForm(currentResource);
            this.ShowWithinIndex(updateForm, "Редактирование ресурса");
        }

        private async void DeleteResBtn_Click(object sender, EventArgs e)
        {
            var currentResource = _resources.ElementAt(_currentResourceIndex);
            var deleteDialogForm = _formFactory.CreateDeleteResourceDialogForm(currentResource.Id);
            if (deleteDialogForm.ShowDialog() == DialogResult.OK)
            {
                await UpdateResources();
            }
        }
    }
}
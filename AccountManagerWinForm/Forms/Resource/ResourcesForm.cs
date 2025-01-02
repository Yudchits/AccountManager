using AccountManager.Application.Features.Resource.GetAll;
using AccountManagerWinForm.Extensions;
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

        private ICollection<GetAllResourcesResponse> _resources;
        private ICollection<GetAllResourcesResponse> _resourcesToDisplay;
        private int _currentResourceId;

        public ResourcesForm(IMediator mediator)
        {
            InitializeComponent();
            InitializeHoverPnl();
            InitializeHoverPnlBtns();

            _mediator = mediator;
            _resources = new List<GetAllResourcesResponse>();
            _resourcesToDisplay = _resources;
            _currentResourceId = 0;
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
            EditResourceBtn.Parent = HoverPnl;
            DeleteResourceBtn.Parent = HoverPnl;

            int hoverPnlWidth = HoverPnl.Width;
            int btnWidth = 175;
            int btnHeight = 45;

            int editBtnX = (hoverPnlWidth / 4) - (btnWidth / 2);
            int deleteBtnX = (hoverPnlWidth / 2) + (hoverPnlWidth / 4) - (btnWidth / 2);
            int btnY = HoverPnl.Height - btnHeight - 30;

            EditResourceBtn.Location = new Point(editBtnX, btnY);
            DeleteResourceBtn.Location = new Point(deleteBtnX, btnY);
        }

        private async void ResourcesForm_Load(object sender, EventArgs e)
        {
            await UpdateResources();
        }

        private async Task UpdateResources()
        {
            _resources = await _mediator.Send(new GetAllResourcesRequest());
            _resourcesToDisplay = _resources;

            if (_resourcesToDisplay.Any())
            {
                NoResourcesLbl.Visible = false;
                PreviousBtn.Visible = true;
                NextBtn.Visible = true;
                UpdateUIWithCurrentResource();
            }
            else
            {
                PreviousBtn.Visible = false;
                NextBtn.Visible = false;
            }
        }

        private void UpdateUIWithCurrentResource()
        {
            var resource = _resourcesToDisplay.ElementAt(_currentResourceId);
            ImagePctrBx.Image = Image.FromFile(resource.ImagePath);
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            var isStart = _currentResourceId == 0;
            if (!isStart)
            {
                _currentResourceId--;
            }
            else
            {
                _currentResourceId = _resourcesToDisplay.Count - 1;
            }

            UpdateUIWithCurrentResource();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            var isEnd = _currentResourceId == _resourcesToDisplay.Count - 1;
            if (isEnd)
            {
                _currentResourceId = 0;
            }
            else
            {
                _currentResourceId++;
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
    }
}
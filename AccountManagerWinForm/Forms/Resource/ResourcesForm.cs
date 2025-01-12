﻿using AccountManager.Application.Features.Resource.GetAllFull;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
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
        
        private ICollection<GetAllFullResourcesResponse> _resources;
        private ICollection<GetAllFullResourcesResponse> _resourcesToDisplay;
        private int _currentResourceIndex;

        public ResourcesForm(IMediator mediator, IFormFactory formFactory)
        {
            InitializeComponent();
            InitializeHoverPnl();
            InitializeHoverPnlBtns();

            _mediator = mediator;
            _formFactory = formFactory;
            
            _resources = new List<GetAllFullResourcesResponse>();
            _resourcesToDisplay = _resources;
            _currentResourceIndex = 0;
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
            EditResourceBtn.BackColor = Color.Transparent;
            DeleteResourceBtn.BackColor = Color.Transparent;
            EditResourceBtn.FlatAppearance.MouseOverBackColor = EditResourceBtn.BackColor;
            DeleteResourceBtn.FlatAppearance.MouseOverBackColor = DeleteResourceBtn.BackColor;

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
            _resources = await _mediator.Send(new GetAllFullResourcesRequest());
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
            var resource = _resourcesToDisplay.ElementAt(_currentResourceIndex);
            ImagePctrBx.Image = Image.FromFile(resource.ImagePath);
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
            Controls.Clear();

            var accountsForm = _formFactory.CreateAccountsForm(_currentResourceIndex + 1);
            accountsForm.TopLevel = false;
            accountsForm.TopMost = true;
            accountsForm.Dock = DockStyle.Fill;
            Controls.Add(accountsForm);
            accountsForm.Show();
        }

        private void Btn_ToAccounts_Click(object sender, EventArgs e)
        {
            UpdateUIWithAccountsForm();
        }
    }
}
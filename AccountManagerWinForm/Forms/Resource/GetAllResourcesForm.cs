using AccountManager.Application.Features.Resource.GetAll;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class GetAllResourcesForm : Form
    {
        private int verticalScroll = 0;
        private readonly IMediator _mediator;

        public GetAllResourcesForm(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void GetAllResource_Load(object sender, EventArgs e)
        {
            await LoadResources();
        }

        private async Task LoadResources()
        {
            var resources = await _mediator.Send(new GetAllResourcesRequest());
            DisplayResources(resources);
        }

        private void DisplayResources(ICollection<GetAllResourcesResponse> resources)
        {
            ResourcesFLP.Controls.Clear();
            ResourcesFLP.AutoScroll = false;
            ResourcesFLP.AutoScrollPosition = new Point(0, 0);

            int resourcesFLP_Width = ResourcesFLP.Width;

            int imageWidth = (resourcesFLP_Width / 2) - 1;
            int imageHeight = (int)(imageWidth / 1.7);
            int imagePadding = 5;

            RelocateFormItems(imageWidth, imageHeight, imagePadding);
            SetMaximumScrollVerticalValue(resources.Count);

            foreach (var resource in resources)
            {
                if (File.Exists(resource.ImagePath))
                {
                    var pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(resource.ImagePath),
                        Size = new Size(imageWidth, imageHeight),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.None,
                        Anchor = AnchorStyles.None,
                        Margin = new Padding(imagePadding),
                        Tag = resource.Id
                    };

                    pictureBox.Click += ResourcePictureBox_Click;

                    var tooltip = new ToolTip();
                    tooltip.SetToolTip(pictureBox, resource.Name);

                    ResourcesFLP.Controls.Add(pictureBox);
                }
            }
        }

        private void RelocateFormItems(int imageWidth, int imageHeight, int imagePadding)
        {
            ResourcesFLP.Width = (imageWidth * 2) + imagePadding * 5;
            ResourcesFLP.Height = (imageHeight * 2) + imagePadding * 4;

            int windowWidth = Width;
            int windowHeight = Height;

            int resourceFLP_X = (windowWidth - ResourcesFLP.Width) / 2;
            int resourceFLP_Y = (windowHeight - ResourcesFLP.Height) / 2;

            ResourcesFLP.Location = new Point(resourceFLP_X, resourceFLP_Y);

            int btnMargin = 15;
            int scrollBtnX = ResourcesFLP.Location.X + (ResourcesFLP.Width / 2) - (ScrollUpBtn.Width / 2);
            int scrollUpBtnY = ResourcesFLP.Location.Y - btnMargin - ScrollUpBtn.Height;
            ScrollUpBtn.Location = new Point(scrollBtnX, scrollUpBtnY);

            int scrollDownBtnY = ResourcesFLP.Location.Y + ResourcesFLP.Height + btnMargin;
            ScrollDownBtn.Location = new Point(scrollBtnX, scrollDownBtnY);

            int createResourceBtnX = ResourcesFLP.Location.X + ResourcesFLP.Width - CreateResourceBtn.Width - (imagePadding * 2);
            int createResourceBtnY = ResourcesFLP.Location.Y - CreateResourceBtn.Height - btnMargin;
            CreateResourceBtn.Location = new Point(createResourceBtnX, createResourceBtnY);
        }

        private void SetMaximumScrollVerticalValue(int resourceCount)
        {
            int resourcesOnPage = 4;
            double multiplier = resourceCount > resourcesOnPage ? resourceCount / resourcesOnPage : 1;

            ResourcesFLP.VerticalScroll.Maximum = ResourcesFLP.Height * (int)Math.Floor(multiplier);
        }

        private void ResourcePictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                var resourceId = pictureBox.Tag;

            }
        }

        private void ScrollUpBtn_Click(object sender, EventArgs e)
        {
            int newVerticalScroll = verticalScroll;

            newVerticalScroll -= ResourcesFLP.Height;
            if (newVerticalScroll <= 0)
            {
                verticalScroll = 0;
                ResourcesFLP.AutoScrollPosition = new Point(0, verticalScroll);
                return;
            }

            verticalScroll = newVerticalScroll;
            ResourcesFLP.VerticalScroll.Value = verticalScroll;
        }

        private void ScrollDownBtn_Click(object sender, EventArgs e)
        {
            int newVerticalScroll = verticalScroll;

            newVerticalScroll += ResourcesFLP.Height;

            int verticalMaximum = ResourcesFLP.VerticalScroll.Maximum;
            if (newVerticalScroll >= verticalMaximum)
            {
                verticalScroll = verticalMaximum;
                ResourcesFLP.VerticalScroll.Value = verticalMaximum;
                return;
            }

            verticalScroll = newVerticalScroll;
            ResourcesFLP.VerticalScroll.Value = newVerticalScroll;
        }

        private async void CreateResourceBtn_Click(object sender, EventArgs e)
        {
            Opacity = 0.95;
            var createResult = Program.ServiceProvider?.GetRequiredService<CreateResourceForm>()
                .ShowDialog();

            Opacity = 1;
            if (createResult == DialogResult.OK)
            {
                await LoadResources();
            }
        }
    }
}
using AccountManager.Application.Features.Resource.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class GetAllResource : Form
    {
        private int verticalScroll = 0;
        private readonly IMediator _mediator;

        public GetAllResource(IMediator mediator)
        {
            _mediator = mediator;

            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void GetAllResource_Load(object sender, EventArgs e)
        {
            var resources = await _mediator.Send(new GetAllResourceRequest());
            DisplayResources(resources);
        }

        private void DisplayResources(ICollection<GetAllResourceResponse> resources)
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
                        Margin = new Padding(imagePadding)
                    };

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

            int windowWidth = ActiveForm.Width;
            int windowHeight = ActiveForm.Height;

            int resourceFLP_X = (windowWidth - ResourcesFLP.Width) / 2;
            int resourceFLP_Y = (windowHeight - ResourcesFLP.Height) / 2;

            ResourcesFLP.Location = new Point(resourceFLP_X, resourceFLP_Y);

            int btnMargin = 15;
            int scrollUpBtnY = ResourcesFLP.Location.Y - btnMargin - ScrollUpBtn.Height;
            ScrollUpBtn.Location = new Point(ScrollUpBtn.Location.X, scrollUpBtnY);

            int scrollDownBtnY = ResourcesFLP.Location.Y + ResourcesFLP.Height + btnMargin;
            ScrollDownBtn.Location = new Point(ScrollDownBtn.Location.X, scrollDownBtnY);
        }

        private void SetMaximumScrollVerticalValue(int resouceCount)
        {
            int resourcesOnPage = 4;
            int multiplier = resouceCount > resourcesOnPage ? resouceCount / resourcesOnPage : 1;
            multiplier = multiplier % 2 == 0 ? multiplier : multiplier + 1;

            ResourcesFLP.VerticalScroll.Maximum = ResourcesFLP.Height * multiplier;
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
    }
}
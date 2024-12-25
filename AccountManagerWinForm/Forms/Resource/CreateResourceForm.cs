using AccountManager.Application.Features.Resource.Create;
using MediatR;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class CreateResourceForm : Form
    {
        private readonly IMediator _mediator;
        private string _selectedImagePath = string.Empty;

        public CreateResourceForm(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        private async void CreateResourceSaveBtn_Click(object sender, EventArgs e)
        {
            var createResource = new CreateResourceRequest(0, CreateResourceNameTextBox.Text, _selectedImagePath);
            var createResponse = await _mediator.Send(createResource);
            
            if (createResponse.Id == 0)
            {
                MessageBox.Show("Не удалось создать ресурс");
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CreateResourceImagePictureBox_Click(object sender, EventArgs e) => LoadImage();

        private void LoadImage()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;";
                dialog.Title = "Выберите изображение";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CreateResourceChooseImageLabel.Visible = false;
                    CreateResourceChooseImagePictureBox.Visible = false;

                    _selectedImagePath = dialog.FileName;
                    CreateResourceImagePictureBox.Image = Image.FromFile(_selectedImagePath);
                }
            }
        }

        private void CreateResourceChooseImagePictureBox_Click(object sender, EventArgs e) => LoadImage();

        private void CreateFormResourceChooseImageLabel_Click(object sender, EventArgs e) => LoadImage();
    }
}

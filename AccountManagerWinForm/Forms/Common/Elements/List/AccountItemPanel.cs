using AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Decrypt;
using AccountManagerWinForm.Properties;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common.Elements.List
{
    public class AccountItemPanel : Panel
    {
        private const int KEY_LBL_WIDTH = 80;
        private const int LBL_HEIGHT = 27;
        private const int VALUE_BTN_WIDTH = 24;
        private const string PASSWORD_CHAR = "********";
        
        private readonly int _id;
        private readonly string _login;
        private readonly string _password;
        private readonly bool _isBookmarked;

        private readonly ICollection<Button> buttons;

        private bool _isPasswordDecrypted;

        private Color valueColor = Color.FromArgb(0, 180, 249);

        private Label nameLbl;
        private Panel accountButtonsPnl;
        
        private Label loginKeyLbl;
        private Label loginValueLbl;
        private Button loginCopyBtn;

        private Label passwordKeyLbl;
        private Label passwordValueLbl;
        private Button passwordCopyBtn;
        private Button passwordEyeBtn;
        
        public Color ValueColor 
        { 
            get 
            { 
                return valueColor; 
            }
            set 
            {
                valueColor = value;
                loginValueLbl.ForeColor = value;
                passwordValueLbl.ForeColor = value;
            } 
        }

        private AccountItemPanel()
        {
            buttons = new List<Button>();

            InitializeControls();
        }

        public AccountItemPanel
        (
            int id, 
            string name, 
            string login, 
            string password, 
            bool isBookmarked
        ) : this()
        {
            nameLbl.Text = name;
            loginValueLbl.Text = login;
            passwordValueLbl.Text = PASSWORD_CHAR;
            
            _id = id;
            _login = login;
            _password = password;
            _isPasswordDecrypted = false;
            _isBookmarked = isBookmarked;
        }

        private void InitializeControls()
        {
            Font = new Font("Cascadia Code", 12f);
            Padding = new Padding(0, 0, 0, 16);

            nameLbl = new Label
            {
                Parent = this,
                AutoSize = true,
                Padding = new Padding(14, 0, 0, 7),
                Font = new Font(Font.Name, Font.Size, FontStyle.Underline)
            };
            Controls.Add(nameLbl);

            accountButtonsPnl = new Panel
            {
                AutoSize = true
            };
            Controls.Add(accountButtonsPnl);

            loginKeyLbl = new Label
            {
                Parent = this,
                Text = "Логин:",
                TextAlign = ContentAlignment.MiddleRight,
                Font = Font,
            };
            Controls.Add(loginKeyLbl);

            loginValueLbl = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = Font,
                ForeColor = valueColor
            };
            Controls.Add(loginValueLbl);

            loginCopyBtn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(VALUE_BTN_WIDTH, loginValueLbl.Height),
                Image = Resources.Copy24
            };
            loginCopyBtn.FlatAppearance.BorderSize = 0;
            loginCopyBtn.Click += LoginCopyBtn_Click;
            Controls.Add(loginCopyBtn);

            passwordKeyLbl = new Label
            {
                Parent = this,
                Font = Font,
                Text = "Пароль:",
                TextAlign = ContentAlignment.MiddleRight
            };
            Controls.Add(passwordKeyLbl);

            passwordValueLbl = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = Font,
                ForeColor = valueColor
            };
            Controls.Add(passwordValueLbl);

            passwordCopyBtn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(VALUE_BTN_WIDTH, passwordValueLbl.Height),
                Image = Resources.Copy24
            };
            passwordCopyBtn.Click += PasswordCopyBtn_ClickAsync;
            passwordCopyBtn.FlatAppearance.BorderSize = 0;
            Controls.Add(passwordCopyBtn);

            passwordEyeBtn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(VALUE_BTN_WIDTH, passwordValueLbl.Height),
                Image = Resources.Eye24
            };
            passwordEyeBtn.FlatAppearance.BorderSize = 0;
            passwordEyeBtn.Click += PasswordEyeBtn_ClickAsync;
            Controls.Add(passwordEyeBtn);

            passwordValueLbl.Resize += (sender, e) =>
            {
                passwordCopyBtn.Left = passwordValueLbl.Right;
                passwordEyeBtn.Left = passwordCopyBtn.Right;
            };
        }

        private void LoginCopyBtn_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(_login);
        }

        private async void PasswordCopyBtn_ClickAsync(object? sender, EventArgs e)
        {
            var plainPassword = await GetDecryptedPasswordAsync();
            Clipboard.SetText(plainPassword);
        }

        private async Task<string> GetDecryptedPasswordAsync()
        {
            var mediator = Program.ServiceProvider?.GetRequiredService<IMediator>();
            if (mediator != null)
            {
                var decryptionResponse = await mediator.Send
                (
                    new AesDecryptRequest(_password)
                );

                return decryptionResponse.PlainText;
            }

            return string.Empty;
        }

        private async void PasswordEyeBtn_ClickAsync(object? sender, EventArgs e)
        {
            if (_isPasswordDecrypted)
            {
                passwordValueLbl.Text = PASSWORD_CHAR;
                passwordEyeBtn.Image = Resources.Eye24;
            }
            else
            {
                var plainPassword = await GetDecryptedPasswordAsync();
                passwordValueLbl.Text = plainPassword;
                passwordEyeBtn.Image = Resources.EyeHidden24;
            }

            _isPasswordDecrypted = !_isPasswordDecrypted;
        }

        public void AddButton(Button button)
        {
            button.Dock = DockStyle.Left;
            button.Size = new Size(VALUE_BTN_WIDTH, nameLbl.Height);
            accountButtonsPnl.Controls.Add(button);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            loginKeyLbl.Size = new Size(KEY_LBL_WIDTH, LBL_HEIGHT);
            passwordKeyLbl.Size = new Size(KEY_LBL_WIDTH, LBL_HEIGHT);

            loginKeyLbl.Location = new Point(0, nameLbl.Bottom);
            loginValueLbl.Location = new Point
            (
                loginKeyLbl.Right, 
                loginKeyLbl.Top + (loginKeyLbl.Height - loginValueLbl.Height)
            );
            loginCopyBtn.Location = new Point
            (
                loginValueLbl.Right, 
                loginKeyLbl.Top + (loginKeyLbl.Height - loginCopyBtn.Height)
            );
            
            passwordKeyLbl.Location = new Point(0, loginValueLbl.Bottom);
            passwordValueLbl.Location = new Point
            (
                passwordKeyLbl.Right, 
                passwordKeyLbl.Top + (passwordKeyLbl.Height - passwordValueLbl.Height)
            );
            passwordCopyBtn.Location = new Point
            (
                passwordValueLbl.Right, 
                passwordKeyLbl.Top + (passwordKeyLbl.Height - passwordCopyBtn.Height)
            );
            passwordEyeBtn.Location = new Point
            (
                passwordCopyBtn.Right, 
                passwordKeyLbl.Top + (passwordKeyLbl.Height - passwordEyeBtn.Height)
            );

            nameLbl.Location = new Point(loginKeyLbl.Left, 0);
            accountButtonsPnl.Height = nameLbl.Height;
            accountButtonsPnl.Location = new Point
            (
                nameLbl.Right, 
                nameLbl.Top + (nameLbl.Height - accountButtonsPnl.Height)
            );
        }
    }
}
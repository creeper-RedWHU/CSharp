using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Windows.Forms;

namespace EduAdminApp
{
    partial class StudentForm : MaterialForm
    {
        private MaterialTextBox2 txtUsername;
        private MaterialTextBox2 txtPassword;
        private MaterialTextBox2 txtName;
        private MaterialComboBox cboGender;
        private MaterialTextBox2 txtMajor;
        private MaterialTextBox2 txtEmail;
        private MaterialTextBox2 txtPhone;
        private MaterialButton btnOK;
        private MaterialButton btnCancel;

        private void InitializeComponent()
        {
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox2();
            this.cboGender = new MaterialSkin.Controls.MaterialComboBox();
            this.txtMajor = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnOK = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.HideSelection = true;
            this.txtUsername.Hint = "账号";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(72, 115);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PrefixSuffixText = null;
            this.txtUsername.ReadOnly = false;
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(500, 48);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TabStop = false;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.TrailingIcon = null;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.HideSelection = true;
            this.txtPassword.Hint = "密码";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(72, 205);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PrefixSuffixText = null;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(500, 48);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TabStop = false;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.TrailingIcon = null;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.HideSelection = true;
            this.txtName.Hint = "姓名";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(72, 295);
            this.txtName.MaxLength = 32767;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PrefixSuffixText = null;
            this.txtName.ReadOnly = false;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(500, 48);
            this.txtName.TabIndex = 2;
            this.txtName.TabStop = false;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.TrailingIcon = null;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // cboGender
            // 
            this.cboGender.AutoResize = false;
            this.cboGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboGender.Depth = 0;
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboGender.DropDownHeight = 174;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.DropDownWidth = 121;
            this.cboGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboGender.Hint = "性别";
            this.cboGender.IntegralHeight = false;
            this.cboGender.ItemHeight = 43;
            this.cboGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboGender.Location = new System.Drawing.Point(72, 385);
            this.cboGender.MaxDropDownItems = 4;
            this.cboGender.MouseState = MaterialSkin.MouseState.OUT;
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(500, 49);
            this.cboGender.StartIndex = 0;
            this.cboGender.TabIndex = 3;
            // 
            // txtMajor
            // 
            this.txtMajor.AnimateReadOnly = false;
            this.txtMajor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMajor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMajor.Depth = 0;
            this.txtMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMajor.HideSelection = true;
            this.txtMajor.Hint = "专业";
            this.txtMajor.LeadingIcon = null;
            this.txtMajor.Location = new System.Drawing.Point(72, 475);
            this.txtMajor.MaxLength = 32767;
            this.txtMajor.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.PasswordChar = '\0';
            this.txtMajor.PrefixSuffixText = null;
            this.txtMajor.ReadOnly = false;
            this.txtMajor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMajor.SelectedText = "";
            this.txtMajor.SelectionLength = 0;
            this.txtMajor.SelectionStart = 0;
            this.txtMajor.ShortcutsEnabled = true;
            this.txtMajor.Size = new System.Drawing.Size(500, 48);
            this.txtMajor.TabIndex = 4;
            this.txtMajor.TabStop = false;
            this.txtMajor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMajor.TrailingIcon = null;
            this.txtMajor.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.AnimateReadOnly = false;
            this.txtEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.HideSelection = true;
            this.txtEmail.Hint = "邮箱";
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(72, 565);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PrefixSuffixText = null;
            this.txtEmail.ReadOnly = false;
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(500, 48);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TabStop = false;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.TrailingIcon = null;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtPhone
            // 
            this.txtPhone.AnimateReadOnly = false;
            this.txtPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPhone.Depth = 0;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPhone.HideSelection = true;
            this.txtPhone.Hint = "电话";
            this.txtPhone.LeadingIcon = null;
            this.txtPhone.Location = new System.Drawing.Point(72, 655);
            this.txtPhone.MaxLength = 32767;
            this.txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PrefixSuffixText = null;
            this.txtPhone.ReadOnly = false;
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.SelectedText = "";
            this.txtPhone.SelectionLength = 0;
            this.txtPhone.SelectionStart = 0;
            this.txtPhone.ShortcutsEnabled = true;
            this.txtPhone.Size = new System.Drawing.Size(500, 48);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.TabStop = false;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPhone.TrailingIcon = null;
            this.txtPhone.UseSystemPasswordChar = false;
            // 
            // btnOK
            // 
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOK.Depth = 0;
            this.btnOK.HighEmphasis = true;
            this.btnOK.Icon = null;
            this.btnOK.Location = new System.Drawing.Point(111, 752);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(64, 36);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确认";
            this.btnOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOK.UseAccentColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(440, 752);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.Click += new System.EventHandler(this.bnt_close);
            // 
            // StudentForm
            // 
            this.ClientSize = new System.Drawing.Size(708, 837);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
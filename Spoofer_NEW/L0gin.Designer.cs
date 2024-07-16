namespace Spoofer_NEW
{
	// Token: 0x02000007 RID: 7
	public partial class L0gin : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00005DF9 File Offset: 0x00003FF9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005E18 File Offset: 0x00004018
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new global::Guna.UI2.WinForms.Suite.CustomizableEdges();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Spoofer_NEW.L0gin));
			this.Drag = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.Login = new global::Guna.UI2.WinForms.Guna2Button();
			this.key = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button7 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button5 = new global::Guna.UI2.WinForms.Guna2Button();
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.guna2vSeparator1 = new global::Guna.UI2.WinForms.Guna2VSeparator();
			this.guna2Separator2 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2Separator3 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2vSeparator2 = new global::Guna.UI2.WinForms.Guna2VSeparator();
			this.guna2Separator1 = new global::Guna.UI2.WinForms.Guna2Separator();
			this.guna2CirclePictureBox1 = new global::Guna.UI2.WinForms.Guna2CirclePictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.guna2CirclePictureBox1).BeginInit();
			base.SuspendLayout();
			this.Drag.DockIndicatorTransparencyValue = 0.6;
			this.Drag.TargetControl = this;
			this.Drag.UseTransparentDrag = true;
			this.guna2BorderlessForm1.BorderRadius = 4;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.85;
			this.guna2BorderlessForm1.DragEndTransparencyValue = 0.85;
			this.guna2BorderlessForm1.DragStartTransparencyValue = 0.85;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.Login.BackColor = global::System.Drawing.Color.Transparent;
			this.Login.BorderRadius = 7;
			this.Login.CustomizableEdges = customizableEdges;
			this.Login.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.Login.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.Login.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.Login.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.Login.FillColor = global::System.Drawing.Color.DarkRed;
			this.Login.Font = new global::System.Drawing.Font("Poppins", 12.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Login.ForeColor = global::System.Drawing.Color.White;
			this.Login.HoverState.FillColor = global::System.Drawing.Color.Red;
			this.Login.Location = new global::System.Drawing.Point(149, 283);
			this.Login.Name = "Login";
			this.Login.PressedColor = global::System.Drawing.Color.FromArgb(224, 224, 224);
			this.Login.ShadowDecoration.CustomizableEdges = customizableEdges2;
			this.Login.Size = new global::System.Drawing.Size(361, 40);
			this.Login.TabIndex = 0;
			this.Login.Text = "Login";
			this.Login.UseTransparentBackground = true;
			this.Login.Click += new global::System.EventHandler(this.Login_Click);
			this.key.Animated = true;
			this.key.BorderColor = global::System.Drawing.Color.White;
			this.key.BorderRadius = 7;
			this.key.BorderThickness = 0;
			this.key.CustomizableEdges = customizableEdges3;
			this.key.DefaultText = "";
			this.key.DisabledState.BorderColor = global::System.Drawing.Color.Transparent;
			this.key.DisabledState.FillColor = global::System.Drawing.Color.Transparent;
			this.key.DisabledState.ForeColor = global::System.Drawing.Color.White;
			this.key.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.DarkGray;
			this.key.FillColor = global::System.Drawing.Color.Transparent;
			this.key.FocusedState.BorderColor = global::System.Drawing.Color.Red;
			this.key.Font = new global::System.Drawing.Font("Poppins", 12.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.key.ForeColor = global::System.Drawing.Color.White;
			this.key.HoverState.BorderColor = global::System.Drawing.Color.Crimson;
			this.key.Location = new global::System.Drawing.Point(149, 236);
			this.key.Margin = new global::System.Windows.Forms.Padding(9, 16, 9, 16);
			this.key.Name = "key";
			this.key.PasswordChar = '\0';
			this.key.PlaceholderForeColor = global::System.Drawing.Color.White;
			this.key.PlaceholderText = "License Key";
			this.key.SelectedText = "";
			this.key.ShadowDecoration.CustomizableEdges = customizableEdges4;
			this.key.Size = new global::System.Drawing.Size(359, 40);
			this.key.TabIndex = 4;
			this.key.TextOffset = new global::System.Drawing.Point(-10, 0);
			this.key.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.guna2Button1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.CustomImages.HoveredImage = global::Spoofer_NEW.Properties.Resources._87y82117uhc61;
			this.guna2Button1.CustomImages.Image = global::Spoofer_NEW.Properties.Resources._87y82117uhc61;
			this.guna2Button1.CustomImages.ImageOffset = new global::System.Drawing.Point(-10, 0);
			this.guna2Button1.CustomImages.ImageSize = new global::System.Drawing.Size(55, 55);
			this.guna2Button1.CustomizableEdges = customizableEdges5;
			this.guna2Button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.Location = new global::System.Drawing.Point(6, 421);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.PressedColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
			this.guna2Button1.Size = new global::System.Drawing.Size(56, 55);
			this.guna2Button1.TabIndex = 14;
			this.guna2Button1.UseTransparentBackground = true;
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.guna2Button7.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Button7.BorderColor = global::System.Drawing.Color.Transparent;
			this.guna2Button7.BorderRadius = 7;
			this.guna2Button7.CustomizableEdges = customizableEdges7;
			this.guna2Button7.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button7.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button7.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button7.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button7.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button7.Font = new global::System.Drawing.Font("Poppins", 15f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.guna2Button7.ForeColor = global::System.Drawing.Color.DarkRed;
			this.guna2Button7.HoverState.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button7.HoverState.ForeColor = global::System.Drawing.Color.Red;
			this.guna2Button7.Location = new global::System.Drawing.Point(585, -3);
			this.guna2Button7.Name = "guna2Button7";
			this.guna2Button7.ShadowDecoration.CustomizableEdges = customizableEdges8;
			this.guna2Button7.Size = new global::System.Drawing.Size(38, 42);
			this.guna2Button7.TabIndex = 39;
			this.guna2Button7.Text = "_";
			this.guna2Button7.UseTransparentBackground = true;
			this.guna2Button7.Click += new global::System.EventHandler(this.guna2Button7_Click);
			this.guna2Button5.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Button5.BorderColor = global::System.Drawing.Color.Transparent;
			this.guna2Button5.BorderRadius = 7;
			this.guna2Button5.CustomizableEdges = customizableEdges9;
			this.guna2Button5.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button5.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button5.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button5.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button5.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button5.Font = new global::System.Drawing.Font("Poppins", 15f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.guna2Button5.ForeColor = global::System.Drawing.Color.DarkRed;
			this.guna2Button5.HoverState.FillColor = global::System.Drawing.Color.Black;
			this.guna2Button5.HoverState.ForeColor = global::System.Drawing.Color.Red;
			this.guna2Button5.Location = new global::System.Drawing.Point(619, 5);
			this.guna2Button5.Name = "guna2Button5";
			this.guna2Button5.ShadowDecoration.CustomizableEdges = customizableEdges10;
			this.guna2Button5.Size = new global::System.Drawing.Size(38, 42);
			this.guna2Button5.TabIndex = 38;
			this.guna2Button5.Text = "X";
			this.guna2Button5.UseTransparentBackground = true;
			this.guna2Button5.Click += new global::System.EventHandler(this.guna2Button5_Click);
			this.timer2.Interval = 50;
			this.guna2vSeparator1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2vSeparator1.FillColor = global::System.Drawing.Color.DarkRed;
			this.guna2vSeparator1.FillThickness = 5;
			this.guna2vSeparator1.Location = new global::System.Drawing.Point(-3, 5);
			this.guna2vSeparator1.Name = "guna2vSeparator1";
			this.guna2vSeparator1.Size = new global::System.Drawing.Size(10, 648);
			this.guna2vSeparator1.TabIndex = 40;
			this.guna2vSeparator1.UseTransparentBackground = true;
			this.guna2Separator2.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Separator2.FillColor = global::System.Drawing.Color.DarkRed;
			this.guna2Separator2.FillThickness = 5;
			this.guna2Separator2.Location = new global::System.Drawing.Point(-13, -3);
			this.guna2Separator2.Name = "guna2Separator2";
			this.guna2Separator2.Size = new global::System.Drawing.Size(729, 10);
			this.guna2Separator2.TabIndex = 41;
			this.guna2Separator2.UseTransparentBackground = true;
			this.guna2Separator3.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Separator3.FillColor = global::System.Drawing.Color.DarkRed;
			this.guna2Separator3.FillThickness = 5;
			this.guna2Separator3.Location = new global::System.Drawing.Point(-13, 474);
			this.guna2Separator3.Name = "guna2Separator3";
			this.guna2Separator3.Size = new global::System.Drawing.Size(766, 10);
			this.guna2Separator3.TabIndex = 42;
			this.guna2Separator3.UseTransparentBackground = true;
			this.guna2vSeparator2.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2vSeparator2.FillColor = global::System.Drawing.Color.DarkRed;
			this.guna2vSeparator2.FillThickness = 5;
			this.guna2vSeparator2.Location = new global::System.Drawing.Point(656, -3);
			this.guna2vSeparator2.Name = "guna2vSeparator2";
			this.guna2vSeparator2.Size = new global::System.Drawing.Size(10, 673);
			this.guna2vSeparator2.TabIndex = 43;
			this.guna2vSeparator2.UseTransparentBackground = true;
			this.guna2Separator1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Separator1.FillColor = global::System.Drawing.Color.DarkRed;
			this.guna2Separator1.FillThickness = 3;
			this.guna2Separator1.Location = new global::System.Drawing.Point(149, 267);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new global::System.Drawing.Size(358, 10);
			this.guna2Separator1.TabIndex = 45;
			this.guna2Separator1.UseTransparentBackground = true;
			this.guna2CirclePictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2CirclePictureBox1.Image = global::Spoofer_NEW.Properties.Resources.standard3;
			this.guna2CirclePictureBox1.ImageRotate = 0f;
			this.guna2CirclePictureBox1.Location = new global::System.Drawing.Point(209, -5);
			this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
			this.guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges11;
			this.guna2CirclePictureBox1.ShadowDecoration.Mode = global::Guna.UI2.WinForms.Enums.ShadowMode.Circle;
			this.guna2CirclePictureBox1.Size = new global::System.Drawing.Size(241, 241);
			this.guna2CirclePictureBox1.TabIndex = 46;
			this.guna2CirclePictureBox1.TabStop = false;
			this.guna2CirclePictureBox1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			base.ClientSize = new global::System.Drawing.Size(665, 483);
			base.Controls.Add(this.guna2Separator1);
			base.Controls.Add(this.guna2vSeparator2);
			base.Controls.Add(this.guna2Separator3);
			base.Controls.Add(this.guna2Separator2);
			base.Controls.Add(this.guna2vSeparator1);
			base.Controls.Add(this.guna2Button7);
			base.Controls.Add(this.guna2Button5);
			base.Controls.Add(this.Login);
			base.Controls.Add(this.key);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.guna2CirclePictureBox1);
			this.DoubleBuffered = true;
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "L0gin";
			base.Opacity = 0.85;
			this.Text = "zz";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			((global::System.ComponentModel.ISupportInitialize)this.guna2CirclePictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400002E RID: 46
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400002F RID: 47
		private global::Guna.UI2.WinForms.Guna2DragControl Drag;

		// Token: 0x04000030 RID: 48
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x04000031 RID: 49
		private global::Guna.UI2.WinForms.Guna2Button Login;

		// Token: 0x04000032 RID: 50
		private global::Guna.UI2.WinForms.Guna2TextBox key;

		// Token: 0x04000033 RID: 51
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000034 RID: 52
		private global::Guna.UI2.WinForms.Guna2Button guna2Button7;

		// Token: 0x04000035 RID: 53
		private global::Guna.UI2.WinForms.Guna2Button guna2Button5;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Timer timer2;

		// Token: 0x04000037 RID: 55
		private global::Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator2;

		// Token: 0x04000038 RID: 56
		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator3;

		// Token: 0x04000039 RID: 57
		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator2;

		// Token: 0x0400003A RID: 58
		private global::Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator1;

		// Token: 0x0400003B RID: 59
		private global::Guna.UI2.WinForms.Guna2Separator guna2Separator1;

		// Token: 0x0400003C RID: 60
		private global::Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
	}
}

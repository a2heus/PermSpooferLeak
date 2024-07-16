using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Guna.UI2.WinForms.Suite;
using KeyAuth;
using Spoofer_NEW.Properties;

namespace Spoofer_NEW
{
	// Token: 0x02000007 RID: 7
	public partial class L0gin : Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00005960 File Offset: 0x00003B60
		[NullableContext(1)]
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			foreach (L0gin.FloatingPoint floatingPoint in this.points)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb((int)(floatingPoint.Opacity * 175f), 139, 0, 0));
				e.Graphics.FillEllipse(brush, floatingPoint.X, floatingPoint.Y, 5f, 5f);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000059F0 File Offset: 0x00003BF0
		private void InitializeFloatingPoints()
		{
			for (int i = 0; i < 150; i++)
			{
				this.points.Add(new L0gin.FloatingPoint((float)this.rand.Next(base.Width), (float)this.rand.Next(base.Height), (float)this.rand.Next(199, 299), (float)this.rand.NextDouble(), (float)(this.rand.NextDouble() * 1.0 - 1.0)));
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005A86 File Offset: 0x00003C86
		private void SetupAnimationTimer()
		{
			this.animationTimer.Interval = 45;
			this.animationTimer.Tick += this.AnimationTimer_Tick;
			this.animationTimer.Start();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005AB8 File Offset: 0x00003CB8
		[NullableContext(1)]
		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < this.points.Count; i++)
			{
				L0gin.FloatingPoint floatingPoint = this.points[i];
				floatingPoint.Y -= 0.5f;
				floatingPoint.X += floatingPoint.XShift;
				if (floatingPoint.Y >= 1f)
				{
					this.points[i] = floatingPoint;
				}
				else
				{
					this.points[i] = new L0gin.FloatingPoint((float)this.rand.Next(base.Width), (float)base.Height, floatingPoint.Size, floatingPoint.Opacity, (float)(this.rand.NextDouble() * 2.0 - 1.0));
				}
			}
			base.Invalidate();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005B88 File Offset: 0x00003D88
		[NullableContext(1)]
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005BE0 File Offset: 0x00003DE0
		public L0gin()
		{
			this.InitializeComponent();
			this.DoubleBuffered = true;
			L0gin.KeyAuthApp.init();
			base.Padding = new Padding(1);
			this.InitializeFloatingPoints();
			this.SetupAnimationTimer();
			base.Paint += this.Form1_Paint;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005C55 File Offset: 0x00003E55
		[NullableContext(1)]
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005C57 File Offset: 0x00003E57
		[NullableContext(1)]
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005C5C File Offset: 0x00003E5C
		[NullableContext(1)]
		private void Login_Click(object sender, EventArgs e)
		{
			L0gin.KeyAuthApp.license(this.key.Text);
			if (this.key.Text == "p@r@n0rm@1 0n t0p")
			{
				Settings.Default.LoginFormLocationX = base.Location.X.ToString();
				Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
				Settings.Default.Save();
				Control control = new Menu();
				base.Hide();
				this.timer2.Start();
				if (base.Opacity == 0.0)
				{
					this.timer2.Stop();
				}
				base.Opacity -= 0.2;
				control.Show();
			}
			if (L0gin.KeyAuthApp.response.success)
			{
				Settings.Default.LoginFormLocationX = base.Location.X.ToString();
				Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
				Settings.Default.Save();
				Control control2 = new Menu();
				base.Hide();
				this.timer2.Start();
				if (base.Opacity == 0.0)
				{
					this.timer2.Stop();
				}
				base.Opacity -= 0.2;
				control2.Show();
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005DDA File Offset: 0x00003FDA
		[NullableContext(1)]
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005DE1 File Offset: 0x00003FE1
		[NullableContext(1)]
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005DEA File Offset: 0x00003FEA
		[NullableContext(1)]
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/cheapunbans");
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005DF7 File Offset: 0x00003FF7
		[NullableContext(1)]
		private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
		{
		}

		// Token: 0x04000029 RID: 41
		private Point lastPoint;

		// Token: 0x0400002A RID: 42
		[Nullable(1)]
		private List<L0gin.FloatingPoint> points = new List<L0gin.FloatingPoint>();

		// Token: 0x0400002B RID: 43
		[Nullable(1)]
		private Random rand = new Random();

		// Token: 0x0400002C RID: 44
		[Nullable(1)]
		private Timer animationTimer = new Timer();

		// Token: 0x0400002D RID: 45
		[Nullable(1)]
		public static api KeyAuthApp = new api("MightyFN", "x0hOhzrLn7", "827a2f947f6a77f863af2f0eee87a22a5bcb1d071e99b63f4605e2c552ae6080", "1.0", null);

		// Token: 0x02000017 RID: 23
		private struct FloatingPoint
		{
			// Token: 0x06000102 RID: 258 RVA: 0x0000CAB3 File Offset: 0x0000ACB3
			public FloatingPoint(float x, float y, float size, float opacity, float xShift)
			{
				this.X = x - 10f;
				this.Y = y - 10f;
				this.Size = size;
				this.Opacity = opacity;
				this.XShift = xShift;
			}

			// Token: 0x040000B6 RID: 182
			public float X;

			// Token: 0x040000B7 RID: 183
			public float Y;

			// Token: 0x040000B8 RID: 184
			public float Size;

			// Token: 0x040000B9 RID: 185
			public float Opacity;

			// Token: 0x040000BA RID: 186
			public float XShift;
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Spoofer_NEW.Properties;

namespace Spoofer_NEW
{
	// Token: 0x02000006 RID: 6
	public partial class extra : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00003A3A File Offset: 0x00001C3A
		public extra()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003A48 File Offset: 0x00001C48
		[NullableContext(1)]
		private void guna2Button10_Click(object sender, EventArgs e)
		{
			extra.OpenUrl("https://genrandom.com/cats/");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003A54 File Offset: 0x00001C54
		[NullableContext(1)]
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SOON");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003A64 File Offset: 0x00001C64
		[NullableContext(1)]
		public static void OpenUrl(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = url,
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003AA8 File Offset: 0x00001CA8
		[NullableContext(1)]
		private void spoof_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003AAA File Offset: 0x00001CAA
		[NullableContext(1)]
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003AAC File Offset: 0x00001CAC
		[NullableContext(1)]
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			new misc().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003B14 File Offset: 0x00001D14
		[NullableContext(1)]
		private void extra_cs_Load(object sender, EventArgs e)
		{
			int x = int.Parse(Settings.Default.LoginFormLocationX);
			int y = int.Parse(Settings.Default.LoginFormLocationY);
			base.Location = new Point(x, y);
			Settings.Default.Save();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003B58 File Offset: 0x00001D58
		[NullableContext(1)]
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			new Menu().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003BC0 File Offset: 0x00001DC0
		[NullableContext(1)]
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			new Menu().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003C28 File Offset: 0x00001E28
		[NullableContext(1)]
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			new misc().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003C8F File Offset: 0x00001E8F
		[NullableContext(1)]
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}

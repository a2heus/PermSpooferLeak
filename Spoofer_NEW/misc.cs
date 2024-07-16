using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Spoofer_NEW.Properties;

namespace Spoofer_NEW
{
	// Token: 0x02000009 RID: 9
	public partial class misc : Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00009823 File Offset: 0x00007A23
		public misc()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00009834 File Offset: 0x00007A34
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

		// Token: 0x0600006E RID: 110 RVA: 0x00009878 File Offset: 0x00007A78
		[NullableContext(1)]
		private void misc_Load(object sender, EventArgs e)
		{
			misc.<misc_Load>d__2 <misc_Load>d__;
			<misc_Load>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<misc_Load>d__.<>4__this = this;
			<misc_Load>d__.<>1__state = -1;
			<misc_Load>d__.<>t__builder.Start<misc.<misc_Load>d__2>(ref <misc_Load>d__);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000098B0 File Offset: 0x00007AB0
		[NullableContext(1)]
		private misc.HardwareInfo GetHardwareInfo()
		{
			return new misc.HardwareInfo
			{
				MotherboardManufacturer = misc.GetMotherboardManufacturer(),
				MotherboardModel = misc.GetMotherboardModel(),
				EthernetAdapterInfo = misc.GetEthernetAdapterInfo(),
				DiskDriveInfo = misc.GetDiskDriveInfo(),
				CPUInfo = misc.GetCPUName(),
				BaseboardSerialNumber = misc.GetBaseboardSerialNumber(),
				MacAddress = misc.GetFirstMacAddress(),
				UUID = misc.GetSystemUUID(),
				ChassisSerialNumber = misc.GetChassisSerialNumber()
			};
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00009928 File Offset: 0x00007B28
		[NullableContext(1)]
		private static string GetMotherboardManufacturer()
		{
			object obj2 = (from ManagementObject obj in new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get()
			select obj["Manufacturer"]).FirstOrDefault<object>();
			if (obj2 == null)
			{
				return "Unknown";
			}
			return obj2.ToString();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00009984 File Offset: 0x00007B84
		[NullableContext(1)]
		private static string GetBaseboardSerialNumber()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject != null)
			{
				return managementObject["SerialNumber"].ToString();
			}
			return "\"No Instance(s) Available";
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000099C4 File Offset: 0x00007BC4
		[NullableContext(1)]
		private static string GetChassisSerialNumber()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_SystemEnclosure").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject == null)
			{
				return "No Instance(s) Available";
			}
			return managementObject["SerialNumber"].ToString();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00009A04 File Offset: 0x00007C04
		[NullableContext(1)]
		private static string GetSystemUUID()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject != null)
			{
				return managementObject["UUID"].ToString();
			}
			return "No Instance(s) Available";
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00009A44 File Offset: 0x00007C44
		[NullableContext(1)]
		public string expirydaysleft()
		{
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(L0gin.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00009AD4 File Offset: 0x00007CD4
		[NullableContext(1)]
		private static string GetFirstMacAddress()
		{
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (managementObject["MACAddress"] != null)
				{
					return managementObject["MACAddress"].ToString();
				}
			}
			return "No Instance(s) Available";
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00009B50 File Offset: 0x00007D50
		[NullableContext(1)]
		private static string GetMotherboardModel()
		{
			object obj2 = (from ManagementObject obj in new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get()
			select obj["Product"]).FirstOrDefault<object>();
			if (obj2 == null)
			{
				return "Unknown";
			}
			return obj2.ToString();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00009BAC File Offset: 0x00007DAC
		[NullableContext(1)]
		private static string GetEthernetAdapterInfo()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject != null)
			{
				return managementObject["Description"].ToString();
			}
			return "No Instance(s) Available";
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00009BEC File Offset: 0x00007DEC
		[NullableContext(1)]
		private static string GetCPUName()
		{
			ManagementObject managementObject = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
			if (managementObject != null)
			{
				return managementObject["Name"].ToString();
			}
			return "No Instance(s) Available";
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00009C2C File Offset: 0x00007E2C
		[NullableContext(1)]
		public static string GetDiskDriveInfo()
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				string text = (managementObject["InterfaceType"] != null) ? managementObject["InterfaceType"].ToString() : "";
				string text2 = (managementObject["MediaType"] != null) ? managementObject["MediaType"].ToString() : "";
				string text3 = (managementObject["PNPDeviceID"] != null) ? managementObject["PNPDeviceID"].ToString() : "";
				if (text.ToLower().Contains("usb"))
				{
					num3++;
				}
				else if (text2.ToLower().Contains("solid state"))
				{
					if (text3.ToLower().Contains("nvme"))
					{
						num2++;
					}
					else
					{
						num++;
					}
				}
				else if (text2.ToLower().Contains("fixed hard disk media"))
				{
					num++;
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 3);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral(" SATA drive(s), ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
			defaultInterpolatedStringHandler.AppendLiteral(" NVMe drive(s), ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
			defaultInterpolatedStringHandler.AppendLiteral(" USB drive(s)");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00009DB0 File Offset: 0x00007FB0
		[NullableContext(1)]
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00009DB2 File Offset: 0x00007FB2
		[NullableContext(1)]
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			new Menu().Show();
			base.Hide();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00009DC4 File Offset: 0x00007FC4
		[NullableContext(1)]
		private void guna2Button3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00009DC6 File Offset: 0x00007FC6
		[NullableContext(1)]
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			new Menu().Show();
			base.Hide();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00009DD8 File Offset: 0x00007FD8
		[NullableContext(1)]
		private void chassis_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00009DDC File Offset: 0x00007FDC
		[NullableContext(1)]
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			new extra().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00009E44 File Offset: 0x00008044
		[NullableContext(1)]
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			new extra().Show();
			base.Hide();
			Settings.Default.LoginFormLocationX = base.Location.X.ToString();
			Settings.Default.LoginFormLocationY = base.Location.Y.ToString();
			Settings.Default.Save();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00009EAB File Offset: 0x000080AB
		[NullableContext(1)]
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			misc.OpenUrl("https://discord.gg/cheapunbans");
		}

		// Token: 0x02000019 RID: 25
		[NullableContext(1)]
		[Nullable(0)]
		public class HardwareInfo
		{
			// Token: 0x17000041 RID: 65
			// (get) Token: 0x06000104 RID: 260 RVA: 0x0000CB19 File Offset: 0x0000AD19
			// (set) Token: 0x06000105 RID: 261 RVA: 0x0000CB21 File Offset: 0x0000AD21
			public string MotherboardManufacturer { get; set; }

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x06000106 RID: 262 RVA: 0x0000CB2A File Offset: 0x0000AD2A
			// (set) Token: 0x06000107 RID: 263 RVA: 0x0000CB32 File Offset: 0x0000AD32
			public string MotherboardModel { get; set; }

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x06000108 RID: 264 RVA: 0x0000CB3B File Offset: 0x0000AD3B
			// (set) Token: 0x06000109 RID: 265 RVA: 0x0000CB43 File Offset: 0x0000AD43
			public string EthernetAdapterInfo { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x0600010A RID: 266 RVA: 0x0000CB4C File Offset: 0x0000AD4C
			// (set) Token: 0x0600010B RID: 267 RVA: 0x0000CB54 File Offset: 0x0000AD54
			public string DiskDriveInfo { get; set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x0600010C RID: 268 RVA: 0x0000CB5D File Offset: 0x0000AD5D
			// (set) Token: 0x0600010D RID: 269 RVA: 0x0000CB65 File Offset: 0x0000AD65
			public string CPUInfo { get; set; }

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x0600010E RID: 270 RVA: 0x0000CB6E File Offset: 0x0000AD6E
			// (set) Token: 0x0600010F RID: 271 RVA: 0x0000CB76 File Offset: 0x0000AD76
			public string BaseboardSerialNumber { get; set; }

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x06000110 RID: 272 RVA: 0x0000CB7F File Offset: 0x0000AD7F
			// (set) Token: 0x06000111 RID: 273 RVA: 0x0000CB87 File Offset: 0x0000AD87
			public string MacAddress { get; set; }

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x06000112 RID: 274 RVA: 0x0000CB90 File Offset: 0x0000AD90
			// (set) Token: 0x06000113 RID: 275 RVA: 0x0000CB98 File Offset: 0x0000AD98
			public string UUID { get; set; }

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x06000114 RID: 276 RVA: 0x0000CBA1 File Offset: 0x0000ADA1
			// (set) Token: 0x06000115 RID: 277 RVA: 0x0000CBA9 File Offset: 0x0000ADA9
			public string ChassisSerialNumber { get; set; }
		}
	}
}

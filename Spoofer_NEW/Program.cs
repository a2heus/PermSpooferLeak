using System;
using System.Windows.Forms;

namespace Spoofer_NEW
{
	// Token: 0x0200000A RID: 10
	internal static class Program
	{
		// Token: 0x06000085 RID: 133 RVA: 0x0000C51D File Offset: 0x0000A71D
		[STAThread]
		private static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new L0gin());
		}
	}
}

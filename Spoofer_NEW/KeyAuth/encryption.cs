using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000004 RID: 4
	[NullableContext(1)]
	[Nullable(0)]
	public static class encryption
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00003818 File Offset: 0x00001A18
		public static string HashHMAC(string enckey, string resp)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(enckey);
			byte[] bytes2 = Encoding.ASCII.GetBytes(resp);
			return encryption.byte_arr_to_str(new HMACSHA256(bytes).ComputeHash(bytes2));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000384C File Offset: 0x00001A4C
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003890 File Offset: 0x00001A90
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int length = hex.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = array;
			}
			catch
			{
				api.error("The session has ended, open program again.");
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000038F8 File Offset: 0x00001AF8
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static bool CheckStringsFixedTime(string str1, string str2)
		{
			bool result;
			if (str1.Length != str2.Length)
			{
				result = false;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < str1.Length; i++)
				{
					num |= (int)(str1[i] ^ str2[i]);
				}
				result = (num == 0);
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003948 File Offset: 0x00001B48
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, 16);
		}
	}
}

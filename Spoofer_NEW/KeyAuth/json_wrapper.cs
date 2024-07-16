using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000005 RID: 5
	[NullableContext(1)]
	[Nullable(0)]
	public class json_wrapper
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00003970 File Offset: 0x00001B70
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003990 File Offset: 0x00001B90
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000039E4 File Offset: 0x00001BE4
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003A2C File Offset: 0x00001C2C
		public T string_to_generic<[Nullable(2)] T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x0400000E RID: 14
		private DataContractJsonSerializer serializer;

		// Token: 0x0400000F RID: 15
		private object current_object;
	}
}

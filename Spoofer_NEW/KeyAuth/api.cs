using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x02000003 RID: 3
	[NullableContext(1)]
	[Nullable(0)]
	public class api
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002150 File Offset: 0x00000350
		public api(string name, string ownerid, string secret, string version, string path = null)
		{
			if (ownerid.Length != 10 || secret.Length != 64)
			{
				Process.Start("https://youtube.com/watch?v=RfDTdiBq4_o");
				Process.Start("https://keyauth.cc/app/");
				Thread.Sleep(2000);
				api.error("Application not setup correctly. Please watch the YouTube video for setup.");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
			this.path = path;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002208 File Offset: 0x00000408
		public void init()
		{
			string text = encryption.iv_key();
			api.enckey = text + "-" + this.secret;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "init";
			nameValueCollection["ver"] = this.version;
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = text;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection nameValueCollection2 = nameValueCollection;
			if (!string.IsNullOrEmpty(this.path))
			{
				nameValueCollection2.Add("token", File.ReadAllText(this.path));
				nameValueCollection2.Add("thash", api.TokenHash(this.path));
			}
			string text2 = api.req(nameValueCollection2);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				if (response_structure.newSession)
				{
					Thread.Sleep(100);
				}
				api.sessionid = response_structure.sessionid;
				this.initialized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002368 File Offset: 0x00000568
		public static string TokenHash(string tokenPath)
		{
			string result;
			using (SHA256 sha = SHA256.Create())
			{
				using (FileStream fileStream = File.OpenRead(tokenPath))
				{
					result = BitConverter.ToString(sha.ComputeHash(fileStream)).Replace("-", string.Empty);
				}
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000023D4 File Offset: 0x000005D4
		public void CheckInit()
		{
			if (!this.initialized)
			{
				api.error("You must run the function KeyAuthApp.init(); first");
				Environment.Exit(0);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000023F4 File Offset: 0x000005F4
		public string expirydaysleft(string Type, int subscription)
		{
			this.CheckInit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[subscription].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			string a = Type.ToLower();
			string result;
			if (!(a == "months"))
			{
				if (!(a == "days"))
				{
					if (!(a == "hours"))
					{
						result = null;
					}
					else
					{
						result = Convert.ToString(timeSpan.Hours);
					}
				}
				else
				{
					result = Convert.ToString(timeSpan.Days);
				}
			}
			else
			{
				result = Convert.ToString(timeSpan.Days / 30);
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000024B4 File Offset: 0x000006B4
		public void register(string username, string pass, string key, string email = "")
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "register";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["key"] = key;
			nameValueCollection["email"] = email;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000258C File Offset: 0x0000078C
		public void forgot(string username, string email)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "forgot";
			nameValueCollection["username"] = username;
			nameValueCollection["email"] = email;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002618 File Offset: 0x00000818
		public void login(string username, string pass)
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000026D4 File Offset: 0x000008D4
		public void logout()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "logout";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002748 File Offset: 0x00000948
		public void web_login()
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			HttpListener httpListener;
			HttpListenerRequest request;
			HttpListenerResponse httpListenerResponse;
			for (;;)
			{
				httpListener = new HttpListener();
				string text = "handshake";
				text = "http://localhost:1337/" + text + "/";
				httpListener.Prefixes.Add(text);
				httpListener.Start();
				HttpListenerContext context = httpListener.GetContext();
				request = context.Request;
				httpListenerResponse = context.Response;
				httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
				httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
				httpListenerResponse.AddHeader("Via", "hugzho's big brain");
				httpListenerResponse.AddHeader("Location", "your kernel ;)");
				httpListenerResponse.AddHeader("Retry-After", "never lmao");
				httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
				if (!(request.HttpMethod == "OPTIONS"))
				{
					break;
				}
				httpListenerResponse.StatusCode = 200;
				Thread.Sleep(1);
				httpListener.Stop();
			}
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			string text2 = request.RawUrl.Replace("/handshake?user=", "").Replace("&token=", " ");
			string value2 = text2.Split(Array.Empty<char>())[0];
			string value3 = text2.Split(new char[]
			{
				' '
			})[1];
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = value2;
			nameValueCollection["token"] = value3;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			bool flag = true;
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
				httpListenerResponse.StatusCode = 420;
				httpListenerResponse.StatusDescription = "SHEESH";
			}
			else
			{
				Console.WriteLine(response_structure.message);
				httpListenerResponse.StatusCode = 200;
				httpListenerResponse.StatusDescription = response_structure.message;
				flag = false;
			}
			byte[] bytes = Encoding.UTF8.GetBytes("Whats up?");
			httpListenerResponse.ContentLength64 = (long)bytes.Length;
			httpListenerResponse.OutputStream.Write(bytes, 0, bytes.Length);
			Thread.Sleep(1);
			httpListener.Stop();
			if (!flag)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000029CC File Offset: 0x00000BCC
		public void button(string button)
		{
			this.CheckInit();
			HttpListener httpListener = new HttpListener();
			string uriPrefix = "http://localhost:1337/" + button + "/";
			httpListener.Prefixes.Add(uriPrefix);
			httpListener.Start();
			HttpListenerContext context = httpListener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse httpListenerResponse = context.Response;
			httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
			httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
			httpListenerResponse.AddHeader("Via", "hugzho's big brain");
			httpListenerResponse.AddHeader("Location", "your kernel ;)");
			httpListenerResponse.AddHeader("Retry-After", "never lmao");
			httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
			httpListenerResponse.StatusCode = 420;
			httpListenerResponse.StatusDescription = "SHEESH";
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			httpListener.Stop();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public void upgrade(string username, string key)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "upgrade";
			nameValueCollection["username"] = username;
			nameValueCollection["key"] = key;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002B44 File Offset: 0x00000D44
		public void license(string key)
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "license";
			nameValueCollection["key"] = key;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public void check()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "check";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002C68 File Offset: 0x00000E68
		public void setvar(string var, string data)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "setvar";
			nameValueCollection["var"] = var;
			nameValueCollection["data"] = data;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data2);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public string getvar(string var)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "getvar";
			nameValueCollection["var"] = var;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			string result;
			if (response_structure.success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002D88 File Offset: 0x00000F88
		public void ban(string reason = null)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "ban";
			nameValueCollection["reason"] = reason;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002E08 File Offset: 0x00001008
		public string var(string varid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "var";
			nameValueCollection["varid"] = varid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			string result;
			if (response_structure.success)
			{
				result = response_structure.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002E9C File Offset: 0x0000109C
		public List<api.users> fetchOnline()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "fetchOnline";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			List<api.users> result;
			if (response_structure.success)
			{
				result = response_structure.users;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002F24 File Offset: 0x00001124
		public void fetchStats()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "fetchStats";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002FAC File Offset: 0x000011AC
		public List<api.msg> chatget(string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatget";
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			List<api.msg> result;
			if (response_structure.success)
			{
				result = response_structure.messages;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003040 File Offset: 0x00001240
		public bool chatsend(string msg, string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatsend";
			nameValueCollection["message"] = msg;
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000030D4 File Offset: 0x000012D4
		public bool checkblack()
		{
			this.CheckInit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "checkblacklist";
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000316C File Offset: 0x0000136C
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "webhook";
			nameValueCollection["webid"] = webid;
			nameValueCollection["params"] = param;
			nameValueCollection["body"] = body;
			nameValueCollection["conttype"] = conttype;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			string result;
			if (response_structure.success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003228 File Offset: 0x00001428
		public byte[] download(string fileid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "file";
			nameValueCollection["fileid"] = fileid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			byte[] result;
			if (response_structure.success)
			{
				result = encryption.str_to_byte_arr(response_structure.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000032C4 File Offset: 0x000014C4
		public void log(string message)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "log";
			nameValueCollection["pcuser"] = Environment.UserName;
			nameValueCollection["message"] = message;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			api.req(nameValueCollection);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003340 File Offset: 0x00001540
		public void changeUsername(string username)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "changeUsername";
			nameValueCollection["newUsername"] = username;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req(nameValueCollection);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(data);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000033C0 File Offset: 0x000015C0
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003430 File Offset: 0x00001630
		public static void error(string message)
		{
			string path = "Logs";
			string text = Path.Combine(path, "ErrorLogs.txt");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (!File.Exists(text))
			{
				using (File.Create(text))
				{
					File.AppendAllText(text, DateTime.Now.ToString() + " > This is the start of your error logs file");
				}
			}
			File.AppendAllText(text, DateTime.Now.ToString() + " > " + message + Environment.NewLine);
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003514 File Offset: 0x00001714
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Proxy = null;
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(api.assertSSL));
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.2/", post_data);
					stopwatch.Stop();
					api.responseTime = stopwatch.ElapsedMilliseconds;
					api.sigCheck(Encoding.Default.GetString(bytes), webClient.ResponseHeaders["signature"], post_data.Get(0));
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode != HttpStatusCode.TooManyRequests)
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000361C File Offset: 0x0000181C
		private static bool assertSSL(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool result;
			if ((!certificate.Issuer.Contains("Cloudflare Inc") && !certificate.Issuer.Contains("Google Trust Services") && !certificate.Issuer.Contains("Let's Encrypt")) || sslPolicyErrors > SslPolicyErrors.None)
			{
				api.error("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. & echo: & echo If not, ask the developer of the program to use custom domains to fix this.");
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000367C File Offset: 0x0000187C
		private static void sigCheck(string resp, string signature, string type)
		{
			if (!(type == "log") && !(type == "file"))
			{
				try
				{
					if (!encryption.CheckStringsFixedTime(encryption.HashHMAC((type == "init") ? api.enckey.Substring(17, 64) : api.enckey, resp), signature))
					{
						api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
						Environment.Exit(0);
					}
				}
				catch
				{
					api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
					Environment.Exit(0);
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000371C File Offset: 0x0000191C
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003780 File Offset: 0x00001980
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000037F3 File Offset: 0x000019F3
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public string ownerid;

		// Token: 0x04000003 RID: 3
		public string secret;

		// Token: 0x04000004 RID: 4
		public string version;

		// Token: 0x04000005 RID: 5
		public string path;

		// Token: 0x04000006 RID: 6
		public static long responseTime;

		// Token: 0x04000007 RID: 7
		private static string sessionid;

		// Token: 0x04000008 RID: 8
		private static string enckey;

		// Token: 0x04000009 RID: 9
		private bool initialized;

		// Token: 0x0400000A RID: 10
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x0400000B RID: 11
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000C RID: 12
		public api.response_class response = new api.response_class();

		// Token: 0x0400000D RID: 13
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x0200000E RID: 14
		[Nullable(0)]
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000015 RID: 21
			// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000C77F File Offset: 0x0000A97F
			// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000C787 File Offset: 0x0000A987
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000C790 File Offset: 0x0000A990
			// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000C798 File Offset: 0x0000A998
			[DataMember]
			public bool newSession { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000C7A1 File Offset: 0x0000A9A1
			// (set) Token: 0x060000A6 RID: 166 RVA: 0x0000C7A9 File Offset: 0x0000A9A9
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000C7B2 File Offset: 0x0000A9B2
			// (set) Token: 0x060000A8 RID: 168 RVA: 0x0000C7BA File Offset: 0x0000A9BA
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x060000A9 RID: 169 RVA: 0x0000C7C3 File Offset: 0x0000A9C3
			// (set) Token: 0x060000AA RID: 170 RVA: 0x0000C7CB File Offset: 0x0000A9CB
			[DataMember]
			public string response { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000AB RID: 171 RVA: 0x0000C7D4 File Offset: 0x0000A9D4
			// (set) Token: 0x060000AC RID: 172 RVA: 0x0000C7DC File Offset: 0x0000A9DC
			[DataMember]
			public string message { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000AD RID: 173 RVA: 0x0000C7E5 File Offset: 0x0000A9E5
			// (set) Token: 0x060000AE RID: 174 RVA: 0x0000C7ED File Offset: 0x0000A9ED
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x060000AF RID: 175 RVA: 0x0000C7F6 File Offset: 0x0000A9F6
			// (set) Token: 0x060000B0 RID: 176 RVA: 0x0000C7FE File Offset: 0x0000A9FE
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000C807 File Offset: 0x0000AA07
			// (set) Token: 0x060000B2 RID: 178 RVA: 0x0000C80F File Offset: 0x0000AA0F
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000C818 File Offset: 0x0000AA18
			// (set) Token: 0x060000B4 RID: 180 RVA: 0x0000C820 File Offset: 0x0000AA20
			[DataMember]
			public List<api.msg> messages { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x060000B5 RID: 181 RVA: 0x0000C829 File Offset: 0x0000AA29
			// (set) Token: 0x060000B6 RID: 182 RVA: 0x0000C831 File Offset: 0x0000AA31
			[DataMember]
			public List<api.users> users { get; set; }
		}

		// Token: 0x0200000F RID: 15
		[Nullable(0)]
		public class msg
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000C842 File Offset: 0x0000AA42
			// (set) Token: 0x060000B9 RID: 185 RVA: 0x0000C84A File Offset: 0x0000AA4A
			public string message { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060000BA RID: 186 RVA: 0x0000C853 File Offset: 0x0000AA53
			// (set) Token: 0x060000BB RID: 187 RVA: 0x0000C85B File Offset: 0x0000AA5B
			public string author { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000BC RID: 188 RVA: 0x0000C864 File Offset: 0x0000AA64
			// (set) Token: 0x060000BD RID: 189 RVA: 0x0000C86C File Offset: 0x0000AA6C
			public string timestamp { get; set; }
		}

		// Token: 0x02000010 RID: 16
		[Nullable(0)]
		public class users
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000BF RID: 191 RVA: 0x0000C87D File Offset: 0x0000AA7D
			// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000C885 File Offset: 0x0000AA85
			public string credential { get; set; }
		}

		// Token: 0x02000011 RID: 17
		[Nullable(0)]
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000C896 File Offset: 0x0000AA96
			// (set) Token: 0x060000C3 RID: 195 RVA: 0x0000C89E File Offset: 0x0000AA9E
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000C4 RID: 196 RVA: 0x0000C8A7 File Offset: 0x0000AAA7
			// (set) Token: 0x060000C5 RID: 197 RVA: 0x0000C8AF File Offset: 0x0000AAAF
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
			// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000C8C0 File Offset: 0x0000AAC0
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000C8C9 File Offset: 0x0000AAC9
			// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000C8D1 File Offset: 0x0000AAD1
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000CA RID: 202 RVA: 0x0000C8DA File Offset: 0x0000AADA
			// (set) Token: 0x060000CB RID: 203 RVA: 0x0000C8E2 File Offset: 0x0000AAE2
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000CC RID: 204 RVA: 0x0000C8EB File Offset: 0x0000AAEB
			// (set) Token: 0x060000CD RID: 205 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000012 RID: 18
		[Nullable(0)]
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000CF RID: 207 RVA: 0x0000C904 File Offset: 0x0000AB04
			// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000C90C File Offset: 0x0000AB0C
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000C915 File Offset: 0x0000AB15
			// (set) Token: 0x060000D2 RID: 210 RVA: 0x0000C91D File Offset: 0x0000AB1D
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000C926 File Offset: 0x0000AB26
			// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000C92E File Offset: 0x0000AB2E
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000C937 File Offset: 0x0000AB37
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000C93F File Offset: 0x0000AB3F
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000C948 File Offset: 0x0000AB48
			// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000C950 File Offset: 0x0000AB50
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000C959 File Offset: 0x0000AB59
			// (set) Token: 0x060000DA RID: 218 RVA: 0x0000C961 File Offset: 0x0000AB61
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000013 RID: 19
		[Nullable(0)]
		public class app_data_class
		{
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000DC RID: 220 RVA: 0x0000C972 File Offset: 0x0000AB72
			// (set) Token: 0x060000DD RID: 221 RVA: 0x0000C97A File Offset: 0x0000AB7A
			public string numUsers { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000DE RID: 222 RVA: 0x0000C983 File Offset: 0x0000AB83
			// (set) Token: 0x060000DF RID: 223 RVA: 0x0000C98B File Offset: 0x0000AB8B
			public string numOnlineUsers { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000C994 File Offset: 0x0000AB94
			// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000C99C File Offset: 0x0000AB9C
			public string numKeys { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000C9A5 File Offset: 0x0000ABA5
			// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000C9AD File Offset: 0x0000ABAD
			public string version { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000C9B6 File Offset: 0x0000ABB6
			// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000C9BE File Offset: 0x0000ABBE
			public string customerPanelLink { get; set; }

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000C9C7 File Offset: 0x0000ABC7
			// (set) Token: 0x060000E7 RID: 231 RVA: 0x0000C9CF File Offset: 0x0000ABCF
			public string downloadLink { get; set; }
		}

		// Token: 0x02000014 RID: 20
		[Nullable(0)]
		public class user_data_class
		{
			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060000E9 RID: 233 RVA: 0x0000C9E0 File Offset: 0x0000ABE0
			// (set) Token: 0x060000EA RID: 234 RVA: 0x0000C9E8 File Offset: 0x0000ABE8
			public string username { get; set; }

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000EB RID: 235 RVA: 0x0000C9F1 File Offset: 0x0000ABF1
			// (set) Token: 0x060000EC RID: 236 RVA: 0x0000C9F9 File Offset: 0x0000ABF9
			public string ip { get; set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060000ED RID: 237 RVA: 0x0000CA02 File Offset: 0x0000AC02
			// (set) Token: 0x060000EE RID: 238 RVA: 0x0000CA0A File Offset: 0x0000AC0A
			public string hwid { get; set; }

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060000EF RID: 239 RVA: 0x0000CA13 File Offset: 0x0000AC13
			// (set) Token: 0x060000F0 RID: 240 RVA: 0x0000CA1B File Offset: 0x0000AC1B
			public string createdate { get; set; }

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000CA24 File Offset: 0x0000AC24
			// (set) Token: 0x060000F2 RID: 242 RVA: 0x0000CA2C File Offset: 0x0000AC2C
			public string lastlogin { get; set; }

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000CA35 File Offset: 0x0000AC35
			// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000CA3D File Offset: 0x0000AC3D
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000015 RID: 21
		[Nullable(0)]
		public class Data
		{
			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000CA4E File Offset: 0x0000AC4E
			// (set) Token: 0x060000F7 RID: 247 RVA: 0x0000CA56 File Offset: 0x0000AC56
			public string subscription { get; set; }

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000CA5F File Offset: 0x0000AC5F
			// (set) Token: 0x060000F9 RID: 249 RVA: 0x0000CA67 File Offset: 0x0000AC67
			public string expiry { get; set; }

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x060000FA RID: 250 RVA: 0x0000CA70 File Offset: 0x0000AC70
			// (set) Token: 0x060000FB RID: 251 RVA: 0x0000CA78 File Offset: 0x0000AC78
			public string timeleft { get; set; }
		}

		// Token: 0x02000016 RID: 22
		[Nullable(0)]
		public class response_class
		{
			// Token: 0x1700003F RID: 63
			// (get) Token: 0x060000FD RID: 253 RVA: 0x0000CA89 File Offset: 0x0000AC89
			// (set) Token: 0x060000FE RID: 254 RVA: 0x0000CA91 File Offset: 0x0000AC91
			public bool success { get; set; }

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060000FF RID: 255 RVA: 0x0000CA9A File Offset: 0x0000AC9A
			// (set) Token: 0x06000100 RID: 256 RVA: 0x0000CAA2 File Offset: 0x0000ACA2
			public string message { get; set; }
		}
	}
}

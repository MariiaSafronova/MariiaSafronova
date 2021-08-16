using MailKit.Net.Imap;
using TestKaspersky.Utils;
using MailKit;
using Aquality.Selenium.Browsers;
using System.Text.RegularExpressions;

namespace TestKaspersky
{
	public class WorkWithMail
	{
		public static bool IfMessageReceived()
		{
			using (var client = new ImapClient())
			{
				AqualityServices.Logger.Info("Connect IMAP server");
				client.Connect("imap.yandex.ru", 993, true);
				AqualityServices.Logger.Info("Do authentification on IMAP server");
				client.Authenticate("","");
				var inbox = client.Inbox;
				inbox.Open(FolderAccess.ReadWrite);				
				for (int i = 0; i < inbox.Count; i++)
				{
					var message = inbox.GetMessage(i);
					if (message.From.ToString().Contains("kaspersky") && Regex.IsMatch(message.TextBody, Constants.DownloadLinkRegex))
					{
						inbox.AddFlags(i, MessageFlags.Deleted, true);
						inbox.Expunge();
						return true;
					}					
				}
				client.Disconnect(true);
				return false;				
			}
		}
	}
}
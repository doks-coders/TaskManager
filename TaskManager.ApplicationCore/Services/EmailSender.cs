using Microsoft.AspNetCore.Identity.UI.Services;

namespace TaskManager.ApplicationCore.Services;

public class EmailSender : IEmailSender
{
	public async Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		//throw new NotImplementedException();
	}
}

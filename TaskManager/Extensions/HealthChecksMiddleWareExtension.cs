using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NuGet.Protocol;
using System.Net.Mime;

namespace TaskManager.Extensions;

public static class HealthChecksMiddleWareExtension
{
	public static WebApplication UseHealthMiddleware(this WebApplication app)
	{
		app.UseHealthChecks("/health",
		new HealthCheckOptions
		{
			ResponseWriter = async (context, report) =>
			{
				var result = new
				{
					status = report.Status.ToString(),
					errors = report.Entries.Select(e => new
					{
						key = e.Key,
						value = Enum.GetName(typeof(HealthStatus), e.Value.Status)
					})
				}.ToJson();
				context.Response.ContentType = MediaTypeNames.Application.Json;
				await context.Response.WriteAsync(result);
			}
		});
		return app;
	}
}

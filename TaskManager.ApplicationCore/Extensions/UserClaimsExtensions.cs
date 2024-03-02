using System.Security.Claims;

namespace TaskManager.ApplicationCore.Extensions;

public static class UserClaimsExtensions
{
	/// <summary>
	/// This extension gets the username from the ClaimsPrincipal
	/// </summary>
	/// <param name="claims"></param>
	/// <returns></returns>
	public static string? GetUserName(this ClaimsPrincipal claims)
	{
		return claims.FindFirstValue(ClaimTypes.Name);
	}
	/// <summary>
	/// This extension gets the user Id from the ClaimsPrincipal
	/// </summary>
	/// <param name="claims"></param>
	/// <returns></returns>
	public static string? GetUserId(this ClaimsPrincipal claims)
	{
		return claims.FindFirstValue(ClaimTypes.NameIdentifier);
	}

}

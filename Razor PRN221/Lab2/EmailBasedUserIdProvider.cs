using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

internal class EmailBasedUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst(ClaimTypes.Email)?.Value!;
    }
}
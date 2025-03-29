using AAuthentic.Application.Interfaces;

namespace AAuthentic.Application.DTOs;

public class Tokens : ITokens
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
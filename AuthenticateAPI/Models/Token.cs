﻿namespace AuthenticateAPI.Models;

public class Token
{
    public int Id { get; private set; }
    public string? TokenValue { get; private set; }
    public bool TokenRevoked { get; private set; }
    public bool TokenExpired { get; private set; }
    public TokenType TokenType { get; private set; }
    public string? UserId { get; set; } 
    public User? User { get; set; }

    public void SetId(int id) => Id = id;
    public void SetTokenValue(string? tokenValue) => TokenValue = tokenValue;
    public void SetTokenRevoked(bool tokenRevoked) => TokenRevoked = tokenRevoked;
    public void SetTokenExpired(bool tokenExpired) => TokenExpired = tokenExpired;
    public void SetTokenType(TokenType tokenType) => TokenType = tokenType;
}
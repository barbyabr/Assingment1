namespace Domain.DTOs;

public class UserLoginDto
{
    public string Username { get; init; } // init; is a specific kind of set; g you can only set this values, when the object is created, but not later modify it. (nie trzeba tak można użyć set ale dobra metoda)
    public string Password { get; init; }
}
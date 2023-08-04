using Microsoft.AspNetCore.Authorization;

namespace LoginSimulator.Authorization;

public class MinimalAge : IAuthorizationRequirement
{
    public MinimalAge(int age)
    {
        Age = age;
    }

    public int Age { get; set; }
}

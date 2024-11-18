
class Admin
{
    // Data fields
    public string Fullname { get; set; }
    public Guid AdminId { get; set; }
    public string AdminPassword { get; set; }

    public bool IsAdmin { get; set; } = true;

private static string CreateRandomPassword(int length = 15)
{
    // Define what character that can be used in the password:
    string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
    // simplify the syntax of new Random():
    Random random = new Random();

    // Define chars that is of type characters in an array, set it to be a new array of characters with length of the parameter length
    char[] chars = new char[length];
    // run a standard for loop that runs with the parameter length:
    for (int i = 0; i < length; i++)
    {
        // for each looping it will add a random character to the array:
        chars[i] = validChars[random.Next(0, validChars.Length)];
    }
    // return the array as a string
    return new string(chars);
}

    // Configuration
    public Admin(string fullname)
    {
        Fullname = fullname;
        AdminId = Guid.NewGuid();
        AdminPassword = CreateRandomPassword();
        IsAdmin = true;
    }

}
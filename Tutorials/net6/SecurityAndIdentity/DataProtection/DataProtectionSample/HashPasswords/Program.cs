using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

string? password = string.Empty;
do
{
    Console.WriteLine("请输入密码!");
    password = Console.ReadLine();

} while (string.IsNullOrEmpty(password));


byte[] salt = new byte[128 / 8];

//using (var rngCsp = new RNGCryptoServiceProvider())
//{
//    rngCsp.GetNonZeroBytes(salt);
//}

using (var rngCsp = RandomNumberGenerator.Create())
{
    rngCsp.GetNonZeroBytes(salt);
}

Console.WriteLine($"Salt:{Convert.ToBase64String(salt)}");

string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
    password: password,
    salt: salt,
    prf: KeyDerivationPrf.HMACSHA256,
    iterationCount: 100000,
    numBytesRequested: 256 / 8));

Console.WriteLine($"hashPassword is :{hashed}");
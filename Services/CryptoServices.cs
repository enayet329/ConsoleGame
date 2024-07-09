using System.Security.Cryptography;

using test.IGameRepo;

namespace test.Services
{
    public class CryptoServices : ICryptoServicesProvider
    {

        public byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var key = new byte[32];
                rng.GetBytes(key);
                return key;
            }
        }

        public string CalculateHMAC(string message, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                var messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var hashBytes = hmac.ComputeHash(messageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

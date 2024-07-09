

namespace test.IGameRepo
{
    internal interface ICryptoServicesProvider
    {
        byte[] GenerateKey();
        string CalculateHMAC(String message, byte[] key);
    }
}

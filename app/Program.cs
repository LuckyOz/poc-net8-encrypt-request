
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        var jsonContent = File.ReadAllText("rsa_key.json");
        var keys = JsonConvert.DeserializeObject<RSAKeyJson>(jsonContent);
        
        // var publicKey = @"-----BEGIN PUBLIC KEY-----
        //                 MIIBITANBgkqhkiG9w0BAQEFAAOCAQ4AMIIBCQKCAQB8GLhrHD6uW19wCuBHAYo+
        //                 YWJnt5HN3nLhX4QSL4sspLL+a6RrpwGDWladMopiPJ4rVHoGU7F3mIj7iiyBfhad
        //                 euIpa4z+z0Lfa4/KEG/v/Kd2HI0Jhh0di2yT3gojzJujvC3OIOJIUkeZAcYhl7id
        //                 UwSDvvyRTQLiRHA6FH1YlRKFQNMKmonBA7Zq1H2fRF/C73c+sGIiSO17K3g/7nw3
        //                 rBrDTB8ivUu6qovSTXJfmPMVY9Ix78Ga0D1DKz9RpNbv9l9V3rLITWc0vGYArzt/
        //                 mFBT1K5xsrljCh4HC8UlVXiKNXq4JGGHjSBnRHLbEw6n4afF+JDDHV6VBeIRLjT9
        //                 AgMBAAE=
        //                 -----END PUBLIC KEY-----";
        //
        // var privateKey = @"-----BEGIN RSA PRIVATE KEY-----
        //                 MIIEogIBAAKCAQB8GLhrHD6uW19wCuBHAYo+YWJnt5HN3nLhX4QSL4sspLL+a6Rr
        //                 pwGDWladMopiPJ4rVHoGU7F3mIj7iiyBfhadeuIpa4z+z0Lfa4/KEG/v/Kd2HI0J
        //                 hh0di2yT3gojzJujvC3OIOJIUkeZAcYhl7idUwSDvvyRTQLiRHA6FH1YlRKFQNMK
        //                 monBA7Zq1H2fRF/C73c+sGIiSO17K3g/7nw3rBrDTB8ivUu6qovSTXJfmPMVY9Ix
        //                 78Ga0D1DKz9RpNbv9l9V3rLITWc0vGYArzt/mFBT1K5xsrljCh4HC8UlVXiKNXq4
        //                 JGGHjSBnRHLbEw6n4afF+JDDHV6VBeIRLjT9AgMBAAECggEABlnVhlXJt26hscA8
        //                 viWMB6lAOgKhCaIqyvHydmPMgZpkNrUXkxLW9vv2ltDxWBm2Fo2aORyrZm1+BTGL
        //                 GY10ZtbVID2K17ePupNspnC06dlKULchWK1ubAaopeClMDPWe0i0J2pzajQbye7X
        //                 TvzOy+5lusBZeK4ySZYrEC3gRFo52IDD2vsaZYXS687W96hjiet2FnEY4ySZEjv0
        //                 NKOHtg3GYv2uH3SolGL37yysO0pW0oSt7HKnrs2aIKShjZu6wNIoa+HA9Dnqf73l
        //                 VVBg/1H6QZnEK+SBVJPzD/v903jy/StPKk1Slk1mnu1eylz0lMFLKQt4+hp23MY1
        //                 G7lTGQKBgQDoDotezfq6kXkvBjpm9MgAMZiNxZo3yo/fbZ4QouFLvml7lQkw7Q+X
        //                 I3APdh2ibN4mMvq8+9ZR/16/81c/LNbrn+FlfjwvcKCtR4Q22HgyThqZ6jewJgXa
        //                 kA+UbprkkmznuZaDIkUT6knG4zTJz63gFL6IqoA9SivDyynBMqm5MwKBgQCI5o6n
        //                 Fv+SE5a1EIIQEFrZ0dXrT+6t6WTGFvBKaVJ3pFkHO2Jx3O1b+M7+QeJPQ5eucN/Q
        //                 R04XajDYlHbd7lyfZukRzk9AyXzj7rdDNwtabY/pIC9nziR1Gu72mFxIkmQuCf71
        //                 75hncP6VyfooYL97E4dEyXJe9C2GFfPMdQA5DwKBgQDN98LaVebaW658/4Esys0N
        //                 5vdptl8IcAE9JbVrPLbNnOdRKlorE+6HjouzHXp2JT0UGKGWxcxXoVs+8kSZLTph
        //                 jtnnVKEk1km3I0gFyiL9O3e+7zWYYldFxCIf9AAFKrYBAyfFotA/Oe9b2WSMT4ob
        //                 3y2ybes++ytXMGcSNN6SIwKBgE8Kx0yEA9WEh9xNBrtdpgbjl56AjS9OdUfGEMD1
        //                 5I59joWVbPaO92DF3EWDJrZbMWWfeCoaMWVlg4RY2/SxXjsOwPzt4GZorzovJxKg
        //                 4mY4ogGY+qX1qKkQfu5T89xW4Y6PaOz4hEcdP3CeqFfN3GCkWtKFeQqH8wza+eOP
        //                 nixTAoGAU6UfG2f2Jd3J/aoUiHqc0ZBvY/7SeANWtj4XLg43JnT5TVnRJAic4boY
        //                 57MK0cZMsAfyAIpd+3hpYxF8jUQK4uunDyx72y/h9gsf2FIAWfn7WL+8RhH2LhWX
        //                 1J2/+qbg1stPSm1Tg7D9O8gZnoBvc8CV3Fd25FgLHXwwZ4D27nA=
        //                 -----END RSA PRIVATE KEY-----";

        var newModel = new expmodel()
        {
            Id = 1,
            Name = "Oz"
        };

        var convertNewModel = JsonConvert.SerializeObject(newModel);

        var dataEnrypt = EncryptAsymmetric(convertNewModel, keys.PublicKey);
        
        var dataDecrypt = DecryptAsymmetric(dataEnrypt, keys.PrivateKey);
        
        Console.WriteLine(dataEnrypt);
        Console.WriteLine(dataDecrypt);
    }
    
    public static string EncryptAsymmetric(string data, string publicKey)
    {
        var rsa = new RSACryptoServiceProvider();
        rsa.ImportFromPem(publicKey.ToCharArray());
        
        var keySize = rsa.KeySize / 8;
        var inputBlockSize = keySize - 42;
 
        var dataBytes = Encoding.UTF8.GetBytes(data);
        var encryptedData = Array.Empty<byte>();
 
        for (var i = 0; i < dataBytes.Length; i += inputBlockSize)
        {
            var block = new byte[Math.Min(inputBlockSize, dataBytes.Length - i)];
            Array.Copy(dataBytes, i, block, 0, block.Length);
 
            var encryptedBlock = rsa.Encrypt(block, false); // OAEP padding
            encryptedData = CombineArrays(encryptedData, encryptedBlock);
        }
 
        return Convert.ToBase64String(encryptedData);
    }
 
    public static string DecryptAsymmetric(string encrypted, string privateKey)
    {
        var rsa = new RSACryptoServiceProvider();
        rsa.ImportFromPem(privateKey.ToCharArray());
        
        var keySize = rsa.KeySize / 8;

        var encryptedData = Convert.FromBase64String(encrypted);
        var decryptedData = Array.Empty<byte>();
 
        for (var i = 0; i < encryptedData.Length; i += keySize)
        {
            var block = new byte[Math.Min(keySize, encryptedData.Length - i)];
            Array.Copy(encryptedData, i, block, 0, block.Length);
 
            var decryptedBlock = rsa.Decrypt(block, false); // OAEP padding true = oaep, false=pkcs1
            decryptedData = CombineArrays(decryptedData, decryptedBlock);
        }
 
        return Encoding.UTF8.GetString(decryptedData);
    }
 
    private static byte[] StringToByteArray(string hex)
    {
        var NumberChars = hex.Length;
        var bytes = new byte[NumberChars / 2];
        
        for (var i = 0; i < NumberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        
        return bytes;
    }
 
    private static byte[] CombineArrays(byte[] first, byte[] second)
    {
        var result = new byte[first.Length + second.Length];
        
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        
        return result;
    }

    public class expmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class RSAKeyJson
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}



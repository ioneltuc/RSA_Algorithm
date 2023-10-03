using RSA_Algorithm;

//Message
string message = "UTM sila";
int[] encryptedMessage = new int[message.Length];
string decryptedMessage = "";

PrimeNumbersFiller.Fill(10000);

var keysGenerator = new KeysGenerator();
keysGenerator.CalculateKeys();

Encryption.e = keysGenerator.GetKeyForEncryption();
Encryption.n = keysGenerator.GetN();

for (int i = 0; i < message.Length; i++)
{
    encryptedMessage[i] = Encryption.Encrypt(message[i]);
}

Console.Write($"\nMessage: {message}");
Console.Write("\nEncrypted message: ");
foreach (var item in encryptedMessage)
{
    Console.Write(item + " ");
}

Decryption.d = keysGenerator.GetKeyForDecryption();
Decryption.n = Encryption.n;

foreach (var item in encryptedMessage)
{
    decryptedMessage += (char)Decryption.Decrypt(item);
}

Console.WriteLine($"\nDecrypted message: {decryptedMessage}");
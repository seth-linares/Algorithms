using System.Numerics;

namespace AlgorithmLib;

public class RSA
{
    private static (BigInteger, BigInteger, BigInteger) Euclid(BigInteger a, BigInteger b)
    {       
        BigInteger j;
        BigInteger i;

        if(b == 0) { // base case
            return (a, 1, 0);
        }


        (BigInteger g, BigInteger i_1 , BigInteger j_1) = Euclid(b, (a % b + b) % b); // (a % b + b) % b is a way to get proper modulo functionality in C#

        i = j_1;
        j = i_1 - (a / b) * j_1;

        return (g, i, j);
    }

    private static BigInteger ModularExponentiation(BigInteger x, BigInteger y, BigInteger n) // y is d in the textbook it seems
    {
        BigInteger z;

        if(y == 0) {
            return 1;
        }

        else {
            
            if(y % 2 == 0) { // if y is even
                z = ModularExponentiation(x, y / 2, n); 
                return (z * z) % n; // get back z^2 % n
            }

            else {
                z = ModularExponentiation(x, (y-1) / 2, n);
                return (z * z * x) % n; // get back (z^2 * x) % n
            }
        }
    }

    public static BigInteger GeneratePrivateKey(BigInteger p, BigInteger q, BigInteger e) 
    {
        BigInteger R;


        R = (p - 1) * (q - 1); // Calculating the totient 

        (_, BigInteger I, _) = Euclid(e, R); // only need to grab the `i`/`I` because I is the modular inverse of e modulo R, which is the private exponent in RSA.
            
        return (I % R + R) % R; // fixed formatting for C#'s bad modulo
        
    }

    public static BigInteger Encrypt(BigInteger value, BigInteger e, BigInteger n)
    {
        return ModularExponentiation(value, e, n); // encrypt the value
    }

    public static BigInteger Decrypt(BigInteger value, BigInteger d, BigInteger n)
    {
        return ModularExponentiation(value, d, n); // decrypt the value
    }


}
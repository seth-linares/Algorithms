# Algorithm Description Document

Author: Seth Linares

Date: 12/11/23

## 1. Name
RSA Encryption

## 2. Abstract
The RSA algorithm is a form of public key cryptography that is widely used for encrypting and decrypting data to secure it for data transmission.


## 3. Methodology
The RSA algorithm, a secure method for encrypting and decrypting messages, involves several important steps and methods. Initially, two large prime numbers are chosen and multiplied to create a number called n. This n and another number e form the public key. The private key is another number d, found using a method called the Euclidean Algorithm. This algorithm helps find d such that it works with e in a special way according to modular arithmetic (a kind of arithmetic that deals with remainders). When someone wants to send an encrypted message, they first turn the message into a number. Then, using the RSA method Modular Exponentiation, they raise this number to the power of e and take the remainder when divided by n (the process is like locking the message). This result can only be reversed (or unlocked) by someone who knows d, the private key. To decrypt the message, the recipient uses the private key d in a similar modular exponentiation process, which reverses the encryption. This is secure because finding d from the public key (n, e) is extremely difficult without knowing the original prime numbers, this can be related to trying to figure out the exact ingredients of a cake just by tasting it. In summary, RSAs security lies in its use of large prime numbers and modular exponentiation, along with the Euclidean Algorithm for key generation. These methods work together to create a system where messages can be securely locked and only unlocked by the intended recipient.

## 4. Pseudocode

```
MODULAR-EXPONENTIATION(x, y, n)
    if y is 0
        return 1
    else
        if y % 2 is 0
            z = MODULAR-EXPONENTIATION(x, y / 2, n)
            return (z * z) % n
        else
            z = MODULAR-EXPONENTIATION(x, (y - 1) / 2, n)
            return (z * z * x) % n

```


## 5. Inputs & Outputs

Inputs:

* x: The base value to be exponentiated.

* y: The exponent used in the calculation.

* n: The modulus under which the exponentiation is performed.

Outputs:
* Returns the result of $x^y \mod n$, which is the modular exponentiation of x raised to the power y, reduced by modulus n.

## 6. Analysis Results

* Worst Case: $O(log(y))$

* Best Case: $\Omega(log(y))$

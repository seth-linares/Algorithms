# Algorithm Description Document

Author: Seth Linares

Date: 12/11/23

## 1. Name
Huffman Tree Compression

## 2. Abstract

Huffman encoding is a data compression algorithm that uses variable length encoding based on the frequency of characters and is used to optimize the overall size of the encoded data.

## 3. Methodology

The Huffman Tree Compression algorithm is a data compression technique that uses variable length encoding based on the frequency of characters, optimizing the overall size of the encoded data. The algorithm works by first creating a frequency profile of the characters in the text to be encoded. This profile is then used to build a Huffman Tree, which is a binary tree where each leaf node represents a character and the path from the root to the leaf represents the encoding of that character. The Huffman Tree is built by repeatedly combining the two nodes with the lowest frequency into a new node, until only one node remains. The Huffman Tree is then used to create an encoding map, which is a dictionary that maps each character to its encoding. The text is then encoded by replacing each character with its encoding. The encoded text can be decoded by traversing the Huffman Tree using the encoded text as a guide. Each time a 0 is encountered, the left child is taken, and each time a 1 is encountered, the right child is taken. When a leaf node is reached, the character represented by that leaf node is appended to the decoded text. The Huffman Tree is used for decoding because it is the only way to know which character each encoding represents.


## 4. Pseudocode

```
PROFILE(text)
    Initialize profile as an empty dictionary
    For each letter in text
        If letter not in profile
            Set profile[letter] = 0
        Increment profile[letter]
    Return profile

BUILD-TREE(profile)
    Initialize prioQueue as a new PriorityQueue
    For each (letter, count) in profile
        Create a new node with Letter = letter and Count = count
        Insert node into prioQueue with priority = count
    While prioQueue.Size() > 1
        left = prioQueue.Dequeue()
        right = prioQueue.Dequeue()
        Create parent node with Letter = '\0', Count = left.Count + right.Count
        Set parent.Left = left and parent.Right = right
        Insert parent into prioQueue with priority = parent.Count
    Return prioQueue.Dequeue()

BUILD-MAP(node, code, map)
    If node is null
        Return
    If node is a leaf (Left and Right are null)
        Set map[node.Letter] = code
    Else
        BUILD-MAP(node.Left, code + "0", map)
        BUILD-MAP(node.Right, code + "1", map)

CREATE-ENCODING-MAP(root)
    Initialize map as an empty dictionary
    BUILD-MAP(root, "", map)
    Return map

ENCODE(text, map)
    Initialize encoded as an empty string
    For each character ch in text
        Append map[ch] to encoded
    Return encoded

DECODE(encodedText, tree)
    Initialize decoded as an empty string
    Set current = tree
    For each bit in encodedText
        If bit is '0'
            current = current.Left
        Else
            current = current.Right
        If current is a leaf (Left and Right are null)
            Append current.Letter to decoded
            Reset current to tree
    Return decoded


```

## 5. Inputs & Outputs


Inputs:

* text: The text to be encoded or decoded.

* map: The encoding map to be used for encoding.

* encodedText: The text to be decoded.

* tree: The tree to be used for decoding.



Outputs:

* encoded: The encoded text.

* decoded: The decoded text.




## 6. Analysis Results

Encode Function:
* Worst Case: $O(n)$

* Best Case: $\Omega(n)$


Decode Function:
* Worst Case: $O(m*log(n))$

* Best Case: $\Omega(m*log(n))$



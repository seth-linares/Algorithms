using System.Collections.Generic;

namespace AlgorithmLib{
    public static class HuffmanTree {
        public class Node { // Node class for the Huffman Tree
            public char Letter { get; set; }
            public int Count { get; init; }
            public Node? Left;
            public Node? Right;
        }

        public static Dictionary<char, int> Profile(string text) { // Generates a frequency profile of characters in the text
            var profile = new Dictionary<char, int>();
            foreach (char letter in text) {
                if (!profile.ContainsKey(letter)) {
                    profile[letter] = 0;
                }
                profile[letter]++;
            }
            return profile;
        }

        public static Node BuildTree(Dictionary<char, int> profile) {
            var prioQueue = new PriorityQueue<Node>(); 
            foreach (var entry in profile) {
                var node = new Node { Letter = entry.Key, Count = entry.Value };
                prioQueue.Insert(node, entry.Value); // insert into prio queue
            }

            while (prioQueue.Size() > 1) { // size of prio queue
                var left = prioQueue.Dequeue(); // dequeue methods stored into left and right
                var right = prioQueue.Dequeue();

                var parent = new Node {
                    Letter = '\0', // non-letter marker for internal nodes
                    Count = left.Count + right.Count,
                    Left = left,
                    Right = right
                };
                prioQueue.Insert(parent, parent.Count); // Reinsert the combined node
            }

            return prioQueue.Dequeue(); // final node is the root of the Huffman Tree
        }

        private static void BuildMap(Node node, string code, Dictionary<char, string> map) { // Builds the encoding map from the Huffman Tree
            if (node == null) return;

            if (node.Left == null && node.Right == null && !node.Letter.Equals('\0')) { // If it's a leaf node, add character and its code to the map
                map[node.Letter] = code;
            } else {
                BuildMap(node.Left, code + "0", map);
                BuildMap(node.Right, code + "1", map);
            }
        }

        public static Dictionary<char, string> CreateEncodingMap(Node root) { // Creates the encoding map for each character in the tree
            var map = new Dictionary<char, string>();
            BuildMap(root, "", map);
            return map;
        }

        public static string Encode(string text, Dictionary<char, string> map) { // Encodes the input text using the Huffman encoding map
            var encoded = "";
            foreach (var ch in text) {
                encoded += map[ch];
            }
            return encoded;
        }

        public static string Decode(string encodedText, Node tree) { // Decodes the encoded text using the Huffman Tree
            var decoded = "";
            var current = tree;
            foreach (var bit in encodedText) {
                current = bit == '0' ? current.Left : current.Right;

                if (current.Left == null && current.Right == null) { // When a leaf node is reached, append the character to the decoded string
                    decoded += current.Letter;
                    current = tree; // Reset to start of tree for next character
                }
            }
            return decoded;
        }
    }
}

using System.Collections.Generic;

namespace AlgorithmLib {
    public static class StringMatcher
    {
        private static List<Dictionary<char, int>> BuildTable(string pattern, List<char> inputs) { // builds the transition table based on the given pattern and set of input characters
        
            var table = new List<Dictionary<char, int>>(); // initialize the table that will store the state transitions for each character
            for (int k = 0; k <= pattern.Length; k++) { // loop used to iterate over each prefix of the pattern including the empty prefix
            
                var map = new Dictionary<char, int>(); // initialize the map that will store the state transitions for the current prefix
                foreach (char letter in inputs) {
                
                    string pka = pattern.Substring(0, k) + letter; // create a string combining the current prefix and the input character
                    int i = Math.Min(k + 1, pattern.Length); // find the longest suffix of pka that is also a prefix of the pattern
                    while (!pka.EndsWith(pattern.Substring(0, i)) && i > 0) {
                    
                        i--;
                    }

                    map[letter] = i;
                }

                table.Add(map);
            }

            return table;
        }

        public static List<int> Match(string text, string pattern, List<char> inputs) { // matches the pattern against the given text using the transition table
        
            var table = BuildTable(pattern, inputs); // create our table of state transitions

            int matchState = pattern.Length; // the length of the pattern is the state we want to reach
            int state = 0;
            var results = new List<int>(); // list to store the indices where the pattern matches in the text

            for (int index = 0; index < text.Length; index++) {
            
                char currentChar = text[index];
                if (table[state].TryGetValue(currentChar, out int nextState)) { // try to move to the next state based on the current character
                    state = nextState;
                }

                else {
                
                    state = 0;
                    if (table[state].TryGetValue(currentChar, out nextState)) { // reset to initial state if the character doesn't lead to a next state
                        state = nextState;
                    }
                }

                if (state == matchState) { // check if the current state is the pattern matched
                    results.Add(index); // add the index where the pattern ends
                }
            }

            return results;
        }

    }
}

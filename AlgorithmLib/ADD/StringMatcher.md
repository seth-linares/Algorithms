# Algorithm Description Document

Author: Seth Linares        

Date: 12/11/23

## 1. Name

String Matcher

## 2. Abstract

An algorithm that is used to efficienly find all occurences of a pattern in a text.

## 3. Methodology

The "String Matcher" algorithm is designed for finding all occurences of a pattern in a text. The algorithm works in 2 phases. The first phase is to build a table often referred to as the "transition table." This table is constructed from the given pattern to match and a set of input characters. The transition table is then used to determine the next state of the algorithm given the current state and the next character in the text. The second phase is the matching phase. This is when the algorithm begins scanning the text, using the transition table to efficiently track the current state of the pattern match. The algorithm begins in the initial state, which is the empty string. The algorithm then reads the next character in the text and uses the table to determine the next state. If the next state is the final state, then the algorithm has found an occurence of the pattern in the text. If the next state is not the final state, then the algorithm continues to read the next character in the text and use the table to determine the next state. The algorithm continues this process until it reaches the end of the text. An important thing to note is that when building the table for the first time, the complexity is such that it will possibly require a significant amount of time. However, once the table is built, the matching phase is very efficient. This is because the table is built in a manner that it can be used to determine the next state of the algorithm in constant time. This means that the matching phase is $O(n)$, where $n$ is the length of the text. This design makes the algorithm particularly efficient for applications where the same pattern is repeatedly matched against different texts, as the transition table needs to be built only once. The main shortcomings of this algorithm are that if the pattern changes the table must be rebuilt and if you are only matching the pattern against a single text, then the table is not worth the time it takes to build it.

## 4. Pseudocode

```
BUILD-TABLE(pattern, inputs)
    table = new List<Dictionary<char, int>>()
    for k = 0 to pattern.Length
        map = new Dictionary<char, int>()
        for each letter in inputs
            pka = pattern.Substring(0, k) + letter
            i = Min(k + 1, pattern.Length)
            while not pka.EndsWith(pattern.Substring(0, i)) and i > 0
                i = i - 1
            map[letter] = i
        table.Add(map)
    return table

MATCH(text, pattern, inputs)
    table = BUILD-TABLE(pattern, inputs)
    matchState = pattern.Length
    state = 0
    results = new List<int>()
    for index = 0 to text.Length - 1
        currentChar = text[index]
        if table[state].TryGetValue(currentChar, nextState)
            state = nextState
        else
            state = 0
            if table[state].TryGetValue(currentChar, nextState)
                state = nextState
        if state == matchState
            results.Add(index)
    return results

```

## 5. Inputs & Outputs

List only inputs and outputs for the MATCH function. 

Inputs:

* text: The text to search for the pattern

* pattern: The pattern to search for in the text

* inputs: The set of characters that can appear in the text

Outputs:

* results: A list of the indices of the text where the pattern appears

## 6. Analysis Results

* Worst Case: $O(m^3*r + n)$

* Best Case: $\Omega(n)$


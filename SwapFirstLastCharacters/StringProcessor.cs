namespace SwapFirstLastCharacters
{
    public class StringProcessor
    {
        public string ProcessString(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = SwapFirstAndLastCharacter(words[i]);
            }
            return string.Join(" ", words);
        }

        private string SwapFirstAndLastCharacter(string word)
        {
            if (word.Length < 2)
            {
                return word; // nothing to swap
            }

            char firstChar = word[0];
            char lastChar = word[word.Length - 1];

            return lastChar + word.Substring(1, word.Length - 2) + firstChar;
        }
    }
}

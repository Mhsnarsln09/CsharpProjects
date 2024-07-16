namespace ConsonantCheckerApp
{
    public class ConsonantChecker
    {
        private static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        public bool HasConsecutiveConsonants(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (IsConsonant(word[i]) && IsConsonant(word[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsConsonant(char c)
        {
            return !vowels.Contains(c) && char.IsLetter(c);
        }
    }
}

namespace Library3
{
    public class WordFrequency
    {
        /// <summary>
        /// Возвращает строку с подсчитаной частотой каждого слова.
        /// </summary>
        /// <param name="text"> текст. </param>
        /// <returns></returns>
        public string CalulateFrequency(string text)
        {
            string result = "";
            var allWords = text.Split(' ', '.');
            var uniqueWords = new List<string>();
            int count = 0;
            foreach (var word in allWords)
            {
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                }
            }
            foreach (var uniqueWord in uniqueWords)
            {
                foreach (var textWord in allWords)
                {
                    if (textWord.Equals(uniqueWord))
                    {
                        count++;
                    }
                }
                result += uniqueWord + " - " + count + "\n";
                count = 0;
            }
            return result;
        }
    }
}
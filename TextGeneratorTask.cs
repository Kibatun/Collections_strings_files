using System;
using System.Collections.Generic;

/*
Описание алгоритма:

На вход алгоритму передается словарь nextWords, полученный в предыдущей задаче, одно или несколько первых слов фразы phraseBeginning
и wordsCount — количество слов, которые нужно дописать к phraseBeginning.

Словарь nextWords в качестве ключей содержит либо отдельные слова, либо пары слов, соединённые через пробел. По ключу key содержится слово,
которым нужно продолжать фразы, заканчивающиеся на key.

Алгоритм должен работать следующим образом:

Итоговая фраза должна начинаться с phraseBeginning.

К ней дописывается wordsCount слов таким образом:

a. Если фраза содержит как минимум два слова и в словаре есть ключ, состоящий из двух последних слов фразы, то продолжать нужно словом, из словаря по этому ключу.

b. Иначе, если в словаре есть ключ, состоящий из одного последнего слова фразы, то продолжать нужно словом, хранящемся в словаре по этому ключу.

c. Иначе, нужно досрочно закончить генерирование фразы и вернуть сгенерированный на данный момент результат.
*/
namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            List<string> result = new List<string>();
            string[] words = phraseBeginning.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
                result.Add(word);
            if (result.Count == 0)
                return phraseBeginning;
            while (wordsCount > 0)
            {
                if (result.Count == 1)
                {
                    if (!nextWords.ContainsKey(result[0]))
                        return phraseBeginning;
                    else
                        result.Add(nextWords[result[0]]);
                    wordsCount--;
                    continue;
                }
                if (result.Count >= 2)
                {
                    int lastWordIndex = result.Count - 1;
                    string singleKey = result[lastWordIndex];
                    string doubleKey = result[lastWordIndex - 1] + ' ' + singleKey;
                    if (nextWords.ContainsKey(doubleKey))
                        result.Add(nextWords[doubleKey]);
                    else if (nextWords.ContainsKey(singleKey))
                        result.Add(nextWords[singleKey]);
                    else
                        return String.Join(" ", result.ToArray());
                    wordsCount--;
                    continue;
                }
            }
            return String.Join(" ", result.ToArray());
        }
    }
}
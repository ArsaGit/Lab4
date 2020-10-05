using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = null;
            //text = ReadText();
            text = ReadTextFromFile();

            Console.WriteLine(text);

            var listOfListsOfWords = new List<List<string>>(GetListOfListsOfWords(text));
            ShowListListString(listOfListsOfWords);
            

        }
        //чтение с клавиатуры
        static string ReadText()
        {
            string text = null;
            do
            {
                string tmp=Console.ReadLine();
                text += tmp;
            } while (Console.ReadKey().Key!=ConsoleKey.Enter);
            return text;
        }
        // чтение из файла
        static string ReadTextFromFile(string fullPath=@"D:\C#\Lab4\text.txt")
        {
            using(FileStream fstream=File.OpenRead(fullPath))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                return textFromFile;
            }
        }
        //возвращает лист листов слов
        static List<List<string>> GetListOfListsOfWords(string text)
        {
            List<List<string>> listOfListsOfWords = new List<List<string>>();
            List<string> listOfSentences = new List<string>(GetListOfSentences(text));
            foreach (string sentence in listOfSentences)
            {
                listOfListsOfWords.Add(GetListOfWords(sentence));
            }
            return listOfListsOfWords;
        }
        //выделяет лист предложений из текста
        static List<string> GetListOfSentences(string text)
        {
            List<string> listOfSentences = new List<string>();
            string[] arrayStr = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' },StringSplitOptions.RemoveEmptyEntries);
            foreach (string senstence in arrayStr)
            {
                string s = senstence;
                s = s.Trim();
                listOfSentences.Add(s);
            }
            return listOfSentences;
        }
        //выделяет лист слов из предложения
        static List<string> GetListOfWords(string sentence)
        {
            var listOfWords = new List<string>();
            int i = 0;
            while (i < sentence.Length)
            {
                StringBuilder word = new StringBuilder(null);
                //int j = i;
                while (i < sentence.Length && (char.IsLetterOrDigit(sentence[i]) || sentence[i].Equals('\'')))
                {
                    word.Append(sentence[i]);
                    i++;
                }
                string wordStr = word.ToString();
                wordStr = wordStr.ToLower();
                if (!IsThereDigits(wordStr)) listOfWords.Add(wordStr);
                i++;
            }
            return listOfWords;
        }
        //есть ли в словах цифры
        static bool IsThereDigits(string word)
        {
            foreach(char ch in word)
            {
                if (char.IsDigit(ch)) return true;
            }
            return false;
        }
        //вывод списка списков слов
        static void ShowListListString(List<List<string>> listListString)
        {
            foreach (List<string> listString in listListString)
            {
                foreach (string word in listString)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}

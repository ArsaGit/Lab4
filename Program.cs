using System;
using System.Collections.Generic;
using System.IO;

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

            List<List<string>> listOfListsOfWords = new List<List<string>>(GetListOfListsOfWords(text));

            foreach(List<string> listOfWords in listOfListsOfWords)
            {
                foreach(string word in listOfWords)
                {
                    Console.WriteLine(word);
                }
            }


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
            List<string> listOfWords = new List<string>();
            for(int i=0;i<sentence.Length;i++)
            {
                string word = null;
                while(char.IsLetterOrDigit(sentence[i])||sentence[i]=='\'')
                {
                    word += sentence[i];
                    i++;
                }
                if(!IsThereDigits(word))listOfWords.Add(word);
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
    }
}

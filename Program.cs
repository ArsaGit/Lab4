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

            List<List<string>> listOfListsOfWords = new List<List<string>>();

            Console.WriteLine(text);
            

            List<string> sentence = new List<string>();
            string[] arr_s = text.Split(new char[] {'.', '!','?',';',':','(',')'});
            foreach(string s in arr_s)
            {
                sentence.Add(s);
            }

            Console.WriteLine("\nLIST:");
            foreach(string s in sentence)
            {
                Console.Write(s);
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

        static List<List<string>> GetListOfListsOfWords(string text)
        {
            List<List<string>> listOfListsOfWords = new List<List<string>>();
            List<string> listOfSentences = new List<string>(GetListOfSentences(text));
            foreach (string sentence in listOfSentences)
            {
                string word;

            }

            return listOfListsOfWords;
        }

        static List<string> GetListOfSentences(string text)
        {
            List<string> listOfSentences = new List<string>();
            string[] arrayStr = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' },StringSplitOptions.RemoveEmptyEntries);
            foreach (string senstence in arrayStr)
            {
                listOfSentences.Add(senstence);
            }
            return listOfSentences;
        }
    }
}

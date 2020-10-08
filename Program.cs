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
            Console.WriteLine("Введите текст:");
            string text = null;
            text = ReadText();
            //text = ReadTextFromFile();

            List<string> listOfSentences =new List<string>(GetListOfSentences(text));
            List<string> listOfUniqueWords = new List<string>(GetListOfUniqueWords(text));
            ShowNumberOfPunctuatioinMarks(text);

            ShowList(listOfSentences);

            ShowListOfUniqueWords(listOfUniqueWords);

            ShowLongestWord(listOfUniqueWords);
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
        static void ShowNumberOfPunctuatioinMarks(string text)
        {
            int n = 0;
            foreach(char ch in text)
            {
                if (ch == '.' || ch == '?' || ch == '!' || ch == ':' || ch == ';' || 
                    ch == ',' || ch == '-' || ch == '(' || ch == ')' || ch == '\"') n++;
            }
            for(int i=0;i<text.Length-2;i++)
            {
                if ((text[i] == '.' && text[i + 1] == '.' && text[i + 2] == '.')) n++;
            }
            Console.WriteLine($"Количество знаков препинания:{n}");
        }
        //выделяет лист предложений из текста
        static List<string> GetListOfSentences(string text)
        {
            List<string> listOfSentences = new List<string>();
            string[] arrayStr = text.Split(new string[] { ".", "!", "?","..."},StringSplitOptions.RemoveEmptyEntries);
            foreach (string senstence in arrayStr)
            {
                string s = senstence;
                s = s.Trim();
                if(!(s==""))listOfSentences.Add(s);
            }
            return listOfSentences;
        }
        //выделяет лист уникальных слов из текста
        static List<string> GetListOfUniqueWords(string text)
        {
            var listOfUniqueWords = new List<string>();
            text = text.ToLower();
            int i = 0;
            while (i < text.Length)
            {
                StringBuilder word = new StringBuilder(null);
                while (i < text.Length && (char.IsLetter(text[i]) || text[i].Equals('\'')))
                {
                    word.Append(text[i]);
                    i++;
                }
                string wordStr = word.ToString();
                
                if(wordStr!=""&&IsWordUnique(wordStr,listOfUniqueWords))listOfUniqueWords.Add(wordStr);
                i++;
            }
            return listOfUniqueWords;
        }
        //проверка на уникальность
        static bool IsWordUnique(string word,List<string> listOfUniqueWords)
        {
            bool isWordUnique = true;
            foreach (string w in listOfUniqueWords)
            {
                if (listOfUniqueWords.Contains(word)) isWordUnique = false;
            }
            return isWordUnique;
        }
        //вывод самого длинного слова и 5 пункт
        static void ShowLongestWord(List<string> list)
        {
            string longestWord="";
            foreach(string w in list)
            {
                if (w.Length> longestWord.Length) longestWord = w;
            }
            Console.WriteLine($"Самое длинное слово:{longestWord}");
            if (longestWord.Length % 2 == 0) Console.WriteLine(longestWord.Substring(longestWord.Length / 2));
            else
            {
                string str = longestWord.Remove(longestWord.Length/2,1).Insert(longestWord.Length / 2,"*");
                Console.WriteLine(str);
            }
        }
        //вывод листа строк
        static void ShowList(List<string> list)
        {
            Console.WriteLine("Предложения:");
            foreach(string s in list)
            {
                Console.WriteLine(s);
            }
        }
        //вывод листа уникальных слов
        static void ShowListOfUniqueWords(List<string> list)
        {
            Console.WriteLine("Уникальные слова:");
            for(int i=0;i<list.Count;i++)
            {
                Console.Write(list[i]);
                if(i<list.Count-1)Console.Write(',');
            }
            Console.Write('\n');
        }
    }
}

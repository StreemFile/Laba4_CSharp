using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            // One();
            // Three();
            Two();
            // Four();
        }

        static void One()
        {
            // OneOne();
            // OneTwo();
            // OneThree();
            // OneFour();
        }

        static void OneOne()
        {
            Console.WriteLine("Введіть ім'я: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Hello " + name + "!");   
        }

        static void OneTwo()
        {
            Console.WriteLine("Введіть перший рядок: ");
            string first = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введіть другий рядок: ");
            string second = Convert.ToString(Console.ReadLine());

            string third = first.Substring(0, 2);
            third += second.Substring(second.Length - 1, 1);
            
            Console.WriteLine(third);

        }

        static void OneThree()
        {
            string apple = "яблуко";
            apple = apple.Trim(new char[] {'я','у','к','о'});
            apple = String.Concat(apple,"ок");
            Console.WriteLine(apple);
        }
        
        static void OneFour()
        {
            Console.WriteLine("Введіть рядок з пробілами: ");
            string toReplace = Convert.ToString(Console.ReadLine());
            toReplace = toReplace.Replace(" ", "_");
            Console.WriteLine(toReplace);
        }

        static void Two()
        {
            Console.WriteLine("Введіть текст: ");
            string text = Convert.ToString(Console.ReadLine());
            
            
            
            List<string> words = new List<string>(text.Split(" "));

            for (int i = 0; i < words.Count; i++)
            {
                if ((words[i].Length != 11)
                    || (words[i][2] != '.' || words[i][5] != '.' || words[i][10] != '.')
                    || (Convert.ToInt32(Convert.ToString(words[i][0]) + Convert.ToString(words[i][1])) > 31) 
                    || (Convert.ToInt32(Convert.ToString(words[i][0]) + Convert.ToString(words[i][1])) < 1)
                    || (Convert.ToInt32(Convert.ToString(words[i][3]) + Convert.ToString(words[i][4])) > 12)
                    || (Convert.ToInt32(Convert.ToString(words[i][3]) + Convert.ToString(words[i][4])) < 1)
                    || (Convert.ToInt32(Convert.ToString(words[i][6]) + Convert.ToString(words[i][7]) + Convert.ToString(words[i][8]) + Convert.ToString(words[i][9])) < 1900)
                    || (Convert.ToInt32(Convert.ToString(words[i][6]) + Convert.ToString(words[i][7]) + Convert.ToString(words[i][8]) + Convert.ToString(words[i][9])) > 2099))
                {
                    words.Remove(words[i]);
                    i--;
                }
            }
            
            Console.WriteLine("У тексті всього " + words.Count + " дат (-a, -и).");
            
            text = text.Replace("31.02.", "28.02.");
            text = text.Replace("30.02.", "28.02.");
            
            for (int i = 0; i < words.Count; i++)
            {
                string yearToCheck = Convert.ToString(words[i][6]) 
                                  + Convert.ToString(words[i][7]) 
                                  + Convert.ToString(words[i][8]) 
                                  + Convert.ToString(words[i][9]);
                if(Convert.ToInt32(yearToCheck) > 2021)
                {
                    string toDelete = Convert.ToString(words[i][0])
                                      + Convert.ToString(words[i][1])
                                      + Convert.ToString(words[i][2])
                                      + Convert.ToString(words[i][3])
                                      + Convert.ToString(words[i][4])
                                      + Convert.ToString(words[i][5])
                                      + yearToCheck
                                      + Convert.ToString(words[i][10]);
                    text = text.Replace(toDelete, "");
                }
            }

            Console.WriteLine("Змінений текст: ");
            Console.WriteLine(text);

        }
        static void Three()
        {
            Console.WriteLine("Введіть рядок: ");
            string text = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("Введіть слово яке потрібно знайти: ");
            string searchedWord = Convert.ToString(Console.ReadLine());
            // Console.WriteLine(text.Contains(searchedWord) 
            //     ? "Слоово " + searchedWord + " є в тексті"
            //     : "Слоово " + searchedWord + " немає в тексті");
           
            Regex rgx = new Regex("[^a-zA-Zа-яА-Я ]");
            text = rgx.Replace(text, "");
            text = text.ToLower();
            
            string[]  words = text.Split(" ");
            
            bool isInText = false;

            foreach (string word in words)
            {
                if (word.Equals(searchedWord))
                {
                    isInText = true;
                    break;
                }
            }

            Console.WriteLine(isInText
                ? "Слоово " + searchedWord + " є в тексті"
                : "Слоово " + searchedWord + " немає в тексті");
        }
        
        static void Four()
        {
            Console.WriteLine("Введіть перший рядок: ");
            string first = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введіть другий рядок: ");
            string second = Convert.ToString(Console.ReadLine());

            Regex rgx = new Regex("[^a-zA-Zа-яА-ЯҐЄІЇґєії ]");
            second = rgx.Replace(second, "").ToLower();

            string[] words = second.Split(" ");
            
            foreach (string word in words)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (Char.ToLower(first[i]) == Char.ToLower(word[0]))
                    {
                        bool isInText = true;
                        int k = i;
                        for (int j = 0; j < word.Length && k < first.Length; j++)
                        {
                            try
                            {
                                if (j == word.Length - 1 && Char.IsLetter(first[k + 1]))
                                {
                                    isInText = false;
                                    break;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                isInText = true;
                            }

                            try
                            {
                                if (k == first.Length - 1 && Char.IsLetter(word[j + 1]))
                                {
                                    isInText = false;
                                    break;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                isInText = true;
                            }

                            if (Char.ToLower(first[k]) != Char.ToLower(word[j]))
                            {
                                isInText = false;
                                break;
                            }
                            k++;
                        }

                        if (isInText)
                        {
                            first = first.Remove(i,word.Length);
                        }
                    }
                }
            }
            Console.WriteLine(first);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    /* p194
     * la soluzione ideale impiega solo due passaggi (a parte la lungezza che era fornita)
     * il secondo passaggio di ordinamento viene fatto usando due indici uno per la posizione di lettura ed uno per quella 
     * di scrittura.
     * la stringa viene riscritta all'indietro come avevo prevvisto
     */
    public class Program
    {
        public static void Main()
        {
            var s = "Hello World! How are you?          ".ToCharArray();

            Console.WriteLine(Urlify(s));
        }
        /*
    l lughezza array
    s lungezza stringa
    */
        public static char[] Urlify(char[] text) //TODO l'esercizio forniva già la lungezza della stringa, non serviva calcolarla
        {
            int strI = FindLastCharacter(text);

            if (strI == -1)
                return text;

            int spaces = CountSpaces(text, strI);

            SpaceWords(text, spaces, strI);
            InsertEncoding(text, strI,spaces);
            return text;
        }

        // O(l - s)
        private static int FindLastCharacter(char[] text)
        {
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (text[i] == ' ')
                    continue;
                return i;
            }
            return -1;
        }

        // O(s)
        private static int CountSpaces(char[] text, int strI)
        {
            int spaces = 0;
            for (int i = strI; i >= 0; i--)
            {
                if (text[i] == ' ')
                    spaces++;
            }
            return spaces;
        }

        // O(s)
        private static void SpaceWords(char[] text, int spaces, int strI)
        {
            for (int i = strI; i >= 0; i--)
            {
                if (text[i] == ' ')
                    spaces--;
                else
                    MoveCharacter(text, spaces, i);
            }
        }

        private static void MoveCharacter(char[] text, int spaces, int index)
        {
            var np = index + spaces * 2;
            text[np] = text[index];
        }

        private static void InsertEncoding(char[] text, int strI, int spaces)
        {
            for (int i = 0; i < strI+spaces*2;i++)//TODO dimenticato una funzionalitá che avevo previsto
            {
                if (text[i] == ' ')
                {
                    text[i] = '%';
                    text[++i] = '2';
                    text[++i] = '0'; // TODO invertito l'operatore di incremento, ++i prima incremeta e poi valuta
                }
            }
        }
    }
}
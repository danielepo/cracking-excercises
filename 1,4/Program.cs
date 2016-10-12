
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4
{
	class Program
	{
		static void Main(string[] args)
		{
			var ex15 = new Ex1_5();
			Console.WriteLine(ex15.OneAway("hello world", "hello world!"));
			Console.WriteLine(ex15.OneAway("hello world", "helloworld"));
			Console.WriteLine(ex15.OneAway("hello world", "hallo world"));
			Console.WriteLine(ex15.OneAway("hello world", "hallo world!"));
			Console.WriteLine(ex15.OneAway("hello world", "helloorld!"));
			Console.WriteLine(ex15.OneAway("", " "));
			Console.WriteLine(ex15.OneAway(" ", "  "));
			Console.WriteLine(ex15.OneAway(" ", " "));
		}
	}
	/*
One Away
 add one, remove one, change one
 
two strings have to have all equals characters except for one:
 - add one -> second string has to have one character more
	"hello word" -> "hello word!"
 - removce one -> second string hat to have one character missing
	"hello word" -> "helloword"
 - change one -> same number of characters but one differnet
	"hello word" -> "hallo word"
	
two different solutions:
 - count the number of each character and they have to differ only by one in on spot
	runs one time for each string and then another on the count
 - swipe the strings with two differnt indexes. 
	- count the differences found, if more that 1 return false if none return false

	
bsically we have two pssibilities
 - the two strings have equal length
 - the two different lengths 
 
 this would simpify the search algorithm because in the first case i can count the differences and if they differ form 1 returns false
 in the second case i use the as the index the bigest so I don't have to guard for index out of range
*/

class Ex1_5
{
	public bool OneAway(string text1,string text2)
	{
		if(Math.Abs(text1.Length - text2.Length) > 1) 
			return false;
			
		if(text1.Length == text2.Length)
			return HandleEqualLenght(text1, text2);
		if(text1.Length > text2.Length)
			return HandleDifferentLength(text1, text2);
		else 
			return HandleDifferentLength(text2, text1);
	}
	
	private bool HandleEqualLenght(string text1, string text2)
	{
		var count = 0;
		for(var i = 0; i < text1.Length; i++)
		{	
			if(text1[i] != text2[i])
				count++;
		}
		
		if(count == 1)
			return true;
		return false;
	}
	
	private bool HandleDifferentLength(string long_, string short_)
	{
		var count = 0;
		var j = 0;
		
		for(var i = 0; i<long_.Length;i++)//todo invertito l'ordine di lettura degli array
		{
			if (j == short_.Length) // todo dimenticato di controllare di non sforare l'array
				return true;
			if(long_[i] == short_[j])//todo confronto errato
			{
				++j;
				continue;
			}
			++i;
			if (i == long_.Length) // forgot   
				return false;
			if (long_[i] == short_[j])
			{
					
				count++;// todo dimenticato di aggiornare un indice
			}
			else
				return false;
		
			++j;
		}
		
		if(count == 1)
			return true;
		return false;
	}
}


}

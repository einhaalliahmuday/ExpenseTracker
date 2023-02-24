using System;
using System.Collections.Generic;

namespace SPClass
{
	class FinalProject 
	{
		static List <string> category = new List <string>();
		static List <int> amount = new List <int> ();
		static char input;
		static string date;
		static int index, budget;
		
		static void Main(string[] args)
		{	
			Console.WriteLine("	DAILY EXPENDITURE	");
			
			Console.WriteLine();
			
			Console.Write("Date (mm/dd/yyyy): ");
			date = Console.ReadLine();
			Console.Write("Budget: ");
			budget = Convert.ToInt32(Console.ReadLine());
			
			ShowMainMenu();
			input = GetUserInput();
			
			do 
			{
				Console.WriteLine();
				
				switch (input)
				{
					case '1':
						AddExpense();
						
						ShowMainMenu();
						input = GetUserInput();
						
						break;
						
					case '2':
						RemoveExpense();
						
						ShowMainMenu();
						input = GetUserInput();
						
						break;
						
					case '3':
						ShowStatementOfExpenses();
						
						ShowMainMenu();
						input = GetUserInput();
						
						break;
					
					case 'x':
					
						break;
					
					default:
						Console.WriteLine("You entered an invalid input.");
						
						ShowMainMenu();
						input = GetUserInput();
						
						break;
				}
			}
			while (input != 'x');
			
			Console.WriteLine();
			Console.WriteLine("Thank you for using the program.");
		}
		
		static void ShowMainMenu()
		{
			Console.WriteLine();
			Console.WriteLine("---------- Main Menu ----------");
			Console.WriteLine("Enter 1 to add expense");
			Console.WriteLine("Enter 2 to remove expense");
			Console.WriteLine("Enter 3 to view and print");
			Console.WriteLine("Enter x to exit application");
			Console.WriteLine("-------------------------------");
		}
		
		static char GetUserInput()
		{
			try 
			{
				Console.Write("Your input: ");
				input = Convert.ToChar(Console.ReadLine());
			}
			catch (Exception e)
			{
				GetUserInput();
			}
			
			return input;
		}
		
		static void AddExpense()
		{
			Console.WriteLine("	ADD");
			Console.Write("Item/Category: ");
			string inputItem = Console.ReadLine();

			Console.Write("Amount: ");
			int inputAmount = Convert.ToInt32(Console.ReadLine());
			
			index = GetIndex(inputItem);
			
			if (DoesItemExists(index)) 
			{		
				inputAmount += amount[index];
				
				amount.Remove(amount[index]);
				category.Remove(inputItem);
			}
			
			category.Add(inputItem);
			amount.Add(inputAmount);
			
			Console.WriteLine();
			Console.WriteLine("Item added!");
			
			return;
		}
		
		static void RemoveExpense()
		{
			Console.WriteLine("	REMOVE");
			Console.Write("Item/Category: ");
			var removeItem = Console.ReadLine();
			
			Console.WriteLine();
			
			index = GetIndex(removeItem);
			
			if (DoesItemExists(index))
			{
				category.Remove(removeItem);
				amount.Remove(amount[index]);
				
				Console.WriteLine("Item removed!");
			}
			else 
			{
				Console.WriteLine("Item does not exist.");
			}
			
			return;
		}
		
		static void ShowStatementOfExpenses() 
		{
			Console.WriteLine(date);
			Console.WriteLine("Budget: {0}", budget);
						
			Console.WriteLine();
			
			Console.WriteLine("Expenses: ");
				foreach(var item in category)
				{
					index = GetIndex(item);
					Console.WriteLine("   {0}     	-	{1}", item, amount[index]);
				}
				
			Console.WriteLine();
						
			int total = GetTotalOfExpenses();
			int balance = budget-total;
			
			Console.WriteLine("Total:		{0}", total);
			Console.WriteLine("Balance:	{0}", budget-total);
		}
		
		static int GetTotalOfExpenses() 
		{
			int total = 0;
			
			foreach(var item in category)
			{	
				index = GetIndex(item);
				
				total += amount[index];
			}
				
			return total;
		}
		
		static int GetIndex(string item)
		{
			int index = category.IndexOf(item);
			
			return index;
		}
		
		static bool DoesItemExists(int index)
		{
			if (index == -1) 
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
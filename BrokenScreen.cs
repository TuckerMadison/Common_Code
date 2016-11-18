using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

	class Program
	{
		
        static void Main(string[] args)
        {
			brokenScreen( "10100111 11111111;8" );
			Console.ReadLine();
        }

		public static int brokenScreen( string input )
		{
			//Tuples representing what section needs to be working in order to display the number
			//The tuples first spot will discribe the length of them.
			Dictionary<char,string> nums =
				new Dictionary<char,string>();
			nums.Add('0',"0,1,2,3,4,5");
			nums.Add('1',"1,2");
			nums.Add('2',"0,1,3,4,6");
			nums.Add('3',"0,1,2,3,6");
			nums.Add('4',"1,2,5,6");
			nums.Add('5',"0,2,3,5,6");
			nums.Add('6',"0,2,3,4,5,6");
			nums.Add('7',"0,1,2");
			nums.Add('8',"0,1,2,3,4,5,6");
			nums.Add( '9',"0,1,2,3,5,6");


			//Seperate the sections and the number to display.
			string[] sections = input.Split();
			string NumToDisplay = sections[sections.Length - 1].Substring(9);
			sections[sections.Length - 1] = sections[sections.Length - 1].Substring( 0, 8 );

			//Now, look at every char and decide what 
			string neededWorking;
			int curr;
			string sect;
			bool willSecWork;
			foreach( char c in NumToDisplay )
			{
				if( c != '.' )
				{
					neededWorking = nums[c];
					Console.WriteLine("Lights Needed For Number {0}: {1}",c,neededWorking );

					for(int i = 0; i < sections.Length; i++)
					{
						sect = sections[i];
						if( willSectionWork( sect, neededWorking ) == true )
						{
							Console.WriteLine( "Section {0} Will Work For {1}!", sect, c );
						}
					}

				}
			}
			return -1;
		}

		public static bool willSectionWork( string section, string lightsNeeded )
		{
			bool willWork;
			char[] theSection = section.ToCharArray();
			string temp;
			int currLight;
			foreach( char c in lightsNeeded )
			{
				if( c != ',' )
				{
					temp = "" + c;
					currLight = Int32.Parse(temp);
					if( theSection[currLight] == '0' )
					{
						Console.WriteLine( "Section {0} will not work due to light {1} being out", section, c );
						return false;
					}
				}
			}
			return true;
		}
	}



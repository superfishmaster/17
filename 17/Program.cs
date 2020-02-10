using System;
using System.Collections.Generic;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 14;
            Stones(n4);


        }

        //Question1 It takes 5h to solve this problem by two methods which are recursion and loop. I learned recursion is invoke himself to solve the problem. 
        private static void PrintLevel(int n)//Create a new method which invoke by the method PrintPattern.
        {
            try
            {

                if (n == 1)

                {
                    Console.Write(n); //when n ==1, result will be 1,then end the program.
                }
                else
                {
                    System.Console.Write("{0}", n);
                    PrintLevel(n - 1);
                }
            }

            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }
        private static void PrintPattern(int m)
        {
            if (m == 1)
            {
                Console.Write(m);//when n ==1, result will be 1,then end the program.

            }
            else
            {
                PrintLevel(m);//invoke method
                System.Console.Write("\n");  //Blank line

                PrintPattern(m - 1);
            }
        }

        // Loop 
        //for (int i = n; i > 0; i--)




        //{
        //    for (int j = i; j > 0; j--)
        //    {
        //        System.Console.Write("{0}",j );


        //    }
        //    System.Console.Write("\r\n");

        //}

        //Question 2 It takes 5 hours. I learned how to write loop statements for nested structures
        private static void PrintSeries(int n2)
        {
            try
            {
                int size = n2;
                int[] sumOfNumbers = new int[size];//Instantiate and link it with variable.
                for (int Item = 0; Item < n2; Item++)//loop
                {
                    int sum = 0;
                    for (int Number = 1; Number <= Item + 1; Number++)//nested loop. Caculate sum of each array
                                                                      // Each array include number from 1 to item+1.
                    {
                        sum = sum + Number;
                    }
                    sumOfNumbers[Item] = sum;
                }
                Console.WriteLine(string.Join(",", sumOfNumbers));//display output
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        // Question 3 It takes 5 hours. I learned how to transfer string to DateTime type and extract string.
        public static string UsfTime(string s)
        {
            try
            {

                string s0 = s.Substring(0, 8);//extract string from 0 to 8
                DateTime d = DateTime.ParseExact(s0, "HH:mm:ss", null); //Instantiate and link it with variable.
                if (s[8] == 'P') //transfer 12h to 24h
                {
                    d=d.AddHours(12);
                }
                string ans;
                int second_amount = d.Hour * 60 * 60 + d.Minute * 60 + d.Second;// Calculate total seconds
                int trans_hour = second_amount / (60 * 45); //Calculate the hours
                int third_amount = second_amount - trans_hour * 60 * 45;
                int trans_minute = third_amount / 45;// Calculate the minutes
                int trans_second = third_amount % 45;//Calculate the seconds

                ans = trans_hour.ToString() + ":" + trans_minute.ToString() + ":" + trans_second.ToString();// get the UsfTime



                Console.WriteLine(ans);

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }

        //Question 4. It takes 6 hours. I learned how to wirte the multiple if statement.
        public static void UsfNumbers(int n3, int k)
        {

            string n = "";
            try
            {
                int i;
                for (i = 1; i < n3 + 1; i++)
                {
                    if ((i - 1) % 11 == 0)
                    {
                        n += "\n";//Blank line
                    }
                    if ((i % 5 == 0) && (i % 7 == 0))
                    {
                        n += " SF";//Replace
                    }
                    else if ((i % 3 == 0) && (i % 5 == 0))
                    {
                        n += " US";//Replace
                    }
                    else if (i % 7 == 0)
                    {
                        n += " F";//Replace
                    }
                    else if (i % 5 == 0)
                    {
                        n += " S";//Replace
                    }
                    else if (i % 3 == 0)
                    {
                        n += " U";//Replace
                    }
                    else
                    {

                        n += (" " + i.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }

            Console.Write(n);
           
        }

        //Quiestion 5 It takes 5 hours.


    
        
        public static List<int[]> PalindromePairs(string[] Words)
        {
            List<int[]> Ans = new List<int[]>();
            try
            {
                int WordsAmount = Words.Length;
                for (int i = 0; i < WordsAmount; i++)//Loop
                {
                    for (int j = 0; j < WordsAmount; j++)//Nested Loop
                    {
                        if (i != j)
                        {
                            string ConcatString = Words[i] + Words[j];
                            if (IsPairString(ConcatString))//Invoke method
                            {
                                int[] PairIndex = { i, j };
                                Ans.Add(PairIndex);
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Question5 error!");
            }
                
            for (int i = 0; i < Ans.Count; i++)   //Printing values through the LIST collection
            {
                foreach (var item in Ans[i])
                {
                    Console.WriteLine(item);

                }
            }
            Console.WriteLine();
            return Ans;
        }
        public static bool IsPairString(String ConcatString)
        {
            try
            {
                int ConcatStringLength = ConcatString.Length;
                if (ConcatStringLength % 2 == 0)
                {
                    int OneStringLength = ConcatStringLength / 2;
                    String FrontString = ConcatString.Substring(0, OneStringLength);
                    String BackString = ConcatString.Substring(OneStringLength, OneStringLength);
                    for (int i = 0; i < OneStringLength; i++)
                    {
                        if (FrontString[i] != BackString[OneStringLength - i - 1])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("IsPairString error!");
                return false;
            }
        }











       


        
        //Question 6 It takes 4 hours. I learned how to use Mod. Base on this question, if we are the first palyer, we have no chance to win when the number is multiplier of 4. On the other hand we can win. In this case , I set numlber as 14.
        public static void Stones(int n4)
        {
            try
            {
                 
                if(n4%4==0)
                {
                    Console.WriteLine("False");//we have no chance to win when the number is multiplier of 4.
                    return;
                }
                if(n4<4)
                {
                    Console.WriteLine(n4);
                    return;
                }
                Console.WriteLine(n4 % 4);
                n4 = n4 - n4 % 4;
                while (n4>0)
                {
                    Console.WriteLine(1);
                    Console.WriteLine(3);
                    n4 = n4 - 4;
                }

            }

            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }




       
    }
}


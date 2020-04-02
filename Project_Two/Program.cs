using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;






namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
            //filepath is a functiont to find file path on his computer
        {
            const string PATH = @"C:\Users\brejosj\Desktop\spring2020\advancedPrograming\superBowl\Project_Two\Super_Bowl_Project.csv";

            FileStream input;
            StreamReader read;
            string line;
            string[] data;
            string path = "";
            string textFile = "";
            // intro
           Console.WriteLine("welcome to the super bowl porgram");
            //finding the file for the cvs
            Console.WriteLine("What file path extension would like to read in (.cvs)");
            string Path = Console.ReadLine();
            Console.WriteLine(textFile);

            Console.WriteLine("\nWhat file path do you want it to be written in (.txt)");
             path = @Console.ReadLine();
            Console.WriteLine(path);



            try
            {
                input = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                read = new StreamReader(input);
                List<SuperYear> sblist = new List<SuperYear>();
                                            //.Skip(1);
                                          //.Select(v => sblist.SuperYear(v));
                                            //.Tolist;

                line = read.ReadLine();
                while (!read.EndOfStream)
                {
                    data = read.ReadLine().Split(',');

                    //SuperYear(data);
                    //passing each line into my over loaded contrutor
                    sblist.Add(new SuperYear(data));
                    //using contruct and passing in each feild
                    //sblist.Add(new SuperYear(data[0],data[1], Convert.ToInt32(data[2]),data[3],data[4],data[5], 
                    //   Convert.ToInt32(data[6]),data[7],data[8], data[9], Convert.ToInt32(data[10]),data[11],data[12],data[13]
                    //   ,data[14]));
                }
                //checking to make sure that my data is objects
                sblist.ForEach(x => Console.WriteLine(x.ToString()));
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //superbolw winners write
            using (StreamWriter file = File.CreateText("test.txt"))
            {
                Console.WriteLine("\n QUESTION ONE");
                file.WriteLine("\n QUestion 1 SUPER BOWL WINNERS");

                file.WriteLine("TEAM NAME" + "\t\t" + "Year WON" + "\t\t"+ "WINNING QB"+" \t\t"+
                   "WINNING Coach" + "\t\t" + "MVP" + "point difference");
            }

            //List<object> listOfSuperBowl = new List<object>();

            //var listOfSuperBowls = File.ReadLines(PATH).Select(line => new SuperYear(line)).ToList();


            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            //reading all file paths in a dir
            //string[] files = Directory.GetFiles(@"C:\Users\brejosj\Desktop\spring2020\advancedPrograming\superBowl");
            //for (var i =0; i < files.Length; i++)

            //{
            //    Console.WriteLine(files[i]);
            //}
            //first neeed to connect to this file and use file to make objects 
        }//end of main    
    }
}

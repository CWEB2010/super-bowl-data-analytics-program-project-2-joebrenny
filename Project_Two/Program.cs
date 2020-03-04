using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;





namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<object> listOfSuperBowl = new List<object>();

            var listOfSuperBowls = File.ReadLines(@"C:\Users\brejosj\Desktop\spring2020\advancedPrograming\superBowl\Project_Two\sbp.csv").Select(line => new SuperYear(line)).ToList();
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
        }   
    }
}

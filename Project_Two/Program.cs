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
            List<SuperYear> sblist = new List<SuperYear>();
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
                //List<SuperYear> sblist = new List<SuperYear>();
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
                read.Close();
                read.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //superbolw winners write
            //using (StreamWriter file = File.CreateText("test.txt"))
            FileStream output = new FileStream(@"C:\Users\brejosj\Desktop\spring2020\advancedPrograming\superBowl\Project_Two\test.txt", FileMode.Create, FileAccess.Write);
            StreamWriter write = new StreamWriter(output);

            //looping through the objects 
            write.WriteLine("Question One\n");
            write.WriteLine(" \t\t team name \t\t year team won \t\t winning QB \t\t" +
                "WINNING Coach \t\t MVP \t\t points difference winning - losing points");

            foreach(SuperYear x in sblist)
            {
                //write out each record
                write.WriteLine($"\t\t\t{x.winningTeam},\t {x.date},\t {x.qb_Winner},\t {x.coachWinner}, {(x.winningPoints-x.loserPoints)}");
            }

            //top 5 attendance________________________________________________
            List<SuperYear> attendanceList = sblist.OrderByDescending(SuperYear => SuperYear.attendance).Take(5).ToList();
                write.WriteLine($"Question 2 \n");
            write.WriteLine($"Year \t Winning Team \t\t Lossing Team \t\t City \t\t State \t\t Staduim \n");
            foreach(SuperYear x in attendanceList)
            {
                Console.WriteLine($"{x.attendance},{x.date}, {x.winningTeam}, {x.teamLoser}, {x.city}, {x.state}, {x.stadium} ");
                
                write.WriteLine($"{x.attendance}, {x.date}, {x.winningTeam}, {x.teamLoser}, {x.city}, {x.state}, {x.stadium} ");

            }
            //state that has the most hosted superbowl
            List<SuperYear> state = sblist.OrderBy(SuperYear => SuperYear.state)/*.Take(11)*/.ToList();
            var mstate = sblist.GroupBy(x => x.state)
                .OrderByDescending(g => g.Count())
                .SelectMany(g =>g).Take(11).ToList();
            //Console.WriteLine(mstate.  ); 

            //var groups = sblist.GroupBy(x => x);
            //var moststate = groups.OrderByDescending(x => x.Count()).First();
            //Console.WriteLine(largest.Key,);
            write.WriteLine($"Question 3 \n");
            write.WriteLine($"City \t STATE \t\t Stadium  \n");
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //var stateqry = from staterec in state
            //               group staterec by new
            //               {
            //                   staterec.state
            //               }
            //               into groupsstate
            //               from cityg in
            //               (from city in groupsstate
            //                orderby city.city, city.date descending, city.stadium
            //                group city by new { city.city })
            //               orderby groupsstate.Key.state
            //               group cityg by new { groupsstate.Key.state };
            //foreach(var outergroup in stateqry)
            //{
            //    Console.WriteLine($"0000{outergroup.Key.state}");
            //    write.WriteLine($"0000{outergroup.Key.state}");

            //}
            //_________________________________________________________________
            //mstate.ForEach(x => write.WriteLine(x.ToString()));

            foreach (SuperYear x in mstate)
            {
                Console.WriteLine($"33{x.state}, {x.city}, {x.stadium}");

                write.WriteLine($"33{x.city}, {x.state}, {x.stadium}");

            }
            //make list of players who won mvp more than once 
            List<SuperYear> mvplist = sblist.OrderBy(SuperYear => SuperYear.mvp)/*.Take(11)*/.ToList();
            write.WriteLine($"\n\nPlayer who havev more than one MVP\n");

            var mvpcount = from x in sblist
                           group x by x.mvp into MVPGROUP
                           where MVPGROUP.Count() >= 2
                           orderby MVPGROUP.Key
                           select MVPGROUP;
            foreach(var x in mvpcount)
            {
                write.WriteLine($"{x.Key}, has {x.Count()} MVPS");
            }

            //Which coach lost the most super bowls?
            write.WriteLine($"\n\n 1.  which coach lost the most superbowls????\n");
            var coachLoss = from z in sblist
                            .GroupBy(z => z.coachLoser)
                            select new
                            {
                                z.Key,
                                most = z.Count()
                            };
            foreach(var z in coachLoss)
            {
                if(z.most == coachLoss.Max( x => x.most))
                {
                    write.WriteLine($"{z.Key} lost  {z.most} superbowls");
                }
            }
            // find the coachs that won the most su0er bowls????
            write.WriteLine($"\n\n2.   which coach won the most superbowls????\n");
            var coachWin = from t in sblist
                           .GroupBy(t => t.coachWinner)
                           select new
                           {
                               t.Key,
                               Most = t.Count()
                           };
            foreach (var t in coachWin)
            {
                if(t.Most == coachWin.Max (x => x.Most))
                {
                    write.WriteLine($"{t.Key} won  {t.Most} superbowls\n\n");
                }
            }
            //Which team(s) won the most super bowls?
            write.WriteLine($"3.  Which team(s) won the most super bowls???\n");
            var teamWin = from x in sblist
                          .GroupBy(x => x.winningTeam)
                          select new
                          {
                              x.Key,
                              Most = x.Count()
                          };
            foreach (var x in teamWin)
            {
                if (x.Most == teamWin.Max(y => y.Most))
                {
                    write.WriteLine($"{x.Key} won  {x.Most} superbowls\n");
                }
            }
            //Which team(s) lost the most super bowls?
            write.WriteLine($"4.  Which team(s) won the most super bowls???\n");
            var teamloss = from x in sblist
                          .GroupBy(x => x.teamLoser)
                          select new
                          {
                              x.Key,
                              Most = x.Count()
                          };
            foreach (var x in teamloss)
            {
                if (x.Most == teamloss.Max(y => y.Most))
                {
                    write.WriteLine($"{x.Key} lost  {x.Most} superbowls\n");
                }
            }
            //Which Super bowl had the greatest point difference?
            write.WriteLine($"5.  Which Super bowl had the greatest point difference????\n");
            var pointdiff = from x in sblist
                            select new
                            {
                                x.sbNum,
                                Most = Math.Abs(x.winningPoints - x.loserPoints)
                            };
            foreach(var x in pointdiff)
            {
                if(x.Most == pointdiff.Max(y=> y.Most))
                {
                    write.WriteLine($"superbowl {x.sbNum} had a spread of {x.Most}");
                }
            }
            //What is the average attendance of all super bowls?
            write.WriteLine($"6.  What is the average attendance of all super bowls?????\n");
            var avrage = sblist.Select(x => x.attendance).Average();
            write.WriteLine($"the average attendance is {avrage}");



            write.Close();
            output.Close();

            //________________________________________
            //{
            //    Console.WriteLine("\n QUESTION ONE");
            //    file.WriteLine("\n QUestion 1 SUPER BOWL WINNERS");

            //    file.WriteLine("TEAM NAME" + "\t\t" + "Year WON" + "\t\t"+ "WINNING QB"+" \t\t"+
            //       "WINNING Coach" + "\t\t" + "MVP" + "point difference");
            //}
            //________________________________________
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    public class SuperYear
    {
        public string date;
        public string sbNum;
        public int attendance;
        public string qb_Winner;
        public  string coachWinner;
        public string winningTeam;
        public int winningPoints;
        public string qbLoser;
        public string coachLoser;
        public string teamLoser;
        public int loserPoints;
        public string mvp;
        public string stadium;
        public string city;
        public string state;

        public SuperYear()
        {

        }
        public SuperYear(string Date, string SbNum, int Attendance, string Qb_Winner, string CoachWinner, 
            string WinningTeam, int WinningPoints, string QbLoser, string CoachLoser, string TeamLoser, int LoserPoints,
            string Mvp, string Stadium, string City, string State)
        {
            date = Date;
            sbNum = SbNum;
            attendance = Attendance;
            qb_Winner = Qb_Winner;
            coachWinner = CoachWinner;
            winningTeam = WinningTeam;
            winningPoints = WinningPoints;
            qbLoser = QbLoser;
            coachLoser = CoachLoser;
            teamLoser = TeamLoser;
            loserPoints = LoserPoints;
            mvp = Mvp;
            stadium = Stadium;
            city = City;
            state = State;

        }
        //attenpt to get the file into objects
        public SuperYear(string[] line)
        {
            var split = line;//.Split(',');

            date = split[0];
            sbNum = split[1];
            attendance = int.Parse(split[2]);
            qb_Winner = split[3];
            coachWinner = split[4];
            winningTeam = split[5];
            winningPoints = int.Parse(split[6]);
            qbLoser = split[7];
            coachLoser = split[8];
            teamLoser = split[9];
            loserPoints = int.Parse(split[10]);
            mvp = split[11];
            stadium = split[12];
            city = split[13];
            state = split[14];
        }
        public override string ToString()
        {
            return string.Format($"date:{date}\n  Number: {sbNum}\n  attendance: {attendance}\n QB WInner:{qb_Winner}\n" +
                $"CoachWinner:{coachWinner}\n Winning Team: {winningTeam}\n Winning Points: {winningPoints}\n  QB Loser: {qbLoser}\n" +
                $"coach Loser: {coachLoser}\n teamLoser: {teamLoser}\n loser Points: {loserPoints}\n MVP: {mvp}\n" +
                $"STADIUM: {stadium}\n CITY: {city}\n STATE: {state}\n\n\n");
        }


    }
}

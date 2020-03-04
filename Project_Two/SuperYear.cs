using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class SuperYear
    {
        string date;
        string sbNum;
        int attendance;
        string qb_Winner;
        string coachWinner;
        string winningTeam;
        int winningPoints;
        string qbLoser;
        string coachLoser;
        string teamLoser;
        int loserPoints;
        string mvp;
        string stadium;
        string city;
        string state;

        SuperYear()
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
        public SuperYear(string line)
        {
            var split = line.Split(',');

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

    }
}

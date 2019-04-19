using System;
using LooneyInvaders.Model;
using LooneyInvaders.Model.Enums;

namespace LooneyInvaders.Extensions
{
    public static class LeaderboardItemExtension
    {
        public static object GetLeaderboardItemField(this LeaderboardItem item, LeaderBoardItemField field)
        {
            switch (field)
            {
                case LeaderBoardItemField.Accuracy: return item != null ? item.Accuracy : default(double);
                case LeaderBoardItemField.Date: return item != null ? item.Date : default(DateTime);
                case LeaderBoardItemField.LevelsCompleted: return item != null ? item.LevelsCompleted : default(double);
                case LeaderBoardItemField.Name: return item != null ? item.Name : string.Empty;
                case LeaderBoardItemField.Rank: return item != null ? item.Rank : default(int);
                case LeaderBoardItemField.Score: return item != null ? item.Score : default(double);
                case LeaderBoardItemField.Time: return item != null ? item.Time : default(double);
                default: return null;
            }
        }
    }
}
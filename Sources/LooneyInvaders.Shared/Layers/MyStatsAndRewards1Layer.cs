using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.DeviceInfo;
using LooneyInvaders.Extensions;
using LooneyInvaders.Model;
using LooneyInvaders.Services.DeviceInfo;

namespace LooneyInvaders.Layers
{
    public class MyStatsAndRewards1Layer : CCLayerColorExt
    {
        private readonly CCSpriteTwoStateButton _btnDateFormat;
        private readonly CCSpriteTwoStateButton _btnGameType;
        private CCNodeExt _pageWeekRegular;
        private CCNodeExt _pageMonthRegular;
        private CCNodeExt _pageWeekPro;
        private CCNodeExt _pageMonthPro;

        private int _bestMonthScoreRegular;
        private int _bestMonthScorePro;
        private int _bestWeekScoreRegular;
        private int _bestWeekScorePro;

        private IDeviceInfoService _deviceInfoService;

        public MyStatsAndRewards1Layer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 485, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            var btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, ButtonType.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            var btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 485, ButtonType.Forward);
            btnForward.OnClick += BtnForward_OnClick;

            _btnDateFormat = AddTwoStateButton(375, 480, "UI/My-stats-&-rewards-page1-week-button-tapped.png", "UI/My-stats-&-rewards-page1-week-button-untapped.png", "UI/My-stats-&-rewards-page1-month-button-tapped.png", "UI/My-stats-&-rewards-page1-month-button-untapped.png", 485);
            _btnDateFormat.ButtonType = ButtonType.OnOff;
            _btnDateFormat.SetStateImages(2);
            _btnDateFormat.OnClick += OnBtnDateFormatClicked;

            _btnGameType = AddTwoStateButton(540, 480, "UI/My-stats-&-rewards-page1-regular-button-tapped.png", "UI/My-stats-&-rewards-page1-regular-button-untapped.png", "UI/My-stats-&-rewards-page1-pro-button-tapped.png", "UI/My-stats-&-rewards-page1-pro-button-untapped.png", 485);
            _btnGameType.ButtonType = ButtonType.OnOff;
            _btnGameType.SetStateImages(2);
            _btnGameType.OnClick += OnBtnGameTypeClicked;

            AddImage(287, 560, "UI/My-stats-&-rewards-title-text.png", 485);

            AddImage(829, 592, "UI/My-stats-&-rewards-page1_8--text.png", 485);

            AddImage(190, 150, "UI/My-stats-&-rewards-page1-diagram-window.png");
            
            for (var i = 0; i < 9; i++)
            {
                AddImage(305, 188 + i * 35, "UI/My-stats-&-rewards-page1-diagram-horizontal-bar.png");
            }

            AddImage(0, 0, "UI/My-stats-&-rewards-page1-security-pattern.png", 480);
            AddImage(30, 0, "UI/My-stats-&-rewards-LOONEY-INVADER-time-zone-info-text.png", 485);
            /* commented out by Adrijan - it caused chrashing and I needed to get to mystats 5 to switch hitler for milo
            DrawWeekStatistic(LeaderboardType.Regular);
            DrawWeekStatistic(LeaderboardType.Pro);
            DrawMonthStatistic(LeaderboardType.Regular);
            DrawMonthStatistic(LeaderboardType.Pro);
            GetBaseStatistics();
            
            ChangeBtnsState();
            */
        }

        private void InitBestOfAllTime(LeaderboardType leaderboardType, CCNodeExt drawOn)
        {
            var bestOfAllTime = Player.Instance.GetBestScoreAllTime(leaderboardType != LeaderboardType.Regular);

            CreateTwoPartInfo(190, 52, "UI/My-stats-&-rewards-page1-best-of-all-time.png", bestOfAllTime.ToString(), true, drawOn);
        }

        private void OnBtnDateFormatClicked(object sender, EventArgs e)
        {
            _btnDateFormat.ChangeState();
            _btnDateFormat.SetStateImages();

            ChangeBtnsState();
        }

        private void OnBtnGameTypeClicked(object sender, EventArgs e)
        {
            _btnGameType.ChangeState();
            _btnGameType.SetStateImages();

            ChangeBtnsState();
        }

        private void ChangeBtnsState()
        {
            HideAllPages();

            if (_btnDateFormat.State == 2 && _btnGameType.State == 2)
            {
                _pageMonthPro.Visible = true;
            }
            else if (_btnDateFormat.State == 2 && _btnGameType.State == 1)
            {
                _pageMonthRegular.Visible = true;
            }
            else if (_btnDateFormat.State == 1 && _btnGameType.State == 2)
            {
                _pageWeekPro.Visible = true;
            }
            else if (_btnDateFormat.State == 1 && _btnGameType.State == 1)
            {
                _pageWeekRegular.Visible = true;
            }
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            var newLayer = new GameInfoScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            TransitionToLayer(new MyStatsAndRewards2Layer());
        }

        private void HideAllPages()
        {
            _pageMonthPro.Visible = false;
            _pageMonthRegular.Visible = false;
            _pageWeekRegular.Visible = false;
            _pageWeekPro.Visible = false;
        }

        private void GetBaseStatistics()
        {
            _deviceInfoService = Shared.GameDelegate.DeviceInfoService ?? new DeviceInfoService();
            var deviceInfo = _deviceInfoService.GetDeviceInfo();

            //device model
            CreateTwoPartInfo(582, 103, "UI/My-stats-&-rewards-page1-device-model.png", deviceInfo.DeviceModel, false);

            //software
            CreateTwoPartInfo(582, 74, "UI/My-stats-&-rewards-page1-software.png", deviceInfo.Software, false);

            //imei/udid
#if __IOS__
            const string imeiLabelName = "UI/My-stats-&-rewards-page1-UDID.png";
#else
            const string imeiLabelName = "UI/My-stats-&-rewards-page1-IMEI.png";
#endif
            CreateTwoPartInfo(582, 50, imeiLabelName, deviceInfo.Imei, false);
        }

        private void CreateTwoPartInfo(int startX, int startY, string firstImageName, string secondPartText, bool isOnlyNumbers, CCNodeExt drawOn = null)
        {
            CCSprite firstPartLabel;

            if (drawOn != null)
            {
                firstPartLabel = drawOn.AddImage(startX, startY, firstImageName);
            }
            else
            {
                firstPartLabel = AddImage(startX, startY, firstImageName);
            }

            var firstPartLabelPosition = firstPartLabel.BoundingBoxTransformedToWorld;
            DrawConsistImage(firstPartLabelPosition, secondPartText, isOnlyNumbers, drawOn);
        }

        private void DrawConsistImage(CCRect previousImagePosition, string valueToDraw, bool isUseNumber28 = false, CCNodeExt drawOn = null)
        {
            var positionX = (int)previousImagePosition.MaxX;
            var positionY = (int)previousImagePosition.MinY;

            if (isUseNumber28)
            {
                positionY += 11;
            }
            else
            {
                positionY += 5;
            }

            CCSprite lastLetter = null;

            for (var i = 0; i < valueToDraw.Length; i++)
            {
                var step = 0;
                string imageToDraw;
                var ch = valueToDraw[i];

                if (isUseNumber28)
                {
                    if (i == 0)
                    {
                        step = -14;
                    }
                    else if ((valueToDraw.Length - i) % 3 == 0)
                    {
                        step = 16;
                    }
                    else
                    {
                        step = 12;
                    }

                    positionX += step;

                    imageToDraw = $"UI/number_28_{ch}.png";
                }
                else
                {
                    if (i == 0)
                    {
                        step = -12;
                    }
                    else if (ch == ' ')
                    {
                        step = 16;
                    }
                    else if (ch == '.')
                    {
                        step = 14;
                    }
                    else if (ch == '1' || ch == '2' || ch == '3'
                             || ch == '4' || ch == '5' || ch == '6'
                             || ch == '7' || ch == '8' || ch == '9' || ch == '0')
                    {
                        step = 9;
                    }
                    else if (lastLetter != null)
                    {
                        var lastSize = (int)(lastLetter.BoundingBoxTransformedToWorld.MaxX - lastLetter.BoundingBoxTransformedToWorld.MinX);
                        step = char.IsLower(ch)
                            ? (int)(lastSize * 0.65)
                            : (int)(lastSize * 0.55);
                    }

                    if (i > 0 && valueToDraw[i - 1] == '.')
                    {
                        step -= 8;
                    }

                    positionX += step;
                    switch (ch)
                    {
                        case ';':
                            imageToDraw = "MyStatsFont/my-stats-font-semicolon.png";
                            break;
                        default:
                            imageToDraw = $"MyStatsFont/my-stats-font-{ch}{(char.IsLower(ch) ? "-small" : string.Empty)}.png";
                            break;
                    }
                }

                if (drawOn != null)
                {
                    lastLetter = drawOn.AddImage(positionX, positionY, imageToDraw);
                }
                else
                {
                    lastLetter = AddImage(positionX, positionY, imageToDraw);
                }

                if (!isUseNumber28 && lastLetter.BoundingBoxTransformedToWorld.MaxX > 970)
                {
                    //move to next line
                    positionX = (int)previousImagePosition.MaxX - 20;
                    positionY -= 14;
                }
            }
        }

        private int GetBestScoreOfWeek(LeaderboardType leaderboardType)
        {
            return leaderboardType == LeaderboardType.Pro ? _bestWeekScorePro : _bestWeekScoreRegular;
        }

        private int GetBestScoreOfLastWeek(LeaderboardType leaderboardType)
        {
            var today = DateTime.Now.AddMinutes(-15).AddSeconds(-10).DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.Now.AddMinutes(-15).AddSeconds(-10).DayOfWeek;
            var weekStartDay = DateTime.Now.AddMinutes(-15).AddSeconds(-10).AddDays(-today - 7 + 1).Date;

            var listOfDayScore = new List<int>();

            for (var day = 0; day < Enum.GetValues(typeof(DayOfWeek)).Length; day++)
            {
                var isPro = leaderboardType == LeaderboardType.Pro;
                listOfDayScore.Add(Player.Instance.GetDayScore(weekStartDay.AddDays(day), isPro));

                if (weekStartDay.AddDays(day) >= DateTime.Now.AddMinutes(-15).AddSeconds(-10).Date)
                {
                    break;
                }
            }

            return listOfDayScore.Max();
        }

        private int GetBestScoreOfMonth(LeaderboardType leaderboardType)
        {
            return leaderboardType == LeaderboardType.Pro ? _bestMonthScorePro : _bestMonthScoreRegular;
        }

        private int GetBestScoreOfLastMonth(LeaderboardType leaderboardType)
        {
            var lastMonthDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month);

            var bestOfLastMonth = 0;

            for (var day = 1; day < lastMonthDays + 1; day++)
            {
                var isPro = leaderboardType == LeaderboardType.Pro;
                var sscore = Player.Instance.GetDayScore(new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, day), isPro);

                if (sscore > bestOfLastMonth)
                    bestOfLastMonth = sscore;
            }

            return bestOfLastMonth;
        }

        private void DrawWeekStatistic(LeaderboardType leaderboardType)
        {
            CCNodeExt currentNode;
            if (leaderboardType == LeaderboardType.Regular)
            {
                _pageWeekRegular = new CCNodeExt();
                currentNode = _pageWeekRegular;
            }
            else
            {
                _pageWeekPro = new CCNodeExt();
                currentNode = _pageWeekPro;
            }

            InitBestOfAllTime(leaderboardType, currentNode);

            const int step = 80;

            var weekStartDay = DateTime.Now.AddMinutes(-15).AddSeconds(-10).StartOfWeek(DayOfWeek.Monday);

            for (var day = 0; day < Enum.GetValues(typeof(DayOfWeek)).Length; day++)
            {
                var dayName = weekStartDay.AddDays(day).ToString("dddd", CultureInfo.InvariantCulture).ToLower();
                currentNode.AddImage(318 + step * day, 151, $"UI/My-stats-&-rewards-page1-{dayName}.png");
            }

            AddChild(currentNode);

            var weeklyScore = GetWeekStatistics(weekStartDay, leaderboardType);
            int maxRounded;

            if (weeklyScore.Count > 0)
            {
                if (leaderboardType == LeaderboardType.Pro)
                {
                    _bestWeekScorePro = weeklyScore.Max();
                    maxRounded = RoundToTop(_bestWeekScorePro);
                }
                else
                {
                    _bestWeekScoreRegular = weeklyScore.Max();
                    maxRounded = RoundToTop(_bestWeekScoreRegular);
                }
            }
            else
            {
                if (leaderboardType == LeaderboardType.Pro)
                    _bestWeekScorePro = 0;
                else
                    _bestWeekScoreRegular = 0;

                maxRounded = RoundToTop(0);
            }

            var stepStat = GetStartStepForLeftNumbers(maxRounded);

            DrawLeftNumbers(stepStat, currentNode);

            const int xStart = 358;
            DrawDotsOnSchedule(weeklyScore, step, stepStat, xStart, currentNode);

            //best of week
            CreateTwoPartInfo(190, 103, "UI/My-stats-&-rewards-page1-best-of-week.png", GetBestScoreOfWeek(leaderboardType).ToString(), true, currentNode);

            //best of week
            CreateTwoPartInfo(190, 79, "UI/My-stats-&-rewards-page1-best-of-last-week.png", GetBestScoreOfLastWeek(leaderboardType).ToString(), true, currentNode);
        }

        private int RoundToTop(int val)
        {
            if (val > 0 && val <= 100)
            {
                return (int)Math.Ceiling(val / 10.0) * 10;
            }

            if (val > 100 && val <= 10000)
            {
                return (int)Math.Ceiling(val / 100.0) * 100;
            }

            if (val > 10000 && val < 100000)
            {
                return (int)Math.Ceiling(val / 1000.0) * 1000;
            }

            if (val > 100000 && val < 1000000)
            {
                return (int)Math.Ceiling(val / 100000.0) * 100000;
            }

            return val;
        }

        private List<int> GetWeekStatistics(DateTime weekStartDay, LeaderboardType leaderboardType)
        {
            var listOfDayScore = new List<int>();

            for (var day = 0; day < Enum.GetValues(typeof(DayOfWeek)).Length; day++)
            {
                if (weekStartDay.AddDays(day) > DateTime.Now.AddMinutes(-15).AddSeconds(-10).Date || weekStartDay.Day == DateTime.Now.Day)
                {
                    if (day > 0)
                        break;
                }

                var isPro = leaderboardType == LeaderboardType.Pro;
                listOfDayScore.Add(Player.Instance.GetDayScore(weekStartDay.AddDays(day), isPro));

            }

            return listOfDayScore;
        }

        private void DrawMonthStatistic(LeaderboardType leaderboardType)
        {
            CCNodeExt currentNode;
            if (leaderboardType == LeaderboardType.Regular)
            {
                _pageMonthRegular = new CCNodeExt();
                currentNode = _pageMonthRegular;
            }
            else
            {
                _pageMonthPro = new CCNodeExt();
                currentNode = _pageMonthPro;
            }

            InitBestOfAllTime(leaderboardType, currentNode);

            var step = 136;

            for (var weekNumber = 0; weekNumber < 4; weekNumber++)
            {
                currentNode.AddImage(316 + step * weekNumber, 151, $"UI/My-stats-&-rewards-page1-week{weekNumber + 1}.png");
            }

            AddChild(currentNode);

            var monthScore = GetMonthStatistics(leaderboardType);

            int maxRounded;

            if (monthScore.Count > 0)
            {
                if (leaderboardType == LeaderboardType.Pro)
                {
                    _bestMonthScorePro = monthScore.Max();
                    maxRounded = RoundToTop(_bestMonthScorePro);
                }
                else
                {
                    _bestMonthScoreRegular = monthScore.Max();
                    maxRounded = RoundToTop(_bestMonthScoreRegular);
                }
            }
            else
            {
                if (leaderboardType == LeaderboardType.Pro)
                    _bestMonthScorePro = 0;
                else
                    _bestMonthScoreRegular = 0;

                maxRounded = RoundToTop(0);
            }

            var stepStat = GetStartStepForLeftNumbers(maxRounded);

            DrawLeftNumbers(stepStat, currentNode);

            step = 18;
            const int xStart = 318;
            DrawDotsOnSchedule(monthScore, step, stepStat, xStart, currentNode);

            //best of month
            CreateTwoPartInfo(190, 103, "UI/My-stats-&-rewards-page1-best-of-month.png", GetBestScoreOfMonth(leaderboardType).ToString(), true, currentNode);

            //best of month
            CreateTwoPartInfo(190, 79, "UI/My-stats-&-rewards-page1-best-of-last-month.png", GetBestScoreOfLastMonth(leaderboardType).ToString(), true, currentNode);
        }

        private List<int> GetMonthStatistics(LeaderboardType leaderboardType)
        {
            var listOfDayliScore = new List<int>();

            var daysInMonth = DateTime.DaysInMonth(DateTime.Now.AddMinutes(-15).AddSeconds(-10).Year, DateTime.Now.AddMinutes(-15).AddSeconds(-10).Month);

            var dayTo = Math.Min(daysInMonth, DateTime.Now.AddMinutes(-15).AddSeconds(-10).Day);

            for (var day = 1; day < dayTo + 1; day++)
            {

                var isPro = leaderboardType == LeaderboardType.Pro;
                listOfDayliScore.Add(Player.Instance.GetDayScore(new DateTime(DateTime.Now.AddMinutes(-15).AddSeconds(-10).Year, DateTime.Now.AddMinutes(-15).AddSeconds(-10).Month, day), isPro));
            }

            return listOfDayliScore;
        }

        private void DrawLeftNumbers(int stepStat, CCNodeExt nodeOn)
        {
            const int yStep = 35;

            for (var i = 0; i < 9; i++)
            {
                var smallStep = 0;
                var indexNum = 0;

                var textToWrite = (i * stepStat).ToString();
                for (var chIndex = textToWrite.Length - 1; chIndex >= 0; chIndex--)
                {
                    nodeOn.AddImage(284 - smallStep, 175 + i * yStep, $"UI/number_38_{textToWrite[chIndex]}.png");

                    if ((indexNum + 1) % 3 == 0)
                    {
                        smallStep += 21;
                    }
                    else
                    {
                        smallStep += 16;
                    }

                    indexNum++;
                }
            }
        }

        private int GetStartStepForLeftNumbers(int maxScore)
        {
            if (maxScore == 0)
                maxScore = 800;

            return RoundToTop(maxScore / 8);
        }

        private void DrawDotsOnSchedule(List<int> scoreList, int step, int stepStat, int xStart, CCNodeExt nodeOn)
        {
            var toDot = new CCPoint();

            for (var i = 0; i < scoreList.Count; i++)
            {
                var nm = scoreList[i];
                string imageName;
                if (nm == scoreList.Max() && nm != 0)
                {
                    imageName = "UI/My-stats-&-rewards-page1-best-score-dot.png";
                }
                else if (nm == 0)
                {
                    imageName = "UI/My-stats-&-rewards-page1-zero-score-dot.png";
                }
                else
                {
                    imageName = "UI/My-stats-&-rewards-page1-regular-score-dot.png";
                }

                var fromDot = toDot;
                var lastImg = nodeOn.AddImage(xStart + step * i, 188 + 280 * nm / (stepStat * 8), imageName, 485);
                toDot = new CCPoint(lastImg.BoundingBoxTransformedToWorld.MidX, lastImg.BoundingBoxTransformedToWorld.MidY);

                if (i > 0)
                {
                    var drw = new CCDrawNode();
                    drw.DrawLine(new CCPoint(fromDot), new CCPoint(toDot), 3f, new CCColor4B(0, 0, 0, 125));
                    nodeOn.AddChild(drw);
                }
            }
        }
    }
}

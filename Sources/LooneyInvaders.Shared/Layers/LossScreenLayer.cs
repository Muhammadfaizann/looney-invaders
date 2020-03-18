using System;
using System.Globalization;
using CocosSharp;
using LooneyInvaders.Extensions;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;
using static LooneyInvaders.AppConstants;
using static LooneyInvaders.Model.Enums.LeaderBoardItemField;

namespace LooneyInvaders.Layers
{
    public class LossScreenLayer : CCLayerColorExt
    {
        public Battlegrounds SelectedBattleground;
        public Enemies SelectedEnemy;
        public Weapons SelectedWeapon;

        private CCSpriteButton _btnContinue;
        private CCSpriteButton _mainMenu;
        private CCSprite _shareYourScore;
        private CCSpriteButton _yes;
        private CCSpriteButton _no;
        private readonly CCSprite _youAreDefeated;

        private bool _isWeHaveScores;
        private bool _isDoneWaitingForScores;
        private bool _isYouAreDefPlayed;

        private readonly int _alienScore;
        private readonly int _alienWave;
        private readonly float _delayOnRepeatMS;

        public LossScreenLayer(Enemies selectedEnemy, Weapons selectedWeapon, Battlegrounds selectedBattleground, int alienScore = 0, int alienWave = 0)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;

            _alienScore = alienScore;
            _alienWave = alienWave;
            _delayOnRepeatMS = 500f;

            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    SetBackground("UI/Loss scenes/afghanistan-lost-war.jpg");
                    break;
                case Battlegrounds.Denmark:
                    SetBackground("UI/Loss scenes/denmark-lost-war.jpg");
                    break;
                case Battlegrounds.England:
                    SetBackground("UI/Loss scenes/UK-lost-war.jpg");
                    break;
                case Battlegrounds.Estonia:
                    SetBackground("UI/Loss scenes/estonia-lost-war.jpg");
                    break;
                case Battlegrounds.Finland:
                    SetBackground("UI/Loss scenes/Finland-lost-war.jpg");
                    break;
                case Battlegrounds.France:
                    SetBackground("UI/Loss scenes/france-lost-war.jpg");
                    break;
                case Battlegrounds.Georgia:
                    SetBackground("UI/Loss scenes/georgia-lost-war.jpg");
                    break;
                case Battlegrounds.GreatBritain:
                    SetBackground("UI/Loss scenes/UK-lost-war.jpg");
                    break;
                case Battlegrounds.Iraq:
                    SetBackground("UI/Loss scenes/iraq-lost-war.jpg");
                    break;
                case Battlegrounds.Israel:
                    SetBackground("UI/Loss scenes/israel-lost-war.jpg");
                    break;
                case Battlegrounds.Japan:
                    SetBackground("UI/Loss scenes/japan-lost-war.jpg");
                    break;
                case Battlegrounds.Libya:
                    SetBackground("UI/Loss scenes/libya-lost-war.jpg");
                    break;
                case Battlegrounds.Norway:
                    SetBackground("UI/Loss scenes/norway-lost-war.jpg");
                    break;
                case Battlegrounds.Poland:
                    SetBackground("UI/Loss scenes/poland-lost-war.jpg");
                    break;
                case Battlegrounds.Russia:
                    SetBackground("UI/Loss scenes/russia-lost-war.jpg");
                    break;
                case Battlegrounds.SouthKorea:
                    SetBackground("UI/Loss scenes/south-korea-lost-war.jpg");
                    break;
                case Battlegrounds.Syria:
                    SetBackground("UI/Loss scenes/syria-lost-war.jpg");
                    break;
                case Battlegrounds.Ukraine:
                    SetBackground("UI/Loss scenes/ukraine-lost-war.jpg");
                    break;
                case Battlegrounds.UnitedStates:
                    SetBackground("UI/Loss scenes/Usa-lost-war.jpg");
                    break;
                case Battlegrounds.Vietnam:
                    SetBackground("UI/Loss scenes/vietnam-lost-war.jpg");
                    break;
                case Battlegrounds.Moon:
                    _youAreDefeated = AddImage(0, 380, "UI/Loss scenes/loss-screen-you-are-defeated-text.png", 3);
                    _youAreDefeated.Opacity = 0;
                    SetBackground("UI/Loss scenes/Moon-lost-war.jpg");
                    break;
            }

            if (Settings.Instance.VoiceoversEnabled)
            {
                if (SelectedEnemy == Enemies.Aliens)
                {
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/you are defeaded VO_mono.wav");
                }
                else
                {
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/You are dead VO_mono.wav");
                }
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Now get up and get your revenge VO_mono.wav");
            }

            AdMobManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;
            ScheduleOnce((_) =>
            {
                try { AdMobManager.ShowBannerBottom(); }
                catch { }
            }, 0f);

            //submit score during shown victory image
            if (_alienScore > GamePlayLayer.BestScoreAlien)
            {
                GamePlayLayer.BestScoreAlien = _alienScore;
                GamePlayLayer.BestScoreAlienWave = _alienWave;

                Player.Instance.SetDayScore(_alienScore, true);
            }
            Player.Instance.Credits += _alienScore;
            ScheduleOnce(async (_) =>
            {
                _isWeHaveScores = await LeaderboardManager.SubmitScoreProAsync(_alienScore, _alienWave);
                _isDoneWaitingForScores = true;
            },
                0f);
            //_isDoneWaitingForScores = true;

            if (SelectedEnemy == Enemies.Aliens)
            {
                GameEnvironment.PlayMusic(Music.GameOverAlien);
            }
            else
            {
                GameEnvironment.PlayMusic(Music.GameOver);
            }

            if (SelectedEnemy == Enemies.Aliens)
            {
                //-------------- Prabhjot ----------------//
                _youAreDefeated = AddImage(0, 380, "UI/Loss scenes/loss-screen-you-are-defeated-text.png", 3);
                _youAreDefeated.Opacity = 0;
                SetBackground("UI/Loss scenes/Moon-lost-war.jpg");
                Schedule(FadeYouAreDefeated);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    _isYouAreDefPlayed = true;
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
                    ScheduleOnce(CalloutRevenge, 2f);
                }

                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    ScheduleOnce(ShowAd, 3.5f);
                }
                else
                {
                    GameEnvironment.PreloadSoundEffect(SoundEffect.ShowScore);
                    _hasScore = true;
                    ScheduleOnce(ShowScoreAlien, 2f);
                }
            }

            ScheduleOnce(ShowGetRevenge, 2f);
        }

        private void CalloutRevenge(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Now get up and get your revenge VO_mono.wav");
        }

        private bool _hasScore;

        private CCNodeExt _getRevengeNode;

        private void ShowGetRevenge(float d)
        {
            _getRevengeNode = new CCNodeExt();

            if (SelectedEnemy == Enemies.Aliens)
            {
                _getRevengeNode.AddImage(0, 380, "UI/Loss scenes/loss-screen-you-are-defeated-text.png", 3);
            }
            else if (!_hasScore)
            {
                _getRevengeNode.AddImage(0, 380, "UI/Loss scenes/You-are-dead-no-track-record-title.png", 3);
            }
            else
            {
                _getRevengeNode.AddImage(0, 380, "UI/You-are-dead-now-get-up-and-get-your-revenge.png", 3);
            }

            var mainMenu = _getRevengeNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            mainMenu.OnClick += mainMenu_OnClick;

            var revenge = _getRevengeNode.AddButton(740, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            revenge.ButtonType = ButtonType.Rewind;
            revenge.OnClick += revenge_OnClick;

            _getRevengeNode.Opacity = 0;
            foreach (var child in _getRevengeNode.Children)
            {
                child.Opacity = _getRevengeNode.Opacity;
            }


            AddChild(_getRevengeNode);

            Schedule(FadeRevengeNode);

            if (Settings.Instance.VoiceoversEnabled)
            {
                if (SelectedEnemy == Enemies.Aliens)
                {
                    if(!_isYouAreDefPlayed)
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
                    //ScheduleOnce(CalloutRevenge, 2.5f);
                }
                else
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/You are dead VO_mono.wav");
                    ScheduleOnce(CalloutRevenge, 2f);
                }

            }

        }

        //private void CalloutDefeated(float dt)
        //{
        //    CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
        //    ScheduleOnce(CalloutRevenge, 2.5f);

        //}

        //private void CalloutDead(float dt)
        //{
        //    CCAudioEngine.SharedEngine.PlayEffect("Sounds/You are dead VO_mono.wav");
        //    ScheduleOnce(CalloutRevenge, 2f);
        //}

        private void FadeYouAreDefeated(float dt)
        {
            _youAreDefeated.Opacity += 2;
            if (_youAreDefeated.Opacity >= 251)
            {
                _youAreDefeated.Opacity = 255;
                Unschedule(FadeYouAreDefeated);
            }
        }


        private void FadeRevengeNode(float dt)
        {
            _getRevengeNode.Opacity += 5;
            if (_getRevengeNode.Opacity >= 251)
            {
                _getRevengeNode.Opacity = 255;
                Unschedule(FadeRevengeNode);
            }

            foreach (var child in _getRevengeNode.Children)
            {
                child.Opacity = _getRevengeNode.Opacity;
            }
        }

        private void RemoveRevengeNode(float dt)
        {
            RemoveChild(_getRevengeNode);
        }

        private CCNodeExt _scoreNode;

        //private void ShowScore(float d)
        //{
        //    switch (GamePlayLayer.BestScoreCountry)
        //    {
        //        case BATTLEGROUNDS.AFGHANISTAN:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-afghanistan.png", 3);
        //            break;
        //        case BATTLEGROUNDS.DENMARK:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-denmark.png", 3);
        //            break;
        //        case BATTLEGROUNDS.ENGLAND:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-england.png", 3);
        //            break;
        //        case BATTLEGROUNDS.ESTONIA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-estonia.png", 3);
        //            break;
        //        case BATTLEGROUNDS.FINLAND:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-finland.png", 3);
        //            break;
        //        case BATTLEGROUNDS.FRANCE:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-france.png", 3);
        //            break;
        //        case BATTLEGROUNDS.GEORGIA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-georgia.png", 3);
        //            break;
        //        case BATTLEGROUNDS.GREAT_BRITAIN:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-great-britain.png", 3);
        //            break;
        //        case BATTLEGROUNDS.IRAQ:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-iraq.png", 3);
        //            break;
        //        case BATTLEGROUNDS.ISRAEL:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-israel.png", 3);
        //            break;
        //        case BATTLEGROUNDS.JAPAN:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-japan.png", 3);
        //            break;
        //        case BATTLEGROUNDS.LIBYA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-libya.png", 3);
        //            break;
        //        case BATTLEGROUNDS.NORWAY:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-norway.png", 3);
        //            break;
        //        case BATTLEGROUNDS.POLAND:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-poland.png", 3);
        //            break;
        //        case BATTLEGROUNDS.RUSSIA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-russia.png", 3);
        //            break;
        //        case BATTLEGROUNDS.SOUTH_KOREA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-south-korea.png", 3);
        //            break;
        //        case BATTLEGROUNDS.SYRIA:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-syria.png", 3);
        //            break;
        //        case BATTLEGROUNDS.UKRAINE:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-ukraine.png", 3);
        //            break;
        //        case BATTLEGROUNDS.UNITED_STATES:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-united-states.png", 3);
        //            break;
        //        case BATTLEGROUNDS.VIETNAM:
        //            _scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-vietnam.png", 3);
        //            break;
        //    }

        //    _scoreNode.AddImage(0, 153, "UI/victory-score-board-just-background.png", 2);
        //    _scoreNode.AddImage(0, 153, "UI/victory-score-board-just-text.png", 3);

        //    _scoreNode.AddImage(0, 70, "UI/victory-share-your-score-and-earn-credits-text.png", 3);

        //    _scoreNode.AddImageLabelRightAligned(466, 391, GamePlayLayer.BestScoreTime.ToString("0.00"), 57);
        //    _scoreNode.AddImage(466, 385, "UI/victory&social-share-score-numbers-(sec).png", 4);

        //    _scoreNode.AddImageLabelRightAligned(572, 318, GamePlayLayer.BestScoreAccuracy.ToString("0.00"), 57);
        //    _scoreNode.AddImage(570, 315, "UI/victory&social-share-score-numbers-(%).png", 4);



        //    _scoreNode.AddImageLabel(420, 245, GamePlayLayer.BestScore.ToString(), 57);

        //    _scoreNode.AddImageLabel(490, 170, Player.Instance.Score.ToString(), 57);

        //    CCSpriteButton yes = _scoreNode.AddButton(850, 70, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
        //    yes.OnClick += yes_OnClick;

        //    CCSpriteButton no = _scoreNode.AddButton(600, 70, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
        //    no.OnClick += no_OnClick;

        //    _scoreNode.Opacity = 0;
        //    foreach (CCNode child in _scoreNode.Children) { child.Opacity = _scoreNode.Opacity; };


        //    AddChild(_scoreNode);

        //    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SHOWSCORE);
        //    Schedule(delegate
        //    {
        //        _scoreNode.Opacity += 5;
        //        if (_scoreNode.Opacity > 250)
        //        {
        //            _scoreNode.Opacity = 255;
        //            UnscheduleAll();
        //        }

        //        foreach (CCNode child in _scoreNode.Children)
        //        {
        //            child.Opacity = _scoreNode.Opacity;
        //        }
        //    });
        //}


        private CCSprite _recordNotification;
        private CCSprite _recordNotificationImage;
        private CCSpriteButton _recordOkIGotIt;
        private bool _recordNotificationShown;

        private void ShowRecordNotification(float dt)
        {
            if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance && LeaderboardManager.PlayerRankProMonthly.Rank == 1)
            {
                Player.Instance.Credits += 45000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance && LeaderboardManager.PlayerRankProMonthly.Rank == 2)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance && LeaderboardManager.PlayerRankProMonthly.Rank == 3)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance && LeaderboardManager.PlayerRankProWeekly.Rank == 1)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance && LeaderboardManager.PlayerRankProWeekly.Rank == 2)
            {
                Player.Instance.Credits += 20000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance && LeaderboardManager.PlayerRankProWeekly.Rank == 3)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance && LeaderboardManager.PlayerRankProDaily.Rank == 1)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance && LeaderboardManager.PlayerRankProDaily.Rank == 2)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance && LeaderboardManager.PlayerRankProDaily.Rank == 3)
            {
                Player.Instance.Credits += 5000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-3rd-background-with-text.png", 3);
            }
            else
            {
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-notification-background-with-text.png", 3);
                if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProAlltime.Score) < Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-all-time.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-month.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-week.png", 4);
                }
                else /*if (isWeHaveScores && score == LeaderboardManager.PlayerRankProDaily.Score)*/
                {
                    _recordNotificationImage = AddImage(35, 379, "UI/victory-notification-personal-best-of-day.png", 4);
                }
            }

            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            _recordOkIGotIt = AddButton(42, 83, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _recordOkIGotIt.OnClick += recordOkIGotIt_OnClick;
            _recordNotificationShown = true;
        }


        private void recordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_recordOkIGotIt);
            RemoveChild(_recordNotification);
            if (_recordNotificationImage != null)
                RemoveChild(_recordNotificationImage);
            ScheduleOnce(ShowScoreAlien, 0f);
        }

        private float _waitForScoreCounter;
        private CCSprite[] _creditsLabels;

        private void ShowScoreAlien(float d)
        {
            WaitScoreBoardServiceResponseWhile(() => !_isDoneWaitingForScores, ref _waitForScoreCounter, _delayOnRepeatMS);

            ScheduleOnce(RemoveRevengeNode, 0f);
            _btnContinue.ChangeAvailability(true);
            _mainMenu.ChangeAvailability(true);

            if (_isWeHaveScores
                && _alienScore > 0
                && (Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProAlltime.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProMonthly.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProWeekly.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProDaily.GetLeaderboardItemField(Score)) < Tolerance)
                && !_recordNotificationShown)
            {
                ScheduleOnce(ShowRecordNotification, 0.5f);
                return;
            }

            //scoreNode = new CCNodeExt();
            //scoreNode.AddImage(0, 564, "UI/Loss scenes/You-are-dead-title.png", 3);
            //scoreNode.AddImage(650, 455, "UI/victory&social-share-global-ranking-all-text.png", 3);


            _scoreNode = new CCNodeExt();
            _scoreNode.AddImage(0, 225, "UI/game-over-screen-extinction-level-scoreboard-background-bars.png", 2);
            _scoreNode.AddImage(245, 225, "UI/game-over-screen-extinction-level-scoreboard-title-text.png", 3);
            _scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
            _shareYourScore = _scoreNode.AddImage(0, 80, "UI/game-over-screen-extinction-level-share-your-score-text.png", 3);


            /* old

            scoreNode.AddImage(147, 488, "UI/game-over-screen-moon-level-game-over-text.png", 3);
            scoreNode.AddImage(610, 290, "UI/game-over-screen-moon-level-global-ranking-text.png", 3);
            scoreNode.AddImage(5, 290, "UI/game-over-screen-moon-level-your-score-text.png", 3);

            scoreNode.AddImage(0, 198, "UI/game-over-screen-moon-level-score-board-just-background.png", 2);
            scoreNode.AddImage(10, 219, "UI/game-over-screen-moon-level-credits-earned-text.png", 3);

            scoreNode.AddImage(0, 70, "UI/victory-share-your-score-and-earn-credits-text.png", 3);

            */

            //current score
            _scoreNode.AddImageLabelCentered(155, 380, _alienScore.ToString(), 52);
            _scoreNode.AddImageLabelCentered(155, 314, _alienWave.ToString(), 50);
            //scoreNode.AddImageLabelCentered(155, 247, rank.ToString(), 52);


            if (_isWeHaveScores && LeaderboardManager.PlayerRankProMonthly != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance)
            {
                _scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-month-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProMonthly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankProWeekly != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance)
            {
                _scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-week-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProWeekly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance)
            {
                _scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-day-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProDaily.Rank.ToString("0"), 52);
            }
            else
            {
                _scoreNode.AddImage(0, 440, "UI/victory-earth-level-non-record-title-text.png", 3);
                _scoreNode.AddImage(40, 251, "UI/victory-earth-level-not-ranked-text.png", 3);
            }
            //credits
            _creditsLabels = _scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);

            //_btnContinue = _scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            _btnContinue = _scoreNode.AddButton(740, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            _btnContinue.Visible = true; // Previously --- false --- Changed by Prabhjot
            _btnContinue.OnClick -= BtnContinue_OnClick;
            _btnContinue.OnClick += BtnContinue_OnClick;

            _mainMenu = _scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            _mainMenu.Visible = true; // Previously this line was not written --- Changed by Prabhjot
            _mainMenu.OnClick -= mainMenu_OnClick;
            _mainMenu.OnClick += mainMenu_OnClick;

            if (_isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && LeaderboardManager.PlayerRankProWeekly != null && LeaderboardManager.PlayerRankProMonthly != null)
            {
                //day
                _scoreNode.AddImageLabelCentered(700, 380, LeaderboardManager.PlayerRankProDaily.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProDaily.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProDaily.Score ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(700, 314, LeaderboardManager.PlayerRankProDaily.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(700, 247, LeaderboardManager.PlayerRankProDaily.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : "green");

                //------------ Prabhjot ------------//
                //week
                _scoreNode.AddImageLabelCentered(847, 380, LeaderboardManager.PlayerRankProWeekly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProWeekly.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProWeekly.Score ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(847, 314, LeaderboardManager.PlayerRankProWeekly.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(847, 247, LeaderboardManager.PlayerRankProWeekly.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : "green");
                //month
                _scoreNode.AddImageLabelCentered(1011, 380, LeaderboardManager.PlayerRankProMonthly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProMonthly.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProMonthly.Score ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(1011, 314, LeaderboardManager.PlayerRankProMonthly.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "green" : "yellow");
                _scoreNode.AddImageLabelCentered(1011, 247, LeaderboardManager.PlayerRankProMonthly.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : "green");

                _yes = _scoreNode.AddButton(834, 90, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
                _yes.OnClick += yes_OnClick;


                _no = _scoreNode.AddButton(520, 90, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
                _no.OnClick += no_OnClick;

                _mainMenu.Visible = false;
                _btnContinue.Visible = false;
            }
            else
            {
                //no or weak internet
                _shareYourScore.Visible = false;
                ScheduleOnce((_) => _btnContinue.ChangeVisibility(true), 0f);

                _scoreNode.AddImage(633, 251, "UI/victory-no-internet-connection-text.png", 3);

                if (!NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    _scoreNode.AddImage(562, 280, "UI/Main-screen-off-line-notification.png", 3);
                }
                else
                {
                    _scoreNode.AddImage(562, 280, "UI/My-stats-&-rewards-slow-internet-connection-notification.png", 3);
                }
            }

            _scoreNode.Opacity = 0;
            foreach (var child in _scoreNode.Children)
            {
                child.Opacity = _scoreNode.Opacity;
            }

            AddChild(_scoreNode);

            GameEnvironment.PlaySoundEffect(SoundEffect.ShowScore);
            Schedule(FadeScoreNode);
        }

        private async void BtnContinue_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();

            var newLayer = new GamePlayLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, true);
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void FadeScoreNode(float dt)
        {
            _scoreNode.Opacity += 5;
            if (_scoreNode.Opacity > 250)
            {
                _scoreNode.Opacity = 255;
                Unschedule(FadeScoreNode);
            }

            foreach (var child in _scoreNode.Children)
            {
                child.Opacity = _scoreNode.Opacity;
            }

            _youAreDefeated.Opacity = (byte)(255 - _scoreNode.Opacity);
        }

        private async void mainMenu_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            AdMobManager.HideBanner();
            CCAudioEngine.SharedEngine.StopAllEffects();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void revenge_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();
            
            var newLayer = new GamePlayLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, true);
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        //CCNodeExt shareNode;
        //CCSpriteTwoStateButton shareScoreBoard;
        //CCSpriteTwoStateButton shareTwitter;
        //CCSpriteTwoStateButton shareFacebook;

        private CCNodeExt _sl;

        private void yes_OnClick(object sender, EventArgs e)
        {
            _sl = new CCNodeExt();

            _sl.AddImageCentered(1136 / 2, 598, "UI/victory-i-just-saved-planet-earth.png", 2);

            _sl.AddImageCentered(1136 / 2, 86, "UI/social-share-game-advertisement-background-and-text.png", 2);

            _sl.AddImageCentered(1136 / 2, 371, "UI/social-share-result-&_ranking-table.png", 2);

            _sl.AddImageLabel(420, 295, _alienScore.ToString(), 52);

            if (_isWeHaveScores && LeaderboardManager.PlayerRankProMonthly != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance)
            {
                _sl.AddImageLabelCentered(995, 295, LeaderboardManager.PlayerRankProMonthly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance)
            {
                _sl.AddImageCentered(995, 295, "UI/number_52_NA.png", 2);
            }
            if (_isWeHaveScores && LeaderboardManager.PlayerRankProWeekly != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance)
            {
                _sl.AddImageLabelCentered(837, 295, LeaderboardManager.PlayerRankProWeekly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance)
            {
                _sl.AddImageCentered(837, 295, "UI/number_52_NA.png", 2);
            }
            if (_isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance)
            {
                _sl.AddImageLabelCentered(701, 295, LeaderboardManager.PlayerRankRegularDaily?.Rank.ToString("0"), 52);
            }
            else
            {
                _sl.AddImage(743, 295, "UI/victory-earth-level-not-ranked-text.png", 3);
            }

            _scoreNode.Visible = false;
            AddChild(_sl);


            _shareYourScore.Visible = false;
            _yes.Visible = false;
            _no.Visible = false;
            SocialNetworkShareManager.ShareLayer("facebook", this);


            _scoreNode.Visible = true;
            RemoveChild(_sl);


            Player.Instance.Credits += _alienWave * 1000;
            foreach (var spr in _creditsLabels)
            {
                _scoreNode.RemoveChild(spr);
            }
            _creditsLabels = _scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
            /*
            if (shareNode == null)
            {
                shareNode = new CCNodeExt();
                shareNode.AddImageCentered(1136 / 2, 598, "UI/Score-share-picker-share-your-score-in-text.png", 2);

                shareScoreBoard = shareNode.AddTwoStateButton(45, 465, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
                shareScoreBoard.OnClick += shareScoreBoard_OnClick;
                shareScoreBoard.ButtonType = BUTTON_TYPE.OnOff;
                shareNode.AddImage(197, 469, "UI/Score-share-picker-game-score-board-text.png", 3);


                shareTwitter = shareNode.AddTwoStateButton(45, 374, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
                shareTwitter.OnClick += shareTwitter_OnClick;
                shareTwitter.ButtonType = BUTTON_TYPE.OnOff;
                shareNode.AddImage(197, 378, "UI/Score-share-picker-twitter-text.png", 3);

                shareFacebook = shareNode.AddTwoStateButton(45, 275, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
                shareFacebook.OnClick += shareFacebook_OnClick;
                shareFacebook.ButtonType = BUTTON_TYPE.OnOff;
                shareNode.AddImage(197, 279, "UI/Score-share-picker-facebook-text.png", 3);


                CCSpriteButton cancelBtn = shareNode.AddButton(47, 148, "UI/Score-share-picker-cancel-button-untapped.png", "UI/Score-share-picker-cancel-button-tapped.png");
                cancelBtn.OnClick += cancelBtn_OnClick;

                CCSpriteButton shareBtn = shareNode.AddButton(809, 148, "UI/Score-share-picker-share-button-untapped.png", "UI/Score-share-picker-share-button-tapped.png");
                shareBtn.OnClick += shareBtn_OnClick;


                shareNode.AddImage(1, 70, "UI/Score-share-picker-terms-of-sharing-backqround.png", 3);
                shareNode.AddImage(2, 70, "UI/Score-share-picker-terms-of-sharing-text-area-without-links.png", 4);

                CCSpriteButton terms = shareNode.AddButton(555, 70, "UI/Score-share-picker-terms-of-sharing-text-area1-with-link.png", "UI/Score-share-picker-terms-of-sharing-text-area1-with-link.png", 5);

                CCSpriteButton privacy = shareNode.AddButton(888, 70, "UI/Score-share-picker-terms-of-sharing-text-area2-with-link.png", "UI/Score-share-picker-terms-of-sharing-text-area2-with-link.png", 5);

                shareNode.Opacity = 0;
                foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
                this.AddChild(shareNode);

            }

            this.Schedule(delegate (float dt)
            {
                if (scoreNode.Opacity > 0)
                {
                    scoreNode.Opacity -= 20;
                    if (scoreNode.Opacity < 20)
                    {
                        scoreNode.Opacity = 0;
                    }
                    foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
                }
                else
                {
                    shareNode.Opacity += 20;
                    if (shareNode.Opacity > 235)
                    {
                        this.UnscheduleAll();
                        shareNode.Opacity = 255;
                    }
                    foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
                }
            });*/
        }


        private void ShowAd(float dt)
        {
            _btnContinue.ChangeAvailability(false);
            _mainMenu.ChangeAvailability(false);

            AdMobManager.HideBanner();
            AdMobManager.ShowInterstitial(0);
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        {
            ScheduleOnce(RemoveRevengeNode, 0f);
        }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            AdMobManager.ShowBannerBottom();
            GameEnvironment.PreloadSoundEffect(SoundEffect.ShowScore);
            _hasScore = true;
            ScheduleOnce(ShowScoreAlien, 0.1f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            AdMobManager.ShowBannerBottom();
            GameEnvironment.PreloadSoundEffect(SoundEffect.ShowScore);
            _hasScore = true;
            ScheduleOnce(ShowScoreAlien, 0.1f);
        }

        //private void shareScoreBoard_OnClick(object sender, EventArgs e)
        //{
        //    shareScoreBoard.ChangeState();
        //    shareScoreBoard.SetStateImages();
        //}

        //private void shareTwitter_OnClick(object sender, EventArgs e)
        //{
        //    shareTwitter.ChangeState();
        //    shareTwitter.SetStateImages();
        //}

        //private void shareFacebook_OnClick(object sender, EventArgs e)
        //{
        //    shareFacebook.ChangeState();
        //    shareFacebook.SetStateImages();
        //}

        //private void cancelBtn_OnClick(object sender, EventArgs e)
        //{
        //    this.Schedule(delegate (float dt)
        //    {
        //        if (shareNode.Opacity > 0)
        //        {
        //            shareNode.Opacity -= 20;
        //            if (shareNode.Opacity < 20)
        //            {
        //                shareNode.Opacity = 0;
        //            }
        //            foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
        //        }
        //        else
        //        {
        //            scoreNode.Opacity += 20;
        //            if (scoreNode.Opacity >= 235)
        //            {
        //                scoreNode.Opacity = 255;
        //                this.UnscheduleAll();
        //            }
        //            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
        //        }
        //    });
        //}

        //private void shareBtn_OnClick(object sender, EventArgs e)
        //{
        //    GamePlayLayer.BestScore = 0;
        //    this.Schedule(delegate (float dt)
        //    {
        //        if (shareNode.Opacity > 0)
        //        {
        //            shareNode.Opacity -= 20;
        //            if (shareNode.Opacity < 20)
        //            {
        //                shareNode.Opacity = 0;
        //                this.UnscheduleAll();
        //                showGetRevenge(0);
        //            }
        //            foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
        //        }
        //    });
        //}

        private void no_OnClick(object sender, EventArgs e)
        {
            _shareYourScore.Visible = false;
            _yes.Visible = false;
            _no.Visible = false;
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
            /*
            this.Schedule(delegate (float dt)
            {
                if (scoreNode.Opacity > 0)
                {
                    scoreNode.Opacity -= 20;
                    if (scoreNode.Opacity < 20)
                    {
                        scoreNode.Opacity = 0;
                        this.UnscheduleAll();
                        showGetRevenge(0);
                    }
                    foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
                }
            });**/
        }
    }
}

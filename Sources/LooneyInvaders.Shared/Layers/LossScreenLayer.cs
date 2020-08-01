using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
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
        private CCSprite _loadingViewPlaceholder;
        private CCSpriteButton _yes;
        private CCSpriteButton _no;
        private readonly CCSprite _youAreDefeated;
        private readonly CCSprite _cartoonBackground;

        private bool _isWeHaveScores;
        private bool _isDoneWaitingForScores;
        private bool _finishAfterWatchingAd;

        private readonly int _alienScore;
        private readonly int _alienWave;
        private readonly float _delayOnRepeatMS;
        
        private (int Count, List<string> Images) _loadingView = (0, new List<string>());
        private readonly TimeSpan _animationMaxTime = TimeSpan.FromSeconds(14);
        private bool _isNextLayerPreparing;

        public LossScreenLayer(Enemies selectedEnemy, Weapons selectedWeapon, Battlegrounds selectedBattleground, int alienScore = 0, int alienWave = 0)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;
            _delayOnRepeatMS = 500f;

            if (SelectedEnemy == Enemies.Aliens)
            {
                _alienScore = alienScore;
                _alienWave = alienWave;
                
                for (var i = 0; i < 32; ++i)
                {
                    _loadingView.Images.Add($"UI/Leaderboard/Conneting-to-leaderboard-1{i.ToString("D" + 2)}.png");
                }
                _loadingView.Count = _loadingView.Images.Count;
                _loadingViewPlaceholder = new CCSprite();

                _cartoonBackground = AddImage(0, 0, "UI/screen-transition_stage_6.png");
            }

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
            AdManager.ClearInterstitialEvents(AdMobManager_OnInterstitialAdOpened, AdMobManager_OnInterstitialAdClosed, AdMobManager_OnInterstitialAdFailedToLoad);
            AdManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;

            if (SelectedEnemy == Enemies.Aliens)
            {
                if (_alienScore > GamePlayLayer.BestScoreAlien)
                {
                    GamePlayLayer.BestScoreAlien = _alienScore;
                    GamePlayLayer.BestScoreAlienWave = _alienWave;
                    Player.Instance.SetDayScore(_alienScore, true);
                }

                if (Settings.Instance.VoiceoversEnabled)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
                    ScheduleOnce(CalloutRevenge, 2.4f);
                }
                Player.Instance.Credits += _alienScore;
                Settings.Instance.LastOfflineProScore = _alienScore;
                Settings.Instance.LastOfflineAlienWave = _alienWave;
                GameEnvironment.PlayMusic(Music.GameOverAlien);
                GameEnvironment.PreloadSoundEffect(SoundEffect.ShowScore);

                var millisecondsToWaitAnimation = 2000;
                ScheduleOnce(async (_) =>
                {
                    _isWeHaveScores = await LeaderboardManager.SubmitScoreProAsync(_alienScore, _alienWave);
                    await Task.Delay(millisecondsToWaitAnimation);
                    _isDoneWaitingForScores = true;
                }, 0f);
                Schedule(AnimateLoadingView, 0.065f); //reached experimentally
            }
            else
            {
                GameEnvironment.PlayMusic(Music.GameOver);
                ScheduleOnce(ShowGetRevengeRegularLevel, 2.3f);
            }
        }

        public override async Task ContinueInitializeAsync()
        {
            await Task.Delay(15); //some small delay
            await base.ContinueInitializeAsync();
        }

        private void AnimateLoadingView(float obj)
        {
            LoopAnimateWithCCSprites(_loadingView.Images,
                200, 230,
                ref _loadingView.Count,
                ref _loadingViewPlaceholder,
                () => !_isDoneWaitingForScores &&
                      !(_recordNotification?.Visible).GetValueOrDefault() &&
                      !(_btnContinue?.Visible).GetValueOrDefault() &&
                      !(_shareYourScore?.Visible).GetValueOrDefault(),
                async (_) =>
                {
                    if (_cartoonBackground == null)
                    { return; }
                    if (!_cartoonBackground.Visible)
                    { Unschedule(AnimateLoadingView); return; }

                    Unschedule(AnimateLoadingView);
                    await AnimateFadeInAsync(() =>
                    {
                        //_youAreDefeated.Visible = true;
                        _cartoonBackground.Visible = false;
                        RemoveChild(_cartoonBackground);
                        ScheduleOnce(_ => ShowScore(true), 1.5f);
                    });
                }, _animationMaxTime);
        }

        private void CalloutRevenge(float dt)
        {
            if (!_isNextLayerPreparing)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Now get up and get your revenge VO_mono.wav");
            }
        }

        private CCNodeExt _getRevengeNode;

        private void ShowGetRevengeRegularLevel(float d)
        {
            _getRevengeNode = new CCNodeExt();
            _getRevengeNode.AddImage(0, 380, "UI/Loss scenes/You-are-dead-no-track-record-title.png", 3);
            
            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/You are dead VO_mono.wav");
                ScheduleOnce(CalloutRevenge, 2f);
            }

            var mainMenu = _getRevengeNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            mainMenu.OnClick += MainMenu_OnClick;

            var revenge = _getRevengeNode.AddButton(740, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            revenge.ButtonType = ButtonType.Rewind;
            revenge.OnClick += Revenge_OnClick;

            _getRevengeNode.Opacity = 0;
            foreach (var child in _getRevengeNode.Children)
            {
                child.Opacity = _getRevengeNode.Opacity;
            }

            AddChild(_getRevengeNode);
            Schedule(FadeRevengeNode);
        }

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
            if (_getRevengeNode != null)
            {
                RemoveChild(_getRevengeNode);
            }
        }

        private CCNodeExt _scoreNode;

        private CCSprite _recordNotification;
        private CCSprite _recordNotificationImage;
        private CCSpriteButton _recordOkIGotIt;
        private bool _recordNotificationShown;

        private void ShowRecordNotification()
        {
            _recordNotificationShown = true;

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
            _recordOkIGotIt.OnClick += RecordOkIGotIt_OnClick;
        }

        private void RecordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_recordOkIGotIt);
            RemoveChild(_recordNotification);
            if (_recordNotificationImage != null)
            {
                RemoveChild(_recordNotificationImage);
            }
            ScheduleOnce(_ => ShowScore(false), 0.1f);
        }

        private int _waitForScoreCounter;
        private CCSprite[] _creditsLabels;
        
        private async void ShowScore(bool showAd)
        {
            await WaitScoreBoardServiceResponseWhile(() => !_isDoneWaitingForScores, (() => _waitForScoreCounter, (val) => _waitForScoreCounter = val), _delayOnRepeatMS);

            if (showAd && !_finishAfterWatchingAd)
            {
                ScheduleOnce(_ => AdManager.ShowInterstitial(), 0.1f);
            }
            else ScheduleOnce(ShowScoreAliens, 0.1f);
        }

        private void ShowScoreAliens(float d)
        {
            if (_isWeHaveScores
                && _alienScore > 0
                && (Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProAlltime.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProMonthly.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProWeekly.GetLeaderboardItemField(Score)) < Tolerance
                    || Math.Abs(_alienScore - (double)LeaderboardManager.PlayerRankProDaily.GetLeaderboardItemField(Score)) < Tolerance)
                && !_recordNotificationShown)
            {
                ScheduleOnce(_ => { try { ShowRecordNotification(); } catch { Caught("9"); } }, 0.5f);
                return;
            }

            if(_finishAfterWatchingAd) {
                return;
            }
            _finishAfterWatchingAd = true;

            _scoreNode = _scoreNode ?? new CCNodeExt();
            _scoreNode.Opacity = 255;
            _scoreNode.AddImage(0, 225, "UI/game-over-screen-extinction-level-scoreboard-background-bars.png", 2);
            _scoreNode.AddImage(245, 225, "UI/game-over-screen-extinction-level-scoreboard-title-text.png", 3);
            _scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
            _shareYourScore = _scoreNode.AddImage(0, 80, "UI/game-over-screen-extinction-level-share-your-score-text.png", 3);
            //current score
            _scoreNode.AddImageLabelCentered(155, 380, _alienScore.ToString(), 52);
            _scoreNode.AddImageLabelCentered(155, 314, _alienWave.ToString(), 50);

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

            _btnContinue = _scoreNode.AddButton(740, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            _btnContinue.Visible = false;
            _btnContinue.OnClick += BtnContinue_OnClick;

            _mainMenu = _scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            _mainMenu.OnClick += MainMenu_OnClick;

            if (!_isWeHaveScores || (LeaderboardManager.PlayerRankProDaily == null && LeaderboardManager.PlayerRankProWeekly == null && LeaderboardManager.PlayerRankProMonthly == null))
            {
                // no or weak internet connection
                _shareYourScore.Visible = false;
                _btnContinue.ChangeVisibility(true);

                if (!NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    _scoreNode.AddImage(633, 251, "UI/victory-no-internet-connection-text.png", 3);
                    _scoreNode.AddImage(562, 280, "UI/Main-screen-off-line-notification.png", 3);
                }
                else
                {
                    _scoreNode.AddImage(562, 280, "UI/My-stats-&-rewards-slow-internet-connection-notification.png", 3);
                }
            }
            else
            {
                //day
                if (LeaderboardManager.PlayerRankProDaily != null)
                {
                    _scoreNode.AddImageLabelCentered(700, 380, LeaderboardManager.PlayerRankProDaily.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProDaily.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProDaily.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(700, 314, LeaderboardManager.PlayerRankProDaily.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(700, 247, LeaderboardManager.PlayerRankProDaily.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProDaily.Score) < Tolerance ? null : "green");
                }
                //week
                if (LeaderboardManager.PlayerRankProWeekly != null)
                {
                    _scoreNode.AddImageLabelCentered(847, 380, LeaderboardManager.PlayerRankProWeekly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProWeekly.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProWeekly.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(847, 314, LeaderboardManager.PlayerRankProWeekly.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(847, 247, LeaderboardManager.PlayerRankProWeekly.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProWeekly.Score) < Tolerance ? null : "green");
                }
                //month
                if (LeaderboardManager.PlayerRankProMonthly != null)
                {
                    _scoreNode.AddImageLabelCentered(1011, 380, LeaderboardManager.PlayerRankProMonthly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : _alienScore > LeaderboardManager.PlayerRankProMonthly.Score ? "red" : _alienScore < LeaderboardManager.PlayerRankProMonthly.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(1011, 314, LeaderboardManager.PlayerRankProMonthly.LevelsCompleted.ToString(CultureInfo.InvariantCulture), 50, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : _alienWave > LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "red" : _alienWave < LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(1011, 247, LeaderboardManager.PlayerRankProMonthly.Rank.ToString(), 52, Math.Abs(_alienScore - LeaderboardManager.PlayerRankProMonthly.Score) < Tolerance ? null : "green");
                }
                _yes = _scoreNode.AddButton(834, 90, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
                _yes.OnClick += (s, e) => { try { Yes_OnClick(); } catch { Caught("11"); } };

                _no = _scoreNode.AddButton(520, 90, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
                _no.OnClick += No_OnClick;

                _mainMenu.Visible = false;
                _btnContinue.Visible = false;
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
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
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

        private async void MainMenu_OnClick(object sender, EventArgs e)
        {
            _isNextLayerPreparing = true;
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void Revenge_OnClick(object sender, EventArgs e)
        {
            _isNextLayerPreparing = true;
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();
            
            var newLayer = new GamePlayLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, true);
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void Yes_OnClick()
        {
            CCNodeExt _sl = new CCNodeExt();

            _sl.AddImageCentered(1136 / 2, 598, "UI/victory-i-just-made-impressive-score.png", 2);
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
                _sl.AddImageLabelCentered(701, 295, LeaderboardManager.PlayerRankProDaily.Rank.ToString("0"), 52);
            }
            else
            {
                _sl.AddImage(743, 295, "UI/victory-earth-level-not-ranked-text.png", 3);
            }

            _scoreNode = _scoreNode ?? new CCNodeExt();
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
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        {
            ScheduleOnce(RemoveRevengeNode, 0f);
        }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            ScheduleOnce(ShowScoreAliens, 0.05f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            AdManager.HideInterstitial();
            ScheduleOnce(ShowScoreAliens, 0.05f);
        }

        private void No_OnClick(object sender, EventArgs e)
        {
            _shareYourScore.Visible = false;
            _yes.Visible = false;
            _no.Visible = false;
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
        }
        
        private void Caught(string message)
        {
            var s = message;
            Debug.WriteLine($"WARNING: got exception {nameof(Caught)} with {s}");
        }
    }
}

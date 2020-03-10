using System;
using System.Linq;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.PNS;
using System.Threading;

namespace LooneyInvaders.Layers
{
    public class MainScreenLayer : CCLayerColorExt
    {
        private PushNotificationService _pushNs;
        // TODO: neki enum za ovo u modelu
        private bool _isShownRankingDay = true;
        private bool _isShownRankingWeek;
        private bool _isShownRankingMonthly;

        private bool _isShownLeaderboardRegular = true;
        private bool _isShownLeaderboardPro;

        //CCSprite imgSpotlightDay;
        //CCSprite imgSpotlightWeek;
        //CCSprite imgSpotlightAllTime;

        private readonly CCSpriteButton _btnQuitGame;
        private readonly CCSpriteButton _btnTapToStart;
        private CCSpriteButton _btnRanking;
        private readonly CCSpriteButton _btnGameSettings;
        private readonly CCSpriteButton _btnGetCredits;
        private readonly CCSpriteButton _btnGameInfo;
        private readonly CCSpriteTwoStateButton _btnScoreboardRegular;
        private readonly CCSpriteTwoStateButton _btnScoreboardPro;
        private readonly CCSprite _imgScoreboard;

        // modal window
        private readonly CCSprite _imgQuitGameWindow;
        private readonly CCSprite _notShowNotificationText;
        private readonly CCSpriteTwoStateButton _btnQuitGameNotificationCheckMark;
        private readonly CCSpriteButton _btnProceedQuittingGame;
        private readonly CCSpriteButton _btnStopQuittingGame;
        private readonly CCSprite _imgQuickGameWindow;
        private readonly CCSpriteButton _btnQuickGame;
        private readonly CCSpriteButton _btnSelectionMode;

        private readonly CCSprite _imgProNotificationWindow;
        private readonly CCSpriteButton _btnProNotificationOk;
        private readonly CCSpriteTwoStateButton _btnProNotificationCheckMark;
        private readonly CCSprite _imgProNotificationCheckMarkLabel;
        private readonly CCSprite _imgOffline;

        private (int Count, List<string> Images) _leaderboardBackground = (0, new List<string>());
        private List<CCLabel> _leaderboardSprites = new List<CCLabel>();

        private CCSprite _imgScoresBackground;
        private CCSprite _gameTipBackground;
        private CCSpriteButton _yesThanks;
        private CCSpriteButton _noThanks;

        public MainScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            //------------ Prabhjot -----------//
            //SetTimer();

            //this.Enabled = false;
            //this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
            //btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
            //btnRanking.OnClick += BtnRanking_OnClick;

            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                if (_isShownLeaderboardPro == false)
                {
                    SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                    _btnRanking.OnClick += BtnRanking_OnClick;
                }
                else
                {
                    SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                    _btnRanking.OnClick += BtnRanking_OnClick;
                }
            }
            else
            {
                if (_isShownLeaderboardPro == false)
                {
                    SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");

                }
                else
                {
                    SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png", "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                }
            }

            /*
            this.AddImage(170, 275, "UI/Main-screen-highest_score-text.png");
            this.AddImage(440, 275, "UI/Main-screen-fastest_defend-text.png");
            this.AddImage(730, 275, "UI/Main-screen-best_accuracy-text.png");
            */

            _imgScoreboard = AddImage(220, 80, "UI/Main-screen-earth-lvl-scoreboard-table.png");

            _imgOffline = AddImage(300, 92, "UI/Main-screen-off-line-notification.png");
            _imgOffline.Visible = !NetworkConnectionManager.IsInternetConnectionAvailable();

            _leaderboardBackground.Images.Add("UI/looney_background_full1.png");
            _leaderboardBackground.Images.Add("UI/looney_background_full2.png");
            _leaderboardBackground.Images.Add("UI/looney_background_full3.png");
            _leaderboardBackground.Count = _leaderboardBackground.Images.Count;
            _imgScoresBackground = AddImage(408, 100, _leaderboardBackground.Images[0]);
            _imgScoresBackground.Visible = !_imgOffline.Visible;
            Schedule(AnimateScoresBackground, 0.5f);

            _btnTapToStart = AddButton(370, 475, "UI/Main-screen-tap-to-start-button-untapped.png", "UI/Main-screen-tap-to-start-button-tapped.png");
            _btnTapToStart.OnClick += BtnTapToStart_OnClick;

            _btnQuitGame = AddButton(1040, 560, "UI/Main-screen-quit-button-untapped.png", "UI/Main-screen-quit-button-tapped.png");
            _btnQuitGame.OnClick += BtnQuitGame_OnClick;
            _btnQuitGame.Visible = Shared.GameDelegate.CloseAppAllowed;

            _btnGameSettings = AddButton(30, 5, "UI/Main-screen-game_settings-button-untapped.png", "UI/Main-screen-game_settings-button-tapped.png");
            _btnGameSettings.OnClick += BtnGameSettings_OnClick;

            _btnGetCredits = AddButton(400, 5, "UI/Main-screen-get_credits-button-untapped.png", "UI/Main-screen-get_credits-button-tapped.png");
            _btnGetCredits.OnClick += BtnGetCredits_OnClick;

            _btnGameInfo = AddButton(760, 5, "UI/Main-screen-game_info-button-untapped.png", "UI/Main-screen-game_info-button-tapped.png");
            _btnGameInfo.OnClick += BtnGameInfo_OnClick;

            /* quit the game notification */

            _imgQuitGameWindow = AddImage(14, 40, "UI/Main-screen-quit-game-notification-background.png", 500);
            _imgQuitGameWindow.Visible = false;
            _btnQuitGameNotificationCheckMark = AddTwoStateButton(35, 205, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 610);
            _btnQuitGameNotificationCheckMark.ButtonType = ButtonType.CheckMark;
            _btnQuitGameNotificationCheckMark.OnClick += BtnQuitGameNotificationCheckMark_OnClick;
            _btnQuitGameNotificationCheckMark.Visible = false;
            _notShowNotificationText = AddImage(95, 210, "UI/do-not-show-this-notification-text.png", 610);
            _notShowNotificationText.Visible = false;
            _btnProceedQuittingGame = AddButton(705, 75, "UI/exit-game-button-untapped.png", "UI/exit-game-button-tapped.png", 510);
            _btnProceedQuittingGame.Visible = false;
            _btnStopQuittingGame = AddButton(35, 75, "UI/back-to-game-button-untapped.png", "UI/back-to-game-button-tapped.png", 510);
            _btnStopQuittingGame.Visible = false;

            /* quick game notification */
            _imgQuickGameWindow = AddImage(14, 8, "UI/Main-screen-quick-game-notification-with-text.png", 500);
            _imgQuickGameWindow.Visible = false;

            _btnSelectionMode = AddButton(35, 25, "UI/Main-screen-quick-game-notification-selection-mode-button-untapped.png", "UI/Main-screen-quick-game-notification-selection-mode-button-tapped.png", 510);
            _btnSelectionMode.Visible = false;
            _btnSelectionMode.Enabled = false;
            _btnSelectionMode.OnClick += BtnSelectionMode_OnClick;

            _btnQuickGame = AddButton(635, 25, "UI/Main-screen-quick-game-notification-quick-game-button-untapped.png", "UI/Main-screen-quick-game-notification-quick-game-button-tapped.png", 510);
            _btnQuickGame.Visible = false;
            _btnQuickGame.Enabled = false;
            _btnQuickGame.ButtonType = ButtonType.Rewind;
            _btnQuickGame.OnClick += BtnQuickGame_OnClick;

            /* pro level notification */
            _imgProNotificationWindow = AddImage(14, 8, "UI/Main-screen-pro-level-notification-background.png", 500);
            _imgProNotificationWindow.Visible = false;

            _btnProNotificationOk = AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _btnProNotificationOk.OnClick += BtnProNotificationOK_OnClick;
            _btnProNotificationOk.Visible = false;

            _btnProNotificationCheckMark = AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 610);
            _btnProNotificationCheckMark.OnClick += BtnProNotificationCheckMark_OnClick;
            _btnProNotificationCheckMark.ButtonType = ButtonType.CheckMark;
            _btnProNotificationCheckMark.Visible = false;

            _imgProNotificationCheckMarkLabel = AddImage(105, 60, "UI/do-not-show-text.png", 610);
            _imgProNotificationCheckMarkLabel.Visible = false;

            AddImage(790, 410, "UI/Main-screen-leaderboard-type-text.png");

            _btnScoreboardRegular = AddTwoStateButton(790, 355, "UI/Main-screen-regular-button-untapped.png", "UI/Main-screen-regular-button-tapped.png", "UI/Main-screen-regular-button-tapped.png", "UI/Main-screen-regular-button-untapped.png");
            _btnScoreboardRegular.SetStateImages(1);
            _btnScoreboardRegular.OnClick -= BtnScoreboardRegular_OnClick;
            _btnScoreboardRegular.OnClick += BtnScoreboardRegular_OnClick;

            _btnScoreboardPro = AddTwoStateButton(975, 355, "UI/Main-screen-pro-button-untapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-untapped.png");
            _btnScoreboardPro.SetStateImages(2);
            _btnScoreboardPro.OnClick -= BtnScoreboardPro_OnClick;
            _btnScoreboardPro.OnClick += BtnScoreboardPro_OnClick;

            Settings.Instance.ApplyValues(); // main menu background music starts to play here after setting the volume
            GameEnvironment.PlayMusic(Music.MainMenu);

            LeaderboardManager.ClearOnLeaderboardsRefreshedEvent();
            LeaderboardManager.OnLeaderboardsRefreshed += (s, e) => ScheduleOnce(RefreshLeaderboard, 0.1f);
            ScheduleOnce(FireRefreshLeaderboard, 0.02f);

            CheckForNotification();
        }

        private void SetTimer()
        {
            var backgroundTask = new Thread(new ThreadStart(() =>
            {
                var timer = new Timer((e) => Enabled = true,
                    null,
                    TimeSpan.FromSeconds(1),
                    TimeSpan.Zero);
            }));
            backgroundTask.Start();
        }

        private void BtnQuitGameNotificationCheckMark_OnClick(object sender, EventArgs e)
        {
            _btnQuitGameNotificationCheckMark.ChangeState();
            _btnQuitGameNotificationCheckMark.SetStateImages();
        }

        private void BtnProNotificationCheckMark_OnClick(object sender, EventArgs e)
        {
            _btnProNotificationCheckMark.ChangeState();
            _btnProNotificationCheckMark.SetStateImages();
        }

        private void BtnProNotificationOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipProLevelShow = _btnProNotificationCheckMark.State != 1;

            HideProNotification(sender, e);
        }

        private async void FireRefreshLeaderboard(float delta)
        {
            await LeaderboardManager.RefreshLeaderboards();
        }

        private void BtnScoreboardPro_OnClick(object sender, EventArgs e)
        {
            if (_isShownLeaderboardPro) return;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipProLevelShow)
            {
                ShowProNotification();
            }

            _btnScoreboardPro.ChangeState();
            _btnScoreboardRegular.ChangeState();
            _btnScoreboardPro.SetStateImages();
            _btnScoreboardRegular.SetStateImages();

            _isShownLeaderboardRegular = !_isShownLeaderboardRegular;
            _isShownLeaderboardPro = !_isShownLeaderboardPro;

            ChangeSpriteImage(_imgScoreboard, "UI/Main-screen-extinction-lvl-scoreboard-table.png");

            Player.Instance.IsProLevelSelected = true;
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ChangeSpriteImage(_btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png");
                _btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png";
                _btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png";
            }
            else
            {
                ChangeSpriteImage(_btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                _btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png";
                _btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png";
            }

            RefreshLeaderboard(0);
        }

        private void BtnScoreboardRegular_OnClick(object sender, EventArgs e)
        {
            if (_isShownLeaderboardRegular) return;

            _btnScoreboardPro.ChangeState();
            _btnScoreboardRegular.ChangeState();
            _btnScoreboardPro.SetStateImages();
            _btnScoreboardRegular.SetStateImages();

            _isShownLeaderboardRegular = !_isShownLeaderboardRegular;
            _isShownLeaderboardPro = !_isShownLeaderboardPro;

            ChangeSpriteImage(_imgScoreboard, "UI/Main-screen-earth-lvl-scoreboard-table.png");

            Player.Instance.IsProLevelSelected = false;
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ChangeSpriteImage(_btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png");
                _btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png";
                _btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png";
            }
            else
            {
                ChangeSpriteImage(_btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                _btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png";
                _btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png";
            }
            RefreshLeaderboard(0);
        }

        private async void BtnGetCredits_OnClick(object sender, EventArgs e)
        {
            var newLayer = new GetMoreCreditsScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnGameSettings_OnClick(object sender, EventArgs e)
        {
            var newLayer = new SettingsScreenLayer(null, GameConstants.NavigationParam.MainScreen);
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnGameInfo_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            var newLayer = new GameInfoScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void BtnQuitGame_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipQuitGameShow)
            {
                Shared.GameDelegate.OnBackButton -= HideQuitGameNotification;
                Shared.GameDelegate.OnBackButton += HideQuitGameNotification;
                ShowQuitGameNotification();
            }
            else
            {
                Shared.GameDelegate.QuitGame();
            }
        }

        private void StartDialog_Back(object sender, EventArgs e)
        {
            _btnTapToStart.Enabled = true;
            _btnRanking.Enabled = true;
            _btnGameInfo.Enabled = true;
            _btnGameSettings.Enabled = true;
            _btnGetCredits.Enabled = true;

            _imgQuickGameWindow.Visible = false;
            _btnSelectionMode.Visible = false;
            _btnSelectionMode.Enabled = false;
            _btnQuickGame.Visible = false;
            _btnQuickGame.Enabled = false;
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapBack);
            Shared.GameDelegate.OnBackButton -= StartDialog_Back;
        }

        private void BtnTapToStart_OnClick(object sender, EventArgs e)
        {
            _btnTapToStart.Enabled = false;
            _btnRanking.Enabled = false;
            _btnGameInfo.Enabled = false;
            _btnGameSettings.Enabled = false;
            _btnGetCredits.Enabled = false;

            _imgQuickGameWindow.Visible = true;
            _btnSelectionMode.Visible = true;
            _btnSelectionMode.Enabled = true;
            _btnQuickGame.Visible = true;
            _btnQuickGame.Enabled = true;

            Shared.GameDelegate.OnBackButton += StartDialog_Back;
        }

        private async void BtnQuickGame_OnClick(object sender, EventArgs e)
        {
            Player.Instance.GetQuickGame(out var enemy, out var battleground, out var weapon);

            var newLayer = new GamePlayLayer(enemy, weapon, battleground, true);
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnSelectionMode_OnClick(object sender, EventArgs e)
        {
            var newLayer = new EnemyPickerLayer();
            if (Shared.GameDelegate.UseAnimationClearing)
            {
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
            else
            {
                TransitionToLayerCartoonStyle(newLayer);
            }
        }

        private void BtnRanking_OnClick(object sender, EventArgs e)
        {
            if (_isShownRankingDay)
            {
                SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");
                _isShownRankingDay = false;
                _isShownRankingWeek = true;
            }
            else if (_isShownRankingWeek)
            {
                SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");
                _isShownRankingWeek = false;
                _isShownRankingMonthly = true;
            }
            else if (_isShownRankingMonthly)
            {
                SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                _isShownRankingMonthly = false;
                _isShownRankingDay = true;
            }

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
            }

            RefreshLeaderboard(0);
        }

        private void AnimateScoresBackground(float obj)
        {
            _imgScoresBackground.Visible = _leaderboardSprites.Count == 0 && !_imgOffline.Visible;
            if (_leaderboardBackground.Count > 0 && _imgScoresBackground.Visible)
            {
                var imageIndex = _leaderboardBackground.Images.Count - --_leaderboardBackground.Count;
                var image = AddImage(408, 100, _leaderboardBackground.Images[imageIndex]);
                Console.WriteLine($"ANIMATION||Index={imageIndex}");
                RemoveChild(_imgScoresBackground);
                _imgScoresBackground = image;
            }
            else
            {
                _leaderboardBackground.Count = _leaderboardBackground.Images.Count;
                if (!_imgScoresBackground.Visible)
                {
                    RemoveChild(_imgScoresBackground);
                    Unschedule(AnimateScoresBackground);
                    return;
                }
            }
        }

        private void RefreshLeaderboard(float obj)
        {
            _imgOffline.Visible = !NetworkConnectionManager.IsInternetConnectionAvailable();
            if (!_imgOffline.Visible)
            {
                if (_isShownRankingDay) SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                else if (_isShownRankingWeek) SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");
                else if (_isShownRankingMonthly) SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");
            }

            if (!_isShownLeaderboardPro)
            {
                _btnRanking = AddButton(0, 355,
                    _imgOffline.Visible ? "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png" : "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png",
					"UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
            }
            else
            {
                _btnRanking = AddButton(0, 355,
                    _imgOffline.Visible ? "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png" : "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png",
					"UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
            }

            foreach (var s in _leaderboardSprites)
            {
                RemoveChild(s);
            }
            _leaderboardSprites.Clear();
            _leaderboardSprites = new List<CCLabel>();

            // offline score
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                if (_isShownLeaderboardRegular && Math.Abs(LeaderboardManager.BestScoreRegularScore) > AppConstants.Tolerance)
                {
                    _leaderboardSprites.Add(AddLabel(410, 280, "YOUR BEST", "Fonts/AktivGroteskBold", 12));
                    _leaderboardSprites.Add(AddLabelRightAligned(595, 280, LeaderboardManager.BestScoreRegularScore.ToString("######"), "Fonts/AktivGroteskBold", 12));
                    _leaderboardSprites.Add(AddLabelRightAligned(710, 280, LeaderboardManager.BestScoreRegularFastestTime.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12));
                    _leaderboardSprites.Add(AddLabelRightAligned(850, 280, LeaderboardManager.BestScoreRegularAccuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12));
                }
                else if (_isShownLeaderboardPro && Math.Abs(LeaderboardManager.BestScoreProScore) > AppConstants.Tolerance)
                {
                    _leaderboardSprites.Add(AddLabel(480, 280, "YOUR BEST", "Fonts/AktivGroteskBold", 12));
                    _leaderboardSprites.Add(AddLabelRightAligned(670, 280, LeaderboardManager.BestScoreProScore.ToString("######"), "Fonts/AktivGroteskBold", 12));
                    _leaderboardSprites.Add(AddLabelRightAligned(800, 280, LeaderboardManager.BestScoreProLevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12));
                }
            }
            else
            {
                _imgOffline.Visible = false;
                try
                {
                    List<LeaderboardItem> lbScore = null;

                    var leaderboard = LeaderboardManager.RegularLeaderboard;
                    if (_isShownLeaderboardRegular) leaderboard = LeaderboardManager.RegularLeaderboard;
                    else if (_isShownLeaderboardPro) leaderboard = LeaderboardManager.ProLeaderboard;

                    if (_isShownRankingDay) lbScore = leaderboard.ScoreDaily;
                    else if (_isShownRankingWeek) lbScore = leaderboard.ScoreWeekly;
                    else if (_isShownRankingMonthly) lbScore = leaderboard.ScoreMonthly;

                    for (var i = 1; i <= 10; i++)
                    {
                        if (lbScore != null && lbScore.Count >= i)
                        {
                            var color = lbScore[i - 1].Name == Player.Instance.Name
                                ? new CCColor3B(255, 235, 180)
                                : new CCColor3B(255, 255, 255);

                            if (_isShownLeaderboardRegular)
                            {
                                _leaderboardSprites.Add(AddLabel(305, 297 - i * 17, lbScore[i - 1].Rank + ".", "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabel(410, 297 - i * 17, lbScore[i - 1].Name, "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabelRightAligned(595, 297 - i * 17, lbScore[i - 1].Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabelRightAligned(710, 297 - i * 17, lbScore[i - 1].Time.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabelRightAligned(850, 297 - i * 17, lbScore[i - 1].Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12, color));
                            }
                            else
                            {
                                _leaderboardSprites.Add(AddLabel(355, 297 - i * 17, lbScore[i - 1].Rank + ".", "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabel(480, 297 - i * 17, lbScore[i - 1].Name, "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabelRightAligned(670, 297 - i * 17, lbScore[i - 1].Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                                _leaderboardSprites.Add(AddLabelRightAligned(800, 297 - i * 17, lbScore[i - 1].LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12, color));
                            }
                        }
                        else
                        {
                            // dots?
                        }
                    }
                }
                catch (Exception ex)
                {
                    var mess = ex.Message;
                }

                LeaderboardItem lbi = null;

                if (_isShownLeaderboardRegular && _isShownRankingDay) lbi = LeaderboardManager.PlayerRankRegularDaily;
                else if (_isShownLeaderboardRegular && _isShownRankingWeek) lbi = LeaderboardManager.PlayerRankRegularWeekly;
                else if (_isShownLeaderboardRegular && _isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankRegularMonthly;
                else if (_isShownLeaderboardPro && _isShownRankingDay) lbi = LeaderboardManager.PlayerRankProDaily;
                else if (_isShownLeaderboardPro && _isShownRankingWeek) lbi = LeaderboardManager.PlayerRankProWeekly;
                else if (_isShownLeaderboardPro && _isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankProMonthly;

                {
                    var color = new CCColor3B(255, 235, 180);
                    if (_isShownLeaderboardRegular && lbi != null && lbi.Rank > 10)
                    {
                        _leaderboardSprites.Add(AddLabel(305, 105, lbi.Rank + ".", "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabel(410, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabelRightAligned(595, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabelRightAligned(710, 105, lbi.Time.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabelRightAligned(850, 105, lbi.Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12, color));
                    }
                    else if (_isShownLeaderboardPro && lbi != null && lbi.Rank > 10)
                    {
                        _leaderboardSprites.Add(AddLabel(355, 105, lbi.Rank + ".", "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabel(480, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabelRightAligned(670, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                        _leaderboardSprites.Add(AddLabelRightAligned(800, 105, lbi.LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12, color));
                    }
                }
            }
        }

        private void HideProNotification(object sender, EventArgs e)
        {
            _btnTapToStart.Enabled = true;
            _btnRanking.Enabled = true;
            _btnGameInfo.Enabled = true;
            _btnGameSettings.Enabled = true;
            _btnGetCredits.Enabled = true;

            _imgProNotificationWindow.Visible = false;
            _imgProNotificationCheckMarkLabel.Visible = false;
            _btnProNotificationCheckMark.Enabled = false;
            _btnProNotificationCheckMark.Visible = false;
            _btnProNotificationOk.Enabled = false;
            _btnProNotificationOk.Visible = false;

            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapBack);
            Shared.GameDelegate.OnBackButton -= HideProNotification;
        }

        private void ShowQuitGameNotification()
        {
            _imgQuitGameWindow.Visible = true;
            _btnQuitGameNotificationCheckMark.Enabled = true;
            _btnQuitGameNotificationCheckMark.Visible = true;
            _notShowNotificationText.Visible = true;
            _btnProceedQuittingGame.OnClick -= OnProceedQuittingGame;
            _btnProceedQuittingGame.OnClick += OnProceedQuittingGame;
            _btnProceedQuittingGame.Visible = true;
            _btnStopQuittingGame.OnClick -= OnStopQuittingGame;
            _btnStopQuittingGame.OnClick += OnStopQuittingGame;
            _btnStopQuittingGame.Visible = true;

            void OnProceedQuittingGame(object sender, EventArgs e)
            {
                Settings.Instance.GameTipQuitGameShow = _btnQuitGameNotificationCheckMark.State != 1;
                Shared.GameDelegate.QuitGame();
            }

            void OnStopQuittingGame(object sender, EventArgs e)
            {
                Settings.Instance.GameTipQuitGameShow = _btnQuitGameNotificationCheckMark.State != 1;
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapBack);
                HideQuitGameNotification(null, EventArgs.Empty);
            }
        }

        private void HideQuitGameNotification(object sender, EventArgs e)
        {
            _imgQuitGameWindow.Visible = false;
            _btnQuitGameNotificationCheckMark.Enabled = false;
            _btnQuitGameNotificationCheckMark.Visible = false;
            _notShowNotificationText.Visible = false;
            _btnProceedQuittingGame.Visible = false;
            _btnStopQuittingGame.Visible = false;
        }

        private void ShowProNotification()
        {
            //---------------- Prabhjot -----------------//
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btnRanking.Enabled = false;
            }
            //btnRanking.Enabled = false;

            _btnTapToStart.Enabled = false;
            _btnGameInfo.Enabled = false;
            _btnGameSettings.Enabled = false;
            _btnGetCredits.Enabled = false;

            _imgProNotificationWindow.Visible = true;
            _imgProNotificationCheckMarkLabel.Visible = true;
            _btnProNotificationCheckMark.Enabled = true;
            _btnProNotificationCheckMark.Visible = true;
            _btnProNotificationOk.Enabled = true;
            _btnProNotificationOk.Visible = true;

            Shared.GameDelegate.OnBackButton += HideProNotification;
        }

        private void CheckForNotification()
        {
            _pushNs = new PushNotificationService();
            var res = _pushNs.IsNeedPermission();

            if (res && !Settings.Instance.IsAskForNotificationToday)
            {
                ScheduleOnce(ShowNotificationTip, 1);
            }
            SetTimer();
        }

        private void ShowNotificationTip(float dt)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.NotificationPopUp);
            _gameTipBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/push-notification-background.png", 1002);

            _yesThanks = AddButton(40, 80, "UI/push-notification-yes-button-untapped.png", "UI/push-notification-yes-button-tapped.png", 1005);
            _yesThanks.OnClick += yesShowNotif_OnClick;

            _noThanks = AddButton(640, 80, "UI/push-notification-no-button-untapped.png", "UI/push-notification-no-button-tapped.png", 1005);
            _noThanks.OnClick += noShowNotif_OnClick;

            Settings.Instance.IsAskForNotificationToday = true;
        }

        private void yesShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_gameTipBackground);
            RemoveChild(_yesThanks);
            RemoveChild(_noThanks);

            _pushNs.AskForPremissons();
        }

        private void noShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_gameTipBackground);
            RemoveChild(_yesThanks);
            RemoveChild(_noThanks);
        }
    }
}

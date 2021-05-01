using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;
using LooneyInvaders.PNS;
using LooneyInvaders.App42;

namespace LooneyInvaders.Layers
{
    public class MainScreenLayer : CCLayerColorExt
    {
        private PushNotificationService _pushNs;

        private bool _isShownRankingDay = true;
        private bool _isShownRankingWeek;
        private bool _isShownRankingMonthly;

        private bool _isShownLeaderboardRegular = true;
        private bool _isShownLeaderboardPro;
        private bool _isLeaderboardRefreshing;

        private readonly Services.Permissions.IPermissionService _permissionService;
        private readonly CCSpriteButton _btnQuitGame;
        private readonly CCSpriteButton _btnTapToStart;

        private readonly CCSpriteButton _btnRanking;
        private readonly CCSpriteButton _btnGameSettings;
        private readonly CCSpriteButton _btnGetCredits;
        private readonly CCSpriteButton _btnGameInfo;
        private readonly CCSpriteTwoStateButton _btnScoreboardRegular;
        private readonly CCSpriteTwoStateButton _btnScoreboardPro;
        private readonly CCSprite _imgScoreboard;

        // modal window
        private readonly CCSprite _imgQuitGameWindow;
        private readonly CCSprite _notShowNotificationText;
        private readonly CCSprite _imgQuickGameWindow;
        private readonly CCSpriteTwoStateButton _btnQuitGameNotificationCheckMark;
        private readonly CCSpriteButton _btnProceedQuittingGame;
        private readonly CCSpriteButton _btnStopQuittingGame;
        private readonly CCSpriteButton _btnQuickGame;
        private readonly CCSpriteButton _btnSelectionMode;

        private readonly CCSprite _imgProNotificationWindow;
        private readonly CCSpriteButton _btnProNotificationOk;
        private readonly CCSpriteTwoStateButton _btnProNotificationCheckMark;
        private readonly CCSprite _imgProNotificationCheckMarkLabel;
        private readonly CCSprite _imgOffline;
        private readonly CCSprite _imgWeakConnection;
        private readonly TimeSpan _animationMaxTime = TimeSpan.FromSeconds(20); //for loading view
        private readonly Action<float> _animateScoresBackgroundActionHolder;
        protected Action<float> AnimateScoresBackgroundAction;
        protected Action<bool> SetScoresBackgroundAction;

        private List<CCLabel> _leaderboardSprites = new List<CCLabel>();
        private (int Count, List<string> Images) _leaderboardBackground = (0, new List<string>());

        private bool _needToForceRefreshLeaderboards;
        private CCSprite _leaderboardBackgroundPlaceholder;
        private CCSprite _gameTipBackground;
        private CCNodeExt _imgChangeNameWindow;
        private CCSpriteButton _yesThanks;
        private CCSpriteButton _noThanks;
        private CCSpriteButton _btnYesChangeName;
        private CCSpriteButton _btnDontChangeName;
        private CCLabel _labelPlayerName;
        private CCLabel _sessionCount;

        protected bool LeaderboardTableIsEmpty => !_leaderboardSprites.Any() && !_imgOffline.Visible;

        public MainScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            if (!Player.Instance.IsNameChanged)
            {
                if (!Player.Instance.IsChangeNamePopupShown)
                {
                    ScheduleOnce(ShowChangeNameNotification, 0.7f);
                    Player.Instance.IsChangeNamePopupShown = true;
                }
            }

            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                if (_isShownLeaderboardPro == false)
                {
                    SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                }
                else
                {
                    SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    _btnRanking = AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
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
            _btnRanking.OnClick += BtnRanking_OnClick;
            _permissionService = Shared.GameDelegate.PermissionService;

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btnRanking.DisableClick();
            }
            var noInternet = !NetworkConnectionManager.IsInternetConnectionAvailable();
            _imgScoreboard = AddImage(220, 80, "UI/Main-screen-earth-lvl-scoreboard-table.png");
            _imgOffline = AddImage(300, 92, "UI/Main-screen-off-line-notification.png");
            _imgOffline.Visible = noInternet;
            _imgWeakConnection = AddImage(300, 92, "UI/My-stats-&-rewards-slow-internet-connection-notification.png");
            _imgWeakConnection.Visible = false;

            for (var i = 1; i <= 26; ++i)
            {
                _leaderboardBackground.Images.Add($"UI/Leaderboard/connecting-to-leaderboard-{i.ToString()}.png");
            }
            _leaderboardBackground.Count = _leaderboardBackground.Images.Count;
            _leaderboardBackgroundPlaceholder = new CCSprite
            {
                Visible = !_imgOffline.Visible
            };
            _animateScoresBackgroundActionHolder = (time) =>
                LoopAnimateWithCCSprites(_leaderboardBackground.Images,
                    360, 186,
                    ref _leaderboardBackground.Count,
                    ref _leaderboardBackgroundPlaceholder,
                    () => LeaderboardTableIsEmpty,
                    (o) => SetScoresBackgroundAction(o), _animationMaxTime);
            InitSetScoresBackgroundAction();
            if (!_imgOffline.Visible)
            {
                Schedule(CallAnimateScoresBackground, 0.06f);
            }
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
            _btnScoreboardRegular.OnClick += BtnScoreboardRegular_OnClick;

            _btnScoreboardPro = AddTwoStateButton(975, 355, "UI/Main-screen-pro-button-untapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-untapped.png");
            _btnScoreboardPro.SetStateImages(2);
            _btnScoreboardPro.OnClick += BtnScoreboardPro_OnClick;

            Settings.Instance.ApplyValues(); // main menu background music starts to play here after setting the volume
            GameEnvironment.PlayMusic(Music.MainMenu);

            LeaderboardManager.ClearOnLeaderboardsRefreshedEvent(); //call once in the start of the app launch
            LeaderboardManager.OnLeaderboardsRefreshed += (s, e) => Task.Run(() => ScheduleOnce(RefreshLeaderboard, 0.01f));
            NetworkConnectionManager.ConnectionChanged += (o, a) => // to show table immediately
            {
                ScheduleOnce(_ =>
                {
                    if (NetworkConnectionManager.IsInternetConnectionAvailable())
                    {
                        Schedule(CallAnimateScoresBackground, 0.06f);
                    }
                    RefreshLeaderboard(false);
                }, 0.1f);
                
            };

            var busy = false;
            ScoreBoardService.GetTopScoresStatusChanged += (object n, UnobservedTaskExceptionEventArgs r) =>
            {
                if (busy) { return; }
                busy = true;

                if (string.IsNullOrEmpty(r.Exception.Message))
                {   //show weak connection notification
                    SetScoresBackgroundAction = null;
                    Unschedule(CallAnimateScoresBackground);
                    ScheduleAndRelax(() =>
                    {
                        _leaderboardBackgroundPlaceholder.Visible = false;
                        if (!_imgWeakConnection.Visible)
                        {
                            ClearLeaderboard();
                            SetupMainScreenBackground(true);
                            SetupConnectionProblemNotification(true);
                        }
                    }, 0.1f);
                }
                else if (!_leaderboardBackgroundPlaceholder.Visible && _imgWeakConnection.Visible)
                {   //remove weak connection notification
                    InitSetScoresBackgroundAction();
                    UnscheduleAll();
                    ScheduleAndRelax(() =>
                    {
                        _imgWeakConnection.Visible = false;
                        _leaderboardBackgroundPlaceholder.Visible = true;

                        RefreshLeaderboard();
                        busy = false;
                    }, 0.1f);
                    Schedule(CallAnimateScoresBackground, 0.06f);
                }
            };

            ScheduleOnce(RefreshLeaderboardOnStart, 0.03f);
            CheckForNotification();

            void ScheduleAndRelax(Action toSchedule, float delay)
            {
                ScheduleOnce(_ => toSchedule(), delay);
                busy = false;
            }

            async void RefreshLeaderboardOnStart(float time)
            {
                _permissionService?.GetPermissions();

                if (noInternet) RefreshLeaderboard(time);
                else await ForceLeaderboardManagerRefreshAsync();
            }

            _sessionCount = AddLabel(10, 10, Settings.Instance.GetSessionsCount().ToString(),"Fonts/AktivGroteskBold", 16f);
        }

        private void CallAnimateScoresBackground(float parameter)
        {
            AnimateScoresBackgroundAction = AnimateScoresBackgroundAction ?? _animateScoresBackgroundActionHolder;
            AnimateScoresBackgroundAction?.Invoke(parameter);
        }

        private void InitSetScoresBackgroundAction()
        {
            SetScoresBackgroundAction = (force) => SetScoresBackgroundIfNoScore(360, 186, "UI/Leaderboard/no-score-in-leaderboard.png", force);
        }

        private void SetTimer()
        {
            var backgrounThreadTask = new Thread(new ThreadStart(() =>
            {
                var timer = new Timer((e) => Enabled = true,
                    null,
                    TimeSpan.FromSeconds(1),
                    TimeSpan.Zero);
            }));
            backgrounThreadTask.Start();
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

        private async Task ForceLeaderboardManagerRefreshAsync() => await LeaderboardManager.RefreshLeaderboards();

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
            if (!_imgWeakConnection.Visible)
            {
                RefreshLeaderboard();
            }
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
            if (!_imgWeakConnection.Visible)
            {
                RefreshLeaderboard();
            }
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
            _imgQuickGameWindow.Visible = false;

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
            ScheduleOnce(BtnRankingOnClick, 0f);

            void BtnRankingOnClick(float elapsed)
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

                RefreshLeaderboard(false);
            }
        }

        private void SetScoresBackgroundIfNoScore(int x, int y, string imageName, bool forceStop)
        {
            _leaderboardBackground.Count = _leaderboardBackground.Images.Count;

            if (forceStop)
            {
                if (AnimateScoresBackgroundAction != null)
                {
                    Unschedule(CallAnimateScoresBackground);
                    AnimateScoresBackgroundAction = null;
                }
                RemoveChild(_leaderboardBackgroundPlaceholder);
                ChangeVisibilityAndAddImageIfNeeded(true);
            }
            else
            {
                ChangeVisibilityAndAddImageIfNeeded(false);
            }

            void ChangeVisibilityAndAddImageIfNeeded(bool needed)
            {
                if (_leaderboardBackgroundPlaceholder.Texture == null || needed)
                {
                    _leaderboardBackgroundPlaceholder = AddImage(x, y, imageName);
                }
                _leaderboardBackgroundPlaceholder.Visible = LeaderboardTableIsEmpty;
            }
        }

        private void SetupConnectionProblemNotification(bool isWeak)
        {
            if (isWeak)
            {
                _imgOffline.Visible = false;
                _imgWeakConnection.Visible = true;
            }
            else
            {
                _imgWeakConnection.Visible = false;
                _imgOffline.Visible = true;
            }

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
            else _leaderboardSprites.Add(AddLabel(530, 280, "NO SCORE", "Fonts/AktivGroteskBold", 12));
        }

        private void SetupMainScreenBackground(bool noOrWeakInternet)
        {
            if (noOrWeakInternet)
            {
                SetBackground("UI/Main-screen-background-spotlights-off.jpg");
            }

            if (!_isShownLeaderboardPro)
            {
                _btnRanking.ChangeImagesTo(noOrWeakInternet ? "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png" : "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png",
                    "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
            }
            else
            {
                _btnRanking.ChangeImagesTo(noOrWeakInternet ? "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png" : "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png",
                    "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
            }
            _btnRanking.DisableClick();

            ChangeSpriteButtonImage(_btnRanking);
        }

        private void RefreshLeaderboard(float time) => RefreshLeaderboard();

        private void RefreshLeaderboard(bool scheduled = true)
        {
            if (_isLeaderboardRefreshing)
            {
                System.Diagnostics.Debug.WriteLine("RETURNED!");
                return;
            }
            _isLeaderboardRefreshing = true;

            var noInternet = !NetworkConnectionManager.IsInternetConnectionAvailable();
            {
                SetupMainScreenBackground(noInternet);
            }
            if (noInternet == false)
            {
                _btnRanking.EnableClick();

                if (_isShownRankingDay) SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                else if (_isShownRankingWeek) SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");
                else if (_isShownRankingMonthly) SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");
            }
            ClearLeaderboard();

            // offline score
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                SetupConnectionProblemNotification(false);
            }
            else
            {
                _imgOffline.Visible = false;
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
                }

                LeaderboardItem lbi = null;

                if (_isShownLeaderboardRegular && _isShownRankingDay) lbi = LeaderboardManager.PlayerRankRegularDaily;
                else if (_isShownLeaderboardRegular && _isShownRankingWeek) lbi = LeaderboardManager.PlayerRankRegularWeekly;
                else if (_isShownLeaderboardRegular && _isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankRegularMonthly;
                else if (_isShownLeaderboardPro && _isShownRankingDay) lbi = LeaderboardManager.PlayerRankProDaily;
                else if (_isShownLeaderboardPro && _isShownRankingWeek) lbi = LeaderboardManager.PlayerRankProWeekly;
                else if (_isShownLeaderboardPro && _isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankProMonthly;

                var _color = new CCColor3B(255, 235, 180);
                if (_isShownLeaderboardRegular && lbi != null && lbi.Rank > 10)
                {
                    _leaderboardSprites.Add(AddLabel(305, 105, lbi.Rank + ".", "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabel(410, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabelRightAligned(595, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabelRightAligned(710, 105, lbi.Time.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabelRightAligned(850, 105, lbi.Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12, _color));
                }
                else if (_isShownLeaderboardPro && lbi != null && lbi.Rank > 10)
                {
                    _leaderboardSprites.Add(AddLabel(355, 105, lbi.Rank + ".", "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabel(480, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabelRightAligned(670, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, _color));
                    _leaderboardSprites.Add(AddLabelRightAligned(800, 105, lbi.LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12, _color));
                }
            }

            SetScoresBackgroundAction?.Invoke(false);
            if (LeaderboardTableIsEmpty && scheduled)
            {
                if (_needToForceRefreshLeaderboards)
                {
                    Task.Run(ForceLeaderboardManagerRefreshAsync);
                    _needToForceRefreshLeaderboards = false;
                }
            }
            else
            {
                _needToForceRefreshLeaderboards = true;
            }
            _isLeaderboardRefreshing = false;
        }

        private void ClearLeaderboard()
        {
            foreach (var s in _leaderboardSprites)
            {
                RemoveChild(s);
            }
            _leaderboardSprites.Clear();
            _leaderboardSprites = new List<CCLabel>();
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
            _yesThanks.OnClick += YesShowNotif_OnClick;

            _noThanks = AddButton(640, 80, "UI/push-notification-no-button-untapped.png", "UI/push-notification-no-button-tapped.png", 1005);
            _noThanks.OnClick += NoShowNotif_OnClick;

            Settings.Instance.IsAskForNotificationToday = true;
        }

        private void YesShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_gameTipBackground);
            RemoveChild(_yesThanks);
            RemoveChild(_noThanks);

            _pushNs.AskForPremissons();
        }

        private void NoShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_gameTipBackground);
            RemoveChild(_yesThanks);
            RemoveChild(_noThanks);
        }
        
        private void ShowChangeNameNotification(float dt = 0f)
        {
            _imgChangeNameWindow = new CCNodeExt();
            _imgChangeNameWindow.AddImage(14, 48, "UI/username-notification.png", 500);
           
            
            _btnYesChangeName = _imgChangeNameWindow.AddButton(35, 70, "UI/push-notification-yes-button-untapped.png", "UI/push-notification-yes-button-tapped.png", 510);
            _btnYesChangeName.OnClick -= OnChangeName;
            _btnYesChangeName.OnClick += OnChangeName;
            
            _btnDontChangeName = _imgChangeNameWindow.AddButton(644, 70, "UI/push-notification-no-button-untapped.png", "UI/push-notification-no-button-tapped.png", 510);
            _btnDontChangeName.OnClick -= OnDontChangeName;
            _btnDontChangeName.OnClick += OnDontChangeName;
            
            _labelPlayerName = _imgChangeNameWindow.AddLabel(400, 396, Player.Instance.Name, "Fonts/AktivGroteskBold", 16);
            _labelPlayerName.ZOrder = 520;
            
            AddChild(_imgChangeNameWindow, 520);

            async void OnChangeName(object sender, EventArgs e)
            {
                var newLayer = new PlayerNameLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }

            void OnDontChangeName(object sender, EventArgs e)
            {
                HideChangeNameNotification();
                _btnDontChangeName.OnClick -= OnDontChangeName;
                _btnYesChangeName.OnClick -= OnChangeName;
            }
        }

        private void HideChangeNameNotification()
        {
            _imgChangeNameWindow.Visible = false;
        }

        public override void OnExit()
        {
            base.OnExit();

            NetworkConnectionManager.ClearConnectionChangedEvent();
            ScoreBoardService.ClearGetTopScoresStatusChangedEvent();
        }
    }
}

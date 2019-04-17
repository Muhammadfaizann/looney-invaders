using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;
using LooneyInvaders.PNS;

namespace LooneyInvaders.Layers
{
    public class MainScreenLayer : CCLayerColorExt
    {
		private PushNotificationService _pushNS;
        // TODO: neki enum za ovo u modelu
        bool isShownRankingDay = true;
        bool isShownRankingWeek = false;
        bool isShownRankingMonthly = false;

        bool isShownLeaderboardRegular = true;
        bool isShownLeaderboardPro = false;

        //CCSprite imgSpotlightDay;
        //CCSprite imgSpotlightWeek;
        //CCSprite imgSpotlightAllTime;

        CCSpriteButton btnTapToStart;
        CCSpriteButton btnRanking;
        CCSpriteButton btnGameSettings;
        CCSpriteButton btnGetCredits;
        CCSpriteButton btnGameInfo;
        CCSpriteTwoStateButton btnScoreboardRegular;
        CCSpriteTwoStateButton btnScoreboardPro;
        CCSprite imgScoreboard;
        CCSprite imgOffline;

        // modal window
        CCSprite imgQuickGameWindow;
        CCSpriteButton btnQuickGame;
        CCSpriteButton btnSelectionMode;

        CCSprite imgProNotificationWindow;
        CCSpriteButton btnProNotificationOK;
        CCSpriteTwoStateButton btnProNotificationCheckMark;
        CCSprite imgProNotificationCheckMarkLabel;

		CCSprite gameTipBackground;
        CCSpriteButton yesThanks;
        CCSpriteButton noThanks;

        List<CCLabel> leaderboardSprites = new List<CCLabel>();
        
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
                if(isShownLeaderboardPro == false)
                {
                    this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                    btnRanking.OnClick += BtnRanking_OnClick;
                }
                else
                {
                    this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                    btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                    btnRanking.OnClick += BtnRanking_OnClick;
                }

            }
            else
            {
                if (isShownLeaderboardPro == false)
                {
                    this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                    btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");

                }
                else
                {
                    this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                    btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png", "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                
                }

            }





            /*
            this.AddImage(170, 275, "UI/Main-screen-highest_score-text.png");
            this.AddImage(440, 275, "UI/Main-screen-fastest_defend-text.png");
            this.AddImage(730, 275, "UI/Main-screen-best_accuracy-text.png");
            */

            imgScoreboard = this.AddImage(220, 80, "UI/Main-screen-earth-lvl-scoreboard-table.png");
                        
            imgOffline = this.AddImage(300, 92, "UI/Main-screen-off-line-notification.png");
            imgOffline.Visible = !NetworkConnectionManager.IsInternetConnectionAvailable();

            btnTapToStart = this.AddButton(370, 475, "UI/Main-screen-tap-to-start-button-untapped.png", "UI/Main-screen-tap-to-start-button-tapped.png");
            btnTapToStart.OnClick += BtnTapToStart_OnClick;


            btnGameSettings = this.AddButton(30, 5, "UI/Main-screen-game_settings-button-untapped.png", "UI/Main-screen-game_settings-button-tapped.png");
            btnGameSettings.OnClick += BtnGameSettings_OnClick;

            btnGetCredits = this.AddButton(400, 5, "UI/Main-screen-get_credits-button-untapped.png", "UI/Main-screen-get_credits-button-tapped.png");
            btnGetCredits.OnClick += BtnGetCredits_OnClick;

            btnGameInfo = this.AddButton(760, 5, "UI/Main-screen-game_info-button-untapped.png", "UI/Main-screen-game_info-button-tapped.png");
            btnGameInfo.OnClick += BtnGameInfo_OnClick;
            
            /* quick game notification */

            imgQuickGameWindow = this.AddImage(14, 8, "UI/Main-screen-quick-game-notification-with-text.png", 500);
            imgQuickGameWindow.Visible = false;

            btnSelectionMode = this.AddButton(35, 25, "UI/Main-screen-quick-game-notification-selection-mode-button-untapped.png", "UI/Main-screen-quick-game-notification-selection-mode-button-tapped.png", 510);
            btnSelectionMode.Visible = false;
            btnSelectionMode.Enabled = false;
            btnSelectionMode.OnClick += BtnSelectionMode_OnClick;

            btnQuickGame = this.AddButton(635, 25, "UI/Main-screen-quick-game-notification-quick-game-button-untapped.png", "UI/Main-screen-quick-game-notification-quick-game-button-tapped.png", 510);
            btnQuickGame.Visible = false;
            btnQuickGame.Enabled = false;
            btnQuickGame.ButtonType = BUTTON_TYPE.Rewind;
            btnQuickGame.OnClick += BtnQuickGame_OnClick;

            /* pro level notification */

            imgProNotificationWindow = this.AddImage(14, 8, "UI/Main-screen-pro-level-notification-background.png", 500);
            imgProNotificationWindow.Visible = false;

            btnProNotificationOK = this.AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            btnProNotificationOK.OnClick += BtnProNotificationOK_OnClick; ;
            btnProNotificationOK.Visible = false;

            btnProNotificationCheckMark = this.AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 610);
            btnProNotificationCheckMark.OnClick += BtnProNotificationCheckMark_OnClick; ;
            btnProNotificationCheckMark.ButtonType = BUTTON_TYPE.CheckMark;
            btnProNotificationCheckMark.Visible = false;

            imgProNotificationCheckMarkLabel = this.AddImage(105, 60, "UI/do-not-show-text.png", 610);
            imgProNotificationCheckMarkLabel.Visible = false;


            btnSelectionMode = this.AddButton(35, 25, "UI/Main-screen-quick-game-notification-selection-mode-button-untapped.png", "UI/Main-screen-quick-game-notification-selection-mode-button-tapped.png", 510);
            btnSelectionMode.Visible = false;
            btnSelectionMode.Enabled = false;
            btnSelectionMode.OnClick += BtnSelectionMode_OnClick;

            btnQuickGame = this.AddButton(635, 25, "UI/Main-screen-quick-game-notification-quick-game-button-untapped.png", "UI/Main-screen-quick-game-notification-quick-game-button-tapped.png", 510);
            btnQuickGame.Visible = false;
            btnQuickGame.Enabled = false;
            btnQuickGame.ButtonType = BUTTON_TYPE.Rewind;
            btnQuickGame.OnClick += BtnQuickGame_OnClick;


            this.AddImage(790, 410, "UI/Main-screen-leaderboard-type-text.png");

            btnScoreboardRegular = this.AddTwoStateButton(790, 355, "UI/Main-screen-regular-button-untapped.png", "UI/Main-screen-regular-button-tapped.png", "UI/Main-screen-regular-button-tapped.png", "UI/Main-screen-regular-button-untapped.png");
            btnScoreboardRegular.State = 2;
            btnScoreboardRegular.SetStateImages();
            btnScoreboardRegular.OnClick += BtnScoreboardRegular_OnClick;

            btnScoreboardPro = this.AddTwoStateButton(975, 355, "UI/Main-screen-pro-button-untapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-tapped.png", "UI/Main-screen-pro-button-untapped.png");            
            btnScoreboardPro.OnClick += BtnScoreboardPro_OnClick;            

            Settings.Instance.ApplyValues(); // main menu background music starts to play here after setting the volume
            GameEnvironment.PlayMusic(MUSIC.MAIN_MENU);

            LooneyInvaders.Model.LeaderboardManager.ClearOnLeaderboardsRefreshedEvent();
            LooneyInvaders.Model.LeaderboardManager.OnLeaderboardsRefreshed += LeaderboardManager_OnLeaderboardsRefreshed;
            Console.WriteLine("BEFORE fireRefreshLeaderboard ---------------------------------");
            this.ScheduleOnce(fireRefreshLeaderboard, 0.54f);
            Console.WriteLine("AFTER fireRefreshLeaderboard ---------------------------------");
			//LeaderboardManager.RefreshLeaderboards();
			//fireRefreshLeaderboard();

			CheckForNotification();
        }


        //------------ Prabhjot -----------//

        System.Threading.Timer timer;
        private void SetTimer()
        {
           var backgroundTask = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                var startTimeSpan = TimeSpan.FromSeconds(1);
                // = new System.Threading.Timer(dueTime:)
                
                var periodTimeSpan = TimeSpan.FromSeconds(0);

                timer = new System.Threading.Timer((e) =>
                {
                    //Code

                    this.Enabled = true;
                    Console.WriteLine("Touch Enabled");

                }, null, startTimeSpan, periodTimeSpan);

            }));
            backgroundTask.Start();

        }


    private void BtnProNotificationCheckMark_OnClick(object sender, EventArgs e)
        {
            btnProNotificationCheckMark.ChangeState();
            btnProNotificationCheckMark.SetStateImages();
        }

        private void BtnProNotificationOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipProLevelShow = btnProNotificationCheckMark.State == 1 ? false : true;

            hideProNotification(sender, e);
        }

        private async void fireRefreshLeaderboard(float delta)
        {
            await Task.Run(() => LeaderboardManager.RefreshLeaderboards());
        }

        private void BtnScoreboardPro_OnClick(object sender, EventArgs e)
        {
            if (isShownLeaderboardPro) return;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipProLevelShow)
            {
                showProNotification(sender, e);
            }

            btnScoreboardPro.ChangeState();
            btnScoreboardRegular.ChangeState();
            btnScoreboardPro.SetStateImages();
            btnScoreboardRegular.SetStateImages();

            isShownLeaderboardRegular = !isShownLeaderboardRegular;
            isShownLeaderboardPro = !isShownLeaderboardPro;

            ChangeSpriteImage(imgScoreboard, "UI/Main-screen-extinction-lvl-scoreboard-table.png");

            Player.Instance.isProLevelSelected = true;
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png");
                btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png";
                btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png";
            }
            else
            {
                ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png";
                btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png";
            }

            refreshLeaderboard(0);
        }

        private void BtnScoreboardRegular_OnClick(object sender, EventArgs e)
        {
            if (isShownLeaderboardRegular) return;

            btnScoreboardPro.ChangeState();
            btnScoreboardRegular.ChangeState();
            btnScoreboardPro.SetStateImages();
            btnScoreboardRegular.SetStateImages();

            isShownLeaderboardRegular = !isShownLeaderboardRegular;
            isShownLeaderboardPro = !isShownLeaderboardPro;

            ChangeSpriteImage(imgScoreboard, "UI/Main-screen-earth-lvl-scoreboard-table.png");

            Player.Instance.isProLevelSelected = false;
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png");
                btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png";
                btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png";
            }
            else
            {
                ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png";
                btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png";
            }
            refreshLeaderboard(0);
        }

        private void BtnGetCredits_OnClick(object sender, EventArgs e)
        {            
            this.TransitionToLayerCartoonStyle(new GetMoreCreditsScreenLayer());
        }

        private void BtnGameSettings_OnClick(object sender, EventArgs e)
        {
			this.TransitionToLayerCartoonStyle(new SettingsScreenLayer(null, GameConstants.NavigationParam.MainScreen));
        }

        private void BtnGameInfo_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.TransitionToLayerCartoonStyle(new GameInfoScreenLayer());
        }

        private void StartDialog_Back(object sender, EventArgs e)
        {
            btnTapToStart.Enabled = true;
            btnRanking.Enabled = true;
            btnGameInfo.Enabled = true;
            btnGameSettings.Enabled = true;
            btnGetCredits.Enabled = true;

            imgQuickGameWindow.Visible = false;
            btnSelectionMode.Visible = false;
            btnSelectionMode.Enabled = false;
            btnQuickGame.Visible = false;
            btnQuickGame.Enabled = false;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_BACK);
            Shared.GameDelegate.OnBackButton -= StartDialog_Back;
         }

        private void BtnTapToStart_OnClick(object sender, EventArgs e)
        {
            btnTapToStart.Enabled = false;
            btnRanking.Enabled = false;
            btnGameInfo.Enabled = false;
            btnGameSettings.Enabled = false;
            btnGetCredits.Enabled = false;

            imgQuickGameWindow.Visible = true;
            btnSelectionMode.Visible = true;
            btnSelectionMode.Enabled = true;
            btnQuickGame.Visible = true;
            btnQuickGame.Enabled = true;


            Shared.GameDelegate.OnBackButton += StartDialog_Back;
        }
                

        private void BtnQuickGame_OnClick(object sender, EventArgs e)
        {
            ENEMIES enemy = ENEMIES.HITLER;
            WEAPONS weapon = WEAPONS.STANDARD;
            BATTLEGROUNDS battleground = BATTLEGROUNDS.POLAND;
            Player.Instance.GetQuickGame(ref enemy, ref battleground, ref weapon);
            this.TransitionToLayerCartoonStyle(new GamePlayLayer(enemy, weapon, battleground, true));
        }

        private void BtnSelectionMode_OnClick(object sender, EventArgs e)
        {            
            this.TransitionToLayerCartoonStyle(new EnemyPickerLayer());
        }

        private void BtnRanking_OnClick(object sender, EventArgs e)
        {
            if (isShownRankingDay)
            {                
                this.SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");
                isShownRankingDay = false;
                isShownRankingWeek = true;
            }
            else if (isShownRankingWeek)
            {
                this.SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");
                isShownRankingWeek = false;
                isShownRankingMonthly = true;
            }
            else if (isShownRankingMonthly)
            {
                this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                isShownRankingMonthly = false;
                isShownRankingDay = true;
            }

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }

            refreshLeaderboard(0);
        }

        private void LeaderboardManager_OnLeaderboardsRefreshed(object sender, EventArgs e)
        {   
            this.ScheduleOnce(refreshLeaderboard, 0.01f);
        }

        private void refreshLeaderboard(float obj)
        {
            imgOffline.Visible = !NetworkConnectionManager.IsInternetConnectionAvailable();

            /*if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                if (isShownRankingDay) this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");                
                else if (isShownRankingWeek) this.SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");                
                else if (isShownRankingMonthly) this.SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");
            }
            else
            {

                //-------------Prabhjot --------------//

                //this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");

                this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                btnRanking.ButtonType = BUTTON_TYPE.CannotTap;
            }*/


            ///////////////////////



            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                if (isShownRankingDay) this.SetBackground("UI/Main-screen-background-day-spotlight-on.jpg");
                else if (isShownRankingWeek) this.SetBackground("UI/Main-screen-background-week-spotlight-on.jpg");
                else if (isShownRankingMonthly) this.SetBackground("UI/Main-screen-background-month-spotlight-on.jpg");

                //if (isShownLeaderboardPro == false)
                //{
                //    ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png");
                //    btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png";
                //    btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-earth-lvl-button-untapped.png";

                //}
                //else
                //{
                //    ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png");
                //    btnRanking.ImageNameTapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png";
                //    btnRanking.ImageNameUntapped = GameEnvironment.ImageDirectory + "UI/Main-screen-world-ranking-extinction-lvl-button-untapped.png";

                //}

            }
            else
            {
                if (isShownLeaderboardPro == false)
                {
                    //this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                     btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png", "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                    //ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-earth-lvl-button-tapped.png");
                }
                else
                {
                    //this.SetBackground("UI/Main-screen-background-spotlights-off.jpg");
                    btnRanking = this.AddButton(0, 355, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png", "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                    //ChangeSpriteImage(btnRanking, "UI/Main-screen-world-ranking-extinction-lvl-button-tapped.png");
                }

            }



            ////////////////////

            foreach (CCLabel s in leaderboardSprites) this.RemoveChild(s);
            leaderboardSprites.Clear();
            leaderboardSprites = new List<CCLabel>();

            // offline score
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                if (isShownLeaderboardRegular && LeaderboardManager.BestScoreRegular_Score != 0)
                {                    
                    leaderboardSprites.Add(this.AddLabel(410, 280, "YOUR BEST", "Fonts/AktivGroteskBold", 12));
                    leaderboardSprites.Add(this.AddLabelRightAligned(595, 280, LeaderboardManager.BestScoreRegular_Score.ToString("######"), "Fonts/AktivGroteskBold", 12));
                    leaderboardSprites.Add(this.AddLabelRightAligned(710, 280, LeaderboardManager.BestScoreRegular_FastestTime.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12));
                    leaderboardSprites.Add(this.AddLabelRightAligned(850, 280, LeaderboardManager.BestScoreRegular_Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12));
                }
                else if (isShownLeaderboardPro && LeaderboardManager.BestScorePro_Score != 0)
                {                    
                    leaderboardSprites.Add(this.AddLabel(480, 280, "YOUR BEST", "Fonts/AktivGroteskBold", 12));
                    leaderboardSprites.Add(this.AddLabelRightAligned(670, 280, LeaderboardManager.BestScorePro_Score.ToString("######"), "Fonts/AktivGroteskBold", 12));
                    leaderboardSprites.Add(this.AddLabelRightAligned(800, 280, LeaderboardManager.BestScorePro_LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12));
                }
            }
            else
            {
                List<LeaderboardItem> lbScore = null;

                Leaderboard leaderboard = LeaderboardManager.RegularLeaderboard;
                if (isShownLeaderboardRegular) leaderboard = LeaderboardManager.RegularLeaderboard;
                else if (isShownLeaderboardPro) leaderboard = LeaderboardManager.ProLeaderboard;

                if (isShownRankingDay) lbScore = leaderboard.ScoreDaily;
                else if (isShownRankingWeek) lbScore = leaderboard.ScoreWeekly;
                else if (isShownRankingMonthly) lbScore = leaderboard.ScoreMonthly;

                CCColor3B color = new CCColor3B(255, 215, 205);
                for (int i = 1; i <= 10; i++)
                {
                    if (lbScore.Count >= i)
                    {
                        color = new CCColor3B(255, 255, 255);
                        if(lbScore[i - 1].Name==Player.Instance.Name) color = new CCColor3B(255, 235, 180);

                        if (isShownLeaderboardRegular)
                        {
                            leaderboardSprites.Add(this.AddLabel(305, 297 - i * 17, lbScore[i - 1].Rank.ToString() + ".", "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabel(410, 297 - i * 17, lbScore[i - 1].Name.ToString(), "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabelRightAligned(595, 297 - i * 17, lbScore[i - 1].Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabelRightAligned(710, 297 - i * 17, lbScore[i - 1].Time.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabelRightAligned(850, 297 - i * 17, lbScore[i - 1].Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12, color));
                        }
                        else
                        {
                            leaderboardSprites.Add(this.AddLabel(355, 297 - i * 17, lbScore[i - 1].Rank.ToString() + ".", "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabel(480, 297 - i * 17, lbScore[i - 1].Name.ToString(), "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabelRightAligned(670, 297 - i * 17, lbScore[i - 1].Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                            leaderboardSprites.Add(this.AddLabelRightAligned(800, 297 - i * 17, lbScore[i - 1].LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12, color));
                        }
                    }
                    else
                    {
                        // dots?
                    }
                }
                
                LeaderboardItem lbi = null;

                if (isShownLeaderboardRegular && isShownRankingDay) lbi = LeaderboardManager.PlayerRankRegularDaily;
                else if (isShownLeaderboardRegular && isShownRankingWeek) lbi = LeaderboardManager.PlayerRankRegularWeekly;
                else if (isShownLeaderboardRegular && isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankRegularMonthly;
                else if (isShownLeaderboardPro && isShownRankingDay) lbi = LeaderboardManager.PlayerRankProDaily;
                else if (isShownLeaderboardPro && isShownRankingWeek) lbi = LeaderboardManager.PlayerRankProWeekly;
                else if (isShownLeaderboardPro && isShownRankingMonthly) lbi = LeaderboardManager.PlayerRankProMonthly;

                color = new CCColor3B(255, 235, 180);
                if (isShownLeaderboardRegular && lbi != null && lbi.Rank > 10)
                {
                    leaderboardSprites.Add(this.AddLabel(305, 105, lbi.Rank.ToString() + ".", "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabel(410, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabelRightAligned(595, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabelRightAligned(710, 105, lbi.Time.ToString("##0.00") + " s", "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabelRightAligned(850, 105, lbi.Accuracy.ToString("#0.00") + " %", "Fonts/AktivGroteskBold", 12, color));
                }
                else if (isShownLeaderboardPro && lbi != null && lbi.Rank > 10)
                {
                    leaderboardSprites.Add(this.AddLabel(355, 105, lbi.Rank.ToString() + ".", "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabel(480, 105, lbi.Name, "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabelRightAligned(670, 105, lbi.Score.ToString("######"), "Fonts/AktivGroteskBold", 12, color));
                    leaderboardSprites.Add(this.AddLabelRightAligned(800, 105, lbi.LevelsCompleted.ToString("####"), "Fonts/AktivGroteskBold", 12, color));
                }
            }
        }

        private void hideProNotification(object sender, EventArgs e)
        {
            btnTapToStart.Enabled = true;
            btnRanking.Enabled = true;
            btnGameInfo.Enabled = true;
            btnGameSettings.Enabled = true;
            btnGetCredits.Enabled = true;

            imgProNotificationWindow.Visible = false;
            imgProNotificationCheckMarkLabel.Visible = false;
            btnProNotificationCheckMark.Enabled = false;
            btnProNotificationCheckMark.Visible = false;
            btnProNotificationOK.Enabled = false;
            btnProNotificationOK.Visible = false;

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_BACK);
            Shared.GameDelegate.OnBackButton -= hideProNotification;
        }

        private void showProNotification(object sender, EventArgs e)
        {
            //---------------- Prabhjot -----------------//
            if (NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                btnRanking.Enabled = false;
            }
            //btnRanking.Enabled = false;


            btnTapToStart.Enabled = false;
            btnGameInfo.Enabled = false;
            btnGameSettings.Enabled = false;
            btnGetCredits.Enabled = false;

            imgProNotificationWindow.Visible = true;
            imgProNotificationCheckMarkLabel.Visible = true;
            btnProNotificationCheckMark.Enabled = true;
            btnProNotificationCheckMark.Visible = true;
            btnProNotificationOK.Enabled = true;
            btnProNotificationOK.Visible = true;

            Shared.GameDelegate.OnBackButton += hideProNotification;
        }

        private void CheckForNotification()
        {
            _pushNS = new PushNotificationService();
            var res = _pushNS.CheckDoesNeedAskPremission();

			if (res && !Settings.Instance.IsAskForNotificationToday)
            {
                ScheduleOnce(showNotificationTip, 1);
            }

            //------------ Prabhjot -----------//

            SetTimer();
        }

        private void showNotificationTip(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            gameTipBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/push-notification-background.png", 1002);

            yesThanks = this.AddButton(40, 80, "UI/push-notification-yes-button-untapped.png", "UI/push-notification-yes-button-tapped.png", 1005);
            yesThanks.OnClick += yesShowNotif_OnClick;

            noThanks = this.AddButton(640, 80, "UI/push-notification-no-button-untapped.png", "UI/push-notification-no-button-tapped.png", 1005);
            noThanks.OnClick += noShowNotif_OnClick;

			Settings.Instance.IsAskForNotificationToday = true;
        }

        private void yesShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(gameTipBackground, true);
            RemoveChild(yesThanks, true);
            RemoveChild(noThanks, true);

            _pushNS.AskForPremissons();
        }

        private void noShowNotif_OnClick(object sender, EventArgs e)
        {
            RemoveChild(gameTipBackground, true);
            RemoveChild(yesThanks, true);
            RemoveChild(noThanks, true);
        }
    }
}
using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.Shared;

namespace LooneyInvaders.Layers
{
    public class LossScreenLayer : CCLayerColorExt
    {
        public BATTLEGROUNDS SelectedBattleground;
        public ENEMIES SelectedEnemy;
        public WEAPONS SelectedWeapon;

        CCSpriteButton btnContinue;
        CCSpriteButton mainMenu;
        CCSprite shareYourScore;
        CCSpriteButton yes;
        CCSpriteButton no;
        CCSprite youAreDefeated;

        private bool isWeHaveScores = false;
        private bool isDoneWaitingForScores = false;

        private int alienScore;
        private int alienWave;

        public LossScreenLayer(ENEMIES selectedEnemy, WEAPONS selectedWeapon, BATTLEGROUNDS selectedBattleground, int AlienScore = 0, int AlienWave = 0)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;

            alienScore = AlienScore;
            alienWave = AlienWave;


            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    this.SetBackground("UI/Loss scenes/afghanistan-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.DENMARK:
                    this.SetBackground("UI/Loss scenes/denmark-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    this.SetBackground("UI/Loss scenes/UK-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    this.SetBackground("UI/Loss scenes/estonia-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.FINLAND:
                    this.SetBackground("UI/Loss scenes/Finland-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.FRANCE:
                    this.SetBackground("UI/Loss scenes/france-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    this.SetBackground("UI/Loss scenes/georgia-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    this.SetBackground("UI/Loss scenes/UK-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.IRAQ:
                    this.SetBackground("UI/Loss scenes/iraq-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    this.SetBackground("UI/Loss scenes/israel-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.JAPAN:
                    this.SetBackground("UI/Loss scenes/japan-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.LIBYA:
                    this.SetBackground("UI/Loss scenes/libya-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.NORWAY:
                    this.SetBackground("UI/Loss scenes/norway-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.POLAND:
                    this.SetBackground("UI/Loss scenes/poland-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    this.SetBackground("UI/Loss scenes/russia-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    this.SetBackground("UI/Loss scenes/south-korea-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.SYRIA:
                    this.SetBackground("UI/Loss scenes/syria-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    this.SetBackground("UI/Loss scenes/ukraine-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    this.SetBackground("UI/Loss scenes/Usa-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    this.SetBackground("UI/Loss scenes/vietnam-lost-war.jpg");
                    break;
                case BATTLEGROUNDS.MOON:
                    youAreDefeated = this.AddImage(0, 380, "UI/Loss scenes/loss-screen-you-are-defeated-text.png", 3);
                    youAreDefeated.Opacity = 0;
                    this.SetBackground("UI/Loss scenes/Moon-lost-war.jpg");
                    break;
            }

            if (Settings.Instance.VoiceoversEnabled)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
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
            AdMobManager.ShowBannerBottom();


            


            
            //submit score during shown victory image
            if (alienScore > GamePlayLayer.BestScoreAlien)
            {
                GamePlayLayer.BestScoreAlien = alienScore;
                GamePlayLayer.BestScoreAlienWave = alienWave;

				Player.Instance.SetDayScore(alienScore, true);
            }
            Player.Instance.Credits += alienScore;
            isWeHaveScores = LooneyInvaders.Model.LeaderboardManager.SubmitScorePro(alienScore, alienWave);
            isDoneWaitingForScores = true;

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                GameEnvironment.PlayMusic(MUSIC.GAMEOVERALIEN);
            }
            else
            {
                GameEnvironment.PlayMusic(MUSIC.GAMEOVER);
            }

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                this.Schedule(fadeYouAreDefeated);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
                    this.ScheduleOnce(CalloutRevenge, 2f);
                }
                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    this.ScheduleOnce(showAd, 5f);
                }
                else
                {
                    GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SHOWSCORE);
                    hasScore = true;
                    this.ScheduleOnce(showScoreAlien, 2f);
                }
            }
            else
            {
                this.ScheduleOnce(showGetRevenge, 2);
            }



        }

        private void CalloutRevenge(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Now get up and get your revenge VO_mono.wav");
        }

        private bool hasScore = false;

        CCNodeExt getRevengeNode;

        private void showGetRevenge(float d)
        {
            getRevengeNode = new CCNodeExt();

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                getRevengeNode.AddImage(0, 380, "UI/Loss scenes/loss-screen-you-are-defeated-text.png", 3);
            }
            else if (!hasScore)
            {
                getRevengeNode.AddImage(0, 380, "UI/Loss scenes/You-are-dead-no-track-record-title.png", 3);
            }
            else
            {
                getRevengeNode.AddImage(0, 380, "UI/You-are-dead-now-get-up-and-get-your-revenge.png", 3);
            }

            CCSpriteButton mainMenu = getRevengeNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            mainMenu.OnClick += mainMenu_OnClick;

            CCSpriteButton revenge = getRevengeNode.AddButton(740, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            revenge.ButtonType = BUTTON_TYPE.Rewind;
            revenge.OnClick += revenge_OnClick;


            getRevengeNode.Opacity = 0;
            foreach (CCNode child in getRevengeNode.Children) { child.Opacity = getRevengeNode.Opacity; };


            this.AddChild(getRevengeNode);

            this.Schedule(fadeRevengeNode);

            if (Settings.Instance.VoiceoversEnabled)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
                    this.ScheduleOnce(CalloutRevenge, 2.5f);
                }
                else
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/You are dead VO_mono.wav");
                    this.ScheduleOnce(CalloutRevenge, 2f);
                }

            }
            
        }

        private void CalloutDefeated(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/you are defeaded VO_mono.wav");
            this.ScheduleOnce(CalloutRevenge, 2.5f);

        }

        private void CalloutDead(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/You are dead VO_mono.wav");
            this.ScheduleOnce(CalloutRevenge, 2f);

        }

        private void fadeYouAreDefeated(float dt)
        {
            youAreDefeated.Opacity += 2;
            if (youAreDefeated.Opacity >= 251)
            {
                youAreDefeated.Opacity = 255;
                this.Unschedule(fadeYouAreDefeated);
            }
            
        }


        private void fadeRevengeNode (float dt)
        {
            getRevengeNode.Opacity += 5;
            if (getRevengeNode.Opacity >= 251)
            {
                getRevengeNode.Opacity = 255;
                this.Unschedule(fadeRevengeNode);
            }
            foreach (CCNode child in getRevengeNode.Children) { child.Opacity = getRevengeNode.Opacity; };
        }
     


        CCNodeExt scoreNode;

        private void showScore(float d)
        {
         


            switch (GamePlayLayer.BestScoreCountry)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-afghanistan.png", 3);
                    break;
                case BATTLEGROUNDS.DENMARK:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-denmark.png", 3);
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-england.png", 3);
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-estonia.png", 3);
                    break;
                case BATTLEGROUNDS.FINLAND:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-finland.png", 3);
                    break;
                case BATTLEGROUNDS.FRANCE:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-france.png", 3);
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-georgia.png", 3);
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-great-britain.png", 3);
                    break;
                case BATTLEGROUNDS.IRAQ:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-iraq.png", 3);
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-israel.png", 3);
                    break;
                case BATTLEGROUNDS.JAPAN:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-japan.png", 3);
                    break;
                case BATTLEGROUNDS.LIBYA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-libya.png", 3);
                    break;
                case BATTLEGROUNDS.NORWAY:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-norway.png", 3);
                    break;
                case BATTLEGROUNDS.POLAND:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-poland.png", 3);
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-russia.png", 3);
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-south-korea.png", 3);
                    break;
                case BATTLEGROUNDS.SYRIA:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-syria.png", 3);
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-ukraine.png", 3);
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-united-states.png", 3);
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    scoreNode.AddImage(5, 455, "UI/Loss scenes/You-are-dead-top-score-text-vietnam.png", 3);
                    break;
            }

            scoreNode.AddImage(0, 153, "UI/victory-score-board-just-background.png", 2);
            scoreNode.AddImage(0, 153, "UI/victory-score-board-just-text.png", 3);

            scoreNode.AddImage(0, 70, "UI/victory-share-your-score-and-earn-credits-text.png", 3);

            scoreNode.AddImageLabelRightAligned(466, 391, GamePlayLayer.BestScoreTime.ToString("0.00"), 57);
            scoreNode.AddImage(466, 385, "UI/victory&social-share-score-numbers-(sec).png", 4);

            scoreNode.AddImageLabelRightAligned(572, 318, GamePlayLayer.BestScoreAccuracy.ToString("0.00"), 57);
            scoreNode.AddImage(570, 315, "UI/victory&social-share-score-numbers-(%).png", 4);



            scoreNode.AddImageLabel(420, 245, GamePlayLayer.BestScore.ToString(), 57);

            scoreNode.AddImageLabel(490, 170, Player.Instance.Score.ToString(), 57);

            CCSpriteButton yes = scoreNode.AddButton(850, 70, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
            yes.OnClick += yes_OnClick;

            CCSpriteButton no = scoreNode.AddButton(600, 70,  "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
            no.OnClick += no_OnClick;

            scoreNode.Opacity = 0;
            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };


            this.AddChild(scoreNode);

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SHOWSCORE);
            this.Schedule(
                delegate (float dt)
                {
                    scoreNode.Opacity += 5;
                    if (scoreNode.Opacity > 250)
                    {
                        scoreNode.Opacity = 255;
                        this.UnscheduleAll();
                    }
                    foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
                }
                );

        }


        CCSprite recordNotification;
        CCSprite recordNotificationImage;
        CCSpriteButton recordOkIGotIt;
        private bool recordNotificationShown = false;

        private void showRecordNotification(float dt)
        {
            if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProMonthly.Score && LeaderboardManager.PlayerRankProMonthly.Rank == 1)
            {
                Player.Instance.Credits += 45000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProMonthly.Score && LeaderboardManager.PlayerRankProMonthly.Rank == 2)
            {
                Player.Instance.Credits += 30000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProMonthly.Score && LeaderboardManager.PlayerRankProMonthly.Rank == 3)
            {
                Player.Instance.Credits += 15000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-3rd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProWeekly.Score && LeaderboardManager.PlayerRankProWeekly.Rank == 1)
            {
                Player.Instance.Credits += 30000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProWeekly.Score && LeaderboardManager.PlayerRankProWeekly.Rank == 2)
            {
                Player.Instance.Credits += 20000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProWeekly.Score && LeaderboardManager.PlayerRankProWeekly.Rank == 3)
            {
                Player.Instance.Credits += 10000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-3rd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProDaily.Score && LeaderboardManager.PlayerRankProDaily.Rank == 1)
            {
                Player.Instance.Credits += 15000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProDaily.Score && LeaderboardManager.PlayerRankProDaily.Rank == 2)
            {
                Player.Instance.Credits += 10000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProDaily.Score && LeaderboardManager.PlayerRankProDaily.Rank == 3)
            {
                Player.Instance.Credits += 5000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-3rd-background-with-text.png", 3);
            }
            else
            {
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-notification-background-with-text.png", 3);
                if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProAlltime.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-all-time.png", 4);
                }
                else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProMonthly.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-month.png", 4);
                }
                else if (isWeHaveScores && alienScore == LeaderboardManager.PlayerRankProWeekly.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-week.png", 4);
                }
                else /*if (isWeHaveScores && score == LeaderboardManager.PlayerRankProDaily.Score)*/
                {
                    recordNotificationImage = this.AddImage(35, 379, "UI/victory-notification-personal-best-of-day.png", 4);
                }
            }


            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);
            recordOkIGotIt = this.AddButton(42, 83, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            recordOkIGotIt.OnClick += recordOkIGotIt_OnClick;
            recordNotificationShown = true;
        }


        private void recordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            this.RemoveChild(recordOkIGotIt);
            this.RemoveChild(recordNotification, true);
            if(recordNotificationImage!=null) this.RemoveChild(recordNotificationImage, true);
            this.ScheduleOnce(showScoreAlien, 0f);

        }

        CCSprite[] creditsLabels;

        private void showScoreAlien(float d)
        {
            if (isWeHaveScores && alienScore > 0 && (alienScore == LeaderboardManager.PlayerRankProAlltime.Score || alienScore == LeaderboardManager.PlayerRankProMonthly.Score || alienScore == LeaderboardManager.PlayerRankProWeekly.Score || alienScore == LeaderboardManager.PlayerRankProDaily.Score) && !recordNotificationShown)
            {
                this.ScheduleOnce(showRecordNotification, 0.5f);
                return;
            }

            //scoreNode = new CCNodeExt();
            //scoreNode.AddImage(0, 564, "UI/Loss scenes/You-are-dead-title.png", 3);
            //scoreNode.AddImage(650, 455, "UI/victory&social-share-global-ranking-all-text.png", 3);


            scoreNode = new CCNodeExt();



            scoreNode.AddImage(0, 225, "UI/game-over-screen-extinction-level-scoreboard-background-bars.png", 2);
            scoreNode.AddImage(245, 225, "UI/game-over-screen-extinction-level-scoreboard-title-text.png", 3);
            scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
            shareYourScore = scoreNode.AddImage(0, 80, "UI/game-over-screen-extinction-level-share-your-score-text.png", 3);


            /* old

            scoreNode.AddImage(147, 488, "UI/game-over-screen-moon-level-game-over-text.png", 3);
            scoreNode.AddImage(610, 290, "UI/game-over-screen-moon-level-global-ranking-text.png", 3);
            scoreNode.AddImage(5, 290, "UI/game-over-screen-moon-level-your-score-text.png", 3);

            scoreNode.AddImage(0, 198, "UI/game-over-screen-moon-level-score-board-just-background.png", 2);
            scoreNode.AddImage(10, 219, "UI/game-over-screen-moon-level-credits-earned-text.png", 3);

            scoreNode.AddImage(0, 70, "UI/victory-share-your-score-and-earn-credits-text.png", 3);

            */

            //current score
            scoreNode.AddImageLabelCentered(155, 380, alienScore.ToString(), 52);
            scoreNode.AddImageLabelCentered(155, 314, alienWave.ToString(), 50);
            //scoreNode.AddImageLabelCentered(155, 247, rank.ToString(), 52);


            if (isWeHaveScores && LeaderboardManager.PlayerRankProMonthly != null && alienScore == LeaderboardManager.PlayerRankProMonthly.Score)
            {
                scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-month-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProMonthly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankProWeekly != null && alienScore == LeaderboardManager.PlayerRankProWeekly.Score)
            {
                scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-week-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProWeekly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && alienScore == LeaderboardManager.PlayerRankProDaily.Score)
            {
                scoreNode.AddImage(0, 440, "UI/victory-earth-level-personal-best-of-day-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankProDaily.Rank.ToString("0"), 52);
            }
            else
            {
                scoreNode.AddImage(0, 440, "UI/victory-earth-level-non-record-title-text.png", 3);
                scoreNode.AddImage(40, 251, "UI/victory-earth-level-not-ranked-text.png", 3);
            }
            //credits
            creditsLabels = scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);

            btnContinue = scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            btnContinue.Visible = false;
            btnContinue.OnClick += BtnContinue_OnClick;

            mainMenu = scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            mainMenu.OnClick += mainMenu_OnClick;

            if (isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null)
            {
                //day
                scoreNode.AddImageLabelCentered(700, 380, LeaderboardManager.PlayerRankProDaily.Score.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProDaily.Score ? null : (alienScore > LeaderboardManager.PlayerRankProDaily.Score ? "red" : (alienScore < LeaderboardManager.PlayerRankProDaily.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(700, 314, LeaderboardManager.PlayerRankProDaily.LevelsCompleted.ToString(), 50, alienScore == LeaderboardManager.PlayerRankProDaily.Score ? null : (alienWave > LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "red" : (alienWave < LeaderboardManager.PlayerRankProDaily.LevelsCompleted ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(700, 247, LeaderboardManager.PlayerRankProDaily.Rank.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProDaily.Score ? null : "green");
                //week
                scoreNode.AddImageLabelCentered(847, 380, LeaderboardManager.PlayerRankProWeekly.Score.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProWeekly.Score ? null : (alienScore > LeaderboardManager.PlayerRankProWeekly.Score ? "red" : (alienScore < LeaderboardManager.PlayerRankProWeekly.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(847, 314, LeaderboardManager.PlayerRankProWeekly.LevelsCompleted.ToString(), 50, alienScore == LeaderboardManager.PlayerRankProWeekly.Score ? null : (alienWave > LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "red" : (alienWave < LeaderboardManager.PlayerRankProWeekly.LevelsCompleted ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(847, 247, LeaderboardManager.PlayerRankProWeekly.Rank.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProWeekly.Score ? null : "green");
                //month
                scoreNode.AddImageLabelCentered(1011, 380, LeaderboardManager.PlayerRankProMonthly.Score.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProMonthly.Score ? null : (alienScore > LeaderboardManager.PlayerRankProMonthly.Score ? "red" : (alienScore < LeaderboardManager.PlayerRankProMonthly.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(1011, 314, LeaderboardManager.PlayerRankProMonthly.LevelsCompleted.ToString(), 50, alienScore == LeaderboardManager.PlayerRankProMonthly.Score ? null : (alienWave > LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "red" : (alienWave < LeaderboardManager.PlayerRankProMonthly.LevelsCompleted ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(1011, 247, LeaderboardManager.PlayerRankProMonthly.Rank.ToString(), 52, alienScore == LeaderboardManager.PlayerRankProMonthly.Score ? null : "green");

                yes = scoreNode.AddButton(834, 90, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
                yes.OnClick += yes_OnClick;

                
                no = scoreNode.AddButton(520, 90, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
                no.OnClick += no_OnClick;

                mainMenu.Visible = false;
                btnContinue.Visible = false;
            }
            else
            {
                //no internet
                shareYourScore.Visible = false;
                btnContinue.Visible = true;
                scoreNode.AddImage(633, 251, "UI/victory-no-internet-connection-text.png", 3);
            }


           

            scoreNode.Opacity = 0;
            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };


            this.AddChild(scoreNode);

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SHOWSCORE);
            this.Schedule(fadeScoreNode);

           

        }

        private void BtnContinue_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.TransitionToLayerCartoonStyle(new GamePlayLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, true));
        }

        private void fadeScoreNode(float dt)
        {
            scoreNode.Opacity += 5;
            if (scoreNode.Opacity > 250)
            {
                scoreNode.Opacity = 255;
                this.Unschedule(fadeScoreNode);
            }
            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };

            youAreDefeated.Opacity = (byte)(255 - scoreNode.Opacity);
        }

        private void mainMenu_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            AdMobManager.HideBanner();
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void revenge_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;

            this.TransitionToLayerCartoonStyle(new GamePlayLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, true));
        }



        CCNodeExt shareNode;
        CCSpriteTwoStateButton shareScoreBoard;
        CCSpriteTwoStateButton shareTwitter;
        CCSpriteTwoStateButton shareFacebook;


        CCNodeExt sl;

        private void yes_OnClick(object sender, EventArgs e)
        {
            sl = new CCNodeExt();

            sl.AddImageCentered(1136 / 2, 598, "UI/victory-i-just-saved-planet-earth.png", 2);

            sl.AddImageCentered(1136 / 2, 86, "UI/social-share-game-advertisement-background-and-text.png", 2);

            sl.AddImageCentered(1136 / 2, 371, "UI/social-share-result-&_ranking-table.png", 2);

            sl.AddImageLabel(420, 295, alienScore.ToString(), 52);

            if (isWeHaveScores && LeaderboardManager.PlayerRankProMonthly != null && alienScore == LeaderboardManager.PlayerRankProMonthly.Score)
            {
                sl.AddImageLabelCentered(995, 295, LeaderboardManager.PlayerRankProMonthly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && alienScore == LeaderboardManager.PlayerRankProDaily.Score)
            {
                sl.AddImageCentered(995, 295, "UI/number_52_NA.png", 2);
            }
            if (isWeHaveScores && LeaderboardManager.PlayerRankProWeekly != null && alienScore == LeaderboardManager.PlayerRankProWeekly.Score)
            {
                sl.AddImageLabelCentered(837, 295, LeaderboardManager.PlayerRankProWeekly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && alienScore == LeaderboardManager.PlayerRankProDaily.Score)
            {
                sl.AddImageCentered(837, 295, "UI/number_52_NA.png", 2);
            }
            if (isWeHaveScores && LeaderboardManager.PlayerRankProDaily != null && alienScore == LeaderboardManager.PlayerRankProDaily.Score)
            {
                sl.AddImageLabelCentered(701, 295, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52);
            }
            else
            {
                sl.AddImage(743, 295, "UI/victory-earth-level-not-ranked-text.png", 3);
            }

            scoreNode.Visible = false;
            this.AddChild(sl);


            shareYourScore.Visible = false;
            yes.Visible = false;
            no.Visible = false;
            SocialNetworkShareManager.ShareLayer("facebook", this);


            scoreNode.Visible = true;
            this.RemoveChild(sl);


            Player.Instance.Credits += 5000;
            foreach (CCSprite spr in creditsLabels)
            {
                scoreNode.RemoveChild(spr);
            }
            creditsLabels = scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);
            btnContinue.Visible = true;
            mainMenu.Visible = true;
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


        private void showAd(float dt)
        {
            AdMobManager.HideBanner();
            AdMobManager.ShowInterstitial();
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        { }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            AdMobManager.ShowBannerBottom();
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SHOWSCORE);
            hasScore = true;
            this.ScheduleOnce(showScoreAlien, 0.1f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            AdMobManager.ShowBannerBottom();
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SHOWSCORE);
            hasScore = true;
            this.ScheduleOnce(showScoreAlien, 0.1f);
        }

        private void shareScoreBoard_OnClick(object sender, EventArgs e)
        {
            shareScoreBoard.ChangeState();
            shareScoreBoard.SetStateImages();
        }

        private void shareTwitter_OnClick(object sender, EventArgs e)
        {
            shareTwitter.ChangeState();
            shareTwitter.SetStateImages();
        }

        private void shareFacebook_OnClick(object sender, EventArgs e)
        {
            shareFacebook.ChangeState();
            shareFacebook.SetStateImages();
        }

        private void cancelBtn_OnClick(object sender, EventArgs e)
        {
            this.Schedule(delegate (float dt)
            {
                if (shareNode.Opacity > 0)
                {
                    shareNode.Opacity -= 20;
                    if (shareNode.Opacity < 20)
                    {
                        shareNode.Opacity = 0;
                    }
                    foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
                }
                else
                {
                    scoreNode.Opacity += 20;
                    if (scoreNode.Opacity >= 235)
                    {
                        scoreNode.Opacity = 255;
                        this.UnscheduleAll();
                    }
                    foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
                }
            });
        }

        private void shareBtn_OnClick(object sender, EventArgs e)
        {
            GamePlayLayer.BestScore = 0;
            this.Schedule(delegate (float dt)
            {
                if (shareNode.Opacity > 0)
                {
                    shareNode.Opacity -= 20;
                    if (shareNode.Opacity < 20)
                    {
                        shareNode.Opacity = 0;
                        this.UnscheduleAll();
                        showGetRevenge(0);
                    }
                    foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
                }
            });
        }

        private void no_OnClick(object sender, EventArgs e)
        {
            shareYourScore.Visible = false;
            yes.Visible = false;
            no.Visible = false;
            btnContinue.Visible = true;
            mainMenu.Visible = true;
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

using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.Shared;

namespace LooneyInvaders.Layers
{
    public class VictoryScreenLayer : CCLayerColorExt
    {
        public BATTLEGROUNDS SelectedBattleground;
        public ENEMIES SelectedEnemy;
        public WEAPONS SelectedWeapon;

        public decimal Time;
        public decimal Accuracy;
        public int LivesLeft;
        public int WinsInSuccession;

        private int score;

        private bool isWeHaveScores = false;
        private bool isDoneWaitingForScores = false;

        CCSprite defeated;
        CCSpriteButton okIGotIt;
        CCSpriteButton btnContinue;
        CCSprite justSavedTitle;
        CCSprite shareYourScore;
        CCSpriteButton mainMenu;
        CCSpriteButton yes;
        CCSpriteButton no;

        BATTLEGROUNDS nextBattleGround;
        ENEMIES nextEnemy;

        public VictoryScreenLayer(ENEMIES selectedEnemy, WEAPONS selectedWeapon, BATTLEGROUNDS selectedBattleground, decimal time, decimal accuracy, int livesLeft = -1, int winsInSuccession = 0)
        {
            Time = time;
            Accuracy = accuracy;
            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;
            LivesLeft = livesLeft;
            WinsInSuccession = winsInSuccession;



            nextEnemy = selectedEnemy;
            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    nextBattleGround = BATTLEGROUNDS.LIBYA;
                    break;
                case BATTLEGROUNDS.DENMARK:
                    nextBattleGround = BATTLEGROUNDS.NORWAY;
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    nextEnemy = ENEMIES.BUSH;
                    nextBattleGround = BATTLEGROUNDS.VIETNAM;
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    nextBattleGround = BATTLEGROUNDS.FINLAND;
                    break;
                case BATTLEGROUNDS.FINLAND:
                    nextEnemy = ENEMIES.KIM;
                    nextBattleGround = BATTLEGROUNDS.SOUTH_KOREA;
                    break;
                case BATTLEGROUNDS.FRANCE:
                    nextBattleGround = BATTLEGROUNDS.ENGLAND;
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    nextBattleGround = BATTLEGROUNDS.UKRAINE;
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    nextBattleGround = BATTLEGROUNDS.UNITED_STATES;
                    break;
                case BATTLEGROUNDS.IRAQ:
                    nextBattleGround = BATTLEGROUNDS.AFGHANISTAN;
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    nextBattleGround = BATTLEGROUNDS.JAPAN;
                    break;
                case BATTLEGROUNDS.JAPAN:
                    nextBattleGround = BATTLEGROUNDS.GREAT_BRITAIN;
                    break;
                case BATTLEGROUNDS.LIBYA:
                    nextBattleGround = BATTLEGROUNDS.RUSSIA;
                    break;
                case BATTLEGROUNDS.NORWAY:
                    nextBattleGround = BATTLEGROUNDS.FRANCE;
                    break;
                case BATTLEGROUNDS.POLAND:
                    nextBattleGround = BATTLEGROUNDS.DENMARK;
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    nextEnemy = ENEMIES.PUTIN;
                    nextBattleGround = BATTLEGROUNDS.GEORGIA;
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    nextBattleGround = BATTLEGROUNDS.ISRAEL;
                    break;
                case BATTLEGROUNDS.SYRIA:
                    nextBattleGround = BATTLEGROUNDS.ESTONIA;
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    nextBattleGround = BATTLEGROUNDS.SYRIA;
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    nextBattleGround = BATTLEGROUNDS.MOON;
                    nextEnemy = ENEMIES.ALIENS;
                    selectedWeapon = WEAPONS.HYBRID;
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    nextBattleGround = BATTLEGROUNDS.IRAQ;
                    break;
            }

            Player.Instance.SetQuickGame(nextEnemy, nextBattleGround, selectedWeapon);

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SHOWSCORE);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/You just saved VO_mono.wav");
                switch (SelectedBattleground)
                {
                    case BATTLEGROUNDS.AFGHANISTAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Afghanistan VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.DENMARK:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Denmark VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ENGLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/England VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ESTONIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Estonia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.FINLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Finland VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.FRANCE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/France VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.GEORGIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Georgia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.GREAT_BRITAIN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Great Britain VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.IRAQ:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Irak VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ISRAEL:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Israel VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.JAPAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Japan VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.LIBYA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Libya VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.NORWAY:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Norway VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.POLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Poland VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.RUSSIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Russia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.SOUTH_KOREA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/South Korea VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.SYRIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Syria VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.UKRAINE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Ukraine VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.UNITED_STATES:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/USA VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.VIETNAM:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vietnam VO_mono.wav");
                        break;
                }
            }


            bool saved = false;

            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    this.SetBackground("UI/Victory scenes/Afganistan-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-afghanistan.png", 2);
                    break;
                case BATTLEGROUNDS.DENMARK:
                    this.SetBackground("UI/Victory scenes/Denmark-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-denmark.png", 2);
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    this.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-england.png", 2);
                    if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ENGLAND) == 0)
                    {
                        this.defeated = this.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-hitler-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    this.SetBackground("UI/Victory scenes/Estonia-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-estonia.png", 2);
                    break;
                case BATTLEGROUNDS.FINLAND:
                    this.SetBackground("UI/Victory scenes/Finland-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-finland.png", 2);
                    if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.FINLAND) == 0)
                    {
                        this.defeated = this.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-putin-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case BATTLEGROUNDS.FRANCE:
                    this.SetBackground("UI/Victory scenes/France-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-france.png", 2);
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    this.SetBackground("UI/Victory scenes/Georgia-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-georgia.png", 2);
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    this.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-great-britain.png", 2);
                    break;
                case BATTLEGROUNDS.IRAQ:
                    this.SetBackground("UI/Victory scenes/Iraq-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-iraq.png", 2);
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    this.SetBackground("UI/Victory scenes/Israel-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-israel.png", 2);
                    break;
                case BATTLEGROUNDS.JAPAN:
                    this.SetBackground("UI/Victory scenes/Japan-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-japan.png", 2);
                    break;
                case BATTLEGROUNDS.LIBYA:
                    this.SetBackground("UI/Victory scenes/Libya-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-libya.png", 2);
                    break;
                case BATTLEGROUNDS.NORWAY:
                    this.SetBackground("UI/Victory scenes/Norway-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-norway.png", 2);
                    break;
                case BATTLEGROUNDS.POLAND:
                    this.SetBackground("UI/Victory scenes/Poland-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-poland.png", 2);
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    this.SetBackground("UI/Victory scenes/Russia-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-russia.png", 2);
                    if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.RUSSIA) == 0)
                    {
                        this.defeated = this.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-george-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    this.SetBackground("UI/Victory scenes/South-Korea-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-south-korea.png", 2);
                    break;
                case BATTLEGROUNDS.SYRIA:
                    this.SetBackground("UI/Victory scenes/Syria-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-syria.png", 2);
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    this.SetBackground("UI/Victory scenes/Ukraine-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-ukraine.png", 2);
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    this.SetBackground("UI/Victory scenes/USA-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-united-states.png", 2);
                    if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.UNITED_STATES) == 0)
                    {
                        this.defeated = this.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-kim-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    this.SetBackground("UI/Victory scenes/Vietnam-victory-scene.jpg");
                    justSavedTitle = this.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-vietnam.png", 2);
                    break;

            }

            AdMobManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;


            score = Convert.ToInt32(Math.Pow(1f / Convert.ToDouble(Time), 0.9f) * Math.Pow(Convert.ToDouble(Accuracy), Convert.ToDouble(Accuracy) / 500f) * 25000);
            if (score > GamePlayLayer.BestScore)
            {
                GamePlayLayer.BestScore = score;
                GamePlayLayer.BestScoreAccuracy = Accuracy;
                GamePlayLayer.BestScoreTime = Time;
                GamePlayLayer.BestScoreCountry = SelectedBattleground;
            }


            //submit score during shown victory image
            Player.Instance.Score += score;
            Player.Instance.Credits += score;
            Player.Instance.AddSavedCountry(SelectedBattleground);
            Player.Instance.SetDayScore(score);

            if (!saved)
            {
                if (WinsInSuccession >= 2 && NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        this.ScheduleOnce(showMultiplierAd, 2.8f);
                    }
                    else
                    {
                        this.ScheduleOnce(showMultiplierAd, 1);
                    }

                }
                else
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        this.ScheduleOnce(showScore, 2.3f);
                    }
                    else
                    {
                        this.ScheduleOnce(showScore, 1f);
                    }
                }
            }
            else
            {
                this.defeated.Visible = false;
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    this.ScheduleOnce(showDefeated, 2.8f);
                }
                else
                {
                    this.ScheduleOnce(showDefeated, 2);
                }
            }

            AdMobManager.ShowBannerBottom();




            isWeHaveScores = LooneyInvaders.Model.LeaderboardManager.SubmitScoreRegular(score, Convert.ToDouble(Accuracy), Convert.ToDouble(Time));
            isDoneWaitingForScores = true;

            GameEnvironment.PlayMusic(MUSIC.VICTORY);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/You just saved VO_mono.wav");
                this.ScheduleOnce(CalloutCountryNameVO, 1.5f);
            }
        }


        private void CalloutCountryNameVO(float dt)
        {
            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Afghanistan VO_mono.wav");
                    break;
                case BATTLEGROUNDS.DENMARK:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Denmark VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/England VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Estonia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.FINLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Finland VO_mono.wav");
                    break;
                case BATTLEGROUNDS.FRANCE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/France VO_mono.wav");
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Georgia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Great Britain VO_mono.wav");
                    break;
                case BATTLEGROUNDS.IRAQ:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Irak VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Israel VO_mono.wav");
                    break;
                case BATTLEGROUNDS.JAPAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Japan VO_mono.wav");
                    break;
                case BATTLEGROUNDS.LIBYA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Libya VO_mono.wav");
                    break;
                case BATTLEGROUNDS.NORWAY:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Norway VO_mono.wav");
                    break;
                case BATTLEGROUNDS.POLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Poland VO_mono.wav");
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Russia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/South Korea VO_mono.wav");
                    break;
                case BATTLEGROUNDS.SYRIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Syria VO_mono.wav");
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Ukraine VO_mono.wav");
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/USA VO_mono.wav");
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vietnam VO_mono.wav");
                    break;
            }
        }


        private CCNodeExt multiplierNode;
        private CCSprite multiplierArrow;
        private CCSprite[] scoreBefore;
        private CCSpriteButton showAd;


        private void showMultiplierAd(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);

            multiplierNode = new CCNodeExt();

            multiplierNode.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-multiply-notification-background.png", 3);
            multiplierNode.AddImageLabelCentered(465, 415, WinsInSuccession.ToString(), 57);
            multiplierNode.AddImageLabelCentered(433, 338, WinsInSuccession.ToString() + "X", 57);
            scoreBefore = multiplierNode.AddImageLabel(40, 270, score.ToString(), 57);
            multiplierArrow = multiplierNode.AddImage(Convert.ToInt32(scoreBefore[scoreBefore.Length - 1].PositionX + 60), 272, "UI/victory-multiply-arrow.png", 4);
            multiplierNode.AddImageLabel(Convert.ToInt32(scoreBefore[scoreBefore.Length - 1].PositionX + 200), 270, (score * WinsInSuccession).ToString(), 57);
            multiplierNode.AddButton(1050, 540, "UI/victory-multiply-notification-cancel-button-untapped.png", "UI/victory-multiply-notification-cancel-button-tapped.png", 4).OnClick += showMultiplierAdCancel_Onclick;
            showAd = multiplierNode.AddButton(40, 77, "UI/victory-multiply-notification-watch-button-untapped.png", "UI/victory-multiply-notification-watch-button-tapped.png", 4);
            showAd.OnClick += showMultiplierAd_Onclick;
            this.AddChild(multiplierNode, 1000);
            this.Schedule(animateArrow, 0.03f);
        }

        private void animateArrow(float dt)
        {
            multiplierArrow.ScaleX = multiplierArrow.ScaleX + 0.012f;
            if (multiplierArrow.ScaleX > 1.23) multiplierArrow.ScaleX = 0.85f;
        }

        private void showMultiplierAd_Onclick(object sender, EventArgs e)
        {
            showAd.Enabled = false;
            AdMobManager.HideBanner();
            AdMobManager.ShowInterstitial(0);
        }

        private void showMultiplierAdCancel_Onclick(object sender, EventArgs e)
        {
            multiplierNode.RemoveAllChildren();
            this.RemoveChild(multiplierNode);
            this.UnscheduleAll();
            this.ScheduleOnce(showScore, 0.2f);
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        { }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            Player.Instance.Credits += score * WinsInSuccession - score;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);
            multiplierNode.RemoveAllChildren();
            this.RemoveChild(multiplierNode);
            this.UnscheduleAll();
            AdMobManager.ShowBannerBottom();
            this.ScheduleOnce(showScore, 0.5f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            AdMobManager.ShowBannerBottom();
            multiplierNode.RemoveAllChildren();
            this.RemoveChild(multiplierNode);
            this.UnscheduleAll();
            this.ScheduleOnce(showScore, 0.2f);
        }


        private void showDefeated(float dt)
        {

            this.defeated.Visible = true;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);
            if (Settings.Instance.VoiceoversEnabled)
            {
                this.ScheduleOnce(calloutCongratulations, 1f);
            }
            okIGotIt = this.AddButton(42, 58, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            okIGotIt.OnClick += okIGotIt_OnClick;

        }

        private void okIGotIt_OnClick(object sender, EventArgs e)
        {
            this.RemoveChild(okIGotIt);
            this.RemoveChild(defeated, true);
            if (WinsInSuccession > 1 && NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                this.ScheduleOnce(showMultiplierAd, 0.2f);

            }
            else
            {
                this.ScheduleOnce(showScore, 0.2f);
            }
        }


        CCSprite recordNotification;
        CCSprite recordNotificationImage;
        CCSpriteButton recordOkIGotIt;
        private bool recordNotificationShown = false;

        private void showRecordNotification(float dt)
        {

            if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularMonthly.Score && LeaderboardManager.PlayerRankRegularMonthly.Rank == 1)
            {
                Player.Instance.Credits += 45000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularMonthly.Score && LeaderboardManager.PlayerRankRegularMonthly.Rank == 2)
            {
                Player.Instance.Credits += 30000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularMonthly.Score && LeaderboardManager.PlayerRankRegularMonthly.Rank == 3)
            {
                Player.Instance.Credits += 15000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-3rd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularWeekly.Score && LeaderboardManager.PlayerRankRegularWeekly.Rank == 1)
            {
                Player.Instance.Credits += 30000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularWeekly.Score && LeaderboardManager.PlayerRankRegularWeekly.Rank == 2)
            {
                Player.Instance.Credits += 20000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularWeekly.Score && LeaderboardManager.PlayerRankRegularWeekly.Rank == 3)
            {
                Player.Instance.Credits += 10000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-3rd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularDaily.Score && LeaderboardManager.PlayerRankRegularDaily.Rank == 1)
            {
                Player.Instance.Credits += 15000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-1st-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularDaily.Score && LeaderboardManager.PlayerRankRegularDaily.Rank == 2)
            {
                Player.Instance.Credits += 10000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-2nd-background-with-text.png", 3);
            }
            else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularDaily.Score && LeaderboardManager.PlayerRankRegularDaily.Rank == 3)
            {
                Player.Instance.Credits += 5000;
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-3rd-background-with-text.png", 3);
            }
            else
            {
                recordNotification = this.AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-notification-background-with-text.png", 3);
                if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularAlltime.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-all-time.png", 4);
                }
                else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularMonthly.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-month.png", 4);
                }
                else if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularWeekly.Score)
                {
                    recordNotificationImage = this.AddImage(35, 367, "UI/victory-notification-personal-best-of-week.png", 4);
                }
                else /*if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularDaily.Score)*/
                {
                    recordNotificationImage = this.AddImage(35, 379, "UI/victory-notification-personal-best-of-day.png", 4);
                }
            }

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWARD_NOTIFICATION);
            if (Settings.Instance.VoiceoversEnabled)
            {
                this.ScheduleOnce(calloutCongratulations, 1f);
            }
            recordOkIGotIt = this.AddButton(42, 83, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            recordOkIGotIt.OnClick += recordOkIGotIt_OnClick;
            recordNotificationShown = true;
        }

        private void calloutCongratulations(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Congratulations VO_mono.wav");
        }

        private void recordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            this.RemoveChild(recordOkIGotIt);
            this.RemoveChild(recordNotification, true);
            if (recordNotificationImage != null) this.RemoveChild(recordNotificationImage, true);
            this.ScheduleOnce(showScore, 0f);

        }

        private float waitForScoreCounter = 0;
        CCNodeExt scoreNode;

        CCSprite[] creditsLabels;

        private void showScore(float dtt)
        {
            if (!isDoneWaitingForScores && waitForScoreCounter < 5)
            {
                waitForScoreCounter += dtt;
                this.ScheduleOnce(showScore, 0.5f);
            }

            if (isWeHaveScores && (score == LeaderboardManager.PlayerRankRegularAlltime.Score || score == LeaderboardManager.PlayerRankRegularMonthly.Score || score == LeaderboardManager.PlayerRankRegularWeekly.Score || score == LeaderboardManager.PlayerRankRegularDaily.Score) && !recordNotificationShown)
            {
                this.ScheduleOnce(showRecordNotification, 0.5f);
                return;
            }

            scoreNode = new CCNodeExt();


            scoreNode.AddImage(0, 225, "UI/victory-earth-level-scoreboard-background-bars.png", 2);
            scoreNode.AddImage(245, 225, "UI/victory-earth-level-scoreboard-title-text.png", 3);
            scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
            shareYourScore = scoreNode.AddImage(0, 80, "UI/victory-earth-level-share-your-score-text.png", 3);

            /*old screen
            scoreNode.AddImage(650, 455, "UI/victory&social-share-global-ranking-all-text.png", 3);
            scoreNode.AddImage(0, 153, "UI/victory-score-board-just-background.png", 2);
            scoreNode.AddImage(0, 153, "UI/victory-score-board-just-text.png", 3);

            scoreNode.AddImage(0, 70, "UI/victory-share-your-score-and-earn-credits-text.png", 3);

            scoreNode.AddImageLabelRightAligned(466, 391, Time.ToString("0.00"), 57);
            scoreNode.AddImage(466, 385, "UI/victory&social-share-score-numbers-(sec).png", 4);

            scoreNode.AddImageLabelRightAligned(572, 318, Accuracy.ToString("0.00"), 57);
            scoreNode.AddImage(570, 315, "UI/victory&social-share-score-numbers-(%).png", 4);
            */





            //current score
            scoreNode.AddImageLabelCentered(155, 432, score.ToString(), 52);
            scoreNode.AddImageLabelCentered(155, 367, Time.ToString("0") + "s", 50);
            scoreNode.AddImageLabelCentered(155, 311, Accuracy.ToString("0") + "%", 50);
            if (isWeHaveScores && LeaderboardManager.PlayerRankRegularMonthly != null && score == LeaderboardManager.PlayerRankRegularMonthly.Score)
            {
                scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-month-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankRegularWeekly != null && score == LeaderboardManager.PlayerRankRegularWeekly.Score)
            {
                scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-week-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && score == LeaderboardManager.PlayerRankRegularDaily.Score)
            {
                scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-day-title-text.png", 3);
                scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52);
            }
            else
            {
                scoreNode.AddImage(0, 490, "UI/victory-earth-level-non-record-title-text.png", 3);
                scoreNode.AddImage(40, 247, "UI/victory-earth-level-not-ranked-text.png", 3);
            }
            //credits
            creditsLabels = scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);

            btnContinue = scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            btnContinue.Visible = false;
            btnContinue.OnClick += BtnContinue_OnClick;

            mainMenu = scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            mainMenu.OnClick += mainMenu_OnClick;


            if (isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null)
            {
                //day
                scoreNode.AddImageLabelCentered(700, 432, LeaderboardManager.PlayerRankRegularDaily.Score.ToString(), 52, score == LeaderboardManager.PlayerRankRegularDaily.Score ? null : (score > LeaderboardManager.PlayerRankRegularDaily.Score ? "red" : (score < LeaderboardManager.PlayerRankRegularDaily.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(700, 367, LeaderboardManager.PlayerRankRegularDaily.Time.ToString("0") + "s", 50, score == LeaderboardManager.PlayerRankRegularDaily.Score ? null : (Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularDaily.Time ? "red" : (Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularDaily.Time ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(700, 311, LeaderboardManager.PlayerRankRegularDaily.Accuracy.ToString("0") + "%", 50, score == LeaderboardManager.PlayerRankRegularDaily.Score ? null : (Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularDaily.Accuracy ? "red" : (Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularDaily.Accuracy ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(700, 245, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52, score == LeaderboardManager.PlayerRankRegularDaily.Score ? null : "green");
                //week
                scoreNode.AddImageLabelCentered(847, 432, LeaderboardManager.PlayerRankRegularWeekly.Score.ToString(), 52, score == LeaderboardManager.PlayerRankRegularWeekly.Score ? null : (score > LeaderboardManager.PlayerRankRegularWeekly.Score ? "red" : (score < LeaderboardManager.PlayerRankRegularWeekly.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(847, 367, LeaderboardManager.PlayerRankRegularWeekly.Time.ToString("0") + "s", 50, score == LeaderboardManager.PlayerRankRegularWeekly.Score ? null : (Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularWeekly.Time ? "red" : (Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularWeekly.Time ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(847, 311, LeaderboardManager.PlayerRankRegularWeekly.Accuracy.ToString("0") + "%", 50, score == LeaderboardManager.PlayerRankRegularWeekly.Score ? null : (Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularWeekly.Accuracy ? "red" : (Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularWeekly.Accuracy ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(847, 245, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52, score == LeaderboardManager.PlayerRankRegularWeekly.Score ? null : "green");
                //month
                scoreNode.AddImageLabelCentered(1011, 432, LeaderboardManager.PlayerRankRegularMonthly.Score.ToString(), 52, score == LeaderboardManager.PlayerRankRegularMonthly.Score ? null : (score > LeaderboardManager.PlayerRankRegularMonthly.Score ? "red" : (score < LeaderboardManager.PlayerRankRegularMonthly.Score ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(1011, 367, LeaderboardManager.PlayerRankRegularMonthly.Time.ToString("0") + "s", 50, score == LeaderboardManager.PlayerRankRegularMonthly.Score ? null : (Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularMonthly.Time ? "red" : (Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularMonthly.Time ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(1011, 311, LeaderboardManager.PlayerRankRegularMonthly.Accuracy.ToString("0") + "%", 50, score == LeaderboardManager.PlayerRankRegularMonthly.Score ? null : (Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularMonthly.Accuracy ? "red" : (Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularMonthly.Accuracy ? "green" : "yellow")));
                scoreNode.AddImageLabelCentered(1011, 245, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52, score == LeaderboardManager.PlayerRankRegularMonthly.Score ? null : "green");

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
                scoreNode.AddImage(633, 247, "UI/victory-no-internet-connection-text.png", 3);
                scoreNode.AddImage(562, 300, "UI/Main-screen-off-line-notification.png", 3);
            }






            scoreNode.Opacity = 0;
            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };


            this.AddChild(scoreNode);

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SHOWSCORE);
            this.Schedule(fadeScore);
        }

        private void fadeScore(float dt)
        {
            scoreNode.Opacity += 5;
            justSavedTitle.Opacity -= 5;
            if (scoreNode.Opacity > 250)
            {
                scoreNode.Opacity = 255;
                justSavedTitle.Opacity = 0;
                this.Unschedule(fadeScore);

            }
            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
        }

        private void BtnContinue_OnClick(object sender, EventArgs e)
        {
            nextLevel();
        }

        CCNodeExt shareNode;
        CCSpriteTwoStateButton shareScoreBoard;
        CCSpriteButton shareTwitter;
        CCSpriteButton shareFacebook;

        private void mainMenu_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;


            AdMobManager.HideBanner();
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        //CCLayerColorExt sl;

        CCNodeExt sl;

        private void yes_OnClick(object sender, EventArgs e)
        {
            sl = new CCNodeExt();

            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    //sl.SetBackground("UI/Victory scenes/Afganistan-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-afghanistan.png", 2);
                    break;
                case BATTLEGROUNDS.DENMARK:
                    //sl.SetBackground("UI/Victory scenes/Denmark-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-denmark.png", 2);
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    //sl.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-england.png", 2);
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    //sl.SetBackground("UI/Victory scenes/Estonia-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-estonia.png", 2);
                    break;
                case BATTLEGROUNDS.FINLAND:
                    //sl.SetBackground("UI/Victory scenes/Finland-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-finland.png", 2);
                    break;
                case BATTLEGROUNDS.FRANCE:
                    //sl.SetBackground("UI/Victory scenes/France-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-france.png", 2);
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    //sl.SetBackground("UI/Victory scenes/Georgia-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-georgia.png", 2);
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    //sl.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-great-britain.png", 2);
                    break;
                case BATTLEGROUNDS.IRAQ:
                    //sl.SetBackground("UI/Victory scenes/Iraq-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-iraq.png", 2);
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    //sl.SetBackground("UI/Victory scenes/Israel-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-israel.png", 2);
                    break;
                case BATTLEGROUNDS.JAPAN:
                    //sl.SetBackground("UI/Victory scenes/Japan-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-japan.png", 2);
                    break;
                case BATTLEGROUNDS.LIBYA:
                    //sl.SetBackground("UI/Victory scenes/Libya-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-libya.png", 2);
                    break;
                case BATTLEGROUNDS.NORWAY:
                    //sl.SetBackground("UI/Victory scenes/Norway-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-norway.png", 2);
                    break;
                case BATTLEGROUNDS.POLAND:
                    //sl.SetBackground("UI/Victory scenes/Poland-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-poland.png", 2);
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    //sl.SetBackground("UI/Victory scenes/Russia-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-russia.png", 2);
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    //sl.SetBackground("UI/Victory scenes/South-Korea-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-south-korea.png", 2);
                    break;
                case BATTLEGROUNDS.SYRIA:
                    //sl.SetBackground("UI/Victory scenes/Syria-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-syria.png", 2);
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    //sl.SetBackground("UI/Victory scenes/Ukraine-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-ukraine.png", 2);
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    //sl.SetBackground("UI/Victory scenes/USA-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-united-states.png", 2);
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    //sl.SetBackground("UI/Victory scenes/Vietnam-victory-scene.jpg");
                    sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-vietnam.png", 2);
                    break;

            }
            sl.AddImageCentered(1136 / 2, 86, "UI/social-share-game-advertisement-background-and-text.png", 2);

            sl.AddImageCentered(1136 / 2, 371, "UI/social-share-result-&_ranking-table.png", 2);

            sl.AddImageLabel(420, 295, score.ToString(), 52);

            if (isWeHaveScores && LeaderboardManager.PlayerRankRegularMonthly != null && score == LeaderboardManager.PlayerRankRegularMonthly.Score)
            {
                sl.AddImageLabelCentered(995, 295, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && score == LeaderboardManager.PlayerRankRegularDaily.Score)
            {
                sl.AddImageCentered(995, 295, "UI/number_52_NA.png", 2);
            }
            if (isWeHaveScores && LeaderboardManager.PlayerRankRegularWeekly != null && score == LeaderboardManager.PlayerRankRegularWeekly.Score)
            {
                sl.AddImageLabelCentered(837, 295, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52);
            }
            else if (isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && score == LeaderboardManager.PlayerRankRegularDaily.Score)
            {
                sl.AddImageCentered(837, 295, "UI/number_52_NA.png", 2);
            }
            if (isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && score == LeaderboardManager.PlayerRankRegularDaily.Score)
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
            this.Schedule(delegate (float dt)
            {
                if (this.IsSharing == true)
                {
                    Console.WriteLine("nema fokus");
                }
                else
                {
                    Console.WriteLine("ima fokus");
                    this.UnscheduleAll();
                }
            }, 0.5f);
            */

            //nextLevel();

            //if (shareNode == null)
            //{
            //    shareNode = new CCNodeExt();
            //    shareNode.AddImageCentered(1136 / 2, 598, "UI/Score-share-picker-share-your-score-in-text.png", 2);

            //    shareScoreBoard = shareNode.AddTwoStateButton(45, 465, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-tapped(no-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
            //    shareScoreBoard.OnClick += shareScoreBoard_OnClick;
            //    shareScoreBoard.ButtonType = BUTTON_TYPE.OnOff;
            //    shareNode.AddImage(197, 469, "UI/Score-share-picker-game-score-board-text.png", 3);


            //    shareTwitter = shareNode.AddButton(45, 374, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
            //    shareTwitter.OnClick += shareTwitter_OnClick;
            //    shareTwitter.ButtonType = BUTTON_TYPE.Regular;
            //    shareNode.AddImage(197, 378, "UI/Score-share-picker-twitter-text.png", 3);

            //    shareFacebook = shareNode.AddButton(45, 275, "UI/Score-share-picker-no-button-untapped(yes-mode).png", "UI/Score-share-picker-no-button-untapped(yes-mode).png", 5);
            //    shareFacebook.OnClick += shareFacebook_OnClick;
            //    shareFacebook.ButtonType = BUTTON_TYPE.Regular;
            //    shareNode.AddImage(197, 279, "UI/Score-share-picker-facebook-text.png", 3);


            //    CCSpriteButton cancelBtn = shareNode.AddButton(47, 148, "UI/Score-share-picker-cancel-button-untapped.png", "UI/Score-share-picker-cancel-button-tapped.png");
            //    cancelBtn.OnClick += cancelBtn_OnClick;

            //    CCSpriteButton shareBtn = shareNode.AddButton(809, 148, "UI/Score-share-picker-share-button-untapped.png", "UI/Score-share-picker-share-button-tapped.png");
            //    shareBtn.OnClick += shareBtn_OnClick;


            //    shareNode.AddImage(1,70, "UI/Score-share-picker-terms-of-sharing-backqround.png", 3);
            //    shareNode.AddImage(2, 70, "UI/Score-share-picker-terms-of-sharing-text-area-without-links.png", 4);

            //    CCSpriteButton terms = shareNode.AddButton(555, 70, "UI/Score-share-picker-terms-of-sharing-text-area1-with-link.png", "UI/Score-share-picker-terms-of-sharing-text-area1-with-link.png", 5);
            //    terms.ButtonType = BUTTON_TYPE.Link;

            //    CCSpriteButton privacy = shareNode.AddButton(888, 70, "UI/Score-share-picker-terms-of-sharing-text-area2-with-link.png", "UI/Score-share-picker-terms-of-sharing-text-area2-with-link.png", 5);
            //    privacy.ButtonType = BUTTON_TYPE.Link;

            //    shareNode.Opacity = 0;
            //    foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
            //    this.AddChild(shareNode);

            //}

            //this.Schedule(delegate (float dt) 
            //{
            //    if (scoreNode.Opacity > 0)
            //    {
            //        scoreNode.Opacity -= 20;
            //        //justSavedTitle.Opacity -= 20;
            //        if (scoreNode.Opacity < 20)
            //        {
            //            scoreNode.Opacity = 0;
            //            //justSavedTitle.Opacity = 0;
            //        }
            //        foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
            //    }
            //    else
            //    {
            //        shareNode.Opacity += 20;
            //        if (shareNode.Opacity > 235)
            //        {
            //            this.UnscheduleAll();
            //            shareNode.Opacity = 255;
            //        }
            //        foreach (CCNode child in shareNode.Children) { child.Opacity = shareNode.Opacity; };
            //    }
            //});

        }


        private void shareScoreBoard_OnClick(object sender, EventArgs e)
        {
            //SocialNetworkShareManager.ShareLayer("facebook", this);
            //shareScoreBoard.ChangeState();
            //shareScoreBoard.SetStateImages();
        }

        private void shareTwitter_OnClick(object sender, EventArgs e)
        {
            //SocialNetworkShareManager.ShareLayer("twitter", this);
        }

        private void shareFacebook_OnClick(object sender, EventArgs e)
        {
            //SocialNetworkShareManager.ShareLayer("facebook", this);
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
                    //justSavedTitle.Opacity += 20;
                    if (scoreNode.Opacity >= 235)
                    {
                        scoreNode.Opacity = 255;
                        //justSavedTitle.Opacity = 255;
                        this.UnscheduleAll();
                    }
                    foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
                }
            });

        }

        /*
        private void shareBtn_OnClick(object sender, EventArgs e)
        {   
            nextLevel();
        }
        */

        private void no_OnClick(object sender, EventArgs e)
        {
            shareYourScore.Visible = false;
            yes.Visible = false;
            no.Visible = false;
            btnContinue.Visible = true;
            mainMenu.Visible = true;
        }

        private void nextLevel()
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();

            if (nextBattleGround == BATTLEGROUNDS.MOON)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new EnemyPickerLayer());
            }
            else
            {
                this.TransitionToLayerCartoonStyle(new GamePlayLayer(nextEnemy, SelectedWeapon, nextBattleGround, true, -1, -1, -1, -1, nextEnemy, LAUNCH_MODE.DEFAULT, LivesLeft, WinsInSuccession));
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Console.WriteLine("LAYER ONENTER");
        }
    }
}

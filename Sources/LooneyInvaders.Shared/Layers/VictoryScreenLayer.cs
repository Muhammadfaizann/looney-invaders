using System;
using System.Globalization;
using System.Threading.Tasks;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;
using static LooneyInvaders.Model.Enums.LeaderBoardItemField;

namespace LooneyInvaders.Layers
{
    public class VictoryScreenLayer : CCLayerColorExt
    {
        public Battlegrounds SelectedBattleground;
        public Enemies SelectedEnemy;
        public Weapons SelectedWeapon;

        public decimal Time;
        public decimal Accuracy;
        public int LivesLeft;
        public int WinsInSuccession;

        private readonly int _score;

        private readonly bool _isWeHaveScores;
        private readonly bool _isDoneWaitingForScores;

        private readonly CCSprite _defeated;
        private CCSpriteButton _okIGotIt;
        private CCSpriteButton _btnContinue;
        private readonly CCSprite _justSavedTitle;
        private CCSprite _shareYourScore;
        private CCSpriteButton _mainMenu;
        private CCSpriteButton _yes;
        private CCSpriteButton _no;

        private readonly Battlegrounds _nextBattleGround;
        private readonly Enemies _nextEnemy;

        public VictoryScreenLayer(Enemies selectedEnemy, Weapons selectedWeapon, Battlegrounds selectedBattleground, decimal time, decimal accuracy, int livesLeft = -1, int winsInSuccession = 0)
        {
            Time = time;
            Accuracy = accuracy;
            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;
            LivesLeft = livesLeft;
            WinsInSuccession = winsInSuccession;

            _nextEnemy = selectedEnemy;
            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    _nextBattleGround = Battlegrounds.Libya;
                    break;
                case Battlegrounds.Denmark:
                    _nextBattleGround = Battlegrounds.Norway;
                    break;
                case Battlegrounds.England:
                    _nextEnemy = Enemies.Bush;
                    _nextBattleGround = Battlegrounds.Vietnam;
                    break;
                case Battlegrounds.Estonia:
                    _nextBattleGround = Battlegrounds.Finland;
                    break;
                case Battlegrounds.Finland:
                    _nextEnemy = Enemies.Kim;
                    _nextBattleGround = Battlegrounds.SouthKorea;
                    break;
                case Battlegrounds.France:
                    _nextBattleGround = Battlegrounds.England;
                    break;
                case Battlegrounds.Georgia:
                    _nextBattleGround = Battlegrounds.Ukraine;
                    break;
                case Battlegrounds.GreatBritain:
                    _nextBattleGround = Battlegrounds.UnitedStates;
                    break;
                case Battlegrounds.Iraq:
                    _nextBattleGround = Battlegrounds.Afghanistan;
                    break;
                case Battlegrounds.Israel:
                    _nextBattleGround = Battlegrounds.Japan;
                    break;
                case Battlegrounds.Japan:
                    _nextBattleGround = Battlegrounds.GreatBritain;
                    break;
                case Battlegrounds.Libya:
                    _nextBattleGround = Battlegrounds.Russia;
                    break;
                case Battlegrounds.Norway:
                    _nextBattleGround = Battlegrounds.France;
                    break;
                case Battlegrounds.Poland:
                    _nextBattleGround = Battlegrounds.Denmark;
                    break;
                case Battlegrounds.Russia:
                    _nextEnemy = Enemies.Putin;
                    _nextBattleGround = Battlegrounds.Georgia;
                    break;
                case Battlegrounds.SouthKorea:
                    _nextBattleGround = Battlegrounds.Israel;
                    break;
                case Battlegrounds.Syria:
                    _nextBattleGround = Battlegrounds.Estonia;
                    break;
                case Battlegrounds.Ukraine:
                    _nextBattleGround = Battlegrounds.Syria;
                    break;
                case Battlegrounds.UnitedStates:
                    _nextBattleGround = Battlegrounds.Moon;
                    _nextEnemy = Enemies.Aliens;
                    selectedWeapon = Weapons.Hybrid;
                    break;
                case Battlegrounds.Vietnam:
                    _nextBattleGround = Battlegrounds.Iraq;
                    break;
            }

            Player.Instance.SetQuickGame(_nextEnemy, _nextBattleGround, selectedWeapon);

            GameEnvironment.PreloadSoundEffect(SoundEffect.ShowScore);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/You just saved VO_mono.wav");
                switch (SelectedBattleground)
                {
                    case Battlegrounds.Afghanistan:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Afghanistan VO_mono.wav");
                        break;
                    case Battlegrounds.Denmark:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Denmark VO_mono.wav");
                        break;
                    case Battlegrounds.England:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/England VO_mono.wav");
                        break;
                    case Battlegrounds.Estonia:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Estonia VO_mono.wav");
                        break;
                    case Battlegrounds.Finland:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Finland VO_mono.wav");
                        break;
                    case Battlegrounds.France:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/France VO_mono.wav");
                        break;
                    case Battlegrounds.Georgia:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Georgia VO_mono.wav");
                        break;
                    case Battlegrounds.GreatBritain:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Great Britain VO_mono.wav");
                        break;
                    case Battlegrounds.Iraq:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Irak VO_mono.wav");
                        break;
                    case Battlegrounds.Israel:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Israel VO_mono.wav");
                        break;
                    case Battlegrounds.Japan:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Japan VO_mono.wav");
                        break;
                    case Battlegrounds.Libya:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Libya VO_mono.wav");
                        break;
                    case Battlegrounds.Norway:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Norway VO_mono.wav");
                        break;
                    case Battlegrounds.Poland:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Poland VO_mono.wav");
                        break;
                    case Battlegrounds.Russia:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Russia VO_mono.wav");
                        break;
                    case Battlegrounds.SouthKorea:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/South Korea VO_mono.wav");
                        break;
                    case Battlegrounds.Syria:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Syria VO_mono.wav");
                        break;
                    case Battlegrounds.Ukraine:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Ukraine VO_mono.wav");
                        break;
                    case Battlegrounds.UnitedStates:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/USA VO_mono.wav");
                        break;
                    case Battlegrounds.Vietnam:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vietnam VO_mono.wav");
                        break;
                }
            }


            var saved = false;

            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    SetBackground("UI/Victory scenes/Afganistan-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-afghanistan.png", 2);
                    break;
                case Battlegrounds.Denmark:
                    SetBackground("UI/Victory scenes/Denmark-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-denmark.png", 2);
                    break;
                case Battlegrounds.England:
                    SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-england.png", 2);
                    if (Player.Instance.GetSavedCountries(Battlegrounds.England) == 0)
                    {
                        _defeated = AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-hitler-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case Battlegrounds.Estonia:
                    SetBackground("UI/Victory scenes/Estonia-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-estonia.png", 2);
                    break;
                case Battlegrounds.Finland:
                    SetBackground("UI/Victory scenes/Finland-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-finland.png", 2);
                    if (Player.Instance.GetSavedCountries(Battlegrounds.Finland) == 0)
                    {
                        _defeated = AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-putin-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case Battlegrounds.France:
                    SetBackground("UI/Victory scenes/France-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-france.png", 2);
                    break;
                case Battlegrounds.Georgia:
                    SetBackground("UI/Victory scenes/Georgia-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-georgia.png", 2);
                    break;
                case Battlegrounds.GreatBritain:
                    SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-great-britain.png", 2);
                    break;
                case Battlegrounds.Iraq:
                    SetBackground("UI/Victory scenes/Iraq-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-iraq.png", 2);
                    break;
                case Battlegrounds.Israel:
                    SetBackground("UI/Victory scenes/Israel-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-israel.png", 2);
                    break;
                case Battlegrounds.Japan:
                    SetBackground("UI/Victory scenes/Japan-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-japan.png", 2);
                    break;
                case Battlegrounds.Libya:
                    SetBackground("UI/Victory scenes/Libya-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-libya.png", 2);
                    break;
                case Battlegrounds.Norway:
                    SetBackground("UI/Victory scenes/Norway-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-norway.png", 2);
                    break;
                case Battlegrounds.Poland:
                    SetBackground("UI/Victory scenes/Poland-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-you-just-saved-poland.png", 2);
                    break;
                case Battlegrounds.Russia:
                    SetBackground("UI/Victory scenes/Russia-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-russia.png", 2);
                    if (Player.Instance.GetSavedCountries(Battlegrounds.Russia) == 0)
                    {
                        _defeated = AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-george-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case Battlegrounds.SouthKorea:
                    SetBackground("UI/Victory scenes/South-Korea-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-south-korea.png", 2);
                    break;
                case Battlegrounds.Syria:
                    SetBackground("UI/Victory scenes/Syria-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-syria.png", 2);
                    break;
                case Battlegrounds.Ukraine:
                    SetBackground("UI/Victory scenes/Ukraine-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-you-just-saved-ukraine.png", 2);
                    break;
                case Battlegrounds.UnitedStates:
                    SetBackground("UI/Victory scenes/USA-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-you-just-saved-united-states.png", 2);
                    if (Player.Instance.GetSavedCountries(Battlegrounds.UnitedStates) == 0)
                    {
                        _defeated = AddImageCentered(1136 / 2, 630 / 2, "UI/victory-notification-kim-defeat-background-title-text.png", 3);
                        saved = true;
                    }
                    break;
                case Battlegrounds.Vietnam:
                    SetBackground("UI/Victory scenes/Vietnam-victory-scene.jpg");
                    _justSavedTitle = AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-you-just-saved-vietnam.png", 2);
                    break;

            }

            AdMobManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;


            _score = Convert.ToInt32(Math.Pow(1f / Convert.ToDouble(Time), 0.9f) * Math.Pow(Convert.ToDouble(Accuracy), Convert.ToDouble(Accuracy) / 500f) * 25000);
            if (_score > GamePlayLayer.BestScore)
            {
                GamePlayLayer.BestScore = _score;
                GamePlayLayer.BestScoreAccuracy = Accuracy;
                GamePlayLayer.BestScoreTime = Time;
                GamePlayLayer.BestScoreCountry = SelectedBattleground;
            }


            //submit score during shown victory image
            Player.Instance.Score += _score;
            Player.Instance.Credits += _score;
            Player.Instance.AddSavedCountry(SelectedBattleground);
            Player.Instance.SetDayScore(_score);

            if (!saved)
            {
                if (WinsInSuccession >= 2 && NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        ScheduleOnce(ShowMultiplierAd, 2.8f);
                    }
                    else
                    {
                        ScheduleOnce(ShowMultiplierAd, 1);
                    }

                }
                else
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 2.3f);
                    }
                    else
                    {
                        ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 1f);
                    }
                }
            }
            else
            {
                _defeated.Visible = false;
                GameEnvironment.PreloadSoundEffect(SoundEffect.RewardNotification);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    ScheduleOnce(ShowDefeated, 2.8f);
                }
                else
                {
                    ScheduleOnce(ShowDefeated, 2);
                }
            }

            AdMobManager.ShowBannerBottom();




            _isWeHaveScores = LeaderboardManager.SubmitScoreRegular(_score, Convert.ToDouble(Accuracy), Convert.ToDouble(Time));
            _isDoneWaitingForScores = true;

            GameEnvironment.PlayMusic(Music.Victory);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/You just saved VO_mono.wav");
                ScheduleOnce(CalloutCountryNameVo, 1.5f);
            }
        }


        private void CalloutCountryNameVo(float dt)
        {
            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Afghanistan VO_mono.wav");
                    break;
                case Battlegrounds.Denmark:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Denmark VO_mono.wav");
                    break;
                case Battlegrounds.England:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/England VO_mono.wav");
                    break;
                case Battlegrounds.Estonia:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Estonia VO_mono.wav");
                    break;
                case Battlegrounds.Finland:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Finland VO_mono.wav");
                    break;
                case Battlegrounds.France:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/France VO_mono.wav");
                    break;
                case Battlegrounds.Georgia:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Georgia VO_mono.wav");
                    break;
                case Battlegrounds.GreatBritain:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Great Britain VO_mono.wav");
                    break;
                case Battlegrounds.Iraq:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Irak VO_mono.wav");
                    break;
                case Battlegrounds.Israel:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Israel VO_mono.wav");
                    break;
                case Battlegrounds.Japan:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Japan VO_mono.wav");
                    break;
                case Battlegrounds.Libya:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Libya VO_mono.wav");
                    break;
                case Battlegrounds.Norway:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Norway VO_mono.wav");
                    break;
                case Battlegrounds.Poland:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Poland VO_mono.wav");
                    break;
                case Battlegrounds.Russia:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Russia VO_mono.wav");
                    break;
                case Battlegrounds.SouthKorea:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/South Korea VO_mono.wav");
                    break;
                case Battlegrounds.Syria:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Syria VO_mono.wav");
                    break;
                case Battlegrounds.Ukraine:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Ukraine VO_mono.wav");
                    break;
                case Battlegrounds.UnitedStates:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/USA VO_mono.wav");
                    break;
                case Battlegrounds.Vietnam:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vietnam VO_mono.wav");
                    break;
            }
        }


        private CCNodeExt _multiplierNode;
        private CCSprite _multiplierArrow;
        private CCSprite[] _scoreBefore;
        private CCSpriteButton _showAd;


        private void ShowMultiplierAd(float dt)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);

            _multiplierNode = new CCNodeExt();

            _multiplierNode.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-multiply-notification-background.png", 3);
            _multiplierNode.AddImageLabelCentered(465, 415, WinsInSuccession.ToString(), 57);
            _multiplierNode.AddImageLabelCentered(433, 338, WinsInSuccession + "X", 57);
            _scoreBefore = _multiplierNode.AddImageLabel(40, 270, _score.ToString(), 57);
            _multiplierArrow = _multiplierNode.AddImage(Convert.ToInt32(_scoreBefore[_scoreBefore.Length - 1].PositionX + 60), 272, "UI/victory-multiply-arrow.png", 4);
            _multiplierNode.AddImageLabel(Convert.ToInt32(_scoreBefore[_scoreBefore.Length - 1].PositionX + 200), 270, (_score * WinsInSuccession).ToString(), 57);
            _multiplierNode.AddButton(1050, 540, "UI/victory-multiply-notification-cancel-button-untapped.png", "UI/victory-multiply-notification-cancel-button-tapped.png", 4).OnClick += showMultiplierAdCancel_Onclick;
            _showAd = _multiplierNode.AddButton(40, 77, "UI/victory-multiply-notification-watch-button-untapped.png", "UI/victory-multiply-notification-watch-button-tapped.png", 4);
            _showAd.OnClick += showMultiplierAd_Onclick;
            AddChild(_multiplierNode, 1000);
            Schedule(AnimateArrow, 0.03f);
        }

        private void AnimateArrow(float dt)
        {
            _multiplierArrow.ScaleX = _multiplierArrow.ScaleX + 0.012f;
            if (_multiplierArrow.ScaleX > 1.23) _multiplierArrow.ScaleX = 0.85f;
        }

        private void showMultiplierAd_Onclick(object sender, EventArgs e)
        {
            _showAd.Enabled = false;
            AdMobManager.HideBanner();
            AdMobManager.ShowInterstitial(0);
        }

        private void showMultiplierAdCancel_Onclick(object sender, EventArgs e)
        {
            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);
            UnscheduleAll();
            ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0.2f);
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        { }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            Player.Instance.Credits += _score * WinsInSuccession - _score;
            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);
            UnscheduleAll();
            AdMobManager.ShowBannerBottom();
            ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0.5f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
            AdMobManager.ShowBannerBottom();
            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);
            UnscheduleAll();
            ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0.2f);
        }


        private void ShowDefeated(float dt)
        {

            _defeated.Visible = true;
            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            if (Settings.Instance.VoiceoversEnabled)
            {
                ScheduleOnce(CalloutCongratulations, 1f);
            }
            _okIGotIt = AddButton(42, 58, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _okIGotIt.OnClick += okIGotIt_OnClick;

        }

        private void okIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_okIGotIt);
            RemoveChild(_defeated);
            if (WinsInSuccession > 1 && NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ScheduleOnce(ShowMultiplierAd, 0.2f);

            }
            else
            {
                ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0.2f);
            }
        }


        private CCSprite _recordNotification;
        private CCSprite _recordNotificationImage;
        private CCSpriteButton _recordOkIGotIt;
        private bool _recordNotificationShown;

        private void ShowRecordNotification(float dt)
        {

            if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 1)
            {
                Player.Instance.Credits += 45000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 2)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 3)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 1)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 2)
            {
                Player.Instance.Credits += 20000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 3)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 1)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 2)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 3)
            {
                Player.Instance.Credits += 5000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-3rd-background-with-text.png", 3);
            }
            else
            {
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-notification-background-with-text.png", 3);
                if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularAlltime.Score) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-all-time.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-month.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-week.png", 4);
                }
                else /*if (isWeHaveScores && score == LeaderboardManager.PlayerRankRegularDaily.Score)*/
                {
                    _recordNotificationImage = AddImage(35, 379, "UI/victory-notification-personal-best-of-day.png", 4);
                }
            }

            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            if (Settings.Instance.VoiceoversEnabled)
            {
                ScheduleOnce(CalloutCongratulations, 1f);
            }
            _recordOkIGotIt = AddButton(42, 83, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _recordOkIGotIt.OnClick += recordOkIGotIt_OnClick;
            _recordNotificationShown = true;
        }

        private void CalloutCongratulations(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Congratulations VO_mono.wav");
        }

        private void recordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_recordOkIGotIt);
            RemoveChild(_recordNotification);
            if (_recordNotificationImage != null) RemoveChild(_recordNotificationImage);
            ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0f);

        }

        private float _waitForScoreCounter;
        private CCNodeExt _scoreNode;

        private CCSprite[] _creditsLabels;

        private void ShowScore(float dtt)
        {
            if (!_isDoneWaitingForScores && _waitForScoreCounter < 5)
            {
                _waitForScoreCounter += dtt;
                ScheduleOnce((obj) => { try { ShowScore(obj); } catch { } }, 0.5f);
            }

            try
            {
                if (_isWeHaveScores
                    && (Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularAlltimeField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularMonthlyField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularWeeklyField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularDailyField(Score)) < AppConstants.Tolerance)
                    && !_recordNotificationShown)
                {
                    ScheduleOnce((obj) => { try { ShowRecordNotification(obj); } catch { } }, 0.5f);
                    return;
                }

                _scoreNode = new CCNodeExt();


                _scoreNode.AddImage(0, 225, "UI/victory-earth-level-scoreboard-background-bars.png", 2);
                _scoreNode.AddImage(245, 225, "UI/victory-earth-level-scoreboard-title-text.png", 3);
                _scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
                _shareYourScore = _scoreNode.AddImage(0, 80, "UI/victory-earth-level-share-your-score-text.png", 3);

            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }

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
            _scoreNode.AddImageLabelCentered(155, 432, _score.ToString(), 52);
            _scoreNode.AddImageLabelCentered(155, 367, Time.ToString("0") + "s", 50);
            _scoreNode.AddImageLabelCentered(155, 311, Accuracy.ToString("0") + "%", 50);
            if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularMonthly != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance)
            {
                _scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-month-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularWeekly != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance)
            {
                _scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-week-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance)
            {
                _scoreNode.AddImage(0, 490, "UI/victory-earth-level-personal-best-of-day-title-text.png", 3);
                _scoreNode.AddImageLabelCentered(155, 245, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52);
            }
            else
            {
                _scoreNode.AddImage(0, 490, "UI/victory-earth-level-non-record-title-text.png", 3);
                _scoreNode.AddImage(40, 247, "UI/victory-earth-level-not-ranked-text.png", 3);
            }
            //credits
            _creditsLabels = _scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);

            //--------- Prabhjot ----------//

            if (Player.Instance.IsProLevelSelected)
            {
                _btnContinue = _scoreNode.AddButton(700, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            }
            else
            {
                _btnContinue = _scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            }

            //btnContinue = scoreNode.AddButton(700, 90, "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--revenge-button-tapped.png");
            //btnContinue = scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            _btnContinue.Visible = false;
            _btnContinue.OnClick += BtnContinue_OnClick;

            _mainMenu = _scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            _mainMenu.OnClick += mainMenu_OnClick;


            if (_isWeHaveScores)
            {
                //day
                if (LeaderboardManager.PlayerRankRegularDaily != null)
                {
                    _scoreNode.AddImageLabelCentered(700, 432, LeaderboardManager.PlayerRankRegularDaily.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance ? null : _score > LeaderboardManager.PlayerRankRegularDaily.Score ? "red" : _score < LeaderboardManager.PlayerRankRegularDaily.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(700, 367, LeaderboardManager.PlayerRankRegularDaily.Time.ToString("0") + "s", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularDaily.Time ? "red" : Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularDaily.Time ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(700, 311, LeaderboardManager.PlayerRankRegularDaily.Accuracy.ToString("0") + "%", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularDaily.Accuracy ? "red" : Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularDaily.Accuracy ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(700, 245, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance ? null : "green");
                }
                //week
                if (LeaderboardManager.PlayerRankRegularWeekly != null)
                {
                    _scoreNode.AddImageLabelCentered(847, 432, LeaderboardManager.PlayerRankRegularWeekly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance ? null : _score > LeaderboardManager.PlayerRankRegularWeekly.Score ? "red" : _score < LeaderboardManager.PlayerRankRegularWeekly.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(847, 367, LeaderboardManager.PlayerRankRegularWeekly.Time.ToString("0") + "s", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularWeekly.Time ? "red" : Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularWeekly.Time ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(847, 311, LeaderboardManager.PlayerRankRegularWeekly.Accuracy.ToString("0") + "%", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularWeekly.Accuracy ? "red" : Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularWeekly.Accuracy ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(847, 245, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance ? null : "green");
                }
                //month
                if (LeaderboardManager.PlayerRankRegularMonthly != null)
                {
                    _scoreNode.AddImageLabelCentered(1011, 432, LeaderboardManager.PlayerRankRegularMonthly.Score.ToString(CultureInfo.InvariantCulture), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance ? null : _score > LeaderboardManager.PlayerRankRegularMonthly.Score ? "red" : _score < LeaderboardManager.PlayerRankRegularMonthly.Score ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(1011, 367, LeaderboardManager.PlayerRankRegularMonthly.Time.ToString("0") + "s", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Time) < LeaderboardManager.PlayerRankRegularMonthly.Time ? "red" : Convert.ToDouble(Time) > LeaderboardManager.PlayerRankRegularMonthly.Time ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(1011, 311, LeaderboardManager.PlayerRankRegularMonthly.Accuracy.ToString("0") + "%", 50, Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance ? null : Convert.ToDouble(Accuracy) > LeaderboardManager.PlayerRankRegularMonthly.Accuracy ? "red" : Convert.ToDouble(Accuracy) < LeaderboardManager.PlayerRankRegularMonthly.Accuracy ? "green" : "yellow");
                    _scoreNode.AddImageLabelCentered(1011, 245, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52, Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance ? null : "green");
                }

                _yes = _scoreNode.AddButton(834, 90, "UI/victory-yes-please-button-untapped.png", "UI/victory-yes-please-button-tapped.png");
                _yes.OnClick += yes_OnClick;

                _no = _scoreNode.AddButton(520, 90, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
                _no.OnClick += no_OnClick;

                _mainMenu.Visible = false;
                _btnContinue.Visible = false;

            }
            else
            {
                //no internet
                _shareYourScore.Visible = false;
                _btnContinue.Visible = true;
                _scoreNode.AddImage(633, 247, "UI/victory-no-internet-connection-text.png", 3);
                _scoreNode.AddImage(562, 300, "UI/Main-screen-off-line-notification.png", 3);
            }

            _scoreNode.Opacity = 0;
            foreach (var child in _scoreNode.Children)
            {
                child.Opacity = _scoreNode.Opacity;
            }

            AddChild(_scoreNode);

            GameEnvironment.PlaySoundEffect(SoundEffect.ShowScore);
            Schedule(FadeScore);
        }

        private void FadeScore(float dt)
        {
            _scoreNode.Opacity += 5;
            _justSavedTitle.Opacity -= 5;
            if (_scoreNode.Opacity > 250)
            {
                _scoreNode.Opacity = 255;
                _justSavedTitle.Opacity = 0;
                Unschedule(FadeScore);

            }
            foreach (var child in _scoreNode.Children)
            {
                child.Opacity = _scoreNode.Opacity;
            }
        }

        private async void BtnContinue_OnClick(object sender, EventArgs e)
        {
            await NextLevel();
        }

        //CCNodeExt shareNode;
        //CCSpriteTwoStateButton _shareScoreBoard;
        //CCSpriteButton _shareTwitter;
        //CCSpriteButton _shareFacebook;

        private async void mainMenu_OnClick(object sender, EventArgs e)
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            AdMobManager.HideBanner();
            CCAudioEngine.SharedEngine.StopAllEffects();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyle(newLayer);
        }

        //CCLayerColorExt sl;

        private CCNodeExt _sl;

        private void yes_OnClick(object sender, EventArgs e)
        {
            _sl = new CCNodeExt();

            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    //sl.SetBackground("UI/Victory scenes/Afganistan-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-afghanistan.png", 2);
                    break;
                case Battlegrounds.Denmark:
                    //sl.SetBackground("UI/Victory scenes/Denmark-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-denmark.png", 2);
                    break;
                case Battlegrounds.England:
                    //sl.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-england.png", 2);
                    break;
                case Battlegrounds.Estonia:
                    //sl.SetBackground("UI/Victory scenes/Estonia-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-estonia.png", 2);
                    break;
                case Battlegrounds.Finland:
                    //sl.SetBackground("UI/Victory scenes/Finland-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-finland.png", 2);
                    break;
                case Battlegrounds.France:
                    //sl.SetBackground("UI/Victory scenes/France-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-france.png", 2);
                    break;
                case Battlegrounds.Georgia:
                    //sl.SetBackground("UI/Victory scenes/Georgia-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-georgia.png", 2);
                    break;
                case Battlegrounds.GreatBritain:
                    //sl.SetBackground("UI/Victory scenes/England&Great-Britain-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-great-britain.png", 2);
                    break;
                case Battlegrounds.Iraq:
                    //sl.SetBackground("UI/Victory scenes/Iraq-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-iraq.png", 2);
                    break;
                case Battlegrounds.Israel:
                    //sl.SetBackground("UI/Victory scenes/Israel-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-israel.png", 2);
                    break;
                case Battlegrounds.Japan:
                    //sl.SetBackground("UI/Victory scenes/Japan-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-japan.png", 2);
                    break;
                case Battlegrounds.Libya:
                    //sl.SetBackground("UI/Victory scenes/Libya-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-libya.png", 2);
                    break;
                case Battlegrounds.Norway:
                    //sl.SetBackground("UI/Victory scenes/Norway-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-norway.png", 2);
                    break;
                case Battlegrounds.Poland:
                    //sl.SetBackground("UI/Victory scenes/Poland-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-poland.png", 2);
                    break;
                case Battlegrounds.Russia:
                    //sl.SetBackground("UI/Victory scenes/Russia-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-russia.png", 2);
                    break;
                case Battlegrounds.SouthKorea:
                    //sl.SetBackground("UI/Victory scenes/South-Korea-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-south-korea.png", 2);
                    break;
                case Battlegrounds.Syria:
                    //sl.SetBackground("UI/Victory scenes/Syria-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-syria.png", 2);
                    break;
                case Battlegrounds.Ukraine:
                    //sl.SetBackground("UI/Victory scenes/Ukraine-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-ukraine.png", 2);
                    break;
                case Battlegrounds.UnitedStates:
                    //sl.SetBackground("UI/Victory scenes/USA-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-united-states.png", 2);
                    break;
                case Battlegrounds.Vietnam:
                    //sl.SetBackground("UI/Victory scenes/Vietnam-victory-scene.jpg");
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-vietnam.png", 2);
                    break;

            }
            _sl.AddImageCentered(1136 / 2, 86, "UI/social-share-game-advertisement-background-and-text.png", 2);

            _sl.AddImageCentered(1136 / 2, 371, "UI/social-share-result-&_ranking-table.png", 2);

            _sl.AddImageLabel(420, 295, _score.ToString(), 52);

            if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularMonthly != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularMonthly.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageLabelCentered(995, 295, LeaderboardManager.PlayerRankRegularMonthly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageCentered(995, 295, "UI/number_52_NA.png", 2); //---------- Prabhjot ----------// 295
            }

            if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularWeekly != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageLabelCentered(837, 285, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageCentered(837, 285, "UI/number_52_NA.png", 2); //---------- Prabhjot ----------// 295
            }

            if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageLabelCentered(701, 295, LeaderboardManager.PlayerRankRegularDaily.Rank.ToString("0"), 52);
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


            Player.Instance.Credits += 5000;
            foreach (var spr in _creditsLabels)
            {
                _scoreNode.RemoveChild(spr);
            }
            _creditsLabels = _scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
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


        //private void shareScoreBoard_OnClick(object sender, EventArgs e)
        //{
        //    //SocialNetworkShareManager.ShareLayer("facebook", this);
        //    //shareScoreBoard.ChangeState();
        //    //shareScoreBoard.SetStateImages();
        //}

        //private void shareTwitter_OnClick(object sender, EventArgs e)
        //{
        //    SocialNetworkShareManager.ShareLayer("twitter", this);
        //}

        //private void shareFacebook_OnClick(object sender, EventArgs e)
        //{
        //    SocialNetworkShareManager.ShareLayer("facebook", this);
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
        //            //justSavedTitle.Opacity += 20;
        //            if (scoreNode.Opacity >= 235)
        //            {
        //                scoreNode.Opacity = 255;
        //                //justSavedTitle.Opacity = 255;
        //                this.UnscheduleAll();
        //            }
        //            foreach (CCNode child in scoreNode.Children) { child.Opacity = scoreNode.Opacity; };
        //        }
        //    });

        //}


        //private void shareBtn_OnClick(object sender, EventArgs e)
        //{
        //    nextLevel();
        //}


        private void no_OnClick(object sender, EventArgs e)
        {
            _shareYourScore.Visible = false;
            _yes.Visible = false;
            _no.Visible = false;
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
        }

        private async Task NextLevel()
        {
            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();

            if (_nextBattleGround == Battlegrounds.Moon)
            {
                AdMobManager.HideBanner();

                var newLayer = new EnemyPickerLayer();
                await TransitionToLayerCartoonStyle(newLayer);
            }
            else
            {
                var newLayer = new GamePlayLayer(
                    _nextEnemy,
                    SelectedWeapon,
                    _nextBattleGround,
                    true, -1, -1, -1, -1,
                    _nextEnemy,
                    LaunchMode.Default,
                    LivesLeft,
                    WinsInSuccession);
                await TransitionToLayerCartoonStyle(newLayer);
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Console.WriteLine("LAYER ONENTER");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Extensions;
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
        private readonly float _delayOnRepeatMS;
        private readonly TimeSpan _animationMaxTime = TimeSpan.FromSeconds(14); //for loading view

        private bool _isWeHaveScores;
        private bool _isDoneWaitingForScores;

        private readonly CCSprite _defeated;
        private readonly CCSprite _justSavedTitle;
        private readonly CCSprite _cartoonBackground;

        private CCSpriteButton _okIGotIt;
        private CCSpriteButton _btnContinue;
        private CCSpriteButton _mainMenu;
        private CCSpriteButton _yes;
        private CCSpriteButton _no;
        private CCSpriteButton _showAd;
        private CCSprite _loadingViewPlaceholder;
        private CCSprite _shareYourScore;
        private CCSprite _multiplierArrow;
        private CCSprite[] _scoreBefore;
        private (int Count, List<string> Images) _loadingView = (0, new List<string>());

        private CCNodeExt _multiplierNode;

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

            _delayOnRepeatMS = 500f;
            _nextEnemy = selectedEnemy;

            Player.Instance.WinCount += 1;
            
            if (Player.Instance.WinCount == 3)
                Player.Instance.IsChangeNamePopupShown = false;

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

            for (var i = 0; i < 32; ++i)
            {
                _loadingView.Images.Add($"UI/Leaderboard/Conneting-to-leaderboard-1{i.ToString("D" + 2)}.png");
            }
            _loadingView.Count = _loadingView.Images.Count;
            _loadingViewPlaceholder = new CCSprite();

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
            _justSavedTitle = _justSavedTitle ?? new CCSprite();
            _justSavedTitle.Visible = false;
            _multiplierNode = new CCNodeExt
            {
                Visible = false
            };
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            AdManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;

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

            //Background = Background ?? new CCSprite();
            //Background.Opacity = 120;

            if (!saved)
            {
                if (WinsInSuccession >= 2 && NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        ScheduleOnce(ShowMultiplierAd, 3.8f);
                    }
                    else
                    {
                        ScheduleOnce(ShowMultiplierAd, 2);
                    }
                }
                else
                {
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("1"); } }, 2.3f);
                    }
                    else
                    {
                        ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("2"); } }, 1.0f);
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
            _cartoonBackground = AddImage(0, 0, "UI/screen-transition_stage_6.png");

            AdManager.ShowBannerBottom();
            GameEnvironment.PlayMusic(Music.Victory);

            if (Settings.Instance.VoiceoversEnabled)
            {
                ScheduleOnce((_) => CCAudioEngine.SharedEngine.PlayEffect("Sounds/You just saved VO_mono.wav"), 0f);
                ScheduleOnce(CalloutCountryNameVo, 1.5f);
            }

            Settings.Instance.LastOfflineRegularScore = _score;
            Settings.Instance.LastOfflineTime = Convert.ToDouble(Time);
            Settings.Instance.LastOfflineAccuracy = Convert.ToDouble(Accuracy);

            ScheduleOnce(async (_) =>
            {
                _isWeHaveScores = await LeaderboardManager.SubmitScoreRegularAsync(_score, Convert.ToDouble(Accuracy), Convert.ToDouble(Time));
                _isDoneWaitingForScores = true;
            }, 0f);
            Schedule(AnimateLoadingView, 0.066f); //reached experimentally
        }

        public override async Task ContinueInitializeAsync()
        {
            await Task.Delay(15); //some small delay
            await base.ContinueInitializeAsync();
        }

        private void Caught(string message)
        {
            var s = message;
            Debug.WriteLine($"WARNING: got exception {nameof(Caught)} with {s}");
        }

        private void AnimateLoadingView(float obj)
        {
            LoopAnimateWithCCSprites(_loadingView.Images,
                200, 230,
                ref _loadingView.Count,
                ref _loadingViewPlaceholder,
                () => !_isDoneWaitingForScores &&
                     !_multiplierNode.Visible &&
                     !(_btnContinue?.Visible).GetValueOrDefault() &&
                     !(_shareYourScore?.Visible).GetValueOrDefault(),
                async (_) =>
                {
                    if (_cartoonBackground == null) { return; }
                    if (!_cartoonBackground.Visible) { Unschedule(AnimateLoadingView); return; }

                    Unschedule(AnimateLoadingView);
                    await AnimateFadeInAsync(() =>
                    {
                        _justSavedTitle.Visible = true;
                        _cartoonBackground.Visible = false;
                        RemoveChild(_cartoonBackground);
                    });
                }, _animationMaxTime);
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

        private async void ShowMultiplierAd(float dt)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            if (_multiplierNode != null)
            {
                _multiplierNode.Opacity = 0;
                _multiplierNode.Visible = true;
                _multiplierNode.AddImageCentered(1136 / 2, 630 / 2, "UI/victory-multiply-notification-background.png", 3);
                _multiplierNode.AddImageLabelCentered(465, 415, WinsInSuccession.ToString(), 57);
                _multiplierNode.AddImageLabelCentered(433, 338, WinsInSuccession + "X", 57);
                _scoreBefore = _multiplierNode.AddImageLabel(40, 270, _score.ToString(), 57);
                _multiplierArrow = _multiplierNode.AddImage(Convert.ToInt32(_scoreBefore[_scoreBefore.Length - 1].PositionX + 60), 272, "UI/victory-multiply-arrow.png", 4);
                _multiplierNode.AddImageLabel(Convert.ToInt32(_scoreBefore[_scoreBefore.Length - 1].PositionX + 200), 270, (_score * WinsInSuccession).ToString(), 57);
                _multiplierNode.AddButton(1050, 540, "UI/victory-multiply-notification-cancel-button-untapped.png", "UI/victory-multiply-notification-cancel-button-tapped.png", 4).OnClick += ShowMultiplierAdCancel_Onclick;
                _showAd = _multiplierNode.AddButton(40, 77, "UI/victory-multiply-notification-watch-button-untapped.png", "UI/victory-multiply-notification-watch-button-tapped.png", 4);
                _showAd.OnClick += ShowMultiplierAd_Onclick;
                AddChild(_multiplierNode, 1000);

                await Task.Delay(330);
                Schedule(AnimateArrow, 0.03f);

                _multiplierNode.Opacity = 255;
            }
        }

        private void AnimateArrow(float dt)
        {
            _multiplierArrow.ScaleX += 0.012f;
            if (_multiplierArrow.ScaleX > 1.23)
            {
                _multiplierArrow.ScaleX = 0.85f;
            }
        }

        private void ShowMultiplierAd_Onclick(object sender, EventArgs e)
        {
            _showAd.Enabled = false;
            AdManager.HideBanner();
            AdManager.ShowInterstitial();
        }

        private void ShowMultiplierAdCancel_Onclick(object sender, EventArgs e)
        {
            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);
            UnscheduleAllExcept((AnimateLoadingView, 0.06f));
            ScheduleOnce((_) => _cartoonBackground.Visible = false, 0f);
            ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("3"); } }, 0.2f);
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e) { }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {
            Player.Instance.Credits += _score * WinsInSuccession - _score;
            GameEnvironment.PlaySoundEffect(SoundEffect.RewardNotification);
            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);
            UnscheduleAllExcept((AnimateLoadingView, 0.06f));

            AdManager.ShowBannerBottom();
            ScheduleOnce((_) => _cartoonBackground.Visible = false, 0f);
            ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("4"); } }, 0.5f);
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
            AdManager.ShowBannerBottom();

            _multiplierNode.RemoveAllChildren();
            RemoveChild(_multiplierNode);

            UnscheduleAllExcept((AnimateLoadingView, 0.06f));
            ScheduleOnce((_) => _cartoonBackground.Visible = false, 0f);
            ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("5"); } }, 0.2f);
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
            _okIGotIt.OnClick += OkIGotIt_OnClick;
        }

        private void OkIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_okIGotIt);
            RemoveChild(_defeated);
            if (WinsInSuccession > 1 && NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                ScheduleOnce(ShowMultiplierAd, 0.2f);
            }
            else
            {
                ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("6"); } }, 0.2f);
            }
        }

        #region ShowRecordNotification

        private CCSprite _recordNotification;
        private CCSprite _recordNotificationImage;
        private CCSpriteButton _recordOkIGotIt;
        private bool _recordNotificationShown;

        private void ShowRecordNotification()
        {
            if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularMonthly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 1)
            {
                Player.Instance.Credits += 45000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularMonthly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 2)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularMonthly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularMonthly.Rank == 3)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-month-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularWeekly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 1)
            {
                Player.Instance.Credits += 30000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularWeekly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 2)
            {
                Player.Instance.Credits += 20000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularWeekly?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularWeekly.Rank == 3)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-week-3rd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularDaily?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 1)
            {
                Player.Instance.Credits += 15000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-1st-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularDaily?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 2)
            {
                Player.Instance.Credits += 10000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-2nd-background-with-text.png", 3);
            }
            else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularDaily?.Score).Val()) < AppConstants.Tolerance && LeaderboardManager.PlayerRankRegularDaily.Rank == 3)
            {
                Player.Instance.Credits += 5000;
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-global-top-score-notification-day-3rd-background-with-text.png", 3);
            }
            else
            {
                _recordNotification = AddImageCentered(1136 / 2, 630 / 2 + 25, "UI/victory-notification-background-with-text.png", 3);
                if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularAlltime?.Score).Val()) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-all-time.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularMonthly?.Score).Val()) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-month.png", 4);
                }
                else if (_isWeHaveScores && Math.Abs(_score - (LeaderboardManager.PlayerRankRegularWeekly?.Score).Val()) < AppConstants.Tolerance)
                {
                    _recordNotificationImage = AddImage(35, 367, "UI/victory-notification-personal-best-of-week.png", 4);
                }
                else
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
            _recordOkIGotIt.OnClick += RecordOkIGotIt_OnClick;
            _recordNotificationShown = true;
        }

        private void CalloutCongratulations(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Congratulations VO_mono.wav");
        }

        private void RecordOkIGotIt_OnClick(object sender, EventArgs e)
        {
            RemoveChild(_recordOkIGotIt);
            RemoveChild(_recordNotification);
            if (_recordNotificationImage != null)
            {
                RemoveChild(_recordNotificationImage);
            }
            ScheduleOnce((obj) => { try { ShowScore(); } catch { Caught("7"); } }, 0f);
        }
        #endregion

        #region ShowScore

        private int _waitForScoreCounter;
        private CCNodeExt _scoreNode;

        private CCSprite[] _creditsLabels;

        private async void ShowScore()
        {
            await WaitScoreBoardServiceResponseWhile(() => !_isDoneWaitingForScores, (() => _waitForScoreCounter, (val) => _waitForScoreCounter = val), _delayOnRepeatMS);
            _scoreNode = new CCNodeExt
            {
                Opacity = 0
            };
            ScheduleOnce(ShowScoreScheduled, 0.5f);
        }

        private void ShowScoreScheduled(float obj)
        {
            try
            {
                if (_isWeHaveScores
                    && (Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularAlltimeField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularMonthlyField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularWeeklyField(Score)) < AppConstants.Tolerance
                        || Math.Abs(_score - (double)LeaderboardManager.GetPlayerRankRegularDailyField(Score)) < AppConstants.Tolerance)
                    && !_recordNotificationShown)
                {
                    ScheduleOnce((_) => { try { ShowRecordNotification(); } catch { Caught("9"); } }, 0.5f);
                    return;
                }
                _scoreNode.Opacity = 255;
                _scoreNode.AddImage(0, 225, "UI/victory-earth-level-scoreboard-background-bars.png", 2);
                _scoreNode.AddImage(245, 225, "UI/victory-earth-level-scoreboard-title-text.png", 3);
                _scoreNode.AddImage(0, 162, "UI/victory-available-credits-text.png", 3);
                _shareYourScore = _scoreNode.AddImage(0, 80, "UI/victory-earth-level-share-your-score-text.png", 3);
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Caught($" {nameof(ShowScore)} - first try!");
            }
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

            _btnContinue = _scoreNode.AddButton(700, 90, "UI/score-comparison-score-board-lets-continue-button-untapped.png", "UI/score-comparison-score-board-lets-continue-button-tapped.png");
            _btnContinue.Visible = false;
            _btnContinue.OnClick += BtnContinue_OnClick;

            _mainMenu = _scoreNode.AddButton(10, 90, "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-untapped.png", "UI/Loss scenes/You-are-dead-no-track-record--main-menu-button-tapped.png");
            _mainMenu.OnClick += MainMenu_OnClick;

            if (!_isWeHaveScores
                || (LeaderboardManager.PlayerRankRegularDaily == null && LeaderboardManager.PlayerRankRegularWeekly == null && LeaderboardManager.PlayerRankRegularMonthly == null))
            {
                //no or weak internet
                _shareYourScore.Visible = false;
                _btnContinue.ChangeVisibility(true);

                if (!NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    _scoreNode.AddImage(633, 247, "UI/victory-no-internet-connection-text.png", 3);
                    _scoreNode.AddImage(562, 300, "UI/Main-screen-off-line-notification.png", 3);
                }
                else
                {
                    _scoreNode.AddImage(562, 300, "UI/My-stats-&-rewards-slow-internet-connection-notification.png", 3);
                }
            }
            else
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
                _yes.OnClick -= yes_OnClick_Handler;
                _yes.OnClick += yes_OnClick_Handler;

                _no = _scoreNode.AddButton(520, 90, "UI/victory-no-thanks-button-untapped.png", "UI/victory-no-thanks-button-tapped.png");
                _no.OnClick -= no_OnClick_Handler;
                _no.OnClick += no_OnClick_Handler;

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
            Schedule(FadeScore);

            void yes_OnClick_Handler(object sender, EventArgs ea)
            {
                ScheduleOnce(Yes_OnClick, 0f);
            }

            void no_OnClick_Handler(object sender, EventArgs ea)
            {
                ScheduleOnce(No_OnClick, 0f);
            }
        }

        private void FadeScore(float dt)
        {
            _scoreNode.Opacity += 5;
            _justSavedTitle.Opacity -= 5;
            if (_scoreNode.Opacity > 250)
            {
                _scoreNode.Opacity = 255;
                _justSavedTitle.Opacity = 0;
                _justSavedTitle.Visible = false;

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

        private async void MainMenu_OnClick(object sender, EventArgs e)
        {
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            AdManager.HideBanner();
            CCAudioEngine.SharedEngine.StopAllEffects();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }
        #endregion

        #region YesNo_OnClick

        private CCNodeExt _sl;

        private async void Yes_OnClick(float obj)
        {
            _yes.ChangeVisibility(false);
            _no.ChangeVisibility(false);

            _sl = new CCNodeExt();

            switch (SelectedBattleground)
            {
                case Battlegrounds.Afghanistan:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-afghanistan.png", 2);
                    break;
                case Battlegrounds.Denmark:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-denmark.png", 2);
                    break;
                case Battlegrounds.England:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-england.png", 2);
                    break;
                case Battlegrounds.Estonia:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-estonia.png", 2);
                    break;
                case Battlegrounds.Finland:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-finland.png", 2);
                    break;
                case Battlegrounds.France:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-france.png", 2);
                    break;
                case Battlegrounds.Georgia:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-georgia.png", 2);
                    break;
                case Battlegrounds.GreatBritain:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-great-britain.png", 2);
                    break;
                case Battlegrounds.Iraq:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-iraq.png", 2);
                    break;
                case Battlegrounds.Israel:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-israel.png", 2);
                    break;
                case Battlegrounds.Japan:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-japan.png", 2);
                    break;
                case Battlegrounds.Libya:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-libya.png", 2);
                    break;
                case Battlegrounds.Norway:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-norway.png", 2);
                    break;
                case Battlegrounds.Poland:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Hitler defeaded/victory-i-just-saved-poland.png", 2);
                    break;
                case Battlegrounds.Russia:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/George defeaded/victory-i-just-saved-russia.png", 2);
                    break;
                case Battlegrounds.SouthKorea:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-south-korea.png", 2);
                    break;
                case Battlegrounds.Syria:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-syria.png", 2);
                    break;
                case Battlegrounds.Ukraine:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Putin defeaded/victory-i-just-saved-ukraine.png", 2);
                    break;
                case Battlegrounds.UnitedStates:
                    _sl.AddImageCentered(1136 / 2, 598, "UI/Kim defeaded/victory-i-just-saved-united-states.png", 2);
                    break;
                case Battlegrounds.Vietnam:
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
                _sl.AddImageCentered(995, 320, "UI/number_52_NA.png", 3); //---------- Prabhjot ----------// 295
            }

            if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularWeekly != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularWeekly.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageLabelCentered(837, 295, LeaderboardManager.PlayerRankRegularWeekly.Rank.ToString("0"), 52);
            }
            else if (_isWeHaveScores && LeaderboardManager.PlayerRankRegularDaily != null && Math.Abs(_score - LeaderboardManager.PlayerRankRegularDaily.Score) < AppConstants.Tolerance)
            {
                _sl.AddImageCentered(837, 320, "UI/number_52_NA.png", 3); //---------- Prabhjot ----------// 295
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

            SocialNetworkShareManager.ShareLayer("facebook", this);

            _scoreNode.Visible = true;
            RemoveChild(_sl);

            Player.Instance.Credits += 5000;
            foreach (var spr in _creditsLabels)
            {
                _scoreNode.RemoveChild(spr);
            }
            _creditsLabels = _scoreNode.AddImageLabel(450, 170, Player.Instance.Credits.ToString(), 57);

            var shadow = AddImage(0, 0, "UI/screen-shadow.png", 9999);
            _btnContinue.Visible = true;
            _btnContinue.DisableClick();
            _mainMenu.Visible = true;
            _mainMenu.DisableClick();

            ScheduleOnce((_) =>
            {
                RemoveChild(shadow);
                _btnContinue.EnableClick();
                _mainMenu.EnableClick();
            }, 1.0f);
        }

        private void No_OnClick(float obj)
        {
            _shareYourScore.Visible = false;
            _yes.Visible = false;
            _no.Visible = false;
            _btnContinue.Visible = true;
            _mainMenu.Visible = true;
        }

        private async Task NextLevel()
        {
            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            CCAudioEngine.SharedEngine.StopAllEffects();

            if (_nextBattleGround == Battlegrounds.Moon)
            {
                AdManager.HideBanner();

                var newLayer = new EnemyPickerLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
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
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
        }
        #endregion

        public override void OnEnter()
        {
            base.OnEnter();

            Console.WriteLine("LAYER ONENTER");
        }
    }
}

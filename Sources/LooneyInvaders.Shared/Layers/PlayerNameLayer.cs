using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;

namespace LooneyInvaders.Layers
{
    public class PlayerNameLayer : CCLayerColorExt
    {
        private CCSpriteButton _btnForward;

        private bool isButtonDisable;
        private string _strInput;
        private string StrInput
        {
            get => _strInput;
            set
            {
                _strInput = value;

                if (_strInput.Length >= 3)
                {
                    if(isButtonDisable & char.IsLetter(_strInput[0]))
                        EnableButtonsOnLayer(_btnForward);
                }
                else
                {
                    isButtonDisable = true;
                    DisableButtonsOnLayer(_btnForward);
                }
            }
        }

        private readonly CCLabel _lblInputLabel;
        private readonly CCLabel _lblInput;
        private readonly CCLabel _lblCursor;

        private readonly List<CCSpriteButton> _caps;
        private readonly List<CCSpriteButton> _small;

        private readonly CCSpriteTwoStateButton _btnShift;

        private readonly SettingsScreenLayer _layerBack;


        public PlayerNameLayer(SettingsScreenLayer layerBack = null)
        {
            _layerBack = layerBack;
            SetBackground("UI/background.jpg");

            //this.AddImage(292, 565, "UI/about-the-game-title-text.png", 500);

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = ButtonType.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = AddButton(1136 - 245, 578, "Keyboard/Keyboard_save_name_button_untapped.png", "Keyboard/Keyboard_save_name_button_tapped.png");
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = ButtonType.Silent;
            

            StrInput = Player.Instance.Name;

            _lblInputLabel = AddLabelCentered(1136 / 2, 550, "Please enter player name below", "Fonts/AktivGroteskBold", 14);

            _lblInput = AddLabelCentered(1136 / 2, 500, StrInput, "Fonts/AktivGroteskBold", 16);
            _lblInput.Scale = 2;
            _lblInput.ZOrder = 1000;

            //create cursor
            _lblCursor = new CCLabel("I", "Fonts/AktivGroteskBold", 16, CCLabelFormat.SpriteFont);
            _lblCursor.Scale = 2;
            _lblCursor.Position = new CCPoint(_lblInput.BoundingBox.MaxX, 500);
            AddChild(_lblCursor);
            Schedule(BlinkCursor, 0.03f);

            const int spX = 80;
            const int keyboardY = 360;
            //int padY = 48;
            //int padX = 45;

            _caps = new List<CCSpriteButton>();
            _small = new List<CCSpriteButton>();

            var slova = "1234567890-";
            for (var i = 0; i < slova.Length; i++)
            {
                CCSpriteButton btnSlovo;
                if (slova[i] == '-')
                {
                    btnSlovo = AddButton(1136 / 2 + (i - 6) * spX, keyboardY, "Keyboard/Keyboard_del_untapped.png", "Keyboard/Keyboard_del_tapped.png");
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.OnClick += btnBackSpace_OnClick;
                }
                else
                {
                    btnSlovo = AddButton(1136 / 2 + (i - 6) * spX, keyboardY, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + (i - 6) * spX + padX, keyboardY + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                    //lblSlovo.Color = new CCColor3B(0, 0, 0);
                    //lblSlovo.Scale = 2;
                    //lblSlovo.ZOrder = 1001;
                }
            }
            slova = "QWERTYUIOP@";
            for (var i = 0; i < slova.Length; i++)
            {
                if (slova[i] != '@')
                {
                    var btnSlovo = AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.Visible = false;
                    _caps.Add(btnSlovo);

                    btnSlovo = AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    _small.Add(btnSlovo);
                }
                else
                {
                    var btnSlovo = AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                }
                //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + spX / 2 + (i - 6) * spX + padX, keyboardY - spX + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                //lblSlovo.Color = new CCColor3B(0, 0, 0);
                //lblSlovo.Scale = 2;
                //lblSlovo.ZOrder = 1001;
            }
            slova = "ASDFGHJKL:";
            for (var i = 0; i < slova.Length; i++)
            {
                if (slova[i] != ':')
                {
                    var btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - spX * 2, "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Visible = false;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    _caps.Add(btnSlovo);

                    btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - spX * 2, "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    _small.Add(btnSlovo);
                }
                else
                {
                    var btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - spX * 2, "Keyboard/Keyboard_double_dot_untapped.png", "Keyboard/Keyboard_double_dot_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                }
                //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + spX + (i - 6) * spX + padX, keyboardY - (spX * 2) + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                //lblSlovo.Color = new CCColor3B(0, 0, 0);
                //lblSlovo.Scale = 2;
                //lblSlovo.ZOrder = 1001;
            }
            slova = "ZXCVBNM.-";
            for (var i = 0; i < slova.Length; i++)
            {
                if (slova[i] != '.' && slova[i] != '-')
                 {
                    var btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - spX * 3, "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.Visible = false;
                    _caps.Add(btnSlovo);

                    btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - spX * 3, "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    _small.Add(btnSlovo);
                }
                else
                {
                    var btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - spX * 3, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                }
                //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + spX * 3 / 2 + (i - 6) * spX + padX, keyboardY - (spX * 3) + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                //lblSlovo.Color = new CCColor3B(0, 0, 0);
                //lblSlovo.Scale = 2;
                //lblSlovo.ZOrder = 1001;
            }

            var btnRazmak = AddButton(1136 / 2 - 220, keyboardY - spX * 4, "Keyboard/Keyboard_spacebar_untapped.png", "Keyboard/Keyboard_spacebar_untapped.png");
            btnRazmak.OnClick += btnSlovo_OnClick;
            btnRazmak.Slovo = ' ';
            btnRazmak.ZOrder = 1000;

            _btnShift = AddTwoStateButton(1136 / 2 - 6 * spX, keyboardY - spX * 3, "Keyboard/Keyboard_shift_single_letter_untapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_untapped.png");
            _btnShift.ButtonType = ButtonType.OnOff;
            _btnShift.OnClick += btnShift_OnClick;
        }

        private void btnShift_OnClick(object sender, EventArgs e)
        {
            _btnShift.ChangeState();
            _btnShift.SetStateImages();
            if (_btnShift.State == 1)
            {
                foreach (var btnSlovo in _caps)
                {
                    btnSlovo.Visible = false;
                }
                foreach (var btnSlovo in _small)
                {
                    btnSlovo.Visible = true;
                }
            }
            else
            {
                foreach (var btnSlovo in _caps)
                {
                    btnSlovo.Visible = true;
                }
                foreach (var btnSlovo in _small)
                {
                    btnSlovo.Visible = false;
                }
            }
        }

        private double _tick;

        private void BlinkCursor(float dt)
        {
            _tick++;

            _lblCursor.Position = StrInput.Length > 0
                ? new CCPoint(_lblInput.BoundingBoxTransformedToWorld.MaxX + 5, 500)
                : new CCPoint(568, 500);

            if (Math.Abs(_tick % 20) < AppConstants.Tolerance)
            {
                _lblCursor.Visible = !_lblCursor.Visible;
            }
        }

        private void btnSlovo_OnClick(object sender, EventArgs e)
        {
            if (StrInput.Length < 15)
            {
                StrInput += ((CCSpriteButton)sender).Slovo;
                _lblInput.Text = StrInput;
                if (StrInput.Length == 1 && _btnShift.State != 1)
                {
                    btnShift_OnClick(sender, e);
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
            }
        }

        private void btnBackSpace_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StrInput))
            {
                StrInput = StrInput.Substring(0, StrInput.Length - 1);
                _lblInput.Text = StrInput;
                if (StrInput.Length == 0 && _btnShift.State == 1)
                {
                    btnShift_OnClick(sender, e);
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
            }
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_layerBack != null)
            {
                Shared.GameDelegate.OnBackButton -= BtnBack_OnClick;
                _layerBack.IsCartoonFadeIn = false;
                Director.PopScene();
            }
            else
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                var newLayer = new MainScreenLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
        }

        private async void BtnForward_OnClick(object sender, EventArgs e)
        {
            var inputName = StrInput;
            if (string.IsNullOrWhiteSpace(inputName))
            {
                _lblInputLabel.Text = "Player name must be more than 3 symbols and start with letter"; // from to with
                return;
            }
            inputName = inputName.Trim();

            if (inputName.Length < 3 || inputName.Length > 0 && !char.IsLetter(inputName[0]))
            {
                _lblInputLabel.Text = "Player name must be more than 3 symbols and start with letter"; // from to with
                return;
            }

            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                if(_btnForward.ButtonType != ButtonType.CannotTap)
                    GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                
                _lblInputLabel.Text = "You have to be connected to internet to change your player name";
                return;
            }

            if (!UserManager.CheckIsUsernameFree(inputName))
            {
                if(_btnForward.ButtonType != ButtonType.CannotTap)
                    GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                
                _lblInputLabel.Text = "Player name already taken, please try another one";
                return;
            }

            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapForward);
            UserManager.ChangeUsername(inputName);
            _lblInputLabel.Text = "Player name changed";
            Player.Instance.IsNameChanged = true;

            LeaderboardManager.BestScoreProScore = 0;
            LeaderboardManager.BestScoreProLevelsCompleted = 0;
            LeaderboardManager.BestScoreProSubmitted = true;

            LeaderboardManager.BestScoreRegularScore = 0;
            LeaderboardManager.BestScoreRegularAccuracy = 0;
            LeaderboardManager.BestScoreRegularFastestTime = 0;
            LeaderboardManager.BestScoreRegularSubmitted = true;

            if (_layerBack != null)
            {
                _layerBack.IsCartoonFadeIn = false;
                Director.PopScene();
                _layerBack.RefreshPlayerName();
            }
            else
            {
                var newLayer = new MainScreenLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class PlayerNameLayer : CCLayerColorExt
    {
        CCSpriteButton _btnForward;
        //CCSprite _imgPage;
        //CCSprite _imgPageNumber;

        //int _activePage = 1;

        string _strInput;
        readonly CCLabel _lblInputLabel;
        readonly CCLabel _lblInput;
        readonly CCLabel _lblCursor;

        readonly List<CCSpriteButton> _caps;
        readonly List<CCSpriteButton> _small;

        readonly CCSpriteTwoStateButton _btnShift;

        readonly SettingsScreenLayer _layerBack;


        public PlayerNameLayer(SettingsScreenLayer layerBack = null)
        {
            _layerBack = layerBack;
            SetBackground("UI/background.jpg");

            //this.AddImage(292, 565, "UI/about-the-game-title-text.png", 500);

            CCSpriteButton btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = AddButton(1136 - 245, 578, "Keyboard/Keyboard_save_name_button_untapped.png", "Keyboard/Keyboard_save_name_button_tapped.png");
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Silent;

            _strInput = Player.Instance.Name;

            _lblInputLabel = AddLabelCentered(1136 / 2, 550, "Please enter player name below", "Fonts/AktivGroteskBold", 14);

            _lblInput = AddLabelCentered(1136 / 2, 500, _strInput, "Fonts/AktivGroteskBold", 16);
            _lblInput.Scale = 2;
            _lblInput.ZOrder = 1000;

            //create cursor
            _lblCursor = new CCLabel("I", "Fonts/AktivGroteskBold", 16, CCLabelFormat.SpriteFont);
            _lblCursor.Scale = 2;
            _lblCursor.Position = new CCPoint(_lblInput.BoundingBox.MaxX, 500);
            AddChild(_lblCursor);
            Schedule(BlinkCursor, 0.03f);

            string slova;

            int spX = 80;
            int keyboardY = 360;
            //int padY = 48;
            //int padX = 45;

            _caps = new List<CCSpriteButton>();
            _small = new List<CCSpriteButton>();

            slova = "1234567890-";
            for (int i = 0; i < slova.Length; i++)
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
            for (int i = 0; i < slova.Length; i++)
            {
                if (slova[i] != '@')
                {
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
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
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png");
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
            for (int i = 0; i < slova.Length; i++)
            {
                if (slova[i] != ':')
                {
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Visible = false;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    _caps.Add(btnSlovo);

                    btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    _small.Add(btnSlovo);
                }
                else
                {
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Keyboard_double_dot_untapped.png", "Keyboard/Keyboard_double_dot_tapped.png");
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
            for (int i = 0; i < slova.Length; i++)
            {
                if (slova[i] != '.' && slova[i] != '-')
                {
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.Visible = false;
                    _caps.Add(btnSlovo);

                    btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    _small.Add(btnSlovo);
                }
                else
                {
                    CCSpriteButton btnSlovo = AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png");
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                }
                //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + spX * 3 / 2 + (i - 6) * spX + padX, keyboardY - (spX * 3) + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                //lblSlovo.Color = new CCColor3B(0, 0, 0);
                //lblSlovo.Scale = 2;
                //lblSlovo.ZOrder = 1001;
            }

            CCSpriteButton btnRazmak = AddButton(1136 / 2 - 220, keyboardY - (spX * 4), "Keyboard/Keyboard_spacebar_untapped.png", "Keyboard/Keyboard_spacebar_untapped.png");
            btnRazmak.OnClick += btnSlovo_OnClick;
            btnRazmak.Slovo = ' ';
            btnRazmak.ZOrder = 1000;

            _btnShift = AddTwoStateButton(1136 / 2 - 6 * spX, keyboardY - (spX * 3), "Keyboard/Keyboard_shift_single_letter_untapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_untapped.png");
            _btnShift.ButtonType = BUTTON_TYPE.OnOff;
            _btnShift.OnClick += btnShift_OnClick;
        }

        private void btnShift_OnClick(object sender, EventArgs e)
        {
            _btnShift.ChangeState();
            _btnShift.SetStateImages();
            if (_btnShift.State == 1)
            {
                foreach (CCSpriteButton btnSlovo in _caps)
                {
                    btnSlovo.Visible = false;
                }
                foreach (CCSpriteButton btnSlovo in _small)
                {
                    btnSlovo.Visible = true;
                }
            }
            else
            {
                foreach (CCSpriteButton btnSlovo in _caps)
                {
                    btnSlovo.Visible = true;
                }
                foreach (CCSpriteButton btnSlovo in _small)
                {
                    btnSlovo.Visible = false;
                }
            }
        }

        double _tick;
        void BlinkCursor(float dt)
        {
            _tick++;

            _lblCursor.Position = _strInput.Length > 0
                ? new CCPoint(_lblInput.BoundingBoxTransformedToWorld.MaxX + 5, 500)
                : new CCPoint(568, 500);

            if (Math.Abs(_tick % 20) < AppConstants.TOLERANCE)
            {
                _lblCursor.Visible = !_lblCursor.Visible;
            }
        }

        private void btnSlovo_OnClick(object sender, EventArgs e)
        {
            if (_strInput.Length < 15)
            {
                _strInput = _strInput + ((CCSpriteButton)sender).Slovo;
                _lblInput.Text = _strInput;
                if (_strInput.Length == 1 && _btnShift.State != 1)
                {
                    btnShift_OnClick(sender, e);
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void btnBackSpace_OnClick(object sender, EventArgs e)
        {
            if (_strInput.Length > 0)
            {
                _strInput = _strInput.Substring(0, _strInput.Length - 1);
                _lblInput.Text = _strInput;
                if (_strInput.Length == 0 && _btnShift.State == 1)
                {
                    btnShift_OnClick(sender, e);
                }
            }
            else
            {
                _btnForward = AddButton(1136 - 245, 578, "Keyboard/Keyboard_save_name_button_tapped.png", "Keyboard/Keyboard_save_name_button_tapped.png");
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_layerBack != null)
            {
                Shared.GameDelegate.OnBackButton -= BtnBack_OnClick;
                _layerBack.IsCartoonFadeIn = false;
                Director.PopScene();
                //this.TransitionToPoppedLayerCartoonStyle();
            }
            else
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_strInput))
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                _lblInputLabel.Text = "Player name must be more than 3 symbols and start with letter"; // from to with
                //lblInputLabel.Text = "Please enter player name below";
                return;
            }

            if (_strInput.Length < 3 || (_strInput.Length > 0 && !char.IsLetter(_strInput[0])))
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                _lblInputLabel.Text = "Player name must be more than 3 symbols and start with letter"; // from to with
                return;
            }

            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                _lblInputLabel.Text = "You have to be connected to internet to change your player name";
                return;
            }

            if (!UserManager.CheckIsUsernameFree(_strInput))
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                _lblInputLabel.Text = "Player name already taken, please try another one";
                return;
            }

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_FORWARD);
            UserManager.ChangeUsername(_strInput);
            _lblInputLabel.Text = "Player name changed";

            LeaderboardManager.BestScorePro_Score = 0;
            LeaderboardManager.BestScorePro_LevelsCompleted = 0;
            LeaderboardManager.BestScorePro_Submitted = true;

            LeaderboardManager.BestScoreRegular_Score = 0;
            LeaderboardManager.BestScoreRegular_Accuracy = 0;
            LeaderboardManager.BestScoreRegular_FastestTime = 0;
            LeaderboardManager.BestScoreRegular_Submitted = true;

            if (_layerBack != null)
            {
                _layerBack.IsCartoonFadeIn = false;
                Director.PopScene();
                //this.TransitionToPoppedLayerCartoonStyle();
                _layerBack.RefreshPlayerName();
            }
            else
            {
                TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
        }
    }
}
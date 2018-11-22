using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class PlayerNameLayer : CCLayerColorExt
    {
        CCSpriteButton _btnForward;
        CCSprite _imgPage;
        CCSprite _imgPageNumber;

        int _activePage = 1;

        string strInput;
        CCLabel lblInputLabel;
        CCLabel lblInput;

        List<CCSpriteButton> caps;
        List<CCSpriteButton> small;

        CCSpriteTwoStateButton btnShift;

        SettingsScreenLayer _layerBack;


        public PlayerNameLayer(SettingsScreenLayer layerBack = null)
        {
            this._layerBack = layerBack;
            this.SetBackground("UI/background.jpg");

            //this.AddImage(292, 565, "UI/about-the-game-title-text.png", 500);

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = this.AddButton(1136-245, 578, "Keyboard/Keyboard_save_name_button_untapped.png", "Keyboard/Keyboard_save_name_button_tapped.png");
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Silent;

            strInput = Player.Instance.Name;

            lblInputLabel = this.AddLabelCentered(1136 / 2, 550, "Please enter player name below", "Fonts/AktivGroteskBold", 14);

            lblInput = this.AddLabelCentered(1136 / 2, 500, strInput, "Fonts/AktivGroteskBold", 16);
            lblInput.Scale = 2;
            lblInput.ZOrder = 1000;

            string slova;

            int spX = 80;
            int keyboardY = 360;
            //int padY = 48;
            //int padX = 45;

            caps = new List<CCSpriteButton>();
            small = new List<CCSpriteButton>();

            slova = "1234567890-";
            for (int i = 0; i < slova.Length; i++)
            {
                CCSpriteButton btnSlovo;
                if (slova[i] == '-')
                {
                    btnSlovo = this.AddButton(1136 / 2 + (i - 6) * spX, keyboardY, "Keyboard/Keyboard_del_untapped.png", "Keyboard/Keyboard_del_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.OnClick += btnBackSpace_OnClick;
                }
                else
                {
                    btnSlovo = this.AddButton(1136 / 2 + (i - 6) * spX, keyboardY, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
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
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.Visible = false;
                    caps.Add(btnSlovo);

                    btnSlovo = this.AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    small.Add(btnSlovo);
                }
                else
                {
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX / 2 + (i - 6) * spX, keyboardY - spX, "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
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
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Visible = false;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    caps.Add(btnSlovo);

                    btnSlovo = this.AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    small.Add(btnSlovo);
                }
                else
                {
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX + (i - 6) * spX, keyboardY - (spX * 2), "Keyboard/Keyboard_double_dot_untapped.png", "Keyboard/Keyboard_double_dot_tapped.png", 100, BUTTON_TYPE.Regular);
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
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Capital letters/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Capital letters/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                    btnSlovo.Visible = false;
                    caps.Add(btnSlovo);

                    btnSlovo = this.AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_untapped.png", "Keyboard/Small letters/Keyboard_" + slova[i].ToString().ToLower() + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i].ToString().ToLower()[0];
                    btnSlovo.ZOrder = 1000;
                    small.Add(btnSlovo);
                }
                else
                {
                    CCSpriteButton btnSlovo = this.AddButton(1136 / 2 + spX * 3 / 2 + (i - 6) * spX, keyboardY - (spX * 3), "Keyboard/Keyboard_" + slova[i] + "_untapped.png", "Keyboard/Keyboard_" + slova[i] + "_tapped.png", 100, BUTTON_TYPE.Regular);
                    btnSlovo.OnClick += btnSlovo_OnClick;
                    btnSlovo.Slovo = slova[i];
                    btnSlovo.ZOrder = 1000;
                }


                //CCLabel lblSlovo = this.AddLabelCentered(1136 / 2 + spX * 3 / 2 + (i - 6) * spX + padX, keyboardY - (spX * 3) + padY, slova[i].ToString(), "Fonts/AktivGroteskBold", 16);
                //lblSlovo.Color = new CCColor3B(0, 0, 0);
                //lblSlovo.Scale = 2;
                //lblSlovo.ZOrder = 1001;
            }

            CCSpriteButton btnRazmak = this.AddButton(1136 / 2 - 220, keyboardY - (spX * 4), "Keyboard/Keyboard_spacebar_untapped.png", "Keyboard/Keyboard_spacebar_untapped.png", 100, BUTTON_TYPE.Regular);
            btnRazmak.OnClick += btnSlovo_OnClick;
            btnRazmak.Slovo = ' ';
            btnRazmak.ZOrder = 1000;

            btnShift = this.AddTwoStateButton(1136 / 2 - 6 * spX, keyboardY - (spX * 3), "Keyboard/Keyboard_shift_single_letter_untapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_tapped.png", "Keyboard/Keyboard_shift_single_letter_untapped.png");
            btnShift.ButtonType = BUTTON_TYPE.OnOff;
            btnShift.OnClick += btnShift_OnClick;


        }

        private void btnShift_OnClick(object sender, EventArgs e)
        {
            btnShift.ChangeState();
            btnShift.SetStateImages();
            if (btnShift.State == 1)
            {
  
                foreach (CCSpriteButton btnSlovo in caps)
                {
                    btnSlovo.Visible = false;
                }
                foreach (CCSpriteButton btnSlovo in small)
                {
                    btnSlovo.Visible = true;
                }

            }
            else
            {

                foreach (CCSpriteButton btnSlovo in caps)
                {
                    btnSlovo.Visible = true;
                }
                foreach (CCSpriteButton btnSlovo in small)
                {
                    btnSlovo.Visible = false;
                }
            }


        }


        private void btnSlovo_OnClick(object sender, EventArgs e)
        {
            if (strInput.Length < 15)
            {
                strInput = strInput + ((CCSpriteButton)sender).Slovo;
                lblInput.Text = strInput;
                if (strInput.Length == 1 && btnShift.State != 1)
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
            if (strInput.Length > 0)
            {
                strInput = strInput.Substring(0, strInput.Length - 1);
                lblInput.Text = strInput;
                if (strInput.Length == 0 && btnShift.State == 1)
                { 
                   btnShift_OnClick(sender, e);
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_layerBack != null)
            {
                Shared.GameDelegate.OnBackButton -= BtnBack_OnClick;
                _layerBack.isCartoonFadeIn = false;
                Director.PopScene();
                //this.TransitionToPoppedLayerCartoonStyle();
                
            }
            else
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                this.TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
        }

       
        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            if (strInput.Length == 0)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                lblInputLabel.Text = "Please enter player name below";
                return;
            }

            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                lblInputLabel.Text = "You have to be connected to internet to change your player name";
                return;
            }

            if (!UserManager.CheckIsUsernameFree(strInput))
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                lblInputLabel.Text = "Player name already taken, please try another one";
                return;
            }

            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_FORWARD);
            UserManager.ChangeUsername(strInput);
            lblInputLabel.Text = "Player name changed";

            LeaderboardManager.BestScorePro_Score = 0;
            LeaderboardManager.BestScorePro_LevelsCompleted = 0;
            LeaderboardManager.BestScorePro_Submitted = true;

            LeaderboardManager.BestScoreRegular_Score = 0;
            LeaderboardManager.BestScoreRegular_Accuracy = 0;
            LeaderboardManager.BestScoreRegular_FastestTime = 0;
            LeaderboardManager.BestScoreRegular_Submitted = true;

            if (_layerBack != null)
            {
                _layerBack.isCartoonFadeIn = false;
                Director.PopScene();
                //this.TransitionToPoppedLayerCartoonStyle();
                _layerBack.RefreshPlayerName();
            }
            else
            {
                this.TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
        }

    
    }
}
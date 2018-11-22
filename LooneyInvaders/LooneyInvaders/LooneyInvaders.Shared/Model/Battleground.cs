using System;
using System.Collections.Generic;
using System.Text;

namespace LooneyInvaders.Model
{
    public class Battleground
    {
        public static string GetBattlegroundImageName(BATTLEGROUNDS battleGround, BATTLEGROUND_STYLE battleGroundStyle)
        {
            string battlegroundStyleName;
            string imageName = "";

            if (Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Cartonic) battlegroundStyleName = "cartonic";
            else battlegroundStyleName = "realistic";

            if (battleGround == BATTLEGROUNDS.POLAND) imageName = "Battlegrounds/poland_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.DENMARK) imageName = "Battlegrounds/denmark_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.NORWAY) imageName = "Battlegrounds/norway_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.FRANCE) imageName = "Battlegrounds/france_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.ENGLAND) imageName = "Battlegrounds/england_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.VIETNAM) imageName = "Battlegrounds/vietnam_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.IRAQ) imageName = "Battlegrounds/iraq_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.AFGHANISTAN) imageName = "Battlegrounds/afganistan_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.LIBYA) imageName = "Battlegrounds/libya_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.RUSSIA) imageName = "Battlegrounds/russia_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.GEORGIA) imageName = "Battlegrounds/georgia_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.UKRAINE) imageName = "Battlegrounds/ukraine_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.SYRIA) imageName = "Battlegrounds/syria_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.ESTONIA) imageName = "Battlegrounds/estonia_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.FINLAND) imageName = "Battlegrounds/finland_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.SOUTH_KOREA) imageName = "Battlegrounds/south-korea_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.ISRAEL) imageName = "Battlegrounds/israel_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.JAPAN) imageName = "Battlegrounds/japan_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.GREAT_BRITAIN) imageName = "Battlegrounds/great-britain_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.UNITED_STATES) imageName = "Battlegrounds/usa_" + battlegroundStyleName + "_1136x640.jpg";
            else if (battleGround == BATTLEGROUNDS.MOON) imageName = "Battlegrounds/Test-battleground-moon-" + battlegroundStyleName + ".jpg";
            else if (battleGround == BATTLEGROUNDS.WHITE_HOUSE && Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Cartonic) imageName = "Battlegrounds/whitehouse-battle-ground-cartoon-style.jpg";
            else if (battleGround == BATTLEGROUNDS.WHITE_HOUSE && Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Realistic) imageName = "Battlegrounds/whitehouse-battle-ground-realistic-style.jpg";
            else if (battleGround == BATTLEGROUNDS.CURTAINS) imageName = "UI/background.jpg";

            return imageName;
        }

    }
}

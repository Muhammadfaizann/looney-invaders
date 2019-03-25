namespace LooneyInvaders.Model
{
    public class Battleground
    {
        public static string GetBattlegroundImageName(Battlegrounds battleGround, BattlegroundStyle battleGroundStyle)
        {
            var imageName = string.Empty;

            var battlegroundStyleName = Settings.Instance.BattlegroundStyle == BattlegroundStyle.Cartonic 
                ? "cartonic" 
                : "realistic";

            switch (battleGround)
            {
                case Battlegrounds.Poland:
                    imageName = "Battlegrounds/poland_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Denmark:
                    imageName = "Battlegrounds/denmark_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Norway:
                    imageName = "Battlegrounds/norway_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.France:
                    imageName = "Battlegrounds/france_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.England:
                    imageName = "Battlegrounds/england_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Vietnam:
                    imageName = "Battlegrounds/vietnam_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Iraq:
                    imageName = "Battlegrounds/iraq_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Afghanistan:
                    imageName = "Battlegrounds/afganistan_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Libya:
                    imageName = "Battlegrounds/libya_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Russia:
                    imageName = "Battlegrounds/russia_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Georgia:
                    imageName = "Battlegrounds/georgia_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Ukraine:
                    imageName = "Battlegrounds/ukraine_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Syria:
                    imageName = "Battlegrounds/syria_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Estonia:
                    imageName = "Battlegrounds/estonia_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Finland:
                    imageName = "Battlegrounds/finland_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.SouthKorea:
                    imageName = "Battlegrounds/south-korea_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Israel:
                    imageName = "Battlegrounds/israel_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Japan:
                    imageName = "Battlegrounds/japan_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.GreatBritain:
                    imageName = "Battlegrounds/great-britain_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.UnitedStates:
                    imageName = "Battlegrounds/usa_" + battlegroundStyleName + "_1136x640.jpg";
                    break;
                case Battlegrounds.Moon:
                    imageName = "Battlegrounds/Test-battleground-moon-" + battlegroundStyleName + ".jpg";
                    break;
                case Battlegrounds.WhiteHouse when Settings.Instance.BattlegroundStyle == BattlegroundStyle.Cartonic:
                    imageName = "Battlegrounds/whitehouse-battle-ground-cartoon-style.jpg";
                    break;
                case Battlegrounds.WhiteHouse when Settings.Instance.BattlegroundStyle == BattlegroundStyle.Realistic:
                    imageName = "Battlegrounds/whitehouse-battle-ground-realistic-style.jpg";
                    break;
                case Battlegrounds.Curtains:
                    imageName = "UI/background.jpg";
                    break;
            }

            return imageName;
        }
    }
}

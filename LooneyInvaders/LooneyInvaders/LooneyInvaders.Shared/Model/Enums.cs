using System;
using System.Collections.Generic;
using System.Text;

namespace LooneyInvaders.Model
{
    public enum MUSIC_STYLE : int { Instrumental, Beatbox }
    public enum BATTLEGROUND_STYLE : int { Cartonic, Realistic }

    public enum BUTTON_TYPE : int { Regular, Back, Forward, VolumeUp, VolumeDown, Silent, Minus, Plus, CannotTap, CheckMark, CreditPurchase, Link, OnOff, Rewind }

    public enum MUSIC : int { MAIN_MENU, SPLASH_SCREEN, BATTLE_WAVE_1, BATTLE_WAVE_2, BATTLE_WAVE_3, BATTLE_COUNTDOWN, BATTLE_COUNTDOWNALIEN, GAMEOVER, GAMEOVERALIEN, VICTORY, NEXTWAVE, NEXTWAVEALIEN, BATTLE_ALIEN1, BATTLE_ALIEN2, BATTLE_ALIEN3, BATTLE_ALIEN4, BATTLE_ALIEN5, BATTLE_ALIEN6, BATTLE_ALIEN7, BATTLE_ALIEN8, BATTLE_ALIEN9 }
    public enum SOUNDEFFECT : int { MENU_TAP, MENU_TAP_BACK, MENU_TAP_FORWARD, MENU_TAP_VOLUME_CHANGE, MENU_TAP_MINUS, MENU_TAP_PLUS, MENU_TAP_CANNOT_TAP, MENU_TAP_CHECKMARK, MENU_TAP_CREDITPURCHASE,
                              ENEMY_HURT_1, ENEMY_HURT_2, ENEMY_HURT_3, ENEMY_KILLED,
                              ENEMY_SPIT, ENEMY_SPIT2, ENEMY_SPIT3, ENEMY_SPIT4,
                              ALIEN_SPIT, ALIEN_SPIT2, ALIEN_SPIT3, 
                              GUN_HIT_1, GUN_HIT_2, GUN_HIT_3, GUN_HIT_GAME_OVER,
                              CANNON_CAL_1_1,
                              CALIBRE_1, CALIBRE_1_HYBRID,
                              BOMB_FALL1, BOMB_FALL2, BOMB_FALL3,
                              EMPTY_CANON,
                              EMPTY_CANON_HYBRID,
                              COUNTDOWN,COUNTDOWNALIEN,
                              REWARD_NOTIFICATION,
                              NOTIFICATION_POP_UP,
                              CLICK_LINK,
                              ON,
                              OFF,
                              REWIND,
                              SHOWSCORE,
                              SWIPE,
                              TEXTAPPEARS,
                              TRANSITION_LOOP1, TRANSITION_LOOP2, TRANSITION_LOOP3, TRANSITION_LOOP4, TRANSITION_LOOP5, TRANSITION_LOOP6,
                              ALIEN_LASER,
                              MULTIPLIER_INDICATOR, MULTIPLIER_LOST,
                              FLYINGSAUCER_INCOMING, FLYINGSAUCER_FLYING, FLYINGSAUCER_EXPLOSION,
                              CANNON_STILL, CANNON_SLOW, CANNON_FAST

    }

    public enum ENEMIES : int { PUTIN, KIM, HITLER, BUSH, ALIENS, TRUMP }
    public enum WEAPONS : int { STANDARD, COMPACT, BAZOOKA, HYBRID }
    /*  public enum BATTLEGROUNDS : int { POLAND, DENMARK, NORWAY, FRANCE, ENGLAND, // Hitler
                                        VIETNAM, IRAQ, AFGHANISTAN, LIBYA, RUSSIA, // Bush
                                        GEORGIA, UKRAINE, SYRIA, ESTONIA, FINLAND, // Putin
                                        SOUTH_KOREA, ISRAEL, JAPAN, GREAT_BRITAIN, UNITED_STATES, // Kim
                                        MOON,
                                        WHITE_HOUSE,
                                        CURTAINS //Steering demo battleground
                                      }*/

    public enum BATTLEGROUNDS : int
    {
        LIBYA, DENMARK, NORWAY, FRANCE, ENGLAND, // Hitler
        VIETNAM, IRAQ, AFGHANISTAN, POLAND, RUSSIA, // Bush
        GEORGIA, UKRAINE, SYRIA, ESTONIA, FINLAND, // Putin
        SOUTH_KOREA, ISRAEL, JAPAN, GREAT_BRITAIN, UNITED_STATES, // Kim
        MOON,
        WHITE_HOUSE,
        CURTAINS //Steering demo battleground
    }

    public enum ENEMYSTATE : int { NORMAL, DAMAGE1, DAMAGE2, GRIMACE1, GRIMACE2 }

    public enum CONTROL_TYPE : int { GYROSCOPE, MANUAL }

    public enum LAUNCH_MODE : int { WEAPONS_UPGRADE_TEST, WEAPON_TEST, STEERING_TEST, DEFAULT} 
}

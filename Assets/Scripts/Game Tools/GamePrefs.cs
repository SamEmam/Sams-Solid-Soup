using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePrefs
{
    private static int player1Score, player2Score, player3Score, player4Score, player5Score, player6Score, player7Score, player8Score;
    private static int gamesPlayed = 0, gamesIndex = 0;
    private static int totalPlayerCount;
    private static List<int> soupList;
    private static bool withSplit = true;
    private static float gameTime;
    private static bool player1 = false, player2 = false, player3 = false, player4 = false, player5 = false, player6 = false, player7 = false, player8 = false;
    private static GameModeEnum gameMode = GameModeEnum.Soup;
    private static SubModeEnum subMode;
    private static ColorEnum p1Color = ColorEnum.Undefined, p2Color = ColorEnum.Undefined, p3Color = ColorEnum.Undefined, p4Color = ColorEnum.Undefined, p5Color = ColorEnum.Undefined, p6Color = ColorEnum.Undefined, p7Color = ColorEnum.Undefined, p8Color = ColorEnum.Undefined;
    private static TypeEnum p1Type, p2Type, p3Type, p4Type, p5Type, p6Type, p7Type, p8Type;
    private static RaceMapEnum raceMapEnum;
    private static bool hasAppliedSettings = false;

    public static bool HasAppliedSettings
    {
        get
        {
            return hasAppliedSettings;
        }
        set
        {
            hasAppliedSettings = value;
        }
    }

    public static int TotalPlayerCount
    {
        get
        {
            return totalPlayerCount;
        }
        set
        {
            totalPlayerCount = value;
        }
    }

    public static bool WithSplit
    {
        get
        {
            return withSplit;
        }
        set
        {
            withSplit = value;
        }
    }

    public static List<int> SoupList
    {
        get
        {
            return soupList;
        }
        set
        {
            soupList = value;
        }
    }

    public static int GamesIndex
    {
        get
        {
            return gamesIndex;
        }
        set
        {
            gamesIndex = value;
        }
    }

    public static int GamesPlayed
    {
        get
        {
            return gamesPlayed;
        }
        set
        {
            gamesPlayed = value;
        }
    }

    public static TypeEnum P1Type
    {
        get
        {
            return p1Type;
        }
        set
        {
            p1Type = value;
        }
    }

    public static TypeEnum P2Type
    {
        get
        {
            return p2Type;
        }
        set
        {
            p2Type = value;
        }
    }

    public static TypeEnum P3Type
    {
        get
        {
            return p3Type;
        }
        set
        {
            p3Type = value;
        }
    }

    public static TypeEnum P4Type
    {
        get
        {
            return p4Type;
        }
        set
        {
            p4Type = value;
        }
    }

    public static TypeEnum P5Type
    {
        get
        {
            return p5Type;
        }
        set
        {
            p5Type = value;
        }
    }

    public static TypeEnum P6Type
    {
        get
        {
            return p6Type;
        }
        set
        {
            p6Type = value;
        }
    }

    public static TypeEnum P7Type
    {
        get
        {
            return p7Type;
        }
        set
        {
            p7Type = value;
        }
    }

    public static TypeEnum P8Type
    {
        get
        {
            return p8Type;
        }
        set
        {
            p8Type = value;
        }
    }

    public static RaceMapEnum RaceMapEnum
    {
        get
        {
            return raceMapEnum;
        }
        set
        {
            raceMapEnum = value;
        }
    }

    public static ColorEnum P1Color
    {
        get
        {
            return p1Color;
        }
        set
        {
            p1Color = value;
        }
    }

    public static ColorEnum P2Color
    {
        get
        {
            return p2Color;
        }
        set
        {
            p2Color = value;
        }
    }

    public static ColorEnum P3Color
    {
        get
        {
            return p3Color;
        }
        set
        {
            p3Color = value;
        }
    }

    public static ColorEnum P4Color
    {
        get
        {
            return p4Color;
        }
        set
        {
            p4Color = value;
        }
    }

    public static ColorEnum P5Color
    {
        get
        {
            return p5Color;
        }
        set
        {
            p5Color = value;
        }
    }

    public static ColorEnum P6Color
    {
        get
        {
            return p6Color;
        }
        set
        {
            p6Color = value;
        }
    }

    public static ColorEnum P7Color
    {
        get
        {
            return p7Color;
        }
        set
        {
            p7Color = value;
        }
    }

    public static ColorEnum P8Color
    {
        get
        {
            return p8Color;
        }
        set
        {
            p8Color = value;
        }
    }

    public static float GameTime
    {
        get
        {
            return gameTime;
        }
        set
        {
            gameTime = value;
        }
    }

    public static SubModeEnum SubMode
    {
        get
        {
            return subMode;
        }
        set
        {
            subMode = value;
        }
    }

    public static GameModeEnum GameMode
    {
        get
        {
            return gameMode;
        }
        set
        {
            gameMode = value;
        }
    }

    // get & set players joined
    public static bool Player1
    {
        get
        {
            return player1;
        }
        set
        {
            player1 = value;
        }
    }
    public static bool Player2
    {
        get
        {
            return player2;
        }
        set
        {
            player2 = value;
        }
    }
    public static bool Player3
    {
        get
        {
            return player3;
        }
        set
        {
            player3 = value;
        }
    }
    public static bool Player4
    {
        get
        {
            return player4;
        }
        set
        {
            player4 = value;
        }
    }
    public static bool Player5
    {
        get
        {
            return player5;
        }
        set
        {
            player5 = value;
        }
    }
    public static bool Player6
    {
        get
        {
            return player6;
        }
        set
        {
            player6 = value;
        }
    }
    public static bool Player7
    {
        get
        {
            return player7;
        }
        set
        {
            player7 = value;
        }
    }
    public static bool Player8
    {
        get
        {
            return player8;
        }
        set
        {
            player8 = value;
        }
    }

    // get & set player Score
    public static int Player1Score
    {
        get
        {
            return player1Score;
        }
        set
        {
            player1Score = value;
        }
    }
    public static int Player2Score
    {
        get
        {
            return player2Score;
        }
        set
        {
            player2Score = value;
        }
    }
    public static int Player3Score
    {
        get
        {
            return player3Score;
        }
        set
        {
            player3Score = value;
        }
    }
    public static int Player4Score
    {
        get
        {
            return player4Score;
        }
        set
        {
            player4Score = value;
        }
    }
    public static int Player5Score
    {
        get
        {
            return player5Score;
        }
        set
        {
            player5Score = value;
        }
    }
    public static int Player6Score
    {
        get
        {
            return player6Score;
        }
        set
        {
            player6Score = value;
        }
    }
    public static int Player7Score
    {
        get
        {
            return player7Score;
        }
        set
        {
            player7Score = value;
        }
    }
    public static int Player8Score
    {
        get
        {
            return player8Score;
        }
        set
        {
            player8Score = value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker_script : MonoBehaviour
{
    public singletone_script singletone;
    public checker_script(singletone_script _singletone)
    {
        singletone = _singletone;
    }

    public void CheckAchievements()
    {
        HighScoreCheck();
    }

    private void HighScoreCheck()
    {
        if (singletone.player_info.score > singletone.player_info.highscore) singletone.player_info.highscore = singletone.player_info.score;
    }

}

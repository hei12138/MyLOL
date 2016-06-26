using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLOL.Models
{
    public class MatchInfo
    {
        public MatchInfo()
        {
            list = new ObservableCollection<MatchList>() { new MatchList { gameState = GameState.Win,kill="10",death="1",assist="2" }, new MatchList { gameState = GameState.Win, kill = "10", death = "1", assist = "2" }, new MatchList { gameState = GameState.Win, kill = "10", death = "1", assist = "2" }, new MatchList { gameState = GameState.Win, kill = "10", death = "1", assist = "2" }, new MatchList { gameState = GameState.Win, kill = "10", death = "1", assist = "2" } };
        }
        public ObservableCollection<MatchList> list { get; set; }
    }
    public class MatchList
    {
        //输赢
        public GameState gameState { get; set; }
        public string hero { get; set; }
        public string kill { get; set; }
        public string death { get; set; }
        public string assist { get; set; }
        public string time { get; set; }
        public string gameclass { get; set; }
    }
    public enum GameState
    {
       Win=0,
       Lose=1,
       Gray=2,
       Escape=3
    }
}

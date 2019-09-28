using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace BallGame.Networking {
  public class BgLobby : NetworkLobbyManager {
    // Start is called before the first frame update
    void Start() {
      MMStart();
      MMListMatches();
    }

    void MMStart(){
      // this.StartMatchMaker();
    }

    void MMListMatches(){
      // this.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
    }

    // public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList){
    //   base.OnMatchList(success, extendedInfo, matchList);
    //   if(!success){
    //     Debug.Log("Match List Failed");
    //     return;
    //   }

    //   Debug.Log("Match List success!");
    //   if(matchList.Count > 0){
    //     Debug.Log($"First Match {matchList[0]}");
    //     MMJoinMatch();
    //   }else{
    //     MMCreateMatch();
    //   }
    // }

    void MMJoinMatch(){

    }

    void MMCreateMatch(){

    }
  }
}
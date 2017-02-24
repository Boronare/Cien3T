using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClientSide
{
    public class ClientMsgHandler : MsgHandler
    {
        public override void HandleMsg(string networkMessage)
        {
            string[] splitMsg = networkMessage.Split('/');
            switch (splitMsg[0])
            {
                case "FreeId":
                    //KingGodClient(int.Parse(splitMsg[0]), "Matched");
                    break;
                default:
                    break;
            }
        }
    }

    /*
     * 메세지 종류
     * 1) Seed/(int) : 양을 생성하는 랜덤 시드
     * 2) PlayerNum/(2 or 1) : 플레이어 넘버
     * 3) Start : 게임을 시작.
     * 4) Disconnect : 게임 종료.
     * 5) Shepherd_S/(PlayerNum, state, frame) : 양치기의 상태
     * 6) Skill_S/(PlayerNum, skillindex, x,y,z, frame)
     */
}

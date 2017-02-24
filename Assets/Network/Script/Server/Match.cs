using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServerSide
{
    public class Match{
		const int MAX = 10;
        int[] freeIds = new int[MAX];
        int playerCount = 0;
		bool[] ready = new bool[MAX];

        public Match() {

        }
        public Match(int freeId) {
            this.freeIds[playerCount] = freeId;
            playerCount++;
        }

		public bool removePlayer(int freeId) {
			int index = findPlayer(freeId);
			if(index != -1) {
				while(index < playerCount - 1)
					freeIds[index] = freeIds[index + 1];
				playerCount--;
				return true;
			}
			return false;
		}

		public int findPlayer(int freeId) {
			for(int index =0; index < playerCount; index++) {
				if(freeIds[index] == freeId)
					return index;
			}
			return -1;

		}

        public void addPlayer(int freeId) {
			if(!(playerCount == MAX)) {
				this.freeIds[playerCount] = freeId;
				playerCount++;
			}
        }

		public void setReady(int id) {
			for(int index = 0; index < MAX; index++) {
				if(id == freeIds[index])
					ready[index] = true;
			}
		}

		public bool isAllReady() {
			for(int index = 0; index < MAX; index++) {
				if(ready[index] == false)
					return false;
			}
			return true;
		}

		public int getFreeId(int index) {
            return this.freeIds[index];
        }
		public int getMax() { return MAX; }
		public int getPlayerCount() { return playerCount; }
    }

}

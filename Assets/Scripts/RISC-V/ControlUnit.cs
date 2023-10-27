using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.RISC_V{

    class ControlUnit{

        private enum State {
            HALT, FETCH, DECODE, READ, EXECUTE, WRITE
        }
        private State currentState;

        private Dictionary<byte,string> opcodeType = new Dictionary<byte, string>(){{0b0110011, "R"}};
        private DataPath dataPath;

        public ControlUnit(){

            this.currentState = State.HALT;
            this.dataPath = DataPath.getInstance();

        }

        public void compute(){

        }

    }

}

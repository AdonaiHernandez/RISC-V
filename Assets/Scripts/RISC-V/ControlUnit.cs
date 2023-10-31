using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.Scripts.RISC_V{

    class ControlUnit{

        private static ControlUnit _instance;
        private enum State {
            HALT, FETCH, DECODE, READ, EXECUTE, WRITE
        }

        private byte cicle;
        private byte instruction;

        private State currentState;
        

        private Dictionary<byte,string> opcodeType = new Dictionary<byte, string>(){{0b0110011, "R"}};

        private ControlUnit(){

            currentState = State.HALT;
            cicle = 0;
        }

        public static ControlUnit getInstance(){
            if (_instance == null){
                _instance = new ControlUnit();
            }

            return _instance;
        }

    }

}

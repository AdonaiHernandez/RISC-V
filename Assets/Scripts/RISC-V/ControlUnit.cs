using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.Scripts.RISC_V{

    class ControlUnit{

        private static ControlUnit _instance;
        private enum State {
            HALT, FETCH, DECODE, MEM_ADD_COMP, EXEC, BRANCH_COMP, JUMP_COMP, MEM_ACC, R_TYPE, MEM_READ
        }

        private byte cicle;
        private byte instruction;

        private State currentState;

        private Dictionary<byte,string> opcodeType = new Dictionary<byte, string>(){{0b0110011, "R"}};

        //CONTROL OUTPUTS

        public byte MemRead;
        public byte AluSrcA;
        public byte IRWrite;
        public byte AluSrcB; 
        public byte AluOp;
        public byte PCWrite;
        public byte PCSource;
        public byte RegDst;
        public byte RegWrite;
        public byte MemToReg;

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

        public void compute(){
            switch (currentState)
            {
                
                case State.HALT:
                    currentState = State.FETCH;
                    MemRead = 1;
                    AluSrcA = 0;
                    IRWrite = 1;
                    AluSrcB = 1;
                    AluOp = 0;
                    PCWrite = 1;
                    PCSource = 0;
                    break;
                case State.FETCH:
                    currentState = opcodeType[instruction] == "R" ? State.EXEC : State.HALT; //TODO
                    AluSrcA = 0;
                    AluSrcB = 0b11;
                    AluOp = 0;
                    break;
                case State.EXEC:
                    currentState = State.R_TYPE;
                    AluSrcA = 1;
                    AluSrcB = 00;
                    AluOp = 0b10;
                    break;
                case State.R_TYPE:
                    currentState = State.FETCH;
                    RegDst = 1;
                    RegWrite = 1;
                    MemToReg = 0;
                    break;
                default:
                    break;
                
            }
        }

        public void setInstruction(byte inst){
            instruction = inst;
        }

    }

}

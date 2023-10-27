using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;

namespace Assets.Scripts.RISC_V
{
    public class DataPath
    {
        private Register programCounter;
        private RegisterBank rBank;
        private Memory instructionMem;
        private Memory dataMem;
        private ALU alu;
        private Register instructionRegister;
        private static DataPath _instance;
        private DataPath(){

            this.programCounter = new Register();
            this.rBank = RegisterBank.getInstance();
            this.instructionMem = new Memory(256);
            this.dataMem = new Memory(256);
            this.alu = ALU.getInstance();

            this.programCounter.setValue(0);
        }

        public static DataPath getInstance(){
            if (_instance == null){
                _instance = new DataPath();
            }
            return _instance;
        }
        
        public void fetchInstruction(){
            uint instruction = this.instructionMem.read(programCounter.getValue());
            this.instructionRegister.setValue(instruction);
        }
    }
}

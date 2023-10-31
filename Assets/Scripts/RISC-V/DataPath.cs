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
        private ControlUnit controlUnit;
        private static DataPath _instance;
        private DataPath(){

            this.programCounter = new Register();
            this.rBank = RegisterBank.getInstance();
            this.instructionMem = new Memory(256);
            this.dataMem = new Memory(256);
            this.alu = ALU.getInstance();
            this.controlUnit = ControlUnit.getInstance();
            this.programCounter.setValue(0);
        }

        public static DataPath getInstance(){
            if (_instance == null){
                _instance = new DataPath();
            }
            return _instance;
        }
        
        public void fetchInstruction(){
            int instruction = this.instructionMem.read(programCounter.getValue());
            this.instructionRegister.setValue(instruction);
        }

        public byte getInstructionOP(){
            return (byte) (this.instructionRegister.getValue() & 0b1111111); //Los 7 bits menos significativos
        }


        public void execute(byte aluOp){
            byte regA = (byte) (this.instructionRegister.getValue() &    0b00000000000011111000000000000000); // 15-19 bit Origen A
            byte regB = (byte) (this.instructionRegister.getValue() &    0b00000001111100000000000000000000); // 20-24 bit Origen B
            byte regDest = (byte) (this.instructionRegister.getValue() & 0b00000000000000000000111110000000); // 7-11  bit Destino

            int regARes = rBank.read(regA);
            int regBRes = rBank.read(regB);

            int res = alu.compute(aluOp, regARes, regBRes);

            rBank.write(regDest, res);

        }
        
    }
}

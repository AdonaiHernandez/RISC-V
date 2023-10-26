using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RISC_V
{
    internal class ALU
    {
        private static ALU _instance;
        public bool zero = false;
        private ALU() { }

        public static ALU getInstance() { 
        
            if (_instance == null)
            {
                _instance = new ALU();
            }
            return _instance;
        
        }

        public uint compute(byte operation, uint operand1, uint operand2) { 
        
            uint result = 0;

            switch (operation) { 
            
                case 0: result = operand1 + operand2; break;
                case 1: result = operand1 - operand2; break;
                case 2: result = operand1 & operand2; break;
                case 3: result = operand1 | operand2; break;
                case 4: result = operand1 ^ operand2; break;
                case 5: result = (uint)((int)operand1 << (int)operand2); break;
                case 6: result = (uint)((int)operand1 >> (int)operand2); break;
                case 7: result = (uint)((int)operand1 >> (int)operand2); break;
                case 8: result = (uint)(operand1 < operand2 ? 1 : 0); break;
                case 9: result = (uint)(operand1 > operand2 ? 1 : 0); break;
            }
            
            this.zero = result == 0;  

            return result;
        }
    }
}

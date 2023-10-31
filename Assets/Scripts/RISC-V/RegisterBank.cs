using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RISC_V
{
    internal class RegisterBank
    {
        private Register[] bank;

        private static RegisterBank _instance;
        private RegisterBank() {
            Register a = new Register();
            Register b = new Register();

            this.bank = new Register[2] { a, b };



        }

        public static RegisterBank getInstance() {

            if (_instance == null)
            {
                _instance = new RegisterBank();
            }

            return _instance;
        
        }

        public int read(int index) {
            return bank[index].getValue();
        }

        public void write(int index, int value)
        {
            bank[index].setValue(value);
        }
    }
}

namespace Assets.Scripts.RISC_V
{
    internal class Register {

        private uint value;

        public Register() {
            this.value = 0;
        }

        public uint getValue() {
            return value;
        }

        public void setValue(uint newValue) { 
        
            this.value = newValue;
        
        }
    }
}

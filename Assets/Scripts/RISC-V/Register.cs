namespace Assets.Scripts.RISC_V
{
    internal class Register {

        private int value;

        public Register() {
            this.value = 0;
        }

        public int getValue() {
            return value;
        }

        public void setValue(int newValue) { 
        
            this.value = newValue;
        
        }
    }
}

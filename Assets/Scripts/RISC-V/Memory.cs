namespace Assets.Scripts.RISC_V
{
    class Memory
    {

        private byte[] data;
        private int size;
        public Memory(int size)
        {

            this.data = new byte[size];
            this.size = size;
        }

        public bool write(byte[] newData, int offset)
        {

            if (newData.Length + offset > this.size)
                return false;

            for (int i = offset; i < newData.Length; i++)
            {

                data[i] = newData[i];

            }

            return true;

        }

        public byte read(uint index)
        {
            return data[index];
        }

        public byte[] readBlock(uint index, int size)
        {
            if (size <= 0 || index + size > this.size)
                return null;

            byte[] ret = new byte[size];
            for (int i = 0; i < size; i++)
            {
                ret[i] = this.data[index + i];
            }
            return ret;
        }

    }
}
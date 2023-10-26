namespace Assets.Scripts.RISC_V
{
    class Memory
    {

        private uint[] data;
        private int size;
        public Memory(int size)
        {

            this.data = new uint[size];
            this.size = size;
        }

        public bool write(uint[] newData, int offset)
        {

            if (newData.Length + offset > this.size)
                return false;

            for (int i = offset; i < newData.Length; i++)
            {

                data[i] = newData[i];

            }

            return true;

        }

        public uint read(uint index)
        {
            return data[index];
        }

        public uint[] readBlock(uint index, int size)
        {
            if (size <= 0 || index + size > this.size)
                return null;

            uint[] ret = new uint[size];
            for (int i = 0; i < size; i++)
            {
                ret[i] = this.data[index + i];
            }
            return ret;
        }

    }
}
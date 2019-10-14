namespace Atlacomm.ArchiveFormat
{
    public partial class Archive
    {
        public byte[] GetFile(string filepath)
        {
            if (!Contains(filepath)) return null;

            long offset = contentOffset;

            byte[] ret = null;

            foreach (string key in index.Keys)
            {
                if (key == filepath)
                {
                    ret = new byte[index[key]];
                    for (long i = 0; i < ret.Length; i++)
                    {
                        ret[i] = data[offset + i];
                    }

                    break;
                }
                offset += index[key];
            }

            return ret;
        }
    }
}

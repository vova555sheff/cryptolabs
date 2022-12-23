namespace Lab9;

public class MD5Digest
{
    public uint A = 0x67452301;
    public uint B = 0xEFCDAB89;
    public uint C = 0x98BADCFE;
    public uint D = 0X10325476;

    public override string ToString()
    {
        return   MD5Helper.ReverseByte(A).ToString("x8") +
                 MD5Helper.ReverseByte(B).ToString("x8") +
                 MD5Helper.ReverseByte(C).ToString("x8") +
                 MD5Helper.ReverseByte(D).ToString("x8");
    }
}
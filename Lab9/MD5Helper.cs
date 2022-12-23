namespace Lab9;

public static class MD5Helper
{
    public static uint RotateLeft(uint uiNumber, ushort shift)
    {
        return ((uiNumber >> 32 - shift) | (uiNumber << shift));
    }

    public static uint ReverseByte(uint uiNumber)
    {
        return (((uiNumber & 0x000000ff) << 24) |
                (uiNumber >> 24) |
                ((uiNumber & 0x00ff0000) >> 8) |
                ((uiNumber & 0x0000ff00) << 8));
    }
}
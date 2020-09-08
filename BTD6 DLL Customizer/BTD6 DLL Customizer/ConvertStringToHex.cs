using System;
using System.Text;
public class ConvertStringToHex
{
    byte[] needByte = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70 };
    byte[] changeToZeroToFifteen = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
    byte[] convertToHigher = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0, 0xB0, 0xC0, 0xD0, 0xE0 , 0xF0 };
    public byte[] ConvertString(string hexText)
	{
        hexText = hexText.Replace(" ", "");
        hexText = hexText.Replace("-", "");
        return ConvertingLogic(hexText, hexText.Length, false, false, false);
    }
    public byte[] ConvertString(string hexText, int length)
    {
        hexText = hexText.Replace(" ", "");
        hexText = hexText.Replace("-", "");
        return ConvertingLogic(hexText, length, true, false, false);
    }
    public byte[] ConvertString(string hexText, int length, bool additionalBytesBack)
    {
        hexText = hexText.Replace(" ", "");
        hexText = hexText.Replace("-", "");
        return ConvertingLogic(hexText, length, true, true, false);
    }
    public byte[] ConvertString(string hexText, int length, bool additionalBytesBack, bool beIn4ByteSync)
    {
        hexText = hexText.Replace(" ", "");
        hexText = hexText.Replace("-", "");
        return ConvertingLogic(hexText, length, true, true, true);
    }
    private byte[] ConvertingLogic(string hexText, int length, bool customLength, bool additionalBytesBack, bool beIn4ByteSync)
    {
        if (customLength)
        {
            length *= 2;
        }
        if (hexText.Length % 2 == 1 && !(additionalBytesBack))
        {
            hexText = "0" + hexText;
            if (!customLength)
            {
                length = hexText.Length;
            }
        }
        if (beIn4ByteSync)
        {
            switch(hexText.Length % 8)
            {
                case 0: break;
                case 1: hexText = "0000000" + hexText; break;
                case 2: hexText = "000000" + hexText; break;
                case 3: hexText = "00000" + hexText; break;
                case 4: hexText = "0000" + hexText; break;
                case 5: hexText = "000" + hexText;break;
                case 6: hexText = "00" + hexText;break;
                case 7: hexText = "0" + hexText; break;
                default: break;
            }
            length = hexText.Length;
        }
        byte[] final = new byte[length/2];
        byte[] initial = Encoding.UTF8.GetBytes(hexText);
        /*int addPriorBytes = ((hexText.Length * 2) / length);
        for(int i = 0; i < addPriorBytes; i++)
        {
            final[i] = 0x00;
        }*/
        byte[] removedDashesAndConverted = new byte[length + 2];
        int n = 0;
        for (int i = 0; i < initial.Length; i++)
        {
            for(int ii = 0; ii < changeToZeroToFifteen.Length; ii++)
            {
                if (initial[i] == needByte[ii])
                {
                    switch (initial[i])
                    {
                        case 48: removedDashesAndConverted[n] = changeToZeroToFifteen[0]; break;
                        case 49: removedDashesAndConverted[n] = changeToZeroToFifteen[1]; break;
                        case 50: removedDashesAndConverted[n] = changeToZeroToFifteen[2]; break;
                        case 51: removedDashesAndConverted[n] = changeToZeroToFifteen[3]; break;
                        case 52: removedDashesAndConverted[n] = changeToZeroToFifteen[4]; break;
                        case 53: removedDashesAndConverted[n] = changeToZeroToFifteen[5]; break;
                        case 54: removedDashesAndConverted[n] = changeToZeroToFifteen[6]; break;
                        case 55: removedDashesAndConverted[n] = changeToZeroToFifteen[7]; break;
                        case 56: removedDashesAndConverted[n] = changeToZeroToFifteen[8]; break;
                        case 57: removedDashesAndConverted[n] = changeToZeroToFifteen[9]; break;
                        case 65: removedDashesAndConverted[n] = changeToZeroToFifteen[10]; break;
                        case 66: removedDashesAndConverted[n] = changeToZeroToFifteen[11]; break;
                        case 67: removedDashesAndConverted[n] = changeToZeroToFifteen[12]; break;
                        case 68: removedDashesAndConverted[n] = changeToZeroToFifteen[13]; break;
                        case 69: removedDashesAndConverted[n] = changeToZeroToFifteen[14]; break;
                        case 70: removedDashesAndConverted[n] = changeToZeroToFifteen[15]; break;
                    }
                    n++;
                }
            }
        }
        if(n % 2 == 1 && n > 1 && additionalBytesBack)//this adds a zero in hex to the last 4 bits incase the last 4 bits didnt come through so it assumes it is (0000)
        {
            removedDashesAndConverted[n] = 0x00;
            n++;
        }
        else if(n == 1)//this makes it so if only 4 bits was entered it will read as if there is a zero infront
        {
            removedDashesAndConverted[1] = removedDashesAndConverted[0];
            removedDashesAndConverted[0] = 0x00;
            n++;
        }
        if (!customLength)
        {
            length = n/2;
        }
        int j = 0;// + addPriorBytes;
        for (int i = 0; i < n /*- addPriorBytes*/; i++)
        {
            if (i % 2 == 0)
            {
                switch (removedDashesAndConverted[i])
                {
                    case 0x00: final[j] = Convert.ToByte(convertToHigher[0] + removedDashesAndConverted[i + 1]); break;
                    case 0x01: final[j] = Convert.ToByte(convertToHigher[1] + removedDashesAndConverted[i + 1]); break;
                    case 0x02: final[j] = Convert.ToByte(convertToHigher[2] + removedDashesAndConverted[i + 1]); break;
                    case 0x03: final[j] = Convert.ToByte(convertToHigher[3] + removedDashesAndConverted[i + 1]); break;
                    case 0x04: final[j] = Convert.ToByte(convertToHigher[4] + removedDashesAndConverted[i + 1]); break;
                    case 0x05: final[j] = Convert.ToByte(convertToHigher[5] + removedDashesAndConverted[i + 1]); break;
                    case 0x06: final[j] = Convert.ToByte(convertToHigher[6] + removedDashesAndConverted[i + 1]); break;
                    case 0x07: final[j] = Convert.ToByte(convertToHigher[7] + removedDashesAndConverted[i + 1]); break;
                    case 0x08: final[j] = Convert.ToByte(convertToHigher[8] + removedDashesAndConverted[i + 1]); break;
                    case 0x09: final[j] = Convert.ToByte(convertToHigher[9] + removedDashesAndConverted[i + 1]); break;
                    case 0x0A: final[j] = Convert.ToByte(convertToHigher[10] + removedDashesAndConverted[i + 1]); break;
                    case 0x0B: final[j] = Convert.ToByte(convertToHigher[11] + removedDashesAndConverted[i + 1]); break;
                    case 0x0C: final[j] = Convert.ToByte(convertToHigher[12] + removedDashesAndConverted[i + 1]); break;
                    case 0x0D: final[j] = Convert.ToByte(convertToHigher[13] + removedDashesAndConverted[i + 1]); break;
                    case 0x0E: final[j] = Convert.ToByte(convertToHigher[14] + removedDashesAndConverted[i + 1]); break;
                    case 0x0F: final[j] = Convert.ToByte(convertToHigher[15] + removedDashesAndConverted[i + 1]); break;
                }
                j++;
            }
        }
        return final;
    }
}
using Foundation;

namespace LooneyInvaders.iOS.Services.DeviceInfo
{
    [Preserve(AllMembers = true)]
    internal class iOSHardware
    {
        public string GetModel(string hardware)
        {
            // https://support.apple.com/kb/HT3939

            switch (hardware)
            {
                // ************
                // iPhone
                // ************
                // Model(s): A1203
                // Apple Tech specs: https://support.apple.com/kb/SP2
                case "iPhone1,1":
                    return "iPhone";
                // ************
                // iPhone 3G
                // ************
                // Model(s): A1241 & A1324
                // Apple Tech specs: https://support.apple.com/kb/SP495
                case "iPhone1,2":
                    return "iPhone 3G";
                // ************
                // iPhone 3GS
                // ************
                // Model(s): A1303 & A1325
                // Apple Tech specs: https://support.apple.com/kb/SP565
                case "iPhone2,1":
                    return "iPhone 3GS";
                // ************
                // iPhone 4
                // ************
                // Model(s): A1332
                // Apple Tech specs: https://support.apple.com/kb/SP587
                case "iPhone3,1":
                case "iPhone3,2":
                    return "iPhone 4 GSM";
                // Model(s): A1349
                case "iPhone3,3":
                    return "iPhone 4 CDMA";
                // ************
                // iPhone 4S
                // ************
                // Model(s): A1387 & A1431
                // Apple Tech specs: https://support.apple.com/kb/SP643
                case "iPhone4,1":
                    return "iPhone 4S";
                // ************
                // iPhone 5
                // ************
                // Model(s): A1428
                // Apple Tech specs: https://support.apple.com/kb/SP655
                case "iPhone5,1":
                    return "iPhone 5 GSM";
                // Model(s): A1429 & A1442
                case "iPhone5,2":
                    return "iPhone 5 Global";
                // ************
                // iPhone 5C
                // ************
                // Model(s): A1456 & A1532
                // Apple Tech specs: https://support.apple.com/kb/SP684
                case "iPhone5,3":
                    return "iPhone 5C GSM";
                // Model(s): A1507, A1516, A1526 & A1529
                case "iPhone5,4":
                    return "iPhone 5C Global";
                // ************
                // iPhone 5S
                // ************
                // Model(s): A1453 & A1533
                // Apple Tech specs: https://support.apple.com/kb/SP685
                case "iPhone6,1":
                    return "iPhone 5S GSM";
                // Model(s): A1457, A1518, A1528 & A1530    
                case "iPhone6,2":
                    return "iPhone 5S Global";
                // ************
                // iPhone 6
                // ************
                // Model(s): A1549, A1586 & A1589
                // Apple Tech specs: https://support.apple.com/kb/SP705
                case "iPhone7,2":
                    return "iPhone 6";
                // ************
                // iPhone 6 Plus
                // ************
                // Model(s): A1522, A1524 & A1593
                // Apple Tech specs: https://support.apple.com/kb/SP706
                case "iPhone7,1":
                    return "iPhone 6 Plus";
                // ************
                // iPhone 6S
                // ************
                // Model(s): A1633, A1688 & A1700
                // Apple Tech specs: https://support.apple.com/kb/SP726
                case "iPhone8,1":
                    return "iPhone 6S";
                // ************
                // iPhone 6S Plus
                // ************
                // Model(s): A1634, A1687 & A1699
                // Apple Tech specs: https://support.apple.com/kb/SP727
                case "iPhone8,2":
                    return "iPhone 6S Plus";
                // ************
                // iPhone SE
                // ************
                // Model(s): A1662 & A1723
                // Apple Tech specs: https://support.apple.com/kb/SP738
                case "iPhone8,4":
                    return "iPhone SE";
                // ************
                // iPhone 7
                // ************
                // Model(s): A1660, A1778, A1779 & A1780
                // Apple Tech specs: https://support.apple.com/kb/SP743
                case "iPhone9,1":
                case "iPhone9,3":
                    return "iPhone 7";
                // ************
                // iPhone 7
                // ************
                // Model(s): A1661, A1784, A1785 and A1786 
                // Apple Tech specs: https://support.apple.com/kb/SP744
                case "iPhone9,2":
                case "iPhone9,4":
                    return "iPhone 7 Plus";
                // ************
                // iPhone 8
                // ************
                // Model(s): A1863, A1905, A1906 & A1907
                // Apple Tech specs: https://support.apple.com/kb/SP767
                case "iPhone10,1":
                case "iPhone10,4":
                    return "iPhone 8";
                // ************
                // iPhone 8 Plus
                // ************
                // Model(s): A1864, A1897, A1898 & A1899
                // Apple Tech specs: https://support.apple.com/kb/SP768
                case "iPhone10,2":
                case "iPhone10,5":
                    return "iPhone 8 Plus";
                // ************
                // iPhone X
                // ************
                // Model(s): A1865, A1901 & A1902
                // Apple Tech specs: https://support.apple.com/kb/SP770
                case "iPhone10,3":
                case "iPhone10,6":
                    return "iPhone X";
                // ************
                // iPod touch
                // ************
                // Model(s): A1213
                // Apple Tech specs: https://support.apple.com/kb/SP3
                case "iPod1,1":
                    return "iPod touch";
                // ************
                // iPod touch 2G
                // ************
                // Model(s): A1288
                // Apple Tech specs: https://support.apple.com/kb/SP496
                case "iPod2,1":
                    return "iPod touch 2G";
                // ************
                // iPod touch 3G
                // ************
                // Model(s): A1318
                // Apple Tech specs: https://support.apple.com/kb/SP570
                case "iPod3,1":
                    return "iPod touch 3G";
                // ************
                // iPod touch 4G
                // ************
                // Model(s): A1367
                // Apple Tech specs: https://support.apple.com/kb/SP594
                case "iPod4,1":
                    return "iPod touch 4G";
                // ************
                // iPod touch 5G
                // ************
                // Model(s): A1421 & A1509
                // Apple Tech specs: (A1421) https://support.apple.com/kb/SP657 & (A1509) https://support.apple.com/kb/SP675
                case "iPod5,1":
                    return "iPod touch 5G";
                // ************
                // iPod touch 6G
                // ************
                // Model(s): A1574
                // Apple Tech specs: (A1574) https://support.apple.com/kb/SP720 
                case "iPod7,1":
                    return "iPod touch 6G";
                // ************
                // iPad
                // ************
                // Model(s): A1219 (WiFi) & A1337 (GSM)
                // Apple Tech specs: https://support.apple.com/kb/SP580
                case "iPad1,1":
                    return "iPad";
                // ************
                // iPad 2
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP622
                // Model(s): A1395
                case "iPad2,1":
                    return "iPad 2 WiFi";
                // Model(s): A1396
                case "iPad2,2":
                    return "iPad 2 GSM";
                // Model(s): A1397
                case "iPad2,3":
                    return "iPad 2 CDMA";
                // Model(s): A1395
                case "iPad2,4":
                    return "iPad 2 Wifi";
                // ************
                // iPad 3
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP647
                // Model(s): A1416
                case "iPad3,1":
                    return "iPad 3 WiFi";
                // Model(s): A1403
                case "iPad3,2":
                    return "iPad 3 Wi-Fi + Cellular (VZ)";
                // Model(s): A1430
                case "iPad3,3":
                    return "iPad 3 Wi-Fi + Cellular";
                // ************
                // iPad 4
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP662
                // Model(s): A1458
                case "iPad3,4":
                    return "iPad 4 Wifi";
                // Model(s): A1459
                case "iPad3,5":
                    return "iPad 4 Wi-Fi + Cellular";
                // Model(s): A1460
                case "iPad3,6":
                    return "iPad 4 Wi-Fi + Cellular (MM)";
                // ************
                // iPad Air
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP692
                // Model(s): A1474
                case "iPad4,1":
                    return "iPad Air Wifi";
                // Model(s): A1475
                case "iPad4,2":
                    return "iPad Air Wi-Fi + Cellular";
                // Model(s): A1476
                case "iPad4,3":
                    return "iPad Air Wi-Fi + Cellular (TD-LTE)";
                // ************
                // iPad Air 2
                // ************
                // Apple Tech specs: 
                // Model(s): A1566
                case "iPad5,3":
                // Model(s): A1567
                case "iPad5,4":
                    return "iPad Air 2";
                // ************
                // iPad Pro (12.9 inch)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP723
                // Model(s): A1584 (Wi-Fi) 
                case "iPad6,7":
                    return "iPad Pro";
                // Model(s): A1652 (Wi-Fi + Cellular)
                case "iPad6,8":
                    return "iPad Pro Wi-Fi + Cellular";
                // ************
                // iPad Pro (9.7 inch)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP739
                // Model(s): A1673
                case "iPad6,3":
                    return "iPad Pro (9.7-inch)";
                // Model(s): A1674, A1675 (Wi-Fi + Cellular)
                case "iPad6,4":
                    return "iPad Pro (9.7-inch) Wi-Fi + Cellular";
                // ************
                // iPad Pro (12.9-inch) (2nd generation)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP761
                // Model(s): A1670
                case "iPad7,1":
                    return "iPad Pro (12.9-inch) (2nd generation)";
                // Model(s): A1671
                case "iPad7,2":
                    return "iPad Pro (12.9-inch) (2nd generation) Wi-Fi + Cellular";
                // ************
                // iPad Pro (10.5-inch)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP762
                // Model(s): A1701
                case "iPad7,3":
                    return "iPad Pro (10.5-inch)";
                // Model(s): A1709
                case "iPad7,4":
                    return "iPad Pro (10.5-inch) Wi-Fi + Cellular";
                // ************
                // iPad mini
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP661
                // Model(s): A1432
                case "iPad2,5":
                    return "iPad mini Wifi";
                // Model(s): A1454
                case "iPad2,6":
                    return "iPad mini Wi-Fi + Cellular";
                // Model(s): A1455
                case "iPad2,7":
                    return "iPad mini Wi-Fi + Cellular (MM)";
                // ************
                // iPad mini 2
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP693
                // Model(s): A1489
                case "iPad4,4":
                    return "iPad mini 2 Wifi";
                // Model(s): A1490
                case "iPad4,5":
                    return "iPad mini 2 Wi-Fi + Cellular";
                // Model(s): A1491
                case "iPad4,6":
                    return "iPad mini 2 Wi-Fi + Cellular (TD-LTE)";
                // ************
                // iPad mini 3
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP709
                // Model(s): A1599
                case "iPad4,7":
                    return "iPad mini 3 Wifi";
                // Model(s): A1600
                case "iPad4,8":
                    return "iPad mini 3 Wi-Fi + Cellular";
                // Model(s): A1601
                case "iPad4,9":
                    return "iPad mini 3 Wi-Fi + Cellular (TD-LTE)";
                // ************
                // iPad mini 4
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP725
                // Model(s): A1538
                case "iPad5,1":
                    return "iPad mini 4";
                // Model(s): A1550
                case "iPad5,2":
                    return "iPad mini 4 Wi-Fi + Cellular";
                // ************
                // iPad (9.7 inch - 5th generation)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP751
                // Model(s): A1822
                case "iPad6,11":
                    return "iPad 5 Wi-Fi";
                // Model(s): A1823
                case "iPad6,12":
                    return "iPad 5 Wi-Fi + Cellular";
                // ************
                // iPad (9.7 inch - 6th generation 2018)
                // ************
                // Apple Tech specs: https://support.apple.com/kb/SP774
                // Model(s): A1893
                case "iPad7,5":
                    return "iPad 6 Wi-Fi";
                // Model(s): A1954
                case "iPad7,6":
                    return "iPad 6 Wi-Fi + Cellular";
                case "i386":
                case "x86_64":
                    return "Simulator";
                case "":
                    return "Unknown";

                default:
                    {
                        return hardware;
                    }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace newCIS2008.Class
{
    internal sealed class GetMachineInfoModule
    {
        /// <summary>
        ///           ''' return Volume Serial Number from hard drive
        ///           ''' </summary>
        /// <param name="strDriveLetter">[optional] Drive letter</param>
        /// <returns>[string] VolumeSerialNumber</returns>
        public static string GetVolumeSerial(string strDriveLetter)
        {
            if (Operators.CompareString(strDriveLetter, "", false) == 0 || strDriveLetter == null)
            {
                strDriveLetter = "C";
            }
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter + ":\"");
            disk.Get();
            return disk["VolumeSerialNumber"].ToString();
        }
        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = string.Empty;
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = moc.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ManagementObject mo = (ManagementObject)enumerator.Current;
                    if (Operators.CompareString(MACAddress, string.Empty, false) == 0 && Conversions.ToBoolean(mo["IPEnabled"]))
                    {
                        MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }
            }
            finally
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator;
                if (enumerator != null)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }
        public static string GetCPUId()
        {
            string cpuInfo = string.Empty;
            string temp = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = moc.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ManagementObject mo = (ManagementObject)enumerator.Current;
                    if (Operators.CompareString(cpuInfo, string.Empty, false) == 0)
                    {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    }
                }
            }
            finally
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator;
                if (enumerator != null)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
            return cpuInfo;
        }
    }
}

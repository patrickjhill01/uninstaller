using System;
using System.Collections.Generic;
using System.Management;
using System.Reflection;

namespace ConsoleApplication3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var class1 = new Program();
            class1.test();
        }
        
        public void test()
        {
            MethodInfo mi = this.GetType().GetMethod("test2");
            mi.Invoke(this, null);
        }
        public List<string> test2()
        {
            // Console.Out.WriteLine("Test2");
            {
                List<string> programs = new List<string>();
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");

                foreach (ManagementObject service in mos.Get())
                {
                    try
                    {
                        programs.Add(service["Name"].ToString());

                    }
                    catch (Exception ex)
                    {
                        //this program may not have a name property
                    }
                    Console.WriteLine(service.ToString());
                }
                return programs;
                
            }
        }
        
    }
}
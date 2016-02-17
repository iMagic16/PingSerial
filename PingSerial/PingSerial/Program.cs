using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingSerial
{
    class Program
    {
        static void Main(string[] args)
        {
            //the purpose of this program is to send commands down a COM port when a certain IP address comes online.
            Console.WriteLine("Starting");
            while (true)
            {
                PingIt("8.8.8.8"); //change this to the phone
                //wait 5 mins between pings
                Console.WriteLine("Waiting 5 minutes");
                System.Threading.Thread.Sleep(300000);
                Console.WriteLine("Restarting...");
            };


        }

        static void PingIt(string IPAddr)
        {
            Ping PINGER = new Ping();

            //send ping
            try
            {
                PingReply PINGER_REPLY = PINGER.Send(IPAddr);

                if (PINGER_REPLY.Status == IPStatus.Success)
                {
                    Console.WriteLine("Address: {0}", PINGER_REPLY.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0} ms", PINGER_REPLY.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", PINGER_REPLY.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", PINGER_REPLY.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", PINGER_REPLY.Buffer.Length);
                    PingSuccess();
                }
                else
                {
                    PingFail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PingSuccess()
        {
            //DoStuffOnSuccess
            Console.WriteLine("TODO: Write this stuff (pingsuccess)");
            SerialSend(true);
        }

        static void PingFail()
        {
            //DoStuffOnFail
            Console.WriteLine("TODO: Write this stuff (pingfail)");
            SerialSend(false);
        }

        static void SerialSend(Boolean OnOff)
        {
            try
            {
                SerialPort serialPort = new SerialPort();
                serialPort = new SerialPort();
                serialPort.PortName = "COM10";
                serialPort.Open();
                Console.WriteLine("Port opened");
                if (OnOff)
                {
                    serialPort.WriteLine("PWR ON");
                    Console.WriteLine("PWR ON");
                }
                else
                {
                    serialPort.WriteLine("PWR OFF");
                    Console.WriteLine("PWR OFF");
                }
                serialPort.Close();
                Console.WriteLine("Port closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

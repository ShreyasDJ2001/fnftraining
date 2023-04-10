using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{ 
    public delegate void DoorStatusChangedEventHandler(DoorStatus status);
    public enum DoorStatus
    {
        OPEN,CLOSE
    }
    public class SecuredDoor
    {
        public DoorStatus status;
        public event DoorStatusChangedEventHandler DoorStatusChanged;
        public void Open()
        {
           status= DoorStatus.OPEN;

            if (DoorStatusChanged != null)
            {
                DoorStatusChanged.Invoke(status);
            }

        }
        public void Close()
        {
            status= DoorStatus.CLOSE;

            if (this.DoorStatusChanged != null)
            {
                this.DoorStatusChanged.Invoke(status);
            }

        }
        
    }
    public class Buzzar
    {
        TextToSpeechConverter textToSpeechConverter = new TextToSpeechConverter();
        public string OpenMessage = "Door opened";
        public string CloseMessage = "Door closed";
        public void MakeNoise(DoorStatus status)
        {
            if (status==DoorStatus.OPEN) { textToSpeechConverter.Convert(OpenMessage); }
            if (status==DoorStatus.CLOSE) { textToSpeechConverter.Convert(CloseMessage); }
        }
    }
    public class TextToSpeechConverter
    {
        public void Convert(string text)
        {
            Console.WriteLine("door opened or door closed");
        }
    }
    internal class Doorassignment
    {
        public static void _Main_(string[] args)
        {
            Buzzar buzzar = new Buzzar();
            SecuredDoor securedDoor = new SecuredDoor();
            securedDoor.DoorStatusChanged += buzzar.MakeNoise;
            securedDoor.Open();
            securedDoor.Close();
            

            
        }
    }
}

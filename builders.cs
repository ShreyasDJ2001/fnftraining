using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Drawing;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
namespace demo.inheritanceBasics
{d
    class image
    {
        public string Name { get; set; }
        public int Size
        {
            get; set;
        }
        public class Builder
        {
            private image _image = new image();

            image i = new image.Builder().WithName("myImage").WithSize(100).Build();


            public Builder WithName(string name)
            {
                _image.Name = name;
                return this;
            }

            public Builder WithSize(int size)
            {
                _image.Size = size;
                return this;
            }

            public image Build()
            {
                return _image;
            }
        }
        class imageGallery
        {
            //Dependency 
            ShareManager _shareManager;
            //Constructure Dependency Injection
            public imageGallery(ShareManager shareManager)
            {
                this._shareManager = shareManager;            
            }

            List<image> images = new List<image>();
            public void AddImage(image newimage)
            {
                images.Add(newimage);
            }
            public image[] getAllImages()
            {
                return images.ToArray();
            }
            public void share(string selectedImage)
            {
                foreach (image image in images)
                {
                    if(image.Name == selectedImage)
                    {
                        _shareManager.send(image);
                        break;
                    }
                }
            }
        }
        class WhatsUpApp
        {
            public void send(image content)
            {
            }
        }
        class Bluetooth
        {
            public void Transfer(image content)
            {
            }
        }
        class MialApp
        {
            public void ComposeMail(image attachment)
            {
                
            }
        }
        enum MessagerAppNames
        {
                WHATSUP,EMAIL,BLUETOOTH
        }
        class ShareManager
        {
            Dictionary<MessagerAppNames, IMessangerApp> _messengerApps;
            public ShareManager(Dictionary<MessagerAppNames,IMessangerApp> messangerApps)
            {
                this._messengerApps = messangerApps;  
            }
            public void send(image selectedImage,MessagerAppNames appNames)
            {
                _messengerApps[appNames].Send(selectedImage);
            }
        }



        public interface IMessangerApp
        {
            public void Send(image selectedImage)
            {
            }
        }
        internal class AppDomain
        {
            //public static AppDomainSetup(string[] args)
            //{
            //    string v = "hi therer";
            //}
            public static Main(string[] args)
            {

                Dictionary<MessagerAppNames, IMessangerApp> messageApps = new Dictionary<MessagerAppNames, IMessangerApp>();
                messageApps.Add(MessagerAppNames.WHATSUP, new WhatsUpApp());
                messageApps.Add(MessagerAppNames.BLUETOOTH, new BluetoothApps());
                messageApps.Add(MessagerAppNames.EMAIL, new MialApp());
                imageGallery imagess = new imageGallery();
                image i = new image();
                Console.WriteLine("enter the name o fthe immage ");
                i.Name = Console.ReadLine();
                Console.WriteLine("enter the size of the imagee ");
                i.Size = int.Parse(Console.ReadLine());
                Console.WriteLine("**************************/n 1-> ADD IMAGE 2->VIEW IMAGE 3->SHARE IMAGE ");
                Console.WriteLine("LIST OF SHARE OPTIONS");
                Console.WriteLine(">>>>>>>>>>>>>>>/na->whatsapp");
                Console.WriteLine(">>>>>>>>>>>>>>>/nb->bluetooth");
                Console.WriteLine(">>>>>>>>>>>>>>>/nc->E-mail");
                string choice = Console.ReadLine();
                //OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    string imagePath = openFileDialog.FileName;
                //    Image image = Image.FromFile(imagePath);
                //    // Do something with the image
                //}    soo this is what i get the demo part 
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("enter the name and addres of the image");
                        imagess.AddImage(i);
                        break;
                    case "2":
                        imagess.getAllImages();
                        break;
                    case "3":

                        imagess.share(i.Name);
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                WhatsUpApp whats = new WhatsUpApp();
                                whats.send(i);
                                break;
                            case "2":
                                Bluetooth blue = new Bluetooth(); 
                                blue.Transfer(i);
                                break;
                            case "3":
                                MialApp mail = new MialApp();
                                mail.ComposeMail(i);
                                break;
                        }
                        break;
                 return ;
                }
            }
        }
    }
}

           
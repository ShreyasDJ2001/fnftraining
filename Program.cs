using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        //static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SampleFile.csv");
        static void Main(string[] args)
        {
            //displayNameAndAddress();
            //displayAllDetails("C:\\Users\\6143439\\Documents\\demo");
            //Get all pdf documents from a givn=en folder and display 
            //displayAllPDF("C:\\Users\\6143439\\Downloads");                  //dpone by me
            //displayPDFDOCdetails("C:\\Users\\6143439\\Downloads");            //done by sir 

            //var fs = File.Create(fileName);
            //fs.Close();
            //File.WriteAllText(fileName, "hi there shreyas how u doing ");
            //File.AppendAllText(fileName, "i am doing fine how about u babes");
            //var content = File.ReadAllText(fileName);
            //Console.WriteLine(content);
            //var empDetails = creatEmployee();
            //File.AppendAllText("Data.csv",empDetails.ToString());
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   
            copyPdfTOMyFiles("C:\\Users\\6143439\\Downloads");
        }

       

        private static void copyPdfTOMyFiles(string  folderPath)
        {
            string Destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyFiles");
            var files= Directory.GetFiles(folderPath,"*.pdf");
            Directory.CreateDirectory(Destination);
            foreach (var file in files)
            {
                var fs= new FileInfo(file);
                var newfile= File.Create(Path.Combine(Destination,fs.Name));
                newfile.Close();
                File.Copy(file, newfile.Name,true);
            }
        }
        private static void displayAllPDF(string path)
        {
            
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (Path.GetExtension(file).ToLower() == ".pdf") 
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string FileName = fileInfo.Name;
                    long FileSize = fileInfo.Length;
                    DateTime CreationDate = fileInfo.CreationTime;

                    Console.WriteLine(FileName);
                    Console.WriteLine(FileSize);
                    Console.WriteLine(CreationDate.ToString());
                    Console.WriteLine();
                } 
            }
            Console.ReadLine();
        }

        public static void displayPDFDOCdetails(string folderpath)
        {
            var entries =Directory.GetFiles(folderpath, "*.pdf");
            foreach (var entry in entries)
            {
                Console.WriteLine("FileName:" + entry);
                var time = File.GetCreationTime(entry);
                FileAttributes attributes = File.GetAttributes(entry);
                Console.WriteLine("File Created time: " + time.ToString("dd/mm/yyyy"));
                var security = File.GetLastAccessTime(entry);
                //var owner = security.GetOwner(typeof(System.Security.Principal.NTAccount));
                //Console.WriteLine("Owner:" + owner.Value);
            }
        }
        public static void displayAllDetails(string path)
        {
            var entries = Directory.GetFileSystemEntries(path);
            foreach(var entry in entries)
            {
                FileAttributes attributes=File.GetAttributes(entry);
                if(attributes == FileAttributes.Directory)
                {
                    Console.WriteLine($"Directory Name:{entry}");
                    var tempList= Directory.GetFiles(entry);
                    foreach(var file in tempList)
                    {
                        Console.WriteLine(file);
                    }
                   
                }
                else
                {
                    Console.WriteLine($"File name :{entry}");
                }
            }

            
        }

        private static void displayNameAndAddress()
        {
            var records = getRecoredsFromCSVFile();
            foreach (var record in records)
            {
                Console.WriteLine(record.EmpName);
                Console.WriteLine(record.EmpSalary);
                Console.WriteLine(record.EmpAddress);

            }

        }
        static List<Employee> getRecoredsFromCSVFile()
        {
            List<Employee> records = new List<Employee>();
            const string csvFile = "../../../myData.csv.csv";
            if(!File.Exists(csvFile))
            {
                Console.WriteLine("file path is wrong ");

            }
            else
            {
                var lines = File.ReadAllLines(csvFile);
                foreach(var line in lines)
                {
                    var words=line.Split(',');
                    var rec = new Employee();
                    rec.EmpId = Convert.ToInt32(words[0]);
                    rec.EmpName = words[1];
                    rec.EmpSalary =Convert.ToInt32(words[2]);
                    rec.EmpAddress = words[3];
                    records.Add(rec);
                }
            }
            return records;


        }

        private static object creatEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name:");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Employee Address:");
            string empAddress = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary:");
            int empSalary = Convert.ToInt32(Console.ReadLine());

            Employee emp = new Employee();
            emp.EmpId = empId;
            emp.EmpName = empName;
            emp.EmpAddress = empAddress;
            emp.EmpSalary = empSalary;

            return emp;
        }
    }
}

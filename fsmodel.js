//working on Filesystem..
const fs = require('fs');

const path = require('path'); //

//fs  module contains APIs FOR io operations .NODEjs a=support both Sync and async functions to perform IO ops .

const filename = "./Ex04Fs.js";
// const contents =fs.readFileSync(filename,"utf-8");
// console.log(contents)

//////////////// example on Async file Reading ///////////

// fs.readFile(filename,"utf-8",(err,data )=>{
//     if(err)console.log(err)
//     else{
//         console.log(data)
//     }
// })

// console.log("first line of the code ")

//////////////example on sync file writing //////////

// const obj={};
// obj.id=123;
// obj.name="testname";
// obj.address="tesataddress";

// fs.writeFileSync("sampletext.txt",JSON.stringify(obj),'utf-8');
// console.log("the file is written completly");

// const obj={ };
// obj.id=123;obj.name="shreyas";obj.address="testaddress";
// let data =`,${JSON.stringify(obj)}`

// fs.appendFileSync("sampletext.txt",data,'utf-8');
// console.log("the file  is updated ")


//////////////// example for async filr writing 

const obj = {};
obj.id = 123;
obj.name = "shreyas";


fs.writeFile("sampletxt.txt", JSON.stringify(obj), 'utf-8');
console.log("async is written");
// fs.appendFile("sampletext.txt",JSON.stringify(obj),'utf-8')

//to store the obj in the form of csv file

const dataDirectory = "C:\myTraining\mtintership_training\node-js"; //added the directory 

const csvFileName = "data.csv";
const csvFilePath = path.join(dataDirectory, csvFileName); // add the csv file to the existing path 
const obj1 = [{
        id: 124,
        name: "shreyas"
    },
    { id: 125, name: "suhas" }
];
// array of object to store the data


const csvHeader = Object.keys(data[0].join(',')); // this represent the header row of the csv file 
const csvRows = data.map(obj => Object.values(obj).join(',')).join('\n'); //represent the data row of the csv file

fs.writeFileSync("csvFilePath", `\n${csvHeader}\n${csvRows}`); //write teh header rwo adn the data row to the csv file 
console.log(`data has been added to the csv filr `)
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Baitapmodule
{
    class Bai1
    {
        //public CreateData input = new CreateData();
        //public Variable variables = new Variable();
        const int numberVariable = 3;
        const string parameter_1 = "a";
        const string parameter_2 = "b";
        const string parameter_3 = "c";

        static void Main(string[] args)
        {
            var filePath = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\inputData.json";
            var outfilePath1 = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\output1.json";
            var outfilePath2 = $@"E:\CODEGYM\Module2\Baitapmodule\Baitapmodule\Data\output2.json,";
            var result = new Data();

            // write data in inputData.json

            //using (StreamWriter sw = File.CreateText(filePath))
            //{
            //    NewInput newInput = new NewInput();
            //    newInput.inputData = CreateInputData();
            //    var datainput = JsonConvert.SerializeObject(newInput);
            //    sw.Write(datainput);
            //}

            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Data>(data);
            }


            // output1Data

            var response = new Response();
            response.outputData = result.inputData;
            foreach (var std in response.outputData)
            {
                int sum = 0;
                foreach (var item in std)
                {
                    sum += item.score;
                }
                std.Add(new Parameter() { name = $"Sum({parameter_1}, {parameter_2}, {parameter_3})", score = sum });
            }

            using (StreamWriter sw = File.CreateText(outfilePath1))
            {
                var data = JsonConvert.SerializeObject(response);
                sw.Write(data);
            }



            // output2Data

            //var response_1 = new Response();
            //response_1.outputData = result.inputData;
            //foreach (var std in response_1.outputData)
            //{               
            //    foreach (var item in std)
            //    {
            //       item.score *= 2;
            //    }                
            //}
            //using (StreamWriter sw = File.CreateText(outfilePath2))
            //{
            //    var data = JsonConvert.SerializeObject(response_1);
            //    sw.Write(data);
            //}
            //Console.ReadKey();
        }
        
        // method write data
        public static List<List<Parameter>> CreateInputData()
        {
            List<List<Parameter>> createdata = new List<List<Parameter>>();
            List<string> parameters = new List<string> { parameter_1, parameter_2, parameter_3 };
            for (int i = 0; i < numberVariable; i++)
            {
                List<Parameter> variables = new List<Parameter>();
                for (int j = 0; j < parameters.Count; j++)
                {
                    bool result; int number;
                    Parameter parameter = new Parameter();
                    parameter.name = parameters[j];
                    do
                    {
                        Console.Write($"Input value {parameters[j]}: ");
                        result = int.TryParse(Console.ReadLine(), out number);
                    } while (!result);
                    parameter.score = number;
                    variables.Add(parameter);
                }
                createdata.Add(variables);
                Console.WriteLine();
            }
            return createdata;
        }


    }
    public class NewInput
    {
        public List<List<Parameter>> inputData { get; set; }
    }


    public class Data
    {
        public List<List<Parameter>> inputData { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        public int score { get; set; }
        public override string ToString()
        {
            return $"{name} = {score}";
        }

    }
    public class Response
    {
        public List<List<Parameter>> outputData { get; set; }
    }

    
}

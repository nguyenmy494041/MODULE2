using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Baitapmodule
{
    class Bai1
    {
        public CreateData input = new CreateData();
        public Variable variables = new Variable();
        const int numberVariable = 2;
        const int numberObject = 2;
        static void Main(string[] args)
        {
            var filePath = $@"C:\Users\USER\source\repos\Baitapmodule\Baitapmodule\Data\inputData.json";
            using (StreamWriter sw = File.CreateText(filePath))
            {

               
                List<List<Parameter>> createdata = CreateVariable();
                
                var data = JsonConvert.SerializeObject(createdata);
                sw.Write(data);
            }


        }
        public void CreateData(StreamWriter sw)
        {

        }
        public static List<List<Parameter>> CreateVariable()
        {
            List<List<Parameter>> createdata = new List<List<Parameter>>();

            for (int i = 0; i < numberVariable; i++)
            {
                List<Parameter> variables = new List<Parameter>();
                for (int j = 0; j < numberVariable; j++)
                {
                    Parameter parameter = new Parameter();
                    Console.Write("Input name properties: ");
                    parameter.name = Console.ReadLine();
                    Console.Write("Input value proerties: ");
                    parameter.score = int.Parse(Console.ReadLine());
                    variables.Add(parameter);
                }
                createdata.Add(variables);
            }
            return createdata;
        }

        //public static CreateData CreateVariable()
        //{
        //    CreateData createdata = new CreateData();

        //    for (int i = 0; i < numberVariable; i++)
        //    {
        //        Variable variables = new Variable();
        //        for (int j = 0; j < numberVariable; j++)
        //        {
        //            Parameter parameter = new Parameter();
        //            Console.Write("Input name properties: ");
        //            parameter.name = Console.ReadLine();
        //            Console.Write("Input value proerties: ");
        //            parameter.score = int.Parse(Console.ReadLine());
        //            variables.variables.Add(parameter);
        //        }
        //        createdata.data.Add(variables);
        //    }
        //    return createdata;
        //}
    }
    public class CreateData
    {
        public List<Variable> data { get; set; }
    }
    public class Variable
    {
        public List<Parameter> variables { get; set; }
        public override string ToString()
        {
            string result = "";
            foreach (var item in variables)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }

    public class Parameter
    {
        public string name { get; set; }
        public int score { get; set; }
        public override string ToString()
        {
            return $"{name} {score}";
        }
    }
}

using System;
using Systsem.Collections.Generic;
using System.Globalization;
//Tasks
//5-6 neurons
//construct own machine learning model without externa libraries
//use back propogation
//output a percentage chance for a rise on a given day after analysing a of stock prices
//check actual return
//bounds : >0.5 = stock likely to go up, <0.5 = stock likely to go down
//compare 

namespace NvidiaStockPriceNeuralNetwork;

class Program{
    static void Main(){
        List<double> prices = LoadPrices("data.csv"); // going to be the function to fetch the prices
        int window_size = 5;

        List<(double[] inputs, double target)> training_data = BuildTrainingData(prices, window_size);

        NeuralNetwork network = new NeuralNetwork(input_size: 5, hidden_size: 4);

        for (int i = 0; i<1000; i++){
            double total_error=0;
            foreach (var sample in training_data){
                total_error += network.Train(sample.inputs, sample.target);
            }
            if (i %100 == 0){
                Console.WriteLine($"Epoch {i} error: {total_error:F4}");
            }
        }
        Console.WriteLine("\n ---Predictions-- \n");

        foreach (var sample in training_data.Take(10)){
            double prediction = network.Forward(sample.inputs);
            Console.WriteLine($"Prediction: {prediction:F4} | Target: {sample.target}");
        }
    }
    static List<double> LoadPrices(string path){
        List<double> prices = new();

        string[] lines = File.ReadAllLines(path);

        for (int i = 0; i < lines.Length; i++){
            string[] columns = lines[i].Split(',');

            double close = double.Parse(columns[1], CultureInfo.InvariantCulture);
            prices.Add(close);
        }
        return prices;
    }
    static List<(double[] inputs, double target)> BuildTrainingData(List<double> prices, int window_size){
        List<(double[] Inputs, double Target)> data = new();
    }
}
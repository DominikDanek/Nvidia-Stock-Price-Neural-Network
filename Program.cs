using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

namespace NvidiaStockPriceNeuralNetwork;

class Program{
    static void Main(){
        List<double> prices = LoadPrices("data.csv"); // going to be the function to fetch the prices
        int window_size = 5;

        List<(double[] inputs, double target)> all_data = BuildTrainingData(prices, window_size);

        int split = (int)(all_data.Count * 0.8); // 4:1 train/test split
        List<(double[] inputs, double target)> train_set = all_data.Take(split).ToList();
        List<(double[] inputs, double target)> test_set = all_data.Skip(split).ToList();

        NeuralNetwork network = new NeuralNetwork(input_size: 5, hidden_size: 4);

        for (int i = 0; i<1000; i++){
            double total_error=0;
            foreach (var sample in train_set){
                total_error += network.Train(sample.inputs, sample.target);
            }
            if (i %100 == 0){
                Console.WriteLine($"Epoch {i} error: {total_error:F4}");
                //indicates how wrong the model was for each sample size
                //if number decreases during itteration, indicates model is getting smarter
            }
        }
        Console.WriteLine("\nEvaluation of Model performance on unseen data:\n");

        int correct_predictions = 0;
        int total = test_set.Count;

        foreach (var sample in test_set){
            double output = network.Forward(sample.inputs);

            int predicted = output > 0.5 ? 1: 0;
            int actual = sample.target > 0.5 ? 1: 0;

            if (predicted == actual){
                correct_predictions++;
            }
        }
        double accuracy = (double)correct_predictions/total * 100;
        Console.WriteLine($"Correct prediction: {correct_predictions}/{total}");
        Console.WriteLine($"Accuracy = {accuracy:F2}%");

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
        List<(double[] inputs, double target)> data = new();
        for (int i = 0; i < prices.Count - window_size - 1; i++){
            double[] inputs = new double[window_size];
            double first_price = prices[i];

            // noramlise inputs
            for (int j = 0; j < window_size; j++){
                inputs[j] = prices[i+j]/first_price;
            }
            double current_price = prices[i + window_size-1];
            double next_price = prices[i + window_size];

            double target = next_price > current_price ? 1.0 : 0.0;
            data.Add((inputs, target));
        }
        return data;
    }
}
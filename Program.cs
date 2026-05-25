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

    NeuralNetwork network = 
    }
}
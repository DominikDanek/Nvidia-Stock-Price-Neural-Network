using System;


class NeuralNetwork{
    double[,] hidden_weights;
    double[] hidden_biases;
    double[] output_weights;
    double output_bias;
    double learning_rate = 0.01;
    static int Forward(){
        
    }
    public neuralNetwork(int input_size, int hidden_size){
        //hidden weights
        //hidden biases
        //output weights
    }
    void initialiseWeights(){
    }
    double randomWeight(){
        return (random.NextDouble() *2) -1;
    }
    public double Forward(double[] inputs){

    }
    public double Train(double[] inputs, double target){

    }
    double sigma(double x){
        return 1.0 / (1.0 + Math.Exp(-x));
    }
    double sigmaDerivative(double output){
        return output * (1 - output);
    }
}
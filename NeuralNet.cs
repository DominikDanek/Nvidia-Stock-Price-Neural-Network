using System;


class NeuralNetwork{
    double[,] hidden_weights;
    double[] hidden_biases;
    double[] output_weights;
    double output_bias;
    double learning_rate = 0.01;
    static int Forward(){
        
    }
    public NeuralNetwork(int input_size, int hidden_size){
        //hidden weights
        //hidden biases
        //output weights
        hidden_weights = new double[hidden_size, input_size];
        hideen_biases = new double[hidden_size];
        output_weights = new double[hidden_size];
        initialiseWeights();
    }
    void initialiseWeights(){
        for (int h = 0; h < GetLenght(0); h++){
            for (int i = 0; i < GetLength(1); i++){
                hidden_weights[h,i] = randomWeight();
            }
            hidden_biases[h] = randomWeight();
            output_weights[h] = randomWeight();
        }
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
using System;


class NeuralNetwork{
    double[,] hidden_weights;
    double[] hidden_biases;
    double[] output_weights;
    double output_bias;
    double learning_rate = 0.01;
    public NeuralNetwork(int input_size, int hidden_size){
        hidden_weights = new double[hidden_size, input_size];
        hidden_biases = new double[hidden_size];
        output_weights = new double[hidden_size];
        initialiseWeights();
    }
    void initialiseWeights(){
        for (int h = 0; h < hidden_weights.GetLength(0); h++){
            for (int i = 0; i < hidden_weights.GetLength(1); i++){
                hidden_weights[h,i] = randomWeight();
            }
            hidden_biases[h] = randomWeight();
            output_weights[h] = randomWeight();
        }
        output_bias = randomWeight();
    }
    double randomWeight(){
        Random random = new Random();
        return (random.NextDouble() *2) -1;
    }
    public double Forward(double[] inputs){
        double[] hidden_outputs = new double[hidden_weights.GetLength(0)];

        //hidden layer
        for (int h = 0; h < hidden_outputs.Length; h++){

            double sum = 0;
            for (int i = 0; i < inputs.Length; i++){
                sum +=inputs[i] * hidden_weights[h, i];
            }
            sum += hidden_biases[h];
            hidden_outputs[h] = sigma(sum);
        }
        //output layer
        double output_sum = 0;
        for (int h = 0; h < hidden_outputs.Length; h++){
            output_sum += hidden_outputs[h] * output_weights[h];
        }
        output_sum += output_bias;

        return sigma(output_sum);
    }
    public double Train(double[] inputs, double target){
        double[] hidden_outputs = new double[hidden_weights.GetLength(0)];


        //forward pass
        for (int h = 0; h < hidden_outputs.Length; h++)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Length; i++){
                sum += inputs[i] *hidden_weights[h, i];
            }
            sum += hidden_biases[h];

            hidden_outputs[h] = sigma(sum);
        }
        double output_sum = 0;

        for (int h= 0; h < hidden_outputs.Length; h++){
            output_sum += hidden_outputs[h]*output_weights[h];
        }

        output_sum+= output_bias;

        double output = sigma(output_sum);
        //calculate error
        double error = target - output;

        //output gradient
        double output_gradient =error * sigmaDerivative(output);

        for (int h = 0; h < hidden_outputs.Length; h++){
            output_weights[h] += learning_rate *output_gradient *hidden_outputs[h];
        }

        //update the output weights
        for (int h = 0; h < hidden_outputs.Length; h++){
            output_weights[h] += learning_rate *output_gradient *hidden_outputs[h];
        }
        for (int h = 0; h < hidden_outputs.Length; h++){
            double hidden_gradient = output_gradient *output_weights[h] *sigmaDerivative(hidden_outputs[h]);

            for (int i = 0; i < inputs.Length; i++){
                hidden_weights[h, i] += learning_rate *hidden_gradient *inputs[i];
            }
            hidden_biases[h] +=learning_rate *hidden_gradient;
        }

        return error * error;
    }
    double sigma(double x){
        return 1.0 / (1.0 + Math.Exp(-x));
    }
    double sigmaDerivative(double output){
        return output * (1 - output);
    }
}
# StockNNFromScratch

A small feedforward neural network written completely from scratch in C#.

This project is designed for learning purposes and demonstrates the core ideas behind machine learning without using external ML libraries.

The model attempts to predict whether a stock's closing price will increase or decrease the next day using a fixed window of previous closing prices.

---

# Project Goal

The purpose of this project is **not** to build a profitable trading model.

The goal is to understand:

- Feedforward neural networks
- Neurons and weights
- Activation functions
- Error/loss calculation
- Backpropagation
- Gradient descent
- Training on historical data

Everything is implemented manually in C#.

---

# How the Model Works

The network learns patterns from previous stock closing prices.

Example:

| Day | Close |
|---|---|
| 1 | 100 |
| 2 | 101 |
| 3 | 102 |
| 4 | 99 |
| 5 | 98 |
| 6 | ? |

If the input window size is 5:

Input:

```text
[100, 101, 102, 99, 98]
```

Target:

```text
0
```

because the next day's price decreased.

The network outputs a value between 0 and 1:

- Closer to 1 = predict price increase
- Closer to 0 = predict price decrease

---

# Neural Network Architecture

The network contains:

- Input layer
- One hidden layer
- Output layer

Example architecture:

```text
5 Inputs
   ↓
4 Hidden Neurons
   ↓
1 Output Neuron
```

---

# CSV Dataset Format

The dataset only needs daily closing prices.

Example:

```csv
Date,Close
2024-01-01,100.25
2024-01-02,101.10
2024-01-03,99.80
2024-01-04,100.50
```

Only the `Close` column is used.

---

# Data Preprocessing

## Sliding Window

The model uses a fixed number of previous prices as input.

Example with window size 5:

```text
[100, 101, 102, 99, 98]
```

becomes one training sample.

---

## Normalization

Raw stock prices can be difficult for a neural network to learn from.

Each window is normalized relative to the first value.

Formula:

```math
normalized = price / firstPriceInWindow
```

Example:

```text
[100, 101, 102, 99, 98]
```

becomes:

```text
[1.0, 1.01, 1.02, 0.99, 0.98]
```

---

# Core Concepts

# 1. Neurons

A neuron receives inputs, multiplies them by weights, adds a bias, and produces an output.

Formula:

```math
z = \sum (x_i w_i) + b
```

Where:

- `x_i` = input value
- `w_i` = weight
- `b` = bias
- `z` = weighted sum

Example:

```text
z = (1.0 × 0.2)
  + (1.01 × -0.1)
  + (0.99 × 0.4)
  + bias
```

---

# 2. Weights

Weights determine how important an input is.

Large positive weight:

- increases neuron output

Large negative weight:

- decreases neuron output

Weights are adjusted during training.

---

# 3. Bias

Bias allows the neuron to shift its output independently of inputs.

Without a bias, the neuron would be too limited.

Formula:

```math
z = \sum (x_i w_i) + b
```

---

# 4. Activation Function

The weighted sum is passed through a sigmoid activation function.

Sigmoid converts any number into a value between 0 and 1.

Formula:

```math
\sigma(x) = \frac{1}{1 + e^{-x}}
```

Properties:

- Output close to 1 = stronger confidence in upward movement
- Output close to 0 = stronger confidence in downward movement

Example:

```text
sigmoid(2.0)  = 0.88
sigmoid(-2.0) = 0.12
```

---

# Forward Propagation

Forward propagation is the process of sending inputs through the network.

Flow:

```text
Input Prices
    ↓
Weighted Sums
    ↓
Activation Functions
    ↓
Hidden Layer Outputs
    ↓
Final Output Prediction
```

---

## Hidden Layer Calculation

Each hidden neuron computes:

```math
h_j = \sigma\left(\sum_i x_i w_{ij} + b_j\right)
```

Where:

- `x_i` = inputs
- `w_{ij}` = weights
- `b_j` = hidden neuron bias
- `h_j` = hidden neuron output

---

## Output Layer Calculation

The output neuron uses hidden layer outputs as input.

Formula:

```math
o = \sigma\left(\sum_j h_j w_j + b\right)
```

Where:

- `h_j` = hidden neuron outputs
- `w_j` = output weights
- `o` = final prediction

---

# Prediction Interpretation

The final output is interpreted as:

| Output | Meaning |
|---|---|
| > 0.5 | Predict price increase |
| < 0.5 | Predict price decrease |

Example:

```text
0.82 → likely increase
0.14 → likely decrease
```

---

# Error / Loss Calculation

After making a prediction, the network compares it to the correct answer.

This difference is called the loss or error.

The project uses Mean Squared Error.

Formula:

```math
E = \frac{1}{2}(target - output)^2
```

Where:

- `target` = expected result
- `output` = network prediction
- `E` = error

Example:

```text
target = 1
output = 0.7

error = 0.045
```

---

# Backpropagation

Backpropagation is the learning process.

The network:

1. Measures prediction error
2. Calculates how much each weight contributed to the error
3. Adjusts weights slightly to reduce future error

---

# Gradient Descent

Weights are updated using gradient descent.

Formula:

```math
w_{new} = w_{old} - \eta \frac{\partial E}{\partial w}
```

Where:

- `w` = weight
- `E` = error
- `η` = learning rate
- `∂E/∂w` = gradient

The gradient tells the network:

- which direction reduces error
- how large the adjustment should be

---

# Learning Rate

The learning rate controls how aggressively weights change.

Small learning rate:

- slower learning
- more stable

Large learning rate:

- faster learning
- may become unstable

Typical value:

```text
0.01
```

---

# Training Process

Training repeatedly feeds data through the network.

Pseudo process:

```text
for each epoch:
    for each training sample:
        forward propagation
        calculate error
        backpropagation
        update weights
```

Over time:

- prediction error decreases
- weights improve
- network learns patterns

---

# Expected Limitations

This project is intentionally simple.

It is not intended to:

- beat financial markets
- produce accurate trading signals
- compete with professional ML systems

The focus is educational.

---

# Why Build It From Scratch?

Implementing everything manually helps build understanding of:

- matrix operations
- gradient descent
- activation functions
- optimization
- neural network structure

Libraries like TensorFlow hide these details.

This project exposes the underlying mechanics.

---

# Example Project Structure

```text
/StockNNFromScratch
│
├── Program.cs
├── NeuralNetwork.cs
├── CsvLoader.cs
├── TrainingSample.cs
└── data/
    └── stock_data.csv
```

---

# Future Improvements

Possible future additions:

- Multiple hidden layers
- ReLU activation
- Additional stock indicators
- Volume data
- Better normalization
- Mini-batch training
- Saving/loading trained weights
- Predicting actual percentage changes

---

# Technologies Used

- C#
- .NET
- No external ML libraries

---

# Educational Purpose

This repository exists to demonstrate the fundamentals of machine learning and neural networks through a fully manual implementation.


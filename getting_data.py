import yfinance as yf
import pandas as pd

ticker = "NVDA"

data = yf.download(
    ticker,
    start="2010-01-01",
    end="2026-12-31"
)

df = data[["Close"]].reset_index()

df.columns = ["Date", "Close"]
df["Close"] = df["Close"].round(3)

csv_filename = "data.csv"
df.to_csv(csv_filename, index=False)

print(f"CSV file saved as: {csv_filename}")
print(df.head())
import pandas as pd

df = pd.read_excel("bridge.xlsx")

with open("bridge-table-values.txt", "w", encoding='utf-8') as f:
    f.write("INTERT INTO bridge\n")
    f.write("VALUES")
    for i in range(df.shape[0]):
        f.write("\t\t(")
        for j in range(df.shape[1]):
            if j < df.shape[1] - 1:
                f.write(f"'{df.iloc[i, j]}',")
            else:
                f.write(f"'{df.iloc[i, j]}',''),\n")


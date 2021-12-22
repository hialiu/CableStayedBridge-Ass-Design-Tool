import sys
try:
    import matplotlib.pyplot as plt
except ImportError:
    print("matplotlib is not installed, use 'pip install matplotlib' in cmd please.")
    exit(1)

try:
    import numpy as np
except ImportError:
    print("numpy is not installed, use 'pip install numpy' in cmd please.")
    exit(1)

# L:跨径数组，用+号连接，H：塔柱高度数组，dOnTown:塔上索距，dOnTown:梁上索距，
# startloc:可选参数表示第一根拉索在塔上位置占上塔柱比例，省略则默认 2/3
def Draw(L, H, dOnBeam, dOnTown, startLoc):
    townNum = len(L) - 1  #塔的数量
    Ys = np.arange(int(H[1] * startLoc), int(H[1] - 2), dOnTown) # 起点，终点，步长

    plt.plot([0, sum(L)], [0, 0], 'k')
    for i in range(townNum):
        townLocX = sum(L[:i + 1])
        plt.plot([townLocX]*2, [-H[0], H[1]], "red")
            
        if townNum == 1:
            for i in range(townNum):
                townLocX = sum(L[:i + 1])
                plt.plot([townLocX]*2, [-H[0], H[1]], "red")
                for j in range(len(Ys)):
                    if townLocX + dOnBeam*(j+1) > townLocX+L[i+1] and townLocX - dOnBeam*(j+1) < townLocX-L[i]:
                        break
                    plt.plot([max(townLocX-dOnBeam*(j+1), 0), townLocX, min(townLocX+dOnBeam*(j+1), sum(L))], [0, Ys[j], 0], "blue", lw=0.5)
        else:
            for i in range(townNum):
                townLocX = sum(L[:i + 1])
                plt.plot([townLocX]*2, [-H[0], H[1]], "red")
                for j in range(len(Ys)):
                    if townLocX + dOnBeam*(j+1) > townLocX+L[i+1]/2 and townLocX - dOnBeam*(j+1) < townLocX-L[i]/2:
                        break

                    if i == 0:
                        plt.plot([max(townLocX-dOnBeam*(j+1), 0), townLocX, townLocX+dOnBeam*(j+1)], [0, Ys[j], 0], "blue", lw=0.5)
                    elif i == townNum-1:
                        plt.plot([townLocX-dOnBeam*(j+1), townLocX, min(townLocX+dOnBeam*(j+1), sum(L))], [0, Ys[j], 0], "blue", lw=0.5)
                    else:
                        plt.plot([townLocX-dOnBeam*(j+1), townLocX, townLocX+dOnBeam*(j+1)], [0, Ys[j], 0], "blue", lw=0.5)


    plt.axis("equal")
    plt.axis("off")
    plt.savefig("temp.png", dpi=300)


def main():
    L = list(map(int, sys.argv[1].strip(",").split("+")))
    H = list(map(int, sys.argv[2].strip(",").split("+")))
    dOnBeam = int(sys.argv[3].strip(","))
    dOnTown = int(sys.argv[4].strip(","))
    try:
        startLoc = float(sys.argv[5].strip(",").split("/")[0]) / float(sys.argv[5].strip(",").split("/")[1])
    except:
        startLoc = 2/3

    Draw(L, H, dOnBeam, dOnTown, startLoc=startLoc)


if __name__ == "__main__":
    main()

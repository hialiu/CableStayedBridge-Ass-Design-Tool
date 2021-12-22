from sys import argv
from matplotlib.pyplot import plot, axis, savefig


def Draw(L, H, dOnBeam, dOnTown, startLoc):
    townNum = len(L) - 1
    if len(H) == 1:
        H = [H[0] * 0.25, H[0]]
    else:
        pass
    
    Ys = list(range(int(H[1] * startLoc), int(H[1] - 2), int(dOnTown)))

    plot([0, sum(L)], [0, 0], 'k')
    for i in range(townNum):
        townLocX = sum(L[:i + 1])
        plot([townLocX]*2, [-H[0], H[1]], "red")
            
        if townNum == 1:
            for i in range(townNum):
                townLocX = sum(L[:i + 1])
                plot([townLocX]*2, [-H[0], H[1]], "red")
                for j in range(len(Ys)):
                    if townLocX + dOnBeam*(j+1) > townLocX+L[i+1] and townLocX - dOnBeam*(j+1) < townLocX-L[i]:
                        break
                    plot([max(townLocX-dOnBeam*(j+1), 0), townLocX, min(townLocX+dOnBeam*(j+1), sum(L))], [0, Ys[j], 0], "blue", lw=0.5)
        else:
            for i in range(townNum):
                townLocX = sum(L[:i + 1])
                plot([townLocX]*2, [-H[0], H[1]], "red")
                for j in range(len(Ys)):
                    if townLocX + dOnBeam*(j+1) > townLocX+L[i+1]/2 and townLocX - dOnBeam*(j+1) < townLocX-L[i]/2:
                        break

                    if i == 0:
                        plot([max(townLocX-dOnBeam*(j+1), 0), townLocX, townLocX+dOnBeam*(j+1)], [0, Ys[j], 0], "blue", lw=0.5)
                    elif i == townNum-1:
                        plot([townLocX-dOnBeam*(j+1), townLocX, min(townLocX+dOnBeam*(j+1), sum(L))], [0, Ys[j], 0], "blue", lw=0.5)
                    else:
                        plot([townLocX-dOnBeam*(j+1), townLocX, townLocX+dOnBeam*(j+1)], [0, Ys[j], 0], "blue", lw=0.5)


    axis("equal")
    axis("off")
    savefig("temp.png", dpi=300)
    savefig("temp.svg", dpi=300)


def main():
    L = list(map(int, argv[1].strip(",").split("+")))
    H = list(map(int, argv[2].strip(",").split("+")))
    dOnBeam = float(argv[3].strip(","))
    dOnTown = float(argv[4].strip(","))
    try:
        startLoc = float(argv[5].strip(",").split("/")[0]) / float(argv[5].strip(",").split("/")[1])
    except:
        startLoc = 2/3

    Draw(L, H, dOnBeam, dOnTown, startLoc=startLoc)


if __name__ == "__main__":
    main()

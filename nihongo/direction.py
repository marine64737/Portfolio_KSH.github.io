import random

direction = [["上（うえ）", "위"],
             ["下（した）", "아래"], 
             ["前（まえ）", "앞"], 
             ["後ろ（うしろ）", "뒤"], 
             ["右（みぎ）", "오른쪽"], 
             ["左（ひだり）", "왼쪽"], 
             ["中（なか）", "안"], 
             ["外（そと）", "밖"], 
             ["そば", "옆"], 
             ["隣（となり）", "옆(같은 종류가 같은 방향으로 바로 옆에)"], 
             ["近く（ちかく）", "근처"], 
             ["間（あいだ）", "사이"]]
w=random.randint(1,2)
while (1):
    s=int(input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> "))
    if s==1:
        print("All Test")
        while 1:
            w=random.randint(1,2)
            if w==1:
                n=random.randint(0, len(direction)-1)
                print("Q(To Kr). {0}의 뜻(한글로)".format(direction[n][0]), end='')
                x=input()
                print("A. {0}".format(direction[n][1]))
                x=input("Next: Enter nth, To select other: Press Any key -> ")
                if x != "": break
            else:
                n=random.randint(0, len(direction)-1)
                print("Q(To Jp). {0}을(를) 일본어로".format(direction[n][1]), end='')
                x=input()
                print("A. {0}".format(direction[n][0]))
                x=input("Next: Enter nth, To select other: Press Any key -> ")
                if x != "": break
    elif s==2:
        print("Nihongo Test")
        while 1:
            n=random.randint(0, len(direction)-1)
            print("Q(To Kr). {0}의 뜻(한글로)".format(direction[n][0]), end='')
            x=input()
            print("A. {0}".format(direction[n][1]), end='')
            x=input("Next: Enter nth, To select other: Press Any key -> ")
            if x != "": break
    elif s==3:
        print("Korean Test")
        while 1:
            n=random.randint(0, len(direction)-1)
            print("Q(To Jp). {0}을(를) 일본어로".format(direction[n][1]), end='')
            x=input()
            print("A. {0}".format(direction[n][0]), end='')
            x=input("Next: Enter nth, To select other: Press Any key -> ")
            if x != "": break
    else: break
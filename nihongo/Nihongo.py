import pandas as pd
import numpy as np
import random
import csv
import openpyxl
from tabulate import tabulate

filename = 'nihongo.xlsx'

def File_Load():
    global b
    global df
    b=input("File Select. 1: Book 1, 2: Book 2, Q: Previous Menu -> ")
    while b!='q' and b!='Q':
        if b == '1': 
            df = pd.read_excel(filename, sheet_name='Book 1')
            break
        elif b == '2':
            df = pd.read_excel(filename, sheet_name='Book 2')
            break
        b=input("File Select. 1: Book 1, 2: Book 2, Q: Previous Menu -> ")
def File_Save(df, excel, sheet):
    while 1:
        s=input(f"Save to {excel}? (y/n) ")
        if s == "y" or "Y":
            with pd.ExcelWriter(excel, mode='a', if_sheet_exists='overlay') as w:
                df.to_excel(w, sheet_name= sheet, index=False)
            break
        elif s=="N" or "n":
            print("Canceled")
            break
def REM_Reset(df, col):
    r=input(f"Are you sure to reset {col} status? Yes: 1, Cancel: Q -> ")
    while r!='q' and r!='Q':
        if r=='1':
            for i in range(df.shape[0]):
                df.loc[i, col]=np.nan
            break
        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
        r=input(f"Are you sure to reset {col} status? Yes: 1, Cancel: Q -> ")
def REM_Reset_All(df):
    r=input("Are you sure to reset All REM status? Yes: 1, Cancel: Q -> ")
    while r!='q' and r!='Q':
        if r=='1':
            for i in range(df.shape[0]):
                df.loc[i, 'N2KREM']=np.nan
                df.loc[i, 'K2NREM']=np.nan
            break
        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
        r=input("Are you sure to reset All REM status? Yes: 1, Cancel: Q -> ")
def Nihongo_Test(df):
    while 1:
        n=random.randint(0, df.shape[0]-1)
        if pd.isna(df['N2KREM'][n]):
            if pd.isna(df['hurigana'][n]):
                x=input(f"Q. {df['nihongo'][n]}의 뜻(한글로) Quit: Q -> ")
                if x == 'Q' or x == 'q': break
            else:
                x=input(f"Q. {df['nihongo'][n]}({df['hurigana'][n]})의 뜻(한글로) Quit: Q -> ")
                if x == 'Q' or x == 'q': break
            x=input(f"A. {df['korean'][n]} Next: Enter, Memorize: Y, Quit: Any key -> ")
            if x != "" and x != "Y" and x != "y": break
            elif x == "Y" or x == "y": 
                df.loc[n, 'N2KREM'] = 1
def Nihongo_Test_Gen(df, ni, ko, hu=None):
    if hu == None:
        n=random.randint(0, df.shape[0]-1)
        print(f"Q. {df[ni][n]}의 뜻(한글로)", end='')
        input()
        print(f"A. {df[ko][n]}")
    else:
        n=random.randint(0, df.shape[0]-1)
        print(f"Q. {df[ni][n]}({df[hu][n]})의 뜻(한글로)", end='')
        input()
        print(f"A. {df[ko][n]}")
def Nihongo_Test_list(ls):
    while 1:
        n=random.randint(0, len(ls)-1)
        print("Q. {0}의 뜻(한글로)".format(ls[n][0]), end='')
        q=input()
        print("A. {0}".format(ls[n][1]))
        x=input("Next: Enter nth, To select other: Press Any key -> ")
        if x != "": break
def Korean_Test(df):
    while 1:
        n=random.randint(0, df.shape[0]-1)
        if pd.isna(df['K2NREM'][n]):
            if pd.isna(df['hurigana'][n]):
                print("Q. {0}을(를) 일본어로".format(df['korean'][n]))
            else:
                print("Q. {0}을(를) 일본어로".format(df['korean'][n]))
            x=input("Next: Enter nth, Complete to Memorize: Y or y, To select other: Press Any key -> ")
            if pd.isna(df['hurigana'][n]):
                print("A. {0}".format(df['nihongo'][n]))
            else:
                print("A. {0}({1})".format(df['nihongo'][n], df['hurigana'][n]))
            if x != "" and x != "Y" and x != "y": break
            elif x == "Y" or x == "y": 
                df.loc[n, 'K2NREM'] = 1

def Korean_Test_Gen(df, ni, ko, hu=None):
    if hu == None:
        n=random.randint(0, df.shape[0]-1)
        print(f"Q. {df[ko][n]}을(를) 일본어로", end='')
        input()
        print(f"A. {df[ni][n]}")
    else:
        n=random.randint(0, df.shape[0]-1)
        print(f"Q. {df[ko][n]}을(를) 일본어로", end='')
        input()
        print(f"A. {df[ni][n]}({df[hu][n]})")
def Korean_Test_list(ls):
    while 1:
        n=random.randint(0, len(ls)-1)
        print("Q. {0}을(를) 일본어로".format(ls[n][1]), end='')
        q=input()
        print("A. {0}".format(ls[n][0]))
        x=input("Next: Enter nth, To select other: Press Any key -> ")
        if x != "": break
def All_Test(excel, sheet, memo, df):
    while 1:
        w=random.randint(1,2)
        n=random.randint(0, df.shape[0]-1)
        if pd.isna(df['N2KREM'][n]) or pd.isna(df['K2NREM'][n]):
            if w==1 and pd.isna(df['N2KREM'][n]):
                print(f"(Nihongo 2 Korean To memorize: {df['N2KREM'].isnull().sum()}/ Total: {df.shape[0]}")
                if pd.isna(df['hurigana'][n]):
                    print(f"Q. {df['nihongo'][n]}의 뜻(한글로)", end='')
                else:
                    print(f"Q. {df['nihongo'][n]}({df['hurigana'][n]})의 뜻(한글로)", end='')
                input()
                print(f"A. {df['korean'][n]}")
                x=input(f"Next: Enter nth, Complete to Memorize: Y or y [{memo} mode], To select other: Press Any key -> ")
                if x != "" and x != "Y" and x != "y": break
                elif x == "Y" or x == "y":
                    df.loc[n, 'N2KREM'] = 1
                    if save == 1:
                        with pd.ExcelWriter(excel, mode='a', if_sheet_exists='overlay') as w:
                            df.to_excel(w, sheet_name= sheet, index=False)
            elif w==2 and pd.isna(df['K2NREM'][n]):
                print(f"(Korean 2 Nihongo To memorize: {df['K2NREM'].isnull().sum()}/ Total: {df.shape[0]}")
                print(f"Q. {df['korean'][n]}을(를) 일본어로", end='')
                input()
                if pd.isna(df['hurigana'][n]):
                    print(f"A. {df['nihongo'][n]}")
                else:
                    print(f"A. {df['nihongo'][n]}({df['hurigana'][n]})")
                x=input(f"Next: Enter nth, Complete to Memorize: Y or y [{memo} mode], To select other: Press Any key -> ")
                if x != "" and x != "Y" and x != "y": break
                elif x == "Y" or x == "y":
                    df.loc[n, 'K2NREM'] = 1
                    if save == 1:
                        with pd.ExcelWriter(excel, mode='a', if_sheet_exists='overlay') as w:
                            df.to_excel(w, sheet_name= sheet, index=False)
        elif not (pd.isnull(df['N2KREM']).values.any() or pd.isnull(df['K2NREM']).values.any()):
            print("Memorized All Word!")
            break
def All_Test_Gen(df, ni, ko, hu=None):
    w=random.randint(1,2)
    if w==1:
        Nihongo_Test_Gen(df, ni, ko, hu)
    else:
        Korean_Test_Gen(df, ni, ko, hu)
def All_Test_list(ls):
    while 1:
        w=random.randint(1,2)
        n=random.randint(0, len(ls)-1)
        if w==1:
            print("Q. {0}의 뜻(한글로)".format(ls[n][0]), end='')
            q=input()
            print("A. {0}".format(ls[n][1]))
            x=input("Next: Enter nth, To select other: Press Any key -> ")
            if x != "": break
        else:
            print("Q. {0}을(를) 일본어로".format(ls[n][1]), end='')
            q=input()
            print("A. {0}".format(ls[n][0]))
            x=input("Next: Enter nth, To select other: Press Any key -> ")
            if x != "": break
print("Japanese Test Start!")
while 1:
    save = 0
    mode = "Default"
    H = 'Home'
    print(f"[{H}]")
    s=input("1: Book, 2: Word, Q: Exit Program, -> ")
    while s != '1' and s != '2' and s != 'q' and s != 'Q':
        s=input("1: Book, 2: Word, Q: Exit Program, -> ")
    while s != 'q' and s != 'Q':
        if s=='1':
            SEL = 'Book'
            print(f"[{H} > {SEL}]")
            #File_Load()
            b=input("File Select. 1: Book 1, 2: Book 2, 3: Book 3, Q: Previous Menu -> ")
            while b != 'q' and b!= 'Q':
                if b == '1': 
                    df = pd.read_excel(filename, sheet_name='Book 1')
                elif b == '2':
                    df = pd.read_excel(filename, sheet_name='Book 2')
                elif b == '3':
                    df = pd.read_excel(filename, sheet_name='Book 3')
                else:
                    b=input("File Select. 1: Book 1, 2: Book 2, 3: Book 3, Q: Previous Menu -> ")
                    continue
                print(f"[{H} > {SEL} > {SEL} {b}]")
                sheet = SEL + b
                menu=input("1: Test, 2: View, 3: REM Reset, 4: Save, 5: Auto Save Mode, Q: Prev -> ")
                while menu!='q' and menu!='Q':
                    if menu=='1':
                        X = 'Test'
                        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                        lang=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                        while lang != 'q' and lang != 'Q':
                            if lang=='1':
                                L = "All"
                                print(f"[{H} > {SEL} > {SEL} {b} > {X} > {L} {X}]")
                                All_Test(filename, sheet, mode, df)
                            elif lang=='2':
                                L = "Nihongo"
                                print(f"[{H} > {SEL} > {SEL} {b} > {X} > {L} {X}]")
                                Nihongo_Test(df)
                            elif lang=='3':
                                L = "Korean"
                                print(f"[{H} > {SEL} > {SEL} {b} > {X} > {L} {X}]")
                                Korean_Test(df)
                            print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                            lang=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                    elif menu=='2':
                        X = 'View'
                        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                        print(tabulate(df, headers='keys', tablefmt='fancy_outline', showindex=True))
                    elif menu=='3':
                        X = 'REM Reset'
                        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                        r=input("Choose to reset REM status. 1. All, 2. Nihongo to Korean, 3. Korean to Nihongo, Cancel: Q -> ")
                        while r != 'Q' and r != 'q':
                            if r == '1':
                                REM_Reset_All(df)
                            elif r == '2':
                                REM_Reset(df, 'N2KREM')
                            elif r == '3':
                                REM_Reset(df, 'K2NREM')
                            print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                            r=input("Choose to reset REM status. 1. All, 2. Nihongo to Korean, 3. Korean to Nihongo, Cancel: Q -> ")
                    elif menu=='4':
                        X = 'Save'
                        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                        sheet = SEL + b
                        File_Save(df, filename, sheet)
                    elif menu=='5':
                        X = 'Auto Save mode'
                        print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                        if save == 1: mode = "Auto Save"
                        else: "Default"
                        s=input(f"Toggle Mode? [Now: {mode} Mode] Yes: 1, Cancel: Q -> ")
                        while s != 'Q' and s != 'q':
                            if s == '1':
                                if save == 0:
                                    save = 1
                                    mode = "Auto Save"
                                    print(f"Auto Save Mode On")
                                else:
                                    save = 0
                                    mode = "Default"
                                    print(f"Auto Save Mode Off")
                            print(f"[{H} > {SEL} > {SEL} {b} > {X}]")
                            s=input(f"Toggle Mode? [Now: {mode} Mode] Yes: 1, Cancel: Q -> ")
                    print(f"[{H} > {SEL} > {SEL} {b}]")
                    menu=input("1: Test, 2: View, 3: REM Reset, 4: Save, 5: Auto Save Mode, Q: Prev -> ")
                print(f"[{H} > {SEL} <- {SEL} {b}]")
                file=input("Load a new file(To Book): 1, Prev(To Home): Q -> ")
                while file != '1' and file != 'q' and file != 'Q':
                    print(f"[{H} > {SEL} <- {SEL} {b}]")
                    file=input("Load a new file(To Book): 1, Prev(To Home): Q -> ")
                if file=='1':
                    print(f"[{H} > {SEL}]")
                    b=input("File Select. 1: Book 1, 2: Book 2, Q: Previous Menu -> ")
                    continue
                else: break
        elif s=='2':
            SEL = 'Word'
            print(f"[{H} > {SEL}]")
            k = input("1: Direction, 2: Number 1, 3: Number 1-2, 4: Number 2, 5: Family, Q: Prev -> ")
            while k != 'q' and k != 'Q':
                T = 'Test'
                if k == '1':
                    df = pd.read_excel('nihongo.xlsx', sheet_name='EA 3')
                    K = 'Direction'
                    print(f"[{H} > {SEL} > {K} {T}]")
                    s=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                    while s!='q' and s!='Q':
                        if s=='1':
                            S = 'All'
                            print(f"[{H} > {SEL} > {K} {T} > {S} {T}]")
                            while 1:
                                All_Test_Gen(df, '방향_n', '방향_k', '방향_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='2':
                            S = 'Nihongo'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                Nihongo_Test_Gen(df, '방향_n', '방향_k', '방향_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='3':
                            S = 'Korean'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                Korean_Test_Gen(df, '방향_n', '방향_k', '방향_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        print(f"[{H} > {SEL} > {K} {T}]")
                        s=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                elif k == '2':
                    df = pd.read_excel('nihongo.xlsx', sheet_name='EA')
                    K = 'Number 1'
                    print(f"[{H} > {SEL} > {K} {T}]")
                    s=input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> ")
                    while s != 'q' and s != 'Q':
                        if s=='1':
                            S = 'All'
                            print(f"[{H} > {SEL} > {K} {T} > {S} {T}]")
                            while 1:
                                w=random.randint(1,6)
                                if w==1:
                                    All_Test_Gen(df, '엔_n', '엔_k')
                                elif w==2:
                                    All_Test_Gen(df, '개_n', '개_k')
                                elif w==3:
                                    All_Test_Gen(df, '장_n', '장_k')
                                elif w==4:
                                    All_Test_Gen(df, '자루/병_n', '자루/병_k')
                                elif w==5:
                                    All_Test_Gen(df, '권_n', '권_k')
                                else:
                                    All_Test_Gen(df, '층_n', '층_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='2':
                            S = 'Nihongo'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(1,6)
                                if w==1:
                                    Nihongo_Test_Gen(df, '엔_n', '엔_k')
                                elif w==2:
                                    Nihongo_Test_Gen(df, '개_n', '개_k')
                                elif w==3:
                                    Nihongo_Test_Gen(df, '장_n', '장_k')
                                elif w==4:
                                    Nihongo_Test_Gen(df, '자루/병_n', '자루/병_k')
                                elif w==5:
                                    Nihongo_Test_Gen(df, '권_n', '권_k')
                                else:
                                    Nihongo_Test_Gen(df, '층_n', '층_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='3':
                            S = 'Korean'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(1,6)
                                if w==1:
                                    Korean_Test_Gen(df, '엔_n', '엔_k')
                                elif w==2:
                                    Korean_Test_Gen(df, '개_n', '개_k')
                                elif w==3:
                                    Korean_Test_Gen(df, '장_n', '장_k')
                                elif w==4:
                                    Korean_Test_Gen(df, '자루/병_n', '자루/병_k')
                                elif w==5:
                                    Korean_Test_Gen(df, '권_n', '권_k')
                                else:
                                    Korean_Test_Gen(df, '층_n', '층_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        print(f"[{H} > {SEL} > {K} {T}]")
                        s=input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> ")
                elif k == '3':
                    df = pd.read_excel('nihongo.xlsx', sheet_name='EA')
                    K = 'Number 1-2'
                    print(f"[{H} > {SEL} > {K} {T}]")
                    s=input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> ")
                    while s != 'q' and s != 'Q':
                        if s=='1':
                            S = 'All'
                            print(f"[{H} > {SEL} > {K} {T} > {S} {T}]")
                            while 1:
                                All_Test_Gen(df, '개_n', '개_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='2':
                            S = 'Nihongo'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                Nihongo_Test_Gen(df, '개_n', '개_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='3':
                            S = 'Korean'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                Nihongo_Test_Gen(df, '개_n', '개_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                elif k == '4':
                    df = pd.read_excel('nihongo.xlsx', sheet_name='EA 2')
                    K = 'Number 2'
                    print(f"[{H} > {SEL} > {K} {T}]")
                    s=input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> ")
                    while s != 'q' and s != 'Q':
                        if s=='1':
                            S = 'All'
                            print(f"[{H} > {SEL} > {K} {T} > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    All_Test_Gen(df, '인원', '인원_k')
                                else:
                                    All_Test_Gen(df, '나이', '나이_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='2':
                            S = 'Nihongo'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    Nihongo_Test_Gen(df, '인원', '인원_k')
                                else:
                                    Nihongo_Test_Gen(df, '나이', '나이_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='3':
                            S = 'Korean'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    Korean_Test_Gen(df, '인원', '인원_k')
                                else:
                                    Korean_Test_Gen(df, '나이', '나이_k')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        print(f"[{H} > {SEL} > {K} {T}]")
                        s=input("1. All, 2: Nihongo, 3: Korean, Other: Any key -> ")
                elif k == '5':
                    df = pd.read_excel('nihongo.xlsx', sheet_name='Family')
                    K = 'Family'
                    print(f"[{H} > {SEL} > {K} {T}]")
                    s=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                    while s!='q' and s!='Q':
                        if s=='1':
                            S = 'All'
                            print(f"[{H} > {SEL} > {K} {T} > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    All_Test_Gen(df, '우리_n', '우리_k', '우리_h')
                                else:
                                    All_Test_Gen(df, '남_n', '남_k', '남_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='2':
                            S = 'Nihongo'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    Nihongo_Test_Gen(df, '우리_n', '우리_k', '우리_h')
                                else:
                                    Nihongo_Test_Gen(df, '남_n', '남_k', '남_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        elif s=='3':
                            S = 'Korean'
                            print(f"[{H} > {SEL} > {S} {T}] > {S} {T}]")
                            while 1:
                                w=random.randint(0,1)
                                if w==0:
                                    Korean_Test_Gen(df, '우리_n', '우리_k', '우리_h')
                                else:
                                    Korean_Test_Gen(df, '남_n', '남_k', '남_h')
                                x=input("Next: Enter nth, To select other: Press Any key -> ")
                                if x != "": break
                        print(f"[{H} > {SEL} > {K} {T}]")
                        s=input("1. All, 2: Nihongo, 3: Korean, Q: Prev -> ")
                print(f"[{H} > {SEL}]")
                k = input("1: Direction, 2: Number 1, 3: Number 1-2, 4: Number 2, 5: Family, Q: Prev -> ")
        print(f"[{H}]")
        s=input("1: Book, 2: Word, Q: Exit Program, -> ")
    if s=='q' or s=='Q': break

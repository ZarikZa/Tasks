import random

suits = ["Пики", "Червы", "Бубны", "Трефы"]
ranks = ["6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз"]
deck = []
for suit in suits:
    for rank in ranks:
        deck.append(f"{rank} {suit}")

random.shuffle(deck)
for cart in deck:
    print("--------------")
    print("|" + cart + "|")
    print("--------------")

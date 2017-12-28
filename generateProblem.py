import random
#stanford_warmups = ["stanford warmup cs9: {}".format(i) for i in range(1,6)]
#stanford_problems = ["stanford cs9 problem {}".format(i) for i in range(6,38)]

#interview_bit = ["interview bit backtracking {}".format(i) for i in range(1,21)]


warm=[]#stanford_warmups
problems = []#stanford_problems + interview_bit

def getRandom(list):
    return random.choice(list)



f=open('problems.txt')
lines=[]
for line in f:
    problems.append(line)


w=open('warmups.txt')

for line in w:
    warm.append(line)

print("------- Warmup -------")
print(getRandom(warm))
print("------ Problems -----------")
print(getRandom(problems))



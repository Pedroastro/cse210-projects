import json

with open("C:/Users/Pedro Castro/Desktop/BYU/CSE 210/cse210-projects/prove/Develop03/t_kjv.json") as file:
    data = json.load(file)
    print(data['row'][0]['field'][-1])
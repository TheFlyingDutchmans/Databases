from datetime import time
from pony.orm import *

db = Database()
# Change connection info to actual information for the imported personcar.sql
db.bind(provider='mysql', host='localhost', user='root', passwd='', db='dba')


class Person(db.Entity):
    id = PrimaryKey(int, auto=True)
    firstName = Required(str)
    lastName = Required(str)
    carID = Optional(int)


class Car(db.Entity):
    id = PrimaryKey(int, auto=True)
    brand = Optional(str)
    color = Required(str)
    timestamp = Optional(time)


db.generate_mapping(create_tables=True)


# Select functions
@db_session
def find_person_by_id(person_id):
    p = Person[person_id]
    print(p.firstName, p.lastName)


@db_session
def find_person_by_first_name(first_name):
    data = db.select("SELECT * from person where firstName = $first_name")
    print(data)


# Create functions
@db_session
def create_person(first_name, last_name, car_id):
    Person(firstName=first_name, lastName=last_name, carID=car_id)
    commit()


@db_session
def create_car(car_brand, car_color):
    Car(brand=car_brand, color=car_color)
    commit()


# Update functions
@db_session
def update_car_color(car_id, car_color):
    db.execute("UPDATE car SET color = $car_color WHERE id = $car_id")


@db_session
def update_person_car_ownership(person_id, car_id):
    db.execute("UPDATE person SET carID = $car_id WHERE id = $person_id")


# Delete functions
@db_session
def delete_person(person_id):
    db.execute("DELETE FROM person WHERE id = $person_id")


@db_session
def delete_all_cars_of_brand(car_brand):
    db.execute("DELETE FROM car WHERE brand = $car_brand")



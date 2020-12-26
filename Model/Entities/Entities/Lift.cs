using System;
using System.Collections.Generic;
using System.Linq;
using Entities.IEntities;
using AdditionalSystemConfiguration;
using Services.Services;

namespace Entities.Entities
{
    public class Lift : ITransporter
    {
        //Up / Down / None
        public string Direction { get; set; }
        public bool IsPaused { get; set; }

        public bool WasOverloaded { get; set; }

        public LiftConfigData liftData { get; }
        private int weight = 0;

        public event Action InteriorUpdated;

        public Lift(LiftConfigData liftData_)
        {
            liftData = liftData_;
            IsPaused = true;
            Direction = "None";
        }

        public void Load(List<IPassanger> passangersToGetIn)
        {

            lock (passangersToGetIn)
            {
                if (passangersToGetIn.Any())
                {
                    passangersToGetIn.Sort((x, y) => x.personData.PersonWeight.CompareTo(y.personData.PersonWeight));

                    foreach (IPassanger passanger in passangersToGetIn)
                    {
                        if (passanger.personData.PersonWeight + weight <= LiftConfigData.maxWeightToCarry)
                        {
                            passanger.IsInTransporter = true;
                            weight += passanger.personData.PersonWeight;
                            passanger.IsCallingTransporter = false;
                            WasOverloaded = false;
                            CounterService.TotalCarriedWeight += passanger.personData.PersonWeight;
                        }
                        else { WasOverloaded = true; }
                    }
                }
            }
        }
        public void Offload(List<IPassanger> passangersToGetOut)
        {
            lock (passangersToGetOut)
            {
                if (passangersToGetOut.Any())
                {
                    foreach (IPassanger passanger in passangersToGetOut)
                    {
                        passanger.IsInTransporter = false;
                        weight -= passanger.personData.PersonWeight;
                        CounterService.NumberOfDeliveredPassangers++;
                    }
                }
            }
        }
        public void Move(List<IPassanger> passangersInTransporter)
        {
            //on the new floor clean overload flag
            WasOverloaded = false;
            //Console.WriteLine(weight);
            if (Direction.Equals("Up"))
            {
                liftData.LiftCurrentFloor++;
            }
            else if (Direction.Equals("Down"))
            {
                liftData.LiftCurrentFloor--;
            }
            lock (passangersInTransporter)
            {
                if (passangersInTransporter.Any())
                {
                    foreach (IPassanger passanger in passangersInTransporter)
                    {
                        passanger.personData.PersonCurrentFloor = liftData.LiftCurrentFloor;
                    }
                }
            }
        }

        public bool ChooseDeriction(List<IPassanger> passangers, List<IPassanger> passangersInTransporter)
        {
            //choose direction in this priority:
            //first check destination of passangers in the transporter in current direction
            //if none were found in current direction - check in opposite
            //if transporter is empty: find a call from the highest floor
            //Console.WriteLine("Try to choose direction..");

            lock (passangers)
            {
                List<IPassanger> passangersCalling = passangers.FindAll(passanger => passanger.IsCallingTransporter);
                if (!passangersCalling.Any() && !passangersInTransporter.Any())
                {
                    return false;
                } 

                if (passangersInTransporter.Any())
                {
                    if (Direction.Equals("Up") && passangersInTransporter.All(passanger =>
                    passanger.personData.PersonDestinationFloor < liftData.LiftCurrentFloor))
                    {
                        Direction = "Down";
                        CounterService.NumberOfTrips++;
                    }
                    else if (Direction.Equals("Down") && passangersInTransporter.All(passanger =>
                    passanger.personData.PersonDestinationFloor > liftData.LiftCurrentFloor))
                    {
                        Direction = "Up";
                        CounterService.NumberOfTrips++;
                    } 
                    else if (Direction.Equals("None") && passangersInTransporter.Any(passanger =>
                    passanger.personData.PersonDestinationFloor > liftData.LiftCurrentFloor))
                    {
                        Direction = "Up";
                        CounterService.NumberOfTrips++;
                    } 
                    else if (Direction.Equals("None") && passangersInTransporter.Any(passanger =>
                    passanger.personData.PersonDestinationFloor < liftData.LiftCurrentFloor))
                    {
                        Direction = "Down";
                        CounterService.NumberOfTrips++;
                    }
                }
                else
                {
                    //check outside
                    int maxCallFloor = passangers.FindAll(passanger => passanger.IsCallingTransporter).
                        Max(passanger => passanger.personData.PersonCurrentFloor);
                    if (maxCallFloor > liftData.LiftCurrentFloor)
                    {
                        if (Direction != "Up")
                        {
                            CounterService.NumberOfTrips++;
                            CounterService.NumberOfBlankTrips++;
                        }
                        Direction = "Up";
                    }
                    else if (maxCallFloor < liftData.LiftCurrentFloor)
                    {
                        if (Direction != "Down")
                        {
                            CounterService.NumberOfTrips++;
                            CounterService.NumberOfBlankTrips++;
                        }
                        Direction = "Down";
                    }
                    else
                    {
                        Direction = "None";
                    }                
                }
            }
            return true;
        }

        public void OnInteriorUpdated()
        {
            InteriorUpdated?.Invoke();
        }
    }
}

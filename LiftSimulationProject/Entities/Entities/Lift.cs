using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Entities.IEntities;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Entities.Entities
{
    public class Lift : ITransporter
    {
        //Up / Down / None
        public string Direction { get; set; }
        public bool IsPaused { get; set; }

        public LiftConfigData liftData { get; }
        private int weight;
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
                        }
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
                        passanger.ContinueLive();
                    }
                }
            }
            

        }
        public void Move(List<IPassanger> passangersInTransporter)
        {
            //passangers might be null
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
                    /*if (transporter.Direction.Equals("Up") && passangersInTransporter.Any(passanger => 
                    passanger.personData.PersonDestinationFloor > transporter.liftData.LiftCurrentFloor))
                    {
                        transporter.Direction = "Up";
                    }
                    else ....*/
                    if (Direction.Equals("Up") && passangersInTransporter.All(passanger =>
                    passanger.personData.PersonDestinationFloor < liftData.LiftCurrentFloor))
                    {
                        Direction = "Down";
                    }
                    /*else if (transporter.Direction.Equals("Down") && passangersInTransporter.Any(passanger =>
                    passanger.personData.PersonDestinationFloor < transporter.liftData.LiftCurrentFloor))
                    {
                        transporter.Direction = "Down";
                    }*/
                    else if (Direction.Equals("Down") && passangersInTransporter.All(passanger =>
                    passanger.personData.PersonDestinationFloor > liftData.LiftCurrentFloor))
                    {
                        Direction = "Up";
                    } 
                    else if (Direction.Equals("None") && passangersInTransporter.Any(passanger =>
                    passanger.personData.PersonDestinationFloor > liftData.LiftCurrentFloor))
                    {
                        Direction = "Up";
                    } 
                    else if (Direction.Equals("None") && passangersInTransporter.Any(passanger =>
                    passanger.personData.PersonDestinationFloor < liftData.LiftCurrentFloor))
                    {
                        Direction = "Down";
                    }
                }
                else
                {
                    Console.WriteLine("*without passangers*");
                    //check outside
                    int maxCallFloor = passangers.FindAll(passanger => passanger.IsCallingTransporter).
                        Max(passanger => passanger.personData.PersonCurrentFloor);
                    if (maxCallFloor > liftData.LiftCurrentFloor)
                    {
                        Direction = "Up";
                    }
                    else if (maxCallFloor < liftData.LiftCurrentFloor)
                    {
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
    }
}

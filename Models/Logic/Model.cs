using System;
using System.Collections.Generic;
namespace VLSMsolver
{
	public class Model
	{ 
		private List<SubNetworkID> SubNetworkIDList;
		private Queue<SubNetworkID> SubNetworkIDQueue;
		private List<bool> CannotUsedList;
		private IPCalculator _IPcalculator;
		private string MajorNetwork;
		private int MajorSubnet;
		private PriorityQueue<Subnet> queueActualSubnet;
		public Model(string _MajorNetwork, int _MajorSubnet, PriorityQueue<Subnet> _queueActualSubnet)
		{
			//constructing
			MajorNetwork = _MajorNetwork;
			MajorSubnet = _MajorSubnet;
			SubNetworkIDList = new List<SubNetworkID>();
			SubNetworkIDQueue = new Queue<SubNetworkID>();
			CannotUsedList = new List<bool>();
			_IPcalculator = new IPCalculator();
			queueActualSubnet = _queueActualSubnet;

			//generating subnet list and queue;
			int CurrentSubnet = MajorSubnet;
			int order = 0;

			while (CurrentSubnet <= 30)
            {
				int totalNetworksPerSubnet = Convert.ToInt16(Math.Pow(2, CurrentSubnet - MajorSubnet));
				for (int i = 0; i < totalNetworksPerSubnet; i++)
                {
					//first networkID in the subnet
					if (i == 0)
					{
						SubNetworkID subNetwork = new SubNetworkID(MajorNetwork, CurrentSubnet, order);
						SubNetworkIDList.Add(subNetwork);
						SubNetworkIDQueue.Enqueue(subNetwork);
						CannotUsedList.Add(false);
						order += 1;
						continue;
					}

					SubNetworkID lastNetworkInTheList = SubNetworkIDList[SubNetworkIDList.Count - 1];
					string nextNetworkAddressInThisSubnet = _IPcalculator.nextNetworkAddress(lastNetworkInTheList.GettingNetworkAddress(), CurrentSubnet);
					SubNetworkID newSubnetwork = new SubNetworkID(nextNetworkAddressInThisSubnet, CurrentSubnet, order);
					SubNetworkIDList.Add(newSubnetwork);
					SubNetworkIDQueue.Enqueue(newSubnetwork);
					CannotUsedList.Add(false);
					order += 1;
				}

				CurrentSubnet += 1;
			}
		}

		private void Noting(int order)
        {
			Queue<int> checkingQueue = new Queue<int>();
			checkingQueue.Enqueue(order);
			int totalSubnet = SubNetworkIDList.Count;

			while (checkingQueue.Count != 0)
            {
				int currentIndex = checkingQueue.Dequeue();
				CannotUsedList[currentIndex] = true;

				int child1 = currentIndex * 2 + 1;
				int child2 = currentIndex * 2 + 2;

				if (child1 < totalSubnet)
                {
					checkingQueue.Enqueue(child1);
                }

				if (child2 < totalSubnet)
                {
					checkingQueue.Enqueue(child2);
                }
			}
		}

		public List<SubNetworkID> Processing()
        {
			List<SubNetworkID> output = new List<SubNetworkID>();
			while (queueActualSubnet.Count() != 0)
            {
				Subnet CurrentSubnetwork = queueActualSubnet.Dequeue();
				int neededCIDR = CurrentSubnetwork.approriateCIDR();

				while (SubNetworkIDQueue.Peek().GettingCIDR() != neededCIDR)
				{
					SubNetworkID RemovedQueue = SubNetworkIDQueue.Dequeue();
				}

				while (SubNetworkIDQueue.Peek().GettingCIDR() == neededCIDR && CannotUsedList[SubNetworkIDQueue.Peek().gettingOrder()])
				{
					SubNetworkID RemovedQueue = SubNetworkIDQueue.Dequeue();
				}

				if (SubNetworkIDQueue.Peek().GettingCIDR() == neededCIDR && CannotUsedList[SubNetworkIDQueue.Peek().gettingOrder()] == false)
                {
					SubNetworkID RemovedQueue = SubNetworkIDQueue.Dequeue();
					string networkID = RemovedQueue.GettingNetworkAddress();
					int CIDR = RemovedQueue.GettingCIDR();
					int order = CurrentSubnetwork.gettingOrder();
					Noting(RemovedQueue.gettingOrder());
					output.Add(new SubNetworkID(networkID, CIDR, order));
				}
			}

			return output;
        }
	}
}


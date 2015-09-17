<Query Kind="Program">
  <Connection>
    <ID>b5a03f6c-40b9-49f7-8dd4-8e5aec830389</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{

//entity 

	//Waiter.Dump();
	
	//anonymous type
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			Description = food.Description,
	//			Price = food.CurrentPrice,
	//			Cost = food.CurrentCost,
	//			Profit = food.CurrentPrice - food.CurrentCost
	//		}
	//	
	////works, but less user friendly and secure		
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			food.Description,
	//			food.CurrentPrice,
	//			food.CurrentCost,
	//			//food.CurrentPrice - food.CurrentCost
	//		}	
	//	
	////this will NOT work
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			Description = food.Description,
	//			Price = food.CurrentPrice,
	//			Cost = food.CurrentCost,
	//			//CHANGE HERE
	//			Profit = Price - Cost
	//		}
	
	
	var results = from food in Items
		where food.MenuCategory.Description.Equals("Entree") && 
			food.Active
	orderby food.CurrentPrice descending
	select new FoodMargin() 
			{
				 Description = food.Description,
				Price = food.CurrentPrice,
				Cost = food.CurrentCost,
				Profit = food.CurrentPrice + food.CurrentCost
				
				//food.CurrentPrice - food.CurrentCost
			};
			results.Dump();
			
			var results2 = from orders in Bills
				where orders.PaidStatus && 
					(orders.BillDate.Month == 9 && orders.BillDate.Year == 2014)
				orderby orders.Waiter.LastName, orders.Waiter.FirstName
				select new BillOrders()
				{
					BillID = orders.BillID, 
					Waiter = orders.Waiter.LastName + "," + orders.Waiter.FirstName,
					Orders = orders.BillItems
				 
				};
				
				results2.Dump();
}

// Define other methods and classes here
//samp[le of A POCO type class; flat data set no structures
public class FoodMargin
{
	public string Description{get; set;}
	public decimal Price {get; set;}
	public decimal Cost {get; set;}
	public decimal Profit {get; set;}
	
}

//
public class BillOrders
{
	public int BillID{get; set;}
	public string Waiter{get; set;}
	public IEnumerable Orders{get; set;}
}
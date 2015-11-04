<Query Kind="Statements">
  <Connection>
    <ID>e1722274-91b2-4b49-9ef7-0a09f28f6ec0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var date = Bills.Max(eachBill => eachBill.BillDate);
date.Dump();

var justDate = Bills.Max(eachBill =>eachBill.BillDate.Date);
justDate.Dump();

var time= Bills.Max(eachBill => eachBill.BillDate).TimeOfDay.Add(new TimeSpan(0,30,0));
time.Dump();
var justDateTime = justDate.Add(time).Dump();


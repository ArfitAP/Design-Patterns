using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegeterianMenu(noCoupon);
Console.WriteLine($"Vegeterian menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegeterianMenu(oneEuroCoupon);
Console.WriteLine($"Vegeterian menu, one euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadLine();
